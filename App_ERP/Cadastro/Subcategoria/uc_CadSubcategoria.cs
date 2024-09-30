using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;
using static App_TelasCompartilhadas.Classes.DadosGeralNfe;

namespace App_ERP.Subcategoria
{
    public partial class uc_CadSubcategoria : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private string operacao = string.Empty;

        private long idSubcategoria = 0;

        //private long idCategoria = 0;

        //private Dictionary<long, string> dicCategoriaProd = new Dictionary<long, string>();

        public uc_CadSubcategoria(frmTelaInicialERP frmtelaInical, string _operacao, long _idSubcategoria)
        {
            InitializeComponent();

            PreencherCategoria();

            _frmTelaInicial = frmtelaInical;

            operacao = _operacao;

            idSubcategoria = _idSubcategoria;

            DadosGeralNfe a = new DadosGeralNfe();

            cmbCSOSN.Properties.AddEnum<SEnNfeCsosn>();

            if (idSubcategoria != 0)
            {
                PreencherCampos();
            }
        }

        private void PreencherCategoria()
        {
            try
            {
                using (Session session = new Session())
                {
                    var categoria = session.Query<tb_categoria_produto>()
                        .Where(x => x.cp_desat == 0)
                        .Select(x => new { x.id_categoria_produto, x.cp_desc })
                        .ToList();

                    cmbCategoria.Properties.DataSource = categoria;
                    cmbCategoria.Properties.DisplayMember = "cp_desc";
                    cmbCategoria.Properties.ValueMember = "id_categoria_produto";
                    cmbCategoria.Properties.NullText = "Selecione a Categoria";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher categoria: {ex.Message}");
            }
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var query = (from subcategoria in uow.Query<tb_subcategoria_produto>()
                                 join categoria in uow.Query<tb_categoria_produto>()
                                     on subcategoria.fk_tb_categoria_produto.id_categoria_produto equals categoria.id_categoria_produto
                                 where subcategoria.id_subcategoria_produto == idSubcategoria
                                 select new
                                 {
                                     categoria.id_categoria_produto, // Precisamos do ID para definir no LookUpEdit
                                     subcategoria.scp_desc
                                 }).FirstOrDefault();

                    txtDescrcricaoSubcategoria.Text = query.scp_desc;

                    cmbCategoria.EditValue = query.id_categoria_produto;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campos da tela de cadastro de subcategoria: {ex.Message}");
            }
        }

        private void uc_CadSubcategoria_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private bool IsCamposPreenchidos()
        {
            if (cmbCategoria.Text == "Selecione a Categoria")
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Categoria.");
                cmbCategoria.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescrcricaoSubcategoria.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Descrição Subcategoria.");
                txtDescrcricaoSubcategoria.Focus();
                return false;
            }

            return true;
        }

        private void CadastrarSubcategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(Convert.ToInt64(cmbCategoria.EditValue));

                    tb_subcategoria_produto subcategoria = new tb_subcategoria_produto(uow);

                    subcategoria.scp_desc = txtDescrcricaoSubcategoria.Text;
                    subcategoria.scp_dtCri = DateTime.Now;
                    subcategoria.scp_dtAlt = DateTime.Now;
                    subcategoria.scp_desat = 0;
                    subcategoria.fk_tb_categoria_produto = categoria;

                    uow.Save(subcategoria);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar subcategoria: {ex.Message}");
            }
        }

        private void AlterarSubcategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(Convert.ToInt64(cmbCategoria.EditValue));

                    tb_subcategoria_produto subcategoria = uow.GetObjectByKey<tb_subcategoria_produto>(idSubcategoria);

                    subcategoria.scp_desc = txtDescrcricaoSubcategoria.Text;
                    subcategoria.scp_dtAlt = DateTime.Now;
                    subcategoria.fk_tb_categoria_produto = categoria;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar subcategoria: {ex.Message}");
            }
        }

        private bool IsSubCategoriaExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string descricaoSubcategoria = txtDescrcricaoSubcategoria.Text;

                    bool isSubcategoriaExiste = uow.Query<tb_subcategoria_produto>()
                        .Any(x => x.scp_desc == descricaoSubcategoria && x.scp_desat == 0);

                    return isSubcategoriaExiste;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar subcategoria: {ex.Message}");

                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsSubCategoriaExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma subcategoria com essa descrição já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                CadastrarSubcategoria();
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    AlterarSubcategoria();
                }
            }

            _frmTelaInicial.TelaSubcategoria();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaSubcategoria();
        }
    }
}