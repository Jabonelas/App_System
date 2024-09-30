using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas;
using App_TelasCompartilhadas.Login;
using DevExpress.XtraGrid.Views.Grid;

namespace App_PDV.Consultas.Itens.Produtos
{
    public partial class uc_Produto : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialPDV _frmTelaInicial;

        private long idProduto = 0;

        public uc_Produto(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            CarregarGridProdutosAtivos();

            //GridView gridView = grdProdutos.MainView as GridView;

            //gridView.OptionsFind.FindFilterColumns = "NomeProduto;DescricaoProduto"; // Defina as colunas que aceita texto
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovoRegistro);
            configBotoes.BotaoAlterar(btnAlterar);
            configBotoes.BotaoExcluir(btnExcluir);
            configBotoes.BotaoBuscar(btnBuscar);

            uc_TituloTelas1.lblTituloTela.Text = "Produtos";
        }

        private void uc_Produto_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
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
                Session session = new Session();

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

        private void TelaCadastrarProduto(string _operacao, long _idProduto)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadProduto ucCadProd = new uc_CadProduto(_frmTelaInicial, _operacao, _idProduto);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadProd);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadProd;

            ucCadProd.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
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

        private void TelaAutenticacaoUsuario()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            frmAutenticacaoUsuario frmAutenticacaoUsuario = new frmAutenticacaoUsuario();
            frmAutenticacaoUsuario.ShowDialog();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.IsUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.IsUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.IsUsuarioComPermissao = false;

                PegaIdProdutoSelecionadoGrid();

                TelaCadastrarProduto("alterar", Convert.ToInt16(idProduto));
            }
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
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.IsUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.IsUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.IsUsuarioComPermissao = false;

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
        }

        private void TelaEstoqueProduto()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_EstoqueProduto ucEstoqueProduto = new uc_EstoqueProduto(_frmTelaInicial, idProduto);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucEstoqueProduto);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucEstoqueProduto;

            ucEstoqueProduto.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PegaIdProdutoSelecionadoGrid();

            TelaEstoqueProduto();
        }
    }
}