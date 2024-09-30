using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.Data.Linq;
using DevExpress.XtraReports.UI;

namespace App_PDV.Caixa.Relatorios
{
    public partial class uc_RelatorioFluxoSaida : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialPDV _frmTelaInicial;

        public uc_RelatorioFluxoSaida(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoBuscar(btnBuscar);
            configBotoes.BotaoImprimir(btnImprimir);
            configBotoes.BotaoExcel(btnExcel);

            uc_TituloTelas1.lblTituloTela.Text = "Relatório de Fluxo de Saída";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }

        private void uc_RelatorioFluxoSaida_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = Convert.ToDateTime(dtInicio.EditValue);
            DateTime dataFinal = Convert.ToDateTime(dtFinal.EditValue);

            if (IscamposPreenchidos())
            {
                if (dataInicio <= dataFinal)
                {
                    CarregarGridMovimentacaoAtivas();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("A data de início não pode ser posterior à data final!");
                }
            }
        }

        private void CarregarGridMovimentacaoAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "CodProduto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "CodProduto ASC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable +=
                linqBuscarDadosMovimentacaoCadastradosAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdFluxoSaida.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMovimentacaoCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                DateTime dataInicio = Convert.ToDateTime(dtInicio.EditValue);
                DateTime dataFinal = Convert.ToDateTime(dtFinal.EditValue);

                var queryMovimentacoesAtivas =
                    from movimentacao in session.Query<tb_movimentacao>()
                    join produto in session.Query<tb_movimentacao_produto>()
                        on movimentacao.id_movimentacao equals produto.fk_tb_movimentacao.id_movimentacao
                    where movimentacao.mv_dtCri.Date >= dataInicio.Date
                          && movimentacao.mv_dtCri.Date <= dataFinal.Date
                          && movimentacao.mv_movTipo == 150
                    group produto by new { produto.mp_desc, produto.fk_tb_produto.pd_codRef }
                    into grupoAtendente
                    select new
                    {
                        CodProduto = grupoAtendente.Key.pd_codRef,
                        Produto = grupoAtendente.Key.mp_desc,
                        SomaQuantidadeItens = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_qtdItens),
                        SomaValorTotalNF = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotNF),
                        SomaValorTotalProd = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotProd),
                        SomaValorTotalDesc = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotDesc)
                    };

                e.QueryableSource = queryMovimentacoesAtivas;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk(
                    $"Erro ao preencher tabela com lista de produtos foram realizadas as vendas: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DateTime dataInicio = Convert.ToDateTime(dtInicio.EditValue);
            DateTime dataFinal = Convert.ToDateTime(dtFinal.EditValue);

            if (IscamposPreenchidos())
            {
                if (dataInicio <= dataFinal)
                {
                    rp_ImpressaoRelatorioFluxoSaida relatorio =
                        new rp_ImpressaoRelatorioFluxoSaida(dataInicio, dataFinal);
                    relatorio.ShowPreview();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("A data de início não pode ser posterior à data final!");
                }
            }
        }

        private bool IscamposPreenchidos()
        {
            if (string.IsNullOrEmpty(dtInicio.Text) || string.IsNullOrEmpty(dtFinal.Text))
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, informe a data de início e à data final!");

                return false;
            }

            return true;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grdFluxoSaida.DataSource != null)
            {
                XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog();

                saveFileDialog.Filter = "Excel Files|*.xlsx";

                string dataInicio = Convert.ToDateTime(dtInicio.EditValue).ToString("dd-MM-yyyy");
                string dataFinal = Convert.ToDateTime(dtFinal.EditValue).ToString("dd-MM-yyyy");

                saveFileDialog.FileName = $"ProdutosVendidos_{dataInicio}_a_{dataFinal}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    grdFluxoSaida.ExportToXlsx(saveFileDialog.FileName);
                }
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, primeiro inicie a busca.");
            }
        }
    }
}