using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraBars.Alerter;

namespace App_ERP
{
    public partial class uc_CadMatriz : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private string operacao = String.Empty;

        private long idMatriz = 0;

        private string cnpjAtual = String.Empty;

        public uc_CadMatriz(frmTelaInicialERP frm, string _operacao, long _idMatriz)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = frm;

            operacao = _operacao;

            idMatriz = _idMatriz;

            PreencherRede();

            if (idMatriz != 0)
            {
                PreencherCampos();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Matriz";
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var query = (from matriz in uow.Query<tb_matriz>()
                                 join rede in uow.Query<tb_rede>()
                                     on matriz.fk_tb_rede.id_rede equals rede.id_rede
                                 where matriz.id_matriz == idMatriz
                                 select new
                                 {
                                     matriz.mt_cnpj,
                                     matriz.mt_razSoc,
                                     matriz.mt_nomeFant,
                                     rede.re_desc,
                                     rede.id_rede,
                                 }).FirstOrDefault();

                    txtCNPJ.Text = query.mt_cnpj;
                    txtRazaoSocial.Text = query.mt_razSoc;
                    txtNomeFant.Text = query.mt_nomeFant;
                    cmbRede.EditValue = query.id_rede;

                    cnpjAtual = query.mt_cnpj;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela de cadastro de matriz: {ex.Message}");
            }
        }

        private void PreencherRede()
        {
            try
            {
                using (Session session = new Session())
                {
                    var rede = session.Query<tb_rede>()
                        .Where(x => x.re_desat == 0)
                        .Select(x => new { x.id_rede, x.re_desc })
                        .ToList();

                    cmbRede.Properties.DataSource = rede;
                    cmbRede.Properties.DisplayMember = "re_desc";
                    cmbRede.Properties.ValueMember = "id_rede";
                    cmbRede.Properties.NullText = "Selecione a Rede";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher rede: {ex.Message}");
            }
        }

        private void uc_CadMatriz_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaMatriz();
        }

        private bool IsCamposPreenchidos()
        {
            if (cmbRede.Text == "Selecione a Rede")
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Rede");
                cmbRede.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCNPJ.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo C.N.P.J..");
                txtCNPJ.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRazaoSocial.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Razão Social.");
                txtRazaoSocial.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNomeFant.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Nome Fantasia.");
                txtNomeFant.Focus();
                return false;
            }

            return true;
        }

        private bool IsMatrizExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string CnpjMatriz = txtCNPJ.Text;

                    var isMatrizExiste = uow.Query<tb_matriz>()
                        .Any(x => x.mt_cnpj == CnpjMatriz && x.mt_desat == 0 && x.mt_cnpj != cnpjAtual);

                    return isMatrizExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar matriz: {ex.Message}");

                return false;
            }
        }

        private void CadastrarMatriz()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = uow.GetObjectByKey<tb_rede>(Convert.ToInt64(cmbRede.EditValue));

                    tb_matriz matriz = new tb_matriz(uow);

                    matriz.mt_razSoc = txtRazaoSocial.Text;
                    matriz.mt_nomeFant = txtNomeFant.Text;
                    matriz.mt_cnpj = txtCNPJ.Text;
                    matriz.mt_dtCri = DateTime.Now;
                    matriz.mt_dtAlt = DateTime.Now;
                    matriz.mt_desat = 0;
                    matriz.mt_hrAbertLj = 0;
                    matriz.mt_hrFchLj = 0;
                    matriz.mt_efetuaTestesEletro = 0;
                    matriz.mt_persTim = 0;
                    matriz.fk_tb_rede = rede;

                    uow.Save(matriz);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar matriz: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsMatrizExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma matriz com esse C.N.P.J já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarMatriz();

                AlertaConfirmacaoCantoInferiorDireito();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarMatriz();

                    AlertaConfirmacaoCantoInferiorDireito();
                }
            }

            _frmTelaInicial.TelaMatriz();
        }

        private void AlertaConfirmacaoCantoInferiorDireito()
        {
            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = _frmTelaInicial.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcConfirmacao.Show(parentForm, info);
            }
        }

        private void AlterarMatriz()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = uow.GetObjectByKey<tb_rede>(Convert.ToInt64(cmbRede.EditValue));

                    tb_matriz matriz = uow.GetObjectByKey<tb_matriz>(idMatriz);

                    matriz.mt_razSoc = txtRazaoSocial.Text;
                    matriz.mt_nomeFant = txtNomeFant.Text;
                    matriz.mt_cnpj = txtCNPJ.Text;
                    matriz.mt_dtAlt = DateTime.Now;
                    matriz.fk_tb_rede = rede;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar matriz: {ex.Message}");
            }
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, AlertHtmlElementMouseEventArgs e)
        {
            // Verifica qual elemento foi clicado pelo 'id'
            if (e.ElementId == "dialogresult-ok")
            {
                alcConfirmacao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcConfirmacao.Dispose();
            }
        }
    }
}