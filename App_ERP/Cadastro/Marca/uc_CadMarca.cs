using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Marca
{
    public partial class uc_CadMarca : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idMarca = 0;

        private string operacao = string.Empty;

        public uc_CadMarca(frmTelaInicialERP frm, string _operacao, long _idMarca)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = frm;

            operacao = _operacao;

            idMarca = _idMarca;

            if (idMarca != 0)
            {
                PreencherCampos();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastrar Marca";
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_marca_produto marca = uow.GetObjectByKey<tb_marca_produto>(Convert.ToInt64(idMarca));

                    txtDescrcricaoMarca.Text = marca.mp_desc;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela de cadastro de marca: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaMarca();
        }

        private void uc_CadMarca_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void AlterarMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_marca_produto marca = uow.GetObjectByKey<tb_marca_produto>(idMarca);

                    marca.mp_desc = txtDescrcricaoMarca.Text;
                    marca.mp_dtAlt = DateTime.Now;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar marca: {ex.Message}");
            }
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtDescrcricaoMarca.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Categoria.");
                txtDescrcricaoMarca.Focus();
                return false;
            }

            return true;
        }

        private void CadastrarMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_marca_produto marca = new tb_marca_produto(uow);

                    marca.mp_desc = txtDescrcricaoMarca.Text;
                    marca.mp_dtCri = DateTime.Now;
                    marca.mp_dtAlt = DateTime.Now;
                    marca.mp_desat = 0;

                    uow.Save(marca);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar marca: {ex.Message}");
            }
        }

        private bool IsMarcarExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string descricaoMarca = txtDescrcricaoMarca.Text;

                    var isMarcaExiste = uow.Query<tb_marca_produto>()
                        .Any(x => x.mp_desc == descricaoMarca && x.mp_desat == 0);

                    return isMarcaExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar marca: {ex.Message}");

                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsMarcarExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma marca com essa descrição já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarMarca();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarMarca();
                }
            }

            _frmTelaInicial.TelaMarca();
        }
    }
}