using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Rede
{
    public partial class uc_CadRede : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private string operacao = String.Empty;

        private long idRede = 0;

        public uc_CadRede(frmTelaInicialERP frm, string _operacao, long _idRede)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = frm;

            operacao = _operacao;

            idRede = _idRede;

            if (idRede != 0)
            {
                PreencherCampos();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Rede";
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = uow.GetObjectByKey<tb_rede>(Convert.ToInt64(idRede));

                    txtRede.Text = rede.re_desc;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela de cadastro de rede: {ex.Message}");
            }
        }

        private void uc_CadRede_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtRede.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Descrição da Rede");
                txtRede.Focus();
                return false;
            }

            return true;
        }

        private bool IsRedeExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string rede = txtRede.Text;

                    var isRedeExiste = uow.Query<tb_rede>()
                        .Any(x => x.re_desc == rede && x.re_desat == 0);

                    return isRedeExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar matriz: {ex.Message}");

                return false;
            }
        }

        private void CadastrarRede()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = new tb_rede(uow);

                    rede.re_dtCri = DateTime.Now;
                    rede.re_dtAlt = DateTime.Now;
                    rede.re_desc = txtRede.Text;
                    rede.re_desat = 0;
                    rede.re_desatSinc = 0;
                    rede.re_PersTim = 0;

                    uow.Save(rede);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar rede: {ex.Message}");
            }
        }

        private void AlterarMatriz()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = uow.GetObjectByKey<tb_rede>(idRede);

                    rede.re_desc = txtRede.Text;
                    rede.re_dtAlt = DateTime.Now;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar rede: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsRedeExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma rede com essa descrição já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarRede();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarMatriz();
                }
            }

            _frmTelaInicial.TelaRede();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaRede();
        }
    }
}