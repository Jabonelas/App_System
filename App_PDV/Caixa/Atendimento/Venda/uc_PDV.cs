using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraGrid.Views.Grid;

namespace App_PDV
{
    public partial class uc_PDV : DevExpress.XtraEditors.XtraUserControl
    {
        private long _idProduto = 0;

        public static BindingList<produtosSelecionados> listaProdutoSelecionado = new BindingList<produtosSelecionados>();

        private frmTelaInicialPDV _frmTelaInicial;

        private int idMovimentacao = 0;

        public uc_PDV(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            PreencherProduto();

            listaProdutoSelecionado.Clear();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            //configBotoes.BotaoSelecionarProduto(btnSelecionarProduto);
            configBotoes.BotaoAdicionarCarrinho(btnSelecionarProduto);
            configBotoes.BotaoPagamento(btnPagamento);
            configBotoes.BotaoExcluir(btnExcluir);

            uc_TituloTelas1.lblTituloTela.Text = "Ponto de Venda";
        }

        private void PreencherProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator filialLogado = uow.GetObjectByKey<tb_ator>(VariaveisGlobais.FilialLogada.id_ator);

                    var produtos = (from produtoFilial in uow.Query<tb_produto_filial>()
                                    join produto in uow.Query<tb_produto>() on produtoFilial.fk_tb_produto.id_produto equals produto.id_produto
                                    join marca in uow.Query<tb_marca_produto>() on produto.fk_tb_marca_produto.id_marca_produto equals marca.id_marca_produto
                                    where produtoFilial.pf_desat == 0 && produtoFilial.fk_tb_ator == filialLogado
                                    select new
                                    {
                                        produtoFilial.id_produto_filial,
                                        produtoFilial.pf_codRef,
                                        produtoFilial.pf_descCurta,
                                        produtoFilial.pf_desc,
                                        marca.mp_desc,
                                        produtoFilial.pf_vlrUnCom,
                                        produtoFilial.pf_est
                                    }).ToList();

                    cmbProdutos.Properties.DataSource = produtos;
                    cmbProdutos.Properties.DisplayMember = "pf_desc";
                    cmbProdutos.Properties.ValueMember = "id_produto_filial";
                    cmbProdutos.Properties.NullText = "Selecione o Produto";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher Produtos: {ex.Message}");
            }
        }

        private void uc_PDV_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        public class produtosSelecionados : INotifyPropertyChanged
        {
            private int _idProdutoFilial;
            private int _codRef;
            private string _descCurta;
            private string _desc;
            private string _marca;
            private int _quantidade;
            private decimal _vlrUnCom;

            public int idProdutoFilial
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

            public string marca
            {
                get { return _marca; }
                set { _marca = value; OnPropertyChanged(nameof(marca)); }
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

            public event PropertyChangedEventHandler PropertyChanged;

            protected void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void PreencherGridProdutoSelecionado()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (cmbProdutos.EditValue == null || string.IsNullOrEmpty(cmbProdutos.EditValue.ToString()))
                    {
                        return;
                    }

                    long idProduto;

                    if (!long.TryParse(cmbProdutos.EditValue.ToString(), out idProduto))
                    {
                        MensagensDoSistema.MensagemAtencaoOk("O valor selecionado não é um identificador válido.");
                        return;
                    }

                    var produtoSelecionado = (from produtoFilial in uow.Query<tb_produto_filial>()
                                              join produto in uow.Query<tb_produto>() on produtoFilial.fk_tb_produto.id_produto equals produto.id_produto
                                              join marca in uow.Query<tb_marca_produto>() on produto.fk_tb_marca_produto.id_marca_produto equals marca.id_marca_produto
                                              where produtoFilial.id_produto_filial == idProduto
                                              select new
                                              {
                                                  produtoFilial.id_produto_filial,
                                                  produtoFilial.pf_codRef,
                                                  produtoFilial.pf_descCurta,
                                                  produtoFilial.pf_desc,
                                                  marca.mp_desc,
                                                  produtoFilial.pf_vlrUnCom,
                                                  produtoFilial.pf_est
                                              }).FirstOrDefault();

                    if (produtoSelecionado.pf_est <= 0)
                    {
                        MensagensDoSistema.MensagemAtencaoOk("O produto selecionado não tem estoque disponível.");

                        return;
                    }

                    listaProdutoSelecionado.Add(new produtosSelecionados
                    {
                        idProdutoFilial = Convert.ToInt16(produtoSelecionado.id_produto_filial),
                        codRef = Convert.ToInt16(produtoSelecionado.pf_codRef),
                        descCurta = produtoSelecionado.pf_descCurta,
                        desc = produtoSelecionado.pf_desc,
                        marca = produtoSelecionado.mp_desc,
                        quantidade = 1,
                        vlrUnCom = produtoSelecionado.pf_vlrUnCom
                    });

                    grdListaProdutos.DataSource = listaProdutoSelecionado;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher produtos selecionado: {ex.Message}");
            }
        }

        private void PreencherCamposComValores()
        {
            decimal valorTotal = 0;

            int quantidadeTotal = 0;

            foreach (var item in listaProdutoSelecionado)
            {
                valorTotal += (item.quantidade * item.vlrUnCom);

                quantidadeTotal += item.quantidade;
            }

            lblTotalGeral.Text = valorTotal.ToString("C2");
        }

        private void btnSelecionarProduto_Click(object sender, EventArgs e)
        {
            PreencherGridProdutoSelecionado();

            PreencherCamposComValores();

            cmbProdutos.Clear();
        }

        private void PegaIdCategoriaSelecionadaGrid()
        {
            GridView view = grdListaProdutos.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    _idProduto = Convert.ToInt16(view.GetRowCellValue(rowHandle, "idProdutoFilial"));
                }
                else
                {
                    _idProduto = 0;
                }
            }
        }

        private void RemoverProduto()
        {
            PegaIdCategoriaSelecionadaGrid();

            if (_idProduto == 0)
            {
                MensagensDoSistema.MensagemErroOk("Nenhum produto foi selecionado.");

                return;
            }

            var produtoSelecionado = listaProdutoSelecionado.FirstOrDefault(p => p.idProdutoFilial == _idProduto);

            listaProdutoSelecionado.Remove(produtoSelecionado);

            grdListaProdutos.DataSource = null;

            grdListaProdutos.DataSource = listaProdutoSelecionado;
        }

        private void VerificarEstoqueProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_produto_filial produtoSelecionado = uow.Query<tb_produto_filial>().FirstOrDefault(p => p.id_produto_filial == _idProduto);

                    var produtoQtdAlterada = listaProdutoSelecionado.FirstOrDefault(p => p.idProdutoFilial == _idProduto);

                    if (produtoQtdAlterada.quantidade > produtoSelecionado.pf_est)
                    {
                        MensagensDoSistema.MensagemAtencaoOk("A quantidade informada excede a quantidade disponível em estoque.");

                        produtoQtdAlterada.quantidade = Convert.ToInt16(produtoSelecionado.pf_est);
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher produtos selecionado: {ex.Message}");
            }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            VerificarEstoqueProduto();

            PreencherCamposComValores();
        }

        private void cmbProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PreencherGridProdutoSelecionado();

                PreencherCamposComValores();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaVendasPDV();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            if (_idProduto != 0)
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Deseja realmente excluir o produto selecionado?");

                if (dialogResult == DialogResult.Yes)
                {
                    RemoverProduto();

                    PreencherCamposComValores();
                }
            }
        }

        private void TelaPagementoPDV()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            frmPagamentoPDV frmPamentoPDV = new frmPagamentoPDV(_frmTelaInicial);
            frmPamentoPDV.ShowDialog();
        }

        private void btnPagamento_Click(object sender, EventArgs e)
        {
            if (listaProdutoSelecionado.Count != 0)
            {
                TelaPagementoPDV();
            }
        }

        private void uc_PDV_Leave(object sender, EventArgs e)
        {
            listaProdutoSelecionado.Clear();
        }
    }
}