using DevExpress.XtraEditors;
using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.Data.Linq;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace App_ERP.Relatorios
{
    public partial class uc_RelatorioVendaVendedor : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP frmTelaInicialERP;

        private decimal total = 0;

        public uc_RelatorioVendaVendedor(frmTelaInicialERP _form)
        {
            InitializeComponent();

            Layout();

            frmTelaInicialERP = _form;

            // Desabilita a edição para todas as colunas
            GridView view = grdVendasVendedor.MainView as GridView;
            if (view != null)
            {
                view.OptionsBehavior.Editable = false;
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoBuscar(btnBuscar);
            configBotoes.BotaoImprimir(btnImprimir);
            configBotoes.BotaoExcel(btnExcel);

            uc_TituloTelas1.lblTituloTela.Text = "Relatório de Vendas por Vendedor";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmTelaInicialERP.ExibirTelaInicial(this);
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

                    lblValorTot.Text = total.ToString("C2");
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

            linqInstantFeedbackSource.KeyExpression = "Vendedor"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "Vendedor ASC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable +=
                linqBuscarDadosMovimentacaoCadastradosAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdVendasVendedor.DataSource = linqInstantFeedbackSource;
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
                    group produto by new { movimentacao.fk_tb_ator_atend }
                    into grupoAtendente
                    select new
                    {
                        Vendedor = grupoAtendente.Key.fk_tb_ator_atend.at_razSoc,
                        VendedorCPF = grupoAtendente.Key.fk_tb_ator_atend.at_cpf,
                        SomaQuantidadeItens = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_qtdItens),
                        SomaValorTotalNF = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotNF),
                        SomaValorTotalProd = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotProd),
                        SomaValorTotalDesc = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotDesc)
                    };

                if (queryMovimentacoesAtivas.Count() == 0)
                {
                    MensagensDoSistema.MensagemInformacaoOk("Nenhuma venda foi registrada neste período.");
                }
                else
                {
                    total = 0;

                    foreach (var item in queryMovimentacoesAtivas)
                    {
                        total += item.SomaValorTotalNF;
                    }
                }

                e.QueryableSource = queryMovimentacoesAtivas;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk(
                    $"Erro ao preencher tabela com lista dos venderos com a quantidade/valor que foram vendidos: {exception}");
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
                    rp_ImpressaoRelatorioVendaVendedor relatorio =
                        new rp_ImpressaoRelatorioVendaVendedor(dataInicio, dataFinal);
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
            if (grdVendasVendedor.DataSource != null)
            {
                XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog();

                saveFileDialog.Filter = "Excel Files|*.xlsx";

                string dataInicio = Convert.ToDateTime(dtInicio.EditValue).ToString("dd-MM-yyyy");
                string dataFinal = Convert.ToDateTime(dtFinal.EditValue).ToString("dd-MM-yyyy");

                saveFileDialog.FileName = $"VendasVendedor_{dataInicio}_a_{dataFinal}.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    grdVendasVendedor.ExportToXlsx(saveFileDialog.FileName);
                }
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, primeiro inicie a busca.");
            }
        }
    }
}