using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Secao
{
    public partial class uc_CadSecao : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;
        private string operacao = string.Empty;
        private long idSecao = 0;

        public uc_CadSecao(frmTelaInicialERP _frm, string _operacao, long _idSecao)
        {
            InitializeComponent();

            _frmTelaInicial = _frm;

            operacao = _operacao;

            idSecao = _idSecao;

            if (idSecao != 0)
            {
                PreencherCampos();
            }
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = uow.GetObjectByKey<tb_secao_produto>(Convert.ToInt64(idSecao));

                    txtDescrcricaoSecao.Text = secao.sp_desc;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela cadastro de seção: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaSecao();
        }

        private void uc_CadSecao_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtDescrcricaoSecao.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Seção.");
                txtDescrcricaoSecao.Focus();
                return false;
            }

            return true;
        }

        private void CadastrarSecao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = new tb_secao_produto(uow);

                    secao.sp_desc = txtDescrcricaoSecao.Text;
                    secao.sp_dtCri = DateTime.Now;
                    secao.sp_dtAlt = DateTime.Now;
                    secao.sp_desat = 0;

                    uow.Save(secao);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar seção: {ex.Message}");
            }
        }

        private void AlterarSecao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = uow.GetObjectByKey<tb_secao_produto>(idSecao);

                    secao.sp_desc = txtDescrcricaoSecao.Text;
                    secao.sp_dtAlt = DateTime.Now;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar secao: {ex.Message}");
            }
        }

        private bool IsSecaoExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string descricaoSecao = txtDescrcricaoSecao.Text;

                    var isSecaoExiste = uow.Query<tb_secao_produto>()
                        .Any(x => x.sp_desc == descricaoSecao && x.sp_desat == 0);

                    return isSecaoExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar secao: {ex.Message}");

                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsSecaoExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma seção com essa descrição já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarSecao();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarSecao();
                }
            }

            _frmTelaInicial.TelaSecao();
        }
    }
}