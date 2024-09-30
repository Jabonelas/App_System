using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Linq;

namespace App_PDV.Consultas.Itens.Produtos
{
    public partial class uc_EstoqueProduto : DevExpress.XtraEditors.XtraUserControl
    {
        private long idProduto = 0;

        private frmTelaInicialPDV _frmTelaInicial;

        public uc_EstoqueProduto(frmTelaInicialPDV _form, long _idProduto)
        {
            InitializeComponent();

            _frmTelaInicial = _form;

            idProduto = _idProduto;

            Layout();

            CarregarGridProdutosFilialAtivos();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);

            uc_TituloTelas1.lblTituloTela.Text = "Estoque do Produto em todas as Filiais";
        }

        private void CarregarGridProdutosFilialAtivos()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_produto_filial"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "pf_codRef DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosProdutosCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdCadastrarProdutos.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosProdutosCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryProdutoCadastradosAtivos =
                    from produtoFilial in session.Query<tb_produto_filial>()
                    join produto in session.Query<tb_produto>()
                        on produtoFilial.fk_tb_produto.id_produto equals produto.id_produto
                    join filial in session.Query<tb_ator>()
                        on produtoFilial.fk_tb_ator.id_ator equals filial.id_ator
                    where produto.pd_desat == 0 && produto.id_produto == idProduto
                    orderby produtoFilial.pf_desc
                    //orderby produtoFilial.fk_tb_ator
                    select new
                    {
                        produtoFilial.id_produto_filial,
                        produtoFilial.pf_codRef,
                        produtoFilial.pf_descCurta,
                        produtoFilial.pf_desc,
                        produtoFilial.pf_vlrUnCom,
                        produtoFilial.pf_desat,
                        produtoFilial.pf_est,
                        filial.at_cnpj,
                        filial.at_nomeFant,
                    };

                e.QueryableSource = queryProdutoCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com produtos das filiais: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void uc_EstoqueProduto_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaProduto();
        }
    }
}