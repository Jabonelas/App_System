using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using App_TelasCompartilhadas.Ator;

namespace App_TelasCompartilhadas.Cadastro.Funcionario
{
    public partial class uc_CadFuncionario : DevExpress.XtraEditors.XtraUserControl
    {
        private string senhaCriptografada = String.Empty;

        private string operacao = string.Empty;

        private long idAtorFuncionario = 0;

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_CadFuncionario(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, string _operacao, long _idAtorFuncionario)
        {
            InitializeComponent();

            Layout();

            var button = txtCEP.Properties.Buttons[0];
            button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            painelTelaInicial = _painelTelaInicial;

            operacao = _operacao;

            idAtorFuncionario = _idAtorFuncionario;

            //buttonEdit1.Properties.PasswordChar = '*';

            PreencherMunicipio();

            PreencherEstado();

            PreencherNivelAcesso();

            PreencherMatriz();

            if (idAtorFuncionario != 0)
            {
                PreencherCampoFuncionarioSelecionado();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Funcionário";
        }

        private void PreencherMatriz()
        {
            try
            {
                using (Session session = new Session())
                {
                    var matriz = session.Query<tb_matriz>()
                        .Where(x => x.mt_desat == 0)
                        .Select(x => new
                        {
                            x.id_matriz,
                            x.mt_nomeFant,
                            x.mt_cnpj
                        })
                        .ToList();

                    cmbMatriz.Properties.DataSource = matriz;
                    cmbMatriz.Properties.DisplayMember = "mt_nomeFant";
                    cmbMatriz.Properties.ValueMember = "id_matriz";
                    cmbMatriz.Properties.NullText = "Selecione a Matriz";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher matriz: {ex.Message}");
            }
        }

        private void PreencherCampoFuncionarioSelecionado()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var query = from tbAtor in uow.Query<tb_ator>()
                                join municipio in uow.Query<tb_municipio>()
                                    on tbAtor.fk_tb_municipio.id_municipio equals municipio.id_municipio
                                join estado in uow.Query<tb_estados_br>()
                                    on tbAtor.fk_tb_estados_br.id_estados_br equals estado.id_estados_br
                                where tbAtor.id_ator == idAtorFuncionario
                                select new
                                {
                                    tbAtor.at_razSoc,
                                    tbAtor.at_cpf,
                                    tbAtor.at_rgRne,
                                    tbAtor.at_telFixo,
                                    tbAtor.at_telCel,
                                    tbAtor.at_email,
                                    tbAtor.at_end_Cep,
                                    tbAtor.at_end_Logr,
                                    tbAtor.at_end_Num,
                                    tbAtor.at_end_Bairro,
                                    tbAtor.at_end_Compl,
                                    tbAtor.at_nomeUsuario,
                                    tbAtor.at_atorTipo,
                                    municipio.id_municipio,
                                    estado.id_estados_br
                                };

                    var ator = query.FirstOrDefault();

                    cmbNivelAcesso.EditValue = ator.at_atorTipo;
                    txtNomeUsuario.Text = ator.at_nomeUsuario;
                    txtNomeCompl.Text = ator.at_razSoc;
                    txtRG.Text = ator.at_rgRne;
                    cmbMunicipio.EditValue = ator.id_municipio;
                    cmbEstado.EditValue = ator.id_estados_br;
                    txtCPF.Text = ator.at_cpf;
                    txtTelFixo.Text = ator.at_telFixo;
                    txtTelCel.Text = ator.at_telCel;
                    txtEmail.Text = ator.at_email;
                    txtCEP.Text = ator.at_end_Cep;
                    txtEndereco.Text = ator.at_end_Logr;
                    txtNumeroEnd.Text = ator.at_end_Num;
                    txtBairro.Text = ator.at_end_Bairro;
                    txtComplementoEnd.Text = ator.at_end_Compl;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campos com o funcionário selecionado: {ex.Message}");
            }
        }

        private void PreencherNivelAcesso()
        {
            // Criando o dicionário
            Dictionary<int, string> dicNivelAcesso = new Dictionary<int, string>
            {
                { 100, "Funcionário" },
                { 101, "Vendedor" },
                { 102, "Gerente" }
            };

            // Convertendo o dicionário em uma lista de objetos anônimos
            var listaNiveisAcesso = dicNivelAcesso.Select(kvp => new { Key = kvp.Key, Value = kvp.Value }).ToList();

            // Configurando o LookUpEdit
            cmbNivelAcesso.Properties.DataSource = listaNiveisAcesso;
            cmbNivelAcesso.Properties.DisplayMember = "Value"; // Propriedade a ser exibida (neste caso, o nome do nível de acesso)
            cmbNivelAcesso.Properties.ValueMember = "Key"; // Propriedade para o valor (neste caso, o ID do nível de acesso)
            cmbNivelAcesso.Properties.NullText = "Selecione o Nível de Acesso";
        }

        private void PreencherEstado()
        {
            try
            {
                using (Session session = new Session())
                {
                    var estado = session.Query<tb_estados_br>()
                        .Where(x => x.eb_desat == 0)
                        .Select(x => new
                        {
                            x.id_estados_br,
                            x.eb_nome,
                            x.eb_sigla
                        })
                        .ToList();

                    cmbEstado.Properties.DataSource = estado;
                    cmbEstado.Properties.DisplayMember = "eb_sigla";
                    cmbEstado.Properties.ValueMember = "id_estados_br";
                    cmbEstado.Properties.NullText = "Selecione o Estado";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher estado: {ex.Message}");
            }
        }

        private void PreencherMunicipio()
        {
            try
            {
                using (Session session = new Session())
                {
                    var municipio = session.Query<tb_municipio>()
                        .Where(x => x.mu_desat == 0)
                        .Select(x => new
                        {
                            x.id_municipio,
                            x.mu_nome,
                            x.mu_id
                        })
                        .ToList();

                    cmbMunicipio.Properties.DataSource = municipio;
                    cmbMunicipio.Properties.DisplayMember = "mu_nome";
                    cmbMunicipio.Properties.ValueMember = "id_municipio";
                    cmbMunicipio.Properties.NullText = "Selecione o Município";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher município: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //{ 100, "Funcionário" },
            //{ 101, "Vendedor" },
            //{ 102, "Gerente" }

            ExibirTelaAnterior(100);
        }

        private void ExibirTelaAnterior(int _tipoAtor)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            painelTelaInicial.Controls.Clear();
            uc_Ator ucAtor = new uc_Ator(painelTelaInicial, _tipoAtor);
            painelTelaInicial.Controls.Add(ucAtor);
            painelTelaInicial.Tag = ucAtor;
            ucAtor.Show();
        }

        private void uc_CadFuncionario_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void BuscarEnderecoCepApi()
        {
            try
            {
                API apiCorreios = new API();

                string cepValido = txtCEP.Text.Replace("-", "").Replace(".", "");

                var tarefa = apiCorreios.APICorreios(cepValido);

                var esperador = tarefa.GetAwaiter();

                string endereco = string.Empty;
                string bairro = string.Empty;
                string municipio = string.Empty;
                string estado = string.Empty;
                string complemento = string.Empty;
                string ibge = string.Empty;

                esperador.OnCompleted(() =>
                {
                    var item = apiCorreios.RetornoApi();

                    endereco = item.logradouro;
                    bairro = item.bairro;
                    municipio = item.localidade;
                    estado = item.uf;
                    complemento = item.complemento;
                    ibge = item.ibge;

                    txtEndereco.Text = endereco;
                    txtBairro.Text = bairro;

                    var dataSourceMun = cmbMunicipio.Properties.DataSource as IEnumerable<dynamic>;
                    if (dataSourceMun != null)
                    {
                        var municipioSelecionado = dataSourceMun
                            .FirstOrDefault(e => e.mu_id == Convert.ToInt64(ibge));

                        if (municipioSelecionado != null)
                        {
                            cmbMunicipio.EditValue = municipioSelecionado.id_municipio;
                        }
                    }

                    var dataSourceEst = cmbEstado.Properties.DataSource as IEnumerable<dynamic>;
                    if (dataSourceEst != null)
                    {
                        var estadoSelecionado = dataSourceEst
                            .FirstOrDefault(e => e.eb_sigla == estado);

                        if (estadoSelecionado != null)
                        {
                            cmbEstado.EditValue = estadoSelecionado.id_estados_br;
                        }
                    }

                    txtComplementoEnd.Text = complemento;

                    if (item.logradouro == null && item.bairro == null && item.localidade == null)
                    {
                        var dialog = MensagensDoSistema.MensagemAtencaoYesNo("C.E.P não encontrado deseja prosseguir?");

                        if (dialog == DialogResult.Yes)
                        {
                            txtEndereco.Focus();
                        }
                        else
                        {
                            txtCEP.Focus();
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao conectar api correios: {ex.Message}");
            }
        }

        private void txtCEP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencherCEP();
            }
        }

        private void PreencherCEP()
        {
            if (txtCEP.Text == "_____-___")
            {
                txtCEP.ErrorText = string.Empty;
                return;
            }

            if (!Validacoes.IsCEPValido(txtCEP.Text) && txtCEP.Text != "_____-___")
            {
                txtCEP.ErrorText = "C.E.P informado invalido!";
            }
            else
            {
                txtCEP.ErrorText = string.Empty;

                if (!txtCEP.Text.Contains("_"))
                {
                    BuscarEnderecoCepApi();
                }
            }
        }

        private void txtCEP_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PreencherCEP();
        }

        #region Validacoes

        private void txtCEP_Validating(object sender, CancelEventArgs e)
        {
            if (txtCEP.Text == "_____-___")
            {
                txtCEP.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!Validacoes.IsCEPValido(txtCEP.Text) && txtCEP.Text != "_____-___")
            {
                txtCEP.ErrorText = "C.E.P informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtCEP.ErrorText = string.Empty;

                if (!txtCEP.Text.Contains("_"))
                {
                    BuscarEnderecoCepApi();
                }
            }
        }

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {
            if (txtCPF.Text == "___.___.___-__")
            {
                txtCPF.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!Validacoes.IsCpfValido(txtCPF.Text) && txtCPF.Text != "___.___.___-__")
            {
                txtCPF.ErrorText = "C.P.F. informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtCPF.ErrorText = string.Empty;
            }
        }

        private void txtRG_Validating(object sender, CancelEventArgs e)
        {
            if (txtRG.Text == "___.___.___-_")
            {
                txtRG.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!Validacoes.IsRGValido(txtRG.Text) && txtRG.Text != "___.___.___-_")
            {
                txtRG.ErrorText = "R.G. informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtRG.ErrorText = string.Empty;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!Validacoes.IsEmailValido(txtEmail.Text))
            {
                txtEmail.ErrorText = "E-mail informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtEmail.ErrorText = string.Empty;
            }
        }

        private void txtNomeUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeUsuario.Text))
            {
                txtNomeUsuario.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (IsNomeUsuarioExiste())
            {
                txtNomeUsuario.ErrorText = "Usuário já cadastrado, por favor informe outro!";
                e.Cancel = true;
            }
            else
            {
                txtNomeUsuario.ErrorText = string.Empty;
            }
        }

        private void txtConfirmarSenha_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                txtConfirmarSenha.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                txtConfirmarSenha.ErrorText = "Atenção: As senhas digitadas não conferem. Verifique se digitou corretamente e tente novamente.";
                e.Cancel = true;
            }
            else
            {
                txtConfirmarSenha.ErrorText = string.Empty;
            }
        }

        #endregion Validacoes

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtNomeCompl.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Razão Social / Nome Completo.");
                txtNomeCompl.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCPF.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo C.P.F..");
                txtCPF.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Senha.");
                txtSenha.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Confirmação de Senha.");
                txtConfirmarSenha.Focus();
                return false;
            }

            return true;
        }

        private void CadastroFuncionario()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_matriz matriz = uow.GetObjectByKey<tb_matriz>(Convert.ToInt64(cmbMatriz.EditValue));

                    tb_municipio municipio = uow.GetObjectByKey<tb_municipio>(Convert.ToInt64(cmbMunicipio.EditValue));

                    tb_estados_br estado = uow.GetObjectByKey<tb_estados_br>(Convert.ToInt64(cmbEstado.EditValue));

                    tb_ator ator = new tb_ator(uow);

                    ator.at_razSoc = txtNomeCompl.Text;
                    ator.at_rgRne = txtRG.Text;
                    ator.at_cpf = txtCPF.Text;
                    ator.at_telFixo = txtTelFixo.Text;
                    ator.at_telCel = txtTelCel.Text;
                    ator.at_email = txtEmail.Text;
                    ator.at_end_Cep = txtCEP.Text;
                    ator.at_end_Logr = txtEndereco.Text;
                    ator.at_end_Num = txtNumeroEnd.Text;
                    ator.at_end_Bairro = txtBairro.Text;
                    ator.at_end_Compl = txtComplementoEnd.Text;
                    ator.at_nomeUsuario = txtNomeUsuario.Text.ToLower();
                    ator.at_senhaUsuarioHashCode = senhaCriptografada;
                    ator.at_dtCri = DateTime.Now;
                    ator.at_dtAlt = DateTime.Now;
                    ator.at_desat = 0;
                    ator.at_genero = 0;
                    ator.at_atorTipo = Convert.ToByte(cmbNivelAcesso.EditValue);
                    ator.at_prop = 0;
                    ator.at_nfeCredSn = 0;
                    ator.at_revenda = 0;
                    ator.at_nfeEnqSN = 0;
                    ator.at_nfeRecBrutaEnqSN = 0;
                    ator.at_receitaBrutaTotal = 0;
                    ator.at_receitaBrutaTotal_ImpXml = 0;
                    ator.at_percComisAtend = 0;
                    ator.at_metaMensal = 0;
                    ator.at_manutPdv = 0;
                    ator.at_canc = 0;

                    //ator.fk_tb_certificado_digital = estado;
                    ator.fk_tb_estados_br = estado;
                    ator.fk_tb_municipio = municipio;
                    ator.fk_tb_matriz = matriz;

                    uow.Save(ator);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar funcionário: {ex.Message}");
            }
        }

        private void AlterarDadosFuncionario()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator ator = uow.GetObjectByKey<tb_ator>(idAtorFuncionario);

                    if (ator != null)
                    {
                        var idMatriz = cmbMatriz.EditValue == null || string.IsNullOrEmpty(cmbMatriz.EditValue.ToString()) ? 0 : Convert.ToInt16(cmbMatriz.EditValue);
                        var matriz = uow.Query<tb_matriz>().FirstOrDefault(x => x.id_matriz == idMatriz);

                        var idMunicipio = cmbMunicipio.EditValue == null || string.IsNullOrEmpty(cmbMunicipio.EditValue.ToString()) ? 0 : Convert.ToInt16(cmbMunicipio.EditValue);
                        var municipio = uow.Query<tb_municipio>().FirstOrDefault(x => x.id_municipio == idMunicipio);

                        var idEstado = cmbEstado.EditValue == null || string.IsNullOrEmpty(cmbEstado.EditValue.ToString()) ? 0 : Convert.ToInt16(cmbEstado.EditValue);
                        var estado = uow.Query<tb_estados_br>().FirstOrDefault(x => x.id_estados_br == idEstado);

                        ator.at_razSoc = txtNomeCompl.Text;
                        ator.at_rgRne = txtRG.Text;
                        ator.at_cpf = txtCPF.Text;
                        ator.at_telFixo = txtTelFixo.Text;
                        ator.at_telCel = txtTelCel.Text;
                        ator.at_email = txtEmail.Text;
                        ator.at_end_Cep = txtCEP.Text;
                        ator.at_end_Logr = txtEndereco.Text;
                        ator.at_end_Num = txtNumeroEnd.Text;
                        ator.at_end_Bairro = txtBairro.Text;
                        ator.at_end_Compl = txtComplementoEnd.Text;
                        ator.at_nomeUsuario = txtNomeUsuario.Text;
                        ator.at_atorTipo = Convert.ToByte(cmbNivelAcesso.EditValue);
                        ator.at_dtAlt = DateTime.Now;

                        if (!string.IsNullOrEmpty(txtSenha.Text) && !string.IsNullOrEmpty(txtConfirmarSenha.Text))
                        {
                            ator.at_senhaUsuarioHashCode = senhaCriptografada;
                        }

                        //ator.fk_tb_certificado_digital = estado;
                        ator.fk_tb_estados_br = estado;
                        ator.fk_tb_municipio = municipio;
                        ator.fk_tb_matriz = matriz;

                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar cadastro funcionário: {ex.Message}");
            }
        }

        private void CriptografarSenha()
        {
            if (!string.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                var senhaDigitada = txtConfirmarSenha.Text;

                // Converte a string para um array de bytes
                byte[] senhaBytes = Encoding.UTF8.GetBytes(senhaDigitada);

                // Cria o objeto SHA256 para calcular o hash
                using (SHA256 sha256 = SHA256.Create())
                {
                    // Calcula o hash da senha em bytes
                    byte[] senhaHash = sha256.ComputeHash(senhaBytes);

                    // Converte o hash em Base64
                    var senhaBase64 = Convert.ToBase64String(senhaHash);

                    senhaCriptografada = senhaBase64;
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var a = cmbNivelAcesso.EditValue;

            if (operacao == "cadastrar" && !IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar")
            {
                CriptografarSenha();

                CadastroFuncionario();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    CriptografarSenha();

                    AlterarDadosFuncionario();
                }
            }

            //{ 100, "Funcionário" },
            //{ 101, "Vendedor" },
            //{ 102, "Gerente" }

            ExibirTelaAnterior(100);
        }

        private bool IsNomeUsuarioExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string nomeUsuario = txtNomeUsuario.Text;

                    var isNomeUsuarioExiste = uow.Query<tb_ator>()
                        .Any(x => x.at_nomeUsuario == nomeUsuario);

                    return isNomeUsuarioExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar nome usuário: {ex.Message}");

                return false;
            }
        }
    }
}