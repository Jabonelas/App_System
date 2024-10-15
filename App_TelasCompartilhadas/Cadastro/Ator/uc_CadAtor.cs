using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Unimake.Business.Security;
using Unimake.Business.DFe.Servicos;
using System.Text.RegularExpressions;

namespace App_TelasCompartilhadas.Ator
{
    public partial class uc_CadAtor : DevExpress.XtraEditors.XtraUserControl
    {
        private long idAtor = 0;
        private int tipoAtor = 0;
        private string operacao = string.Empty;

        private X509Certificate2 certificadoDigital = null;

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        //Tipos Ator

        //(1, 'Consumidor'),
        //(10, 'Empresa'),
        //(11, 'Filial'),
        //(20, 'Fornecedor'),
        //(30, 'Transporte'),
        //(40, 'Intermediador'),
        //(100, 'Funcionário'),
        //(101, 'Vendedor'),
        //(102, 'Gerente');

        public uc_CadAtor(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, string _operacao, long _idAtor, int _tipoAtor)
        {
            InitializeComponent();

            LayoutBotoes();

            painelTelaInicial = _painelTelaInicial;

            //imagem botao da pesquisa do CEP
            //var button = txtCEP.Properties.Buttons[0];
            //button.Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            operacao = _operacao;

            idAtor = _idAtor;

            tipoAtor = _tipoAtor;

            PreencherComboBox();

            FormatarTelaTipoAtor(tipoAtor);

            PreencherMunicipio();

            PreencherEstado();

            PreencherMatriz();

            if (idAtor != 0)
            {
                PreencherCampoAtorSelecionado();
            }

            LayoutAbas();
        }

        private void LayoutAbas()
        {
            //(11 - 'Filial')
            if (tipoAtor == 11)
            {
                AbaFiscal.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                AbaRFB.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                abaPessoaFisica.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //(10 - 'Empresa'), (20 - 'Fornecedor'), (30 - 'Transporte')
            if (tipoAtor == 10 || tipoAtor == 20 || tipoAtor == 30)
            {
                abaPessoaFisica.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }

            //(1, 'Consumidor')
            if (tipoAtor == 1)
            {
                abaPessoaJuridica.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);
        }

        private void PreencherComboBox()
        {
            cmbTipoAmbEmis.Properties.AddEnum<DadosGeralNfe.SEnNfeTipoAmb>();
            cnbRegimeTribu.Properties.AddEnum<DadosGeralNfe.SEnNfeCodRegTrib>();
            cmbIndicadorInscEstad.Properties.AddEnum<DadosGeralNfe.SEnNfeIndInscEst>();
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

        private void PreencherCampoAtorSelecionado()
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
                                join matriz in uow.Query<tb_matriz>()
                                    on tbAtor.fk_tb_matriz.id_matriz equals matriz.id_matriz

                                where tbAtor.id_ator == idAtor
                                select new
                                {
                                    tbAtor.at_nomeFant,
                                    tbAtor.at_razSoc,
                                    tbAtor.at_cnpj,
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
                                    tbAtor.at_nfeIndInscEst,
                                    tbAtor.at_inscEst,
                                    tbAtor.at_inscEstSubst,
                                    tbAtor.at_inscSuframa,
                                    tbAtor.at_nfeCodRegTrib,
                                    tbAtor.at_inscMun,
                                    tbAtor.at_nfeCscIdHom,
                                    tbAtor.at_nfeCscTokenHom,
                                    tbAtor.at_nfeCscIdProd,
                                    tbAtor.at_nfeCscTokenProd,
                                    tbAtor.at_emailCont,
                                    tbAtor.at_obsFisc,
                                    tbAtor.at_nfeTipoAmb,
                                    tbAtor.at_metaMensal,
                                    municipio.id_municipio,
                                    estado.id_estados_br,
                                    matriz.id_matriz
                                };

                    var ator = query.FirstOrDefault();

                    txtNomeFantNomeAbrev.Text = ator.at_nomeFant;
                    txtRazaoSocialNomeCompl.Text = ator.at_razSoc;
                    txtCNPJ.Text = ator.at_cnpj;

                    if (ator.at_rgRne != null && ator.at_rgRne.Contains("-"))
                    {
                        txtRG.Text = ator.at_rgRne;
                    }
                    else
                    {
                        txtRNE.Text = ator.at_rgRne;
                    }

                    cmbMatriz.EditValue = ator.id_matriz;
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
                    cmbIndicadorInscEstad.EditValue = (DadosGeralNfe.SEnNfeIndInscEst)ator.at_nfeIndInscEst;
                    txtInscEstad.Text = ator.at_inscEst;
                    txtInscrEstdSubs.Text = ator.at_inscEstSubst;
                    txtInscSufra.Text = ator.at_inscSuframa;
                    cnbRegimeTribu.EditValue = (DadosGeralNfe.SEnNfeCodRegTrib)ator.at_nfeCodRegTrib;
                    txtInscMunic.Text = ator.at_inscMun;
                    txtCodSegContHom.Text = ator.at_nfeCscIdHom.ToString();
                    txtTokenCodSegContHom.Text = ator.at_nfeCscTokenHom;
                    txtCodSegContProd.Text = ator.at_nfeCscIdProd.ToString();
                    txtTokenCodSegContProd.Text = ator.at_nfeCscTokenProd;
                    txtEmailContabilidade.Text = ator.at_emailCont;
                    txtObserFisc.Text = ator.at_obsFisc;
                    txtMetaMensal.Text = ator.at_metaMensal.ToString("C2");
                    cmbTipoAmbEmis.EditValue = (DadosGeralNfe.SEnNfeTipoAmb)ator.at_nfeTipoAmb;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campos com o cadastro selecionado: {ex.Message}");
            }
        }

        //Tipos Ator

        //(1, 'Consumidor'),
        //(10, 'Empresa'),
        //(11, 'Filial'),
        //(20, 'Fornecedor'),
        //(30, 'Transporte'),
        //(40, 'Intermediador'),
        //(100, 'Funcionário'),
        //(101, 'Vendedor'),
        //(102, 'Gerente');

        private void FormatarTelaTipoAtor(int _tipoAtor)
        {
            switch (_tipoAtor)
            {
                case 1:
                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Consumidor";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados do consumidor para realizar o cadastrado";
                    break;

                case 10:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Empresa";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados da empresa para realizar o cadastrado";
                    break;

                case 11:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Filial";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados de filial para realizar o cadastrado";
                    break;

                case 20:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Fornecedor";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados de fornecedor para realizar o cadastrado";
                    break;

                case 30:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Transportadora";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados da transportadora para realizar o cadastrado";

                    break;

                case 40:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Intermediador";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados de intermediador para realizar o cadastrado";

                    break;

                case 100:

                    uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Funcionário";
                    layoutControlGroup1.Text = "Aqui você pode inserir os dados de funcionário para realizar o cadastrado";

                    break;
            }
        }

        //Botao do CEP
        private void buttonEdit1_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            PreencherCEP();
        }

        private void btnArquivoCertDig_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            // Usando XtraOpenFileDialog da DevExpress
            DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            xtraOpenFileDialog.Filter = "Arquivos PFX (*.pfx)|*.pfx";
            xtraOpenFileDialog.Title = "Selecione um arquivo PFX";

            if (xtraOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(xtraOpenFileDialog.FileName) || string.IsNullOrEmpty(txtSenhaCertificadoDigital.Text))
                {
                    return;
                }
                if (!File.Exists(xtraOpenFileDialog.FileName) || new FileInfo(xtraOpenFileDialog.FileName).Length <= 0)
                {
                    return;
                }

                try
                {
                    var certificado = new CertificadoDigital();

                    var certificadoBase64 = certificado.ToBase64(xtraOpenFileDialog.FileName);

                    var certificadoSelecionado = certificado.FromBase64(certificadoBase64, txtSenhaCertificadoDigital.Text);

                    certificadoDigital = certificadoSelecionado;
                }
                catch (Exception ex)
                {
                    MensagensDoSistema.MensagemErroOk($"Erro ao pegar dados do certificado digital selecionado: {ex.Message}");
                }
            }

            TelaCarregamento.EsconderCarregamento();
        }

        private void SalvarCertificadoDigital()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_certificado_digital cert = new tb_certificado_digital(uow);

                    cert.cd_dtCri = DateTime.Now;
                    cert.cd_dtAlt = DateTime.Now;
                    cert.cd_cnpj = Regex.Replace(txtCNPJ.Text, @"[^\d]", "");
                    cert.cd_razSoc = txtRazaoSocialNomeCompl.Text;
                    cert.cd_pwd = txtSenhaCertificadoDigital.Text;
                    cert.cd_serial = certificadoDigital.SerialNumber;
                    cert.cd_dtPub = certificadoDigital.NotBefore;
                    cert.cd_dtExp = certificadoDigital.NotAfter;
                    cert.cd_ativo = 1;
                    cert.cd_rawData = certificadoDigital.Export(X509ContentType.Pfx, txtSenhaCertificadoDigital.Text);

                    cert.Save();
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao salvar dados do certificado digital: {ex.Message}");
            }
        }

        private void uc_CadAtor_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            ExibirTelaAnterior();
        }

        private void ExibirTelaAnterior()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            painelTelaInicial.Controls.Clear();
            uc_Ator ucAtor = new uc_Ator(painelTelaInicial, tipoAtor);
            painelTelaInicial.Controls.Add(ucAtor);
            painelTelaInicial.Tag = ucAtor;
            ucAtor.Show();
        }

        #region Validacoes dos campos

        private void txtCPF_Validating(object sender, CancelEventArgs e)
        {
            if (txtCPF.Text == "___.___.___-__")
            {
                txtCPF.ErrorText = string.Empty;
                txtRNE.Enabled = true;
                e.Cancel = false;
                return;
            }

            if (!ValidacoesCampos.IsCpfValido(txtCPF.Text) && txtCPF.Text != "___.___.___-__")
            {
                txtCPF.ErrorText = "C.P.F. informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtCPF.ErrorText = string.Empty;
                txtRNE.Text = "";
                txtRNE.Enabled = false;
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

            if (!ValidacoesCampos.IsRGValido(txtRG.Text) && txtRG.Text != "___.___.___-_")
            {
                txtRG.ErrorText = "R.G. informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtRG.ErrorText = string.Empty;
            }
        }

        private void txtCNPJ_Validating(object sender, CancelEventArgs e)
        {
            if (txtCNPJ.Text == "__.___.___/____-__")
            {
                txtCNPJ.ErrorText = string.Empty;
                e.Cancel = false;
                txtRG.Enabled = true;
                return;
            }

            if (!ValidacoesCampos.IsCnpjValido(txtCNPJ.Text) && txtCNPJ.Text != "__.___.___/____-__")
            {
                txtCNPJ.ErrorText = "C.N.P.J. informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtCNPJ.ErrorText = string.Empty;
                txtRG.Text = "";
                txtRG.Enabled = false;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailContabilidade.Text))
            {
                txtEmailContabilidade.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!ValidacoesCampos.IsEmailValido(txtEmailContabilidade.Text))
            {
                txtEmailContabilidade.ErrorText = "E-mail informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtEmailContabilidade.ErrorText = string.Empty;
            }
        }

        private void txtEmailContabilidade_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailContabilidade.Text))
            {
                txtEmailContabilidade.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!ValidacoesCampos.IsEmailValido(txtEmailContabilidade.Text))
            {
                txtEmailContabilidade.ErrorText = "E-mail informado invalido!";
                e.Cancel = true;
            }
            else
            {
                txtEmailContabilidade.ErrorText = string.Empty;
            }
        }

        private void buttonEdit1_Properties_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtCEP.Text == "_____-___")
            {
                txtCEP.ErrorText = string.Empty;
                e.Cancel = false;
                return;
            }

            if (!ValidacoesCampos.IsCEPValido(txtCEP.Text) && txtCEP.Text != "_____-___")
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

        #endregion Validacoes dos campos

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

        private long CadastroAtor()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_matriz matriz = uow.GetObjectByKey<tb_matriz>(Convert.ToInt64(cmbMatriz.EditValue));

                    tb_municipio municipio = uow.GetObjectByKey<tb_municipio>(Convert.ToInt64(cmbMunicipio.EditValue));

                    tb_estados_br estado = uow.GetObjectByKey<tb_estados_br>(Convert.ToInt64(cmbEstado.EditValue));

                    var indicadorUnscricaoEstadual = cmbIndicadorInscEstad.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeIndInscEst)cmbIndicadorInscEstad.EditValue;

                    var regimeTributario = cnbRegimeTribu.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeCodRegTrib)cnbRegimeTribu.EditValue;

                    var tipoAmbienteEmissaoNfe = cmbTipoAmbEmis.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeTipoAmb)cmbTipoAmbEmis.EditValue;

                    var idICodSegContriHom = string.IsNullOrEmpty(txtCodSegContHom.Text) ? 0 : Convert.ToInt32(txtCodSegContHom.Text);

                    var idICodSegContriProd = string.IsNullOrEmpty(txtCodSegContProd.Text) ? 0 : Convert.ToInt32(txtCodSegContProd.Text);

                    tb_ator ator = new tb_ator(uow);

                    ator.at_nomeFant = txtNomeFantNomeAbrev.Text;
                    ator.at_razSoc = txtRazaoSocialNomeCompl.Text;
                    ator.at_cnpj = txtCNPJ.Text;
                    ator.at_rgRne = txtRNE.Text == String.Empty ? txtRG.Text : txtRNE.Text;
                    ator.at_cpf = txtCPF.Text;
                    ator.at_telFixo = txtTelFixo.Text;
                    ator.at_telCel = txtTelCel.Text;
                    ator.at_email = txtEmail.Text;
                    ator.at_end_Cep = txtCEP.Text;
                    ator.at_end_Logr = txtEndereco.Text;
                    ator.at_end_Num = txtNumeroEnd.Text;
                    ator.at_end_Bairro = txtBairro.Text;
                    ator.at_end_Compl = txtComplementoEnd.Text;
                    ator.at_nfeIndInscEst = Convert.ToByte(indicadorUnscricaoEstadual);
                    ator.at_inscEst = txtInscEstad.Text;
                    ator.at_inscEstSubst = txtInscrEstdSubs.Text;
                    ator.at_inscSuframa = txtInscSufra.Text;
                    ator.at_nfeCodRegTrib = Convert.ToByte(regimeTributario);
                    ator.at_inscMun = txtInscMunic.Text;
                    ator.at_nfeCscIdHom = Convert.ToByte(idICodSegContriHom);
                    ator.at_nfeCscTokenHom = txtTokenCodSegContHom.Text;
                    ator.at_nfeCscIdProd = Convert.ToByte(idICodSegContriProd);
                    ator.at_nfeCscTokenProd = txtTokenCodSegContProd.Text;
                    ator.at_emailCont = txtEmailContabilidade.Text;
                    ator.at_obsFisc = txtObserFisc.Text;
                    ator.at_nfeTipoAmb = Convert.ToByte(tipoAmbienteEmissaoNfe);

                    ator.at_dtCri = DateTime.Now;
                    ator.at_dtAlt = DateTime.Now;
                    ator.at_desat = 0;
                    ator.at_genero = 0;
                    ator.at_atorTipo = Convert.ToByte(tipoAtor);
                    ator.at_prop = 0;
                    ator.at_nfeCredSn = 0;
                    ator.at_revenda = 0;
                    ator.at_nfeEnqSN = 0;
                    ator.at_nfeRecBrutaEnqSN = 0;
                    ator.at_receitaBrutaTotal = 0;
                    ator.at_receitaBrutaTotal_ImpXml = 0;
                    ator.at_percComisAtend = 0;
                    ator.at_metaMensal = string.IsNullOrEmpty(txtMetaMensal.Text) ? 0 : Convert.ToDecimal(txtMetaMensal.Text.Replace("R$", ""));
                    ator.at_manutPdv = 0;
                    ator.at_canc = 0;

                    //ator.fk_tb_certificado_digital = estado;
                    ator.fk_tb_estados_br = estado;
                    ator.fk_tb_municipio = municipio;
                    ator.fk_tb_matriz = matriz;

                    uow.Save(ator);
                    uow.CommitChanges();

                    return ator.id_ator;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar ator: {ex.Message}");

                return 0;
            }
        }

        private void AlterarDadosAtor()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator ator = uow.GetObjectByKey<tb_ator>(idAtor);

                    if (ator != null)
                    {
                        tb_matriz matriz = uow.GetObjectByKey<tb_matriz>(Convert.ToInt64(cmbMatriz.EditValue));

                        tb_municipio municipio = uow.GetObjectByKey<tb_municipio>(Convert.ToInt64(cmbMunicipio.EditValue));

                        tb_estados_br estado = uow.GetObjectByKey<tb_estados_br>(Convert.ToInt64(cmbEstado.EditValue));

                        var indicadorUnscricaoEstadual = cmbIndicadorInscEstad.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeIndInscEst)cmbIndicadorInscEstad.EditValue;

                        var regimeTributario = cnbRegimeTribu.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeCodRegTrib)cnbRegimeTribu.EditValue;

                        var tipoAmbienteEmissaoNfe = cmbTipoAmbEmis.EditValue == null ? 0 : (byte)(DadosGeralNfe.SEnNfeTipoAmb)cmbTipoAmbEmis.EditValue;

                        var idICodSegContriHom = string.IsNullOrEmpty(txtCodSegContHom.Text) ? 0 : Convert.ToInt32(txtCodSegContHom.Text);

                        var idICodSegContriProd = string.IsNullOrEmpty(txtCodSegContProd.Text) ? 0 : Convert.ToInt32(txtCodSegContProd.Text);

                        ator.at_nomeFant = txtNomeFantNomeAbrev.Text;
                        ator.at_razSoc = txtRazaoSocialNomeCompl.Text;
                        ator.at_cnpj = txtCNPJ.Text;
                        ator.at_rgRne = txtRNE.Text == String.Empty ? txtRG.Text : txtRNE.Text;
                        ator.at_cpf = txtCPF.Text;
                        ator.at_telFixo = txtTelFixo.Text;
                        ator.at_telCel = txtTelCel.Text;
                        ator.at_email = txtEmail.Text;
                        ator.at_end_Cep = txtCEP.Text;
                        ator.at_end_Logr = txtEndereco.Text;
                        ator.at_end_Num = txtNumeroEnd.Text;
                        ator.at_end_Bairro = txtBairro.Text;
                        ator.at_end_Compl = txtComplementoEnd.Text;
                        ator.at_nfeIndInscEst = Convert.ToByte(indicadorUnscricaoEstadual);
                        ator.at_inscEst = txtInscEstad.Text;
                        ator.at_inscEstSubst = txtInscrEstdSubs.Text;
                        ator.at_inscSuframa = txtInscSufra.Text;
                        ator.at_nfeCodRegTrib = Convert.ToByte(regimeTributario);
                        ator.at_inscMun = txtInscMunic.Text;
                        ator.at_nfeCscIdHom = Convert.ToByte(idICodSegContriHom);
                        ator.at_nfeCscTokenHom = txtTokenCodSegContHom.Text;
                        ator.at_nfeCscIdProd = Convert.ToByte(idICodSegContriProd);
                        ator.at_nfeCscTokenProd = txtTokenCodSegContProd.Text;
                        ator.at_emailCont = txtEmailContabilidade.Text;
                        ator.at_obsFisc = txtObserFisc.Text;
                        ator.at_nfeTipoAmb = Convert.ToByte(tipoAmbienteEmissaoNfe);
                        ator.at_dtAlt = DateTime.Now;
                        ator.at_metaMensal = string.IsNullOrEmpty(txtMetaMensal.Text) ? 0 : Convert.ToDecimal(txtMetaMensal.Text.Replace("R$", ""));

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
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar cadastro ator: {ex.Message}");
            }
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtNomeFantNomeAbrev.Text) || string.IsNullOrEmpty(txtRazaoSocialNomeCompl.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha os campos corretamente.");
                return false;
            }

            if (string.IsNullOrEmpty(txtCEP.Text) || string.IsNullOrEmpty(txtEndereco.Text) || string.IsNullOrEmpty(txtNumeroEnd.Text) || string.IsNullOrEmpty(txtBairro.Text) || cmbMunicipio.Text == "Selecione o Município" || cmbEstado.Text == "Selecione o Estado")
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha os campos de endereço corretamente.");
                return false;
            }

            return true;
        }

        private bool IsCamposPreenchidosEmissaoNFCe()
        {
            //Tipo ambiente 1 ou 2, emite cupom fiscal - NFCe
            if ((byte)(DadosGeralNfe.SEnNfeTipoAmb)cmbTipoAmbEmis.EditValue != 0)
            {
                if (string.IsNullOrEmpty(txtInscEstad.Text))
                {
                    MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Inscrição estadual (I.E.).");
                    return false;
                }

                if (string.IsNullOrEmpty(txtInscMunic.Text))
                {
                    MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Inscrição municipal (I.M.).");
                    return false;
                }

                if (string.IsNullOrEmpty(txtTokenCodSegContHom.Text) || string.IsNullOrEmpty(txtTokenCodSegContProd.Text))
                {
                    MensagensDoSistema.MensagemInformacaoOk("Preencha os campos Token do C.S.C. - Hom e Token do C.S.C. - Prod.");
                    return false;
                }

                if (string.IsNullOrEmpty(txtCodSegContHom.Text) || string.IsNullOrEmpty(txtCodSegContProd.Text))
                {
                    MensagensDoSistema.MensagemInformacaoOk("Preencha os campos Cód. seg. do C.S.C. - Hom e Cód. seg. do C.S.C. - Prod.");
                    return false;
                }
            }

            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar")
            {
                long idAtorCadastrado = CadastroAtor();

                //Verificar se o ator cadastrado é filial
                if (tipoAtor == 11)
                {
                    if (!IsCamposPreenchidosEmissaoNFCe())
                    {
                        return;
                    }

                    CadastroProdutoFilial(idAtorCadastrado);

                    SalvarCertificadoDigital();
                }

                uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(painelTelaInicial);
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarDadosAtor();

                    uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(painelTelaInicial);
                }
            }

            ExibirTelaAnterior();
        }

        private void CadastroProdutoFilial(long _idAtorFilialCadastrada)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator _atorFilial = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(_idAtorFilialCadastrada));

                    var _produto = uow.Query<tb_produto>()
                        .Where(x => x.pd_desat == 0);

                    foreach (var item in _produto)
                    {
                        tb_produto_filial produtoFilial = new tb_produto_filial(uow);

                        produtoFilial.pf_codRef = item.pd_codRef;
                        produtoFilial.pf_desc = item.pd_desc;
                        produtoFilial.pf_descCurta = item.pd_descCurta;
                        produtoFilial.pf_proTipo = item.pd_proTipo;
                        produtoFilial.pf_unMedCom = item.pd_unMedCom;
                        produtoFilial.pf_dtCri = DateTime.Now;
                        produtoFilial.pf_dtAlt = DateTime.Now;
                        produtoFilial.pf_vlrUnCom = item.pd_vlrUnComBase;
                        produtoFilial.pf_cstUnCom = item.pd_cstUnComBase;
                        produtoFilial.pf_estMin = item.pd_estMinBase;
                        produtoFilial.pf_est = 0;
                        produtoFilial.pf_desat = 0;
                        produtoFilial.fk_tb_ator = _atorFilial;
                        produtoFilial.fk_tb_produto = item;

                        uow.Save(produtoFilial);
                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar produto filial no cadastro da filial: {ex.Message}");
            }
        }

        private void PreencherCEP()
        {
            if (txtCEP.Text == "_____-___")
            {
                txtCEP.ErrorText = string.Empty;
                return;
            }

            if (!ValidacoesCampos.IsCEPValido(txtCEP.Text) && txtCEP.Text != "_____-___")
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

        private void txtCEP_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencherCEP();
            }
        }
    }
}