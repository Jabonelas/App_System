using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Login;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace App_TelasCompartilhadas.Produtos
{
    public partial class uc_Produto : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        private long idProduto = 0;

        private string formaOrdenarGrid = "";

        public uc_Produto(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, string _formaOrdenarGrid)
        {
            InitializeComponent();

            Layout();

            formaOrdenarGrid = _formaOrdenarGrid;
            painelTelaInicial = _painelTelaInicial;

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
            configBotoes.BotaoVisualizar(btnVisualizar);

            uc_TituloTelas1.lblTituloTela.Text = "Produtos";
        }

        private void uc_Produto_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            painelTelaInicial.Controls.Clear();
            uc_TelaInicial ucTelaInicial = new uc_TelaInicial();
            painelTelaInicial.Controls.Add(ucTelaInicial);
            painelTelaInicial.Tag = ucTelaInicial;

            ucTelaInicial.Show();
        }

        private void CarregarGridProdutosAtivos()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_produto"; //Coluna Primary Key

            if (formaOrdenarGrid == "Estoque")
            {
                linqInstantFeedbackSource.DefaultSorting = "pd_estTot ASC"; //Coluna de ordenação padrão na ordem escolhida
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosProdutosEstoqueBaixoAtivos; //Buscar os dados que vao preencher o grid com produtos com estoque baixo.
            }
            else
            {
                linqInstantFeedbackSource.DefaultSorting = "pd_codRef DESC"; //Coluna de ordenação padrão na ordem escolhida
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosProdutosCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            }

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

        public class ProdutoEstoqueBaixoModel
        {
            public long id_produto { get; set; }
            public string cp_desc { get; set; }
            public string scp_desc { get; set; }
            public long pd_codRef { get; set; }
            public string pd_descCurta { get; set; }
            public string pd_desc { get; set; }
            public decimal pd_vlrUnComBase { get; set; }
            public decimal pd_desat { get; set; }
            public decimal pd_estTot { get; set; }
            public string mp_desc { get; set; }
        }

        private void linqBuscarDadosProdutosEstoqueBaixoAtivos(object sender, GetQueryableEventArgs e)
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
                                                    join produtoFilial in session.Query<tb_produto_filial>()
                                                        on produto.id_produto equals produtoFilial.fk_tb_produto.id_produto
                                                    where produto.pd_desat == 0 && produtoFilial.pf_est <= produtoFilial.pf_estMin
                                                    group new { produto, produtoFilial } by produtoFilial.pf_codRef into g
                                                    select new ProdutoEstoqueBaixoModel
                                                    {
                                                        id_produto = g.Max(p => p.produto.id_produto), // Usar Max ou Min para pegar um id válido
                                                        cp_desc = g.Max(p => p.produto.fk_tb_subcategoria_produto.fk_tb_categoria_produto.cp_desc), // Pega o campo desejado
                                                        scp_desc = g.Max(p => p.produto.fk_tb_subcategoria_produto.scp_desc),
                                                        pd_codRef = g.Key, // Usa a chave do grupo
                                                        pd_descCurta = g.Max(p => p.produto.pd_descCurta),
                                                        pd_desc = g.Max(p => p.produto.pd_desc),
                                                        pd_vlrUnComBase = g.Max(p => p.produto.pd_vlrUnComBase),
                                                        pd_desat = g.Max(p => p.produto.pd_desat),
                                                        pd_estTot = g.Max(p => p.produto.pd_estTot),
                                                        mp_desc = g.Max(p => p.produto.fk_tb_marca_produto.mp_desc)
                                                    };

                e.QueryableSource = queryProdutoCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com produtos com estoque baixo e ativos: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void TelaCadastrarProduto(string _operacao, long _idProduto)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            painelTelaInicial.Controls.Clear();
            uc_CadProduto ucCadProd = new uc_CadProduto(painelTelaInicial, _operacao, _idProduto, formaOrdenarGrid);
            painelTelaInicial.Controls.Add(ucCadProd);
            painelTelaInicial.Tag = ucCadProd;

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
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

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

        private void AlertaExclusaoCantoInferiorDireito()
        {
            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = painelTelaInicial.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcExclusao.Show(parentForm, info);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

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

                    AlertaExclusaoCantoInferiorDireito();
                }
            }
        }

        private void TelaEstoqueProduto(string _formaOrdenarGrid)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            painelTelaInicial.Controls.Clear();
            uc_EstoqueProduto ucEstoqueProduto = new uc_EstoqueProduto(painelTelaInicial, idProduto, _formaOrdenarGrid);
            painelTelaInicial.Controls.Add(ucEstoqueProduto);
            painelTelaInicial.Tag = ucEstoqueProduto;

            ucEstoqueProduto.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PegaIdProdutoSelecionadoGrid();

            TelaEstoqueProduto(formaOrdenarGrid);
        }

        private void alcExclusao_HtmlElementMouseClick(object sender, AlertHtmlElementMouseEventArgs e)
        {
            // Verifica qual elemento foi clicado pelo 'id'
            if (e.ElementId == "dialogresult-ok")
            {
                alcExclusao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcExclusao.Dispose();
            }
        }
    }
}