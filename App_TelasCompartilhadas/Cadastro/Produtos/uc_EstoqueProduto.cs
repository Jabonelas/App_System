using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using System.ComponentModel;
using App_TelasCompartilhadas.Login;

namespace App_TelasCompartilhadas.Produtos
{
    public partial class uc_EstoqueProduto : DevExpress.XtraEditors.XtraUserControl
    {
        private long idProduto = 0;

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        private string formaOrdenarGrid = "";

        public static BindingList<produtosSelecionados> listaProdutoFilial = new BindingList<produtosSelecionados>();

        public uc_EstoqueProduto(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, long _idProduto, string _formaOrdenarGrid)
        {
            InitializeComponent();

            painelTelaInicial = _painelTelaInicial;

            idProduto = _idProduto;

            formaOrdenarGrid = _formaOrdenarGrid;

            //GridView view = grdListaProdutos.MainView as GridView;

            //view.OptionsBehavior.Editable = false;

            HabilitarEventoAlteracaoDentroGrid();

            LayoutBotoes();

            CarregarGridProdutoEstoqueFiliais();
        }

        public class produtosSelecionados : INotifyPropertyChanged
        {
            private long _idProdutoFilial;
            private int _codRef;
            private string _descCurta;
            private string _desc;
            private int _quantidade;
            private decimal _vlrUnCom;
            private string _cnpjFilial;
            private string _filial;

            public long idProdutoFilial
            {
                get { return _idProdutoFilial; }
                set { _idProdutoFilial = value; OnPropertyChanged(nameof(idProdutoFilial)); }
            }

            public int codRef
            {
                get { return _codRef; }
                set { _codRef = value; OnPropertyChanged(nameof(codRef)); }
            }

            public string descCurta
            {
                get { return _descCurta; }
                set { _descCurta = value; OnPropertyChanged(nameof(descCurta)); }
            }

            public string desc
            {
                get { return _desc; }
                set { _desc = value; OnPropertyChanged(nameof(desc)); }
            }

            public int quantidade
            {
                get { return _quantidade; }
                set { _quantidade = value; OnPropertyChanged(nameof(quantidade)); }
            }

            public decimal vlrUnCom
            {
                get { return _vlrUnCom; }
                set { _vlrUnCom = value; OnPropertyChanged(nameof(vlrUnCom)); }
            }

            public string cnpjFilial
            {
                get { return _cnpjFilial; }
                set { _cnpjFilial = value; OnPropertyChanged(nameof(cnpjFilial)); }
            }

            public string filial
            {
                get { return _filial; }
                set { _filial = value; OnPropertyChanged(nameof(filial)); }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private GridView view = null;

        private void HabilitarEventoAlteracaoDentroGrid()
        {
            view = grdListaProdutos.MainView as GridView;

            view.OptionsBehavior.Editable = false;

            view.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click; // Iniciar a edição ao clicar

            // Verifique se o view não é nulo antes de associar o evento
            if (view != null)
            {
                // Adicionando o evento CellValueChanged ao GridView
                //view.CellValueChanged += view_CellValueChanged;
            }
        }

        private void grdListaProdutos_DoubleClick(object sender, EventArgs e)
        {
            bool isUsuarioLogadoGerente = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102;

            if (!isUsuarioLogadoGerente)
            {
                frmAutenticacaoUsuario frmAutenticacaoUsuario = new frmAutenticacaoUsuario();
                frmAutenticacaoUsuario.ShowDialog();
            }

            if (VariaveisGlobais.isUsuarioComPermissao || isUsuarioLogadoGerente)
            {
                view.OptionsBehavior.Editable = true;
            }
        }

        private void gridView3_RowEditCanceled(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            VariaveisGlobais.isUsuarioComPermissao = false;
        }

        private void gridView3_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            // Obter o objeto atualizado (linha completa)
            var linhaAtualizada = e.Row;

            // Exemplo de como pegar valores específicos da linha
            long idProdutoFilial = (long)((GridView)sender).GetRowCellValue(e.RowHandle, "idProdutoFilial");

            // Exemplo de como acessar os valores da linha atualizada
            var novoValorQuantidade = ((GridView)sender).GetRowCellValue(e.RowHandle, "quantidade");

            // Chamar função de atualização passando os valores da linha
            AtualizarProdutoFilial(idProdutoFilial, novoValorQuantidade);

            // Mostrar alerta de confirmação

            VariaveisGlobais.isUsuarioComPermissao = false;

            uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(painelTelaInicial);
        }

        private void AtualizarProdutoFilial(long idProdutoFilial, object novoValor)
        {
            try
            {
                using (UnitOfWork session = new UnitOfWork())
                {
                    tb_produto_filial produtoFilial = session.GetObjectByKey<tb_produto_filial>(idProdutoFilial);

                    tb_produto produto = session.GetObjectByKey<tb_produto>(produtoFilial.fk_tb_produto.id_produto);

                    produto.pd_estTot += Convert.ToInt32(novoValor) - produtoFilial.pf_est;

                    produtoFilial.pf_est = Convert.ToInt32(novoValor);

                    session.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar o produto geral/filial: {ex.Message}");
            }
        }

        private void CarregarGridProdutoEstoqueFiliais()
        {
            try
            {
                using (Session uow = new Session())
                {
                    var produtoSelecionado =
                        from produtoFilial in uow.Query<tb_produto_filial>()
                        join produto in uow.Query<tb_produto>()
                            on produtoFilial.fk_tb_produto.id_produto equals produto.id_produto
                        join filial in uow.Query<tb_ator>()
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

                    foreach (var item in produtoSelecionado)
                    {
                        listaProdutoFilial.Add(new produtosSelecionados
                        {
                            idProdutoFilial = Convert.ToInt16(item.id_produto_filial),
                            codRef = Convert.ToInt16(item.pf_codRef),
                            descCurta = item.pf_descCurta,
                            desc = item.pf_desc,
                            quantidade = Convert.ToInt32(item.pf_est),
                            vlrUnCom = item.pf_vlrUnCom,
                            cnpjFilial = item.at_cnpj,
                            filial = item.at_nomeFant
                        });
                    }

                    grdListaProdutos.DataSource = listaProdutoFilial;
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com produtos das filiais: {exception}");
            }
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);

            uc_TituloTelas1.lblTituloTela.Text = "Estoque do Produto em todas as Filiais";
        }

        private void uc_EstoqueProduto_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            painelTelaInicial.Controls.Clear();
            uc_Produto ucProduto = new uc_Produto(painelTelaInicial, formaOrdenarGrid);
            painelTelaInicial.Controls.Add(ucProduto);
            painelTelaInicial.Tag = ucProduto;

            ucProduto.Show();
        }
    }
}