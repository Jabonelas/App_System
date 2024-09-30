using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP
{
    public partial class uc_Categoria : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private int idCategoria = 0;

        public uc_Categoria(frmTelaInicialERP _form)
        {
            InitializeComponent();

            CarregarGridCategoriassAtivas();

            _frmTelaInicial = _form;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TelaCadastrarCategoria(string _operacao, int _idCategoria)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadCategoria ucCadCategoria = new uc_CadCategoria(_frmTelaInicial, _operacao, _idCategoria);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadCategoria);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadCategoria;
            ucCadCategoria.Show();
        }

        private void uc_Categoria_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void CarregarGridCategoriassAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_categoria_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "sp_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosCategoriaCadastradasAtivas; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdCategorias.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosCategoriaCadastradasAtivas(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryCategoriaCadastradosAtivos =
                    from categoria in session.Query<tb_categoria_produto>()
                    join secao in session.Query<tb_secao_produto>()
                        on categoria.fk_tb_secao_produto.id_secao_produto equals secao.id_secao_produto
                    where categoria.cp_desat == 0
                    orderby categoria.cp_desc ascending
                    select new
                    {
                        categoria.id_categoria_produto,
                        secao.sp_desc,
                        categoria.cp_desc,
                    };

                e.QueryableSource = queryCategoriaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com categorias: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void PegaIdCategoriaSelecionadaGrid()
        {
            GridView view = grdCategorias.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idCategoria = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_categoria_produto"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            TelaCadastrarCategoria("Alterar", idCategoria);
        }

        private bool IsProdutoComCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isProdutoComCategoria = uow.Query<tb_produto>()
                        .Any(x => x.fk_tb_categoria_produto.id_categoria_produto == idCategoria && x.pd_desat == 0);

                    return isProdutoComCategoria;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar produto cadastrado com esta categoria: {ex.Message}");

                return false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            if (IsProdutoComCategoria())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta categoria, pois ela está vinculada ao cadastro de algum produto.");

                idCategoria = 0;

                return;
            }

            if (idCategoria > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta categoria?");

                if (result == DialogResult.Yes)
                {
                    ExcluirCategoria();
                }
            }
        }

        private void ExcluirCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(Convert.ToInt64(idCategoria));

                    categoria.cp_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridCategoriassAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir categoria: {ex.Message}");
            }
        }

        private void btnCadastrar_Click_2(object sender, EventArgs e)
        {
            TelaCadastrarCategoria("cadastrar", 0);
        }
    }
}