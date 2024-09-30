using System;
using System.Linq;
using System.Windows.Forms;
using App_ERP.Produto;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Linq;

namespace App_ERP
{
    public partial class uc_Prod : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idProduto = 0;

        public uc_Prod(frmTelaInicialERP _form)
        {
            InitializeComponent();

            _frmTelaInicial = _form;

            CarregarGridProdutosAtivos();
        }

        private void CarregarGridProdutosAtivos()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "pd_codRef DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosProdutosCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.

            grdProdutos.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosProdutosCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                UnitOfWork session = new UnitOfWork();

                var queryProdutoCadastradosAtivos = from produto in session.Query<tb_produto>()
                                                    join subcategoria in session.Query<tb_subcategoria_produto>()
                                                        on produto.fk_tb_subcategoria_produto.id_subcategoria_produto equals subcategoria.id_subcategoria_produto
                                                    join categoria in session.Query<tb_categoria_produto>()
                                                        on subcategoria.fk_tb_categoria_produto.id_categoria_produto equals categoria.id_categoria_produto
                                                    join marca in session.Query<tb_marca_produto>()
                                                        on produto.fk_tb_marca_produto.id_marca_produto equals marca.id_marca_produto
                                                    where produto.pd_desat == 0
                                                    orderby produto.pd_codRef
                                                    select new
                                                    {
                                                        produto.id_produto,
                                                        categoria.cp_desc,
                                                        subcategoria.scp_desc,
                                                        produto.pd_codRef,
                                                        produto.pd_descCurta,
                                                        produto.pd_desc,
                                                        produto.pd_vlrUnComBase,
                                                        produto.pd_desat,
                                                        produto.pd_estTot,
                                                        marca.mp_desc,
                                                    };

                e.QueryableSource = queryProdutoCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com produtos ativos: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TelaCadastrarProduto(string _operacao, long _idProduto)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadProduto ucCadProd = new uc_CadProduto(_frmTelaInicial, _operacao, _idProduto);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadProd);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadProd;
            this.Invoke(new Action(() => TelaDeCarregamento.EsconderCarregamento()));
            ucCadProd.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarProduto("cadastrar", 0);
        }

        private void PegaIdProdutoSelecionadoGrid()
        {
            GridView view = grdProdutos.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idProduto = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_produto"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdProdutoSelecionadoGrid();

            TelaCadastrarProduto("alterar", Convert.ToInt16(idProduto));
        }

        private void DesativarDadosProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_produto produto = uow.GetObjectByKey<tb_produto>(idProduto);

                    if (produto != null)
                    {
                        produto.pd_desat = 1;

                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao desativar produto: {ex.Message}");
            }
        }

        private void DesativarDadosProdutoFilial()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_produto_filial produtoFilial = uow.GetObjectByKey<tb_produto_filial>(Convert.ToInt64(idProduto));

                    produtoFilial.pf_desat = 1;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao desativar produto filial: {ex.Message}");
            }
        }

        private bool IsEstoqueZerado()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var estoqueTotal = uow.Query<tb_produto>()
                        .Where(x => x.id_produto == idProduto)
                        .Select(x => x.pd_estTot)
                        .FirstOrDefault();

                    if (Convert.ToInt16(estoqueTotal) > 0)
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar estoque: {ex.Message}");

                return false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdProdutoSelecionadoGrid();

            if (!IsEstoqueZerado())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir este cadastro de um produto que possui estoque.");

                idProduto = 0;

                return;
            }

            var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir este produto?");

            if (dialogResult == DialogResult.Yes)
            {
                DesativarDadosProduto();

                DesativarDadosProdutoFilial();

                CarregarGridProdutosAtivos();
            }
        }

        private void uc_Prod_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }
    }
}