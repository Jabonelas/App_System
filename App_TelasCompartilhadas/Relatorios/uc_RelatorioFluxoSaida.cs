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

namespace App_TelasCompartilhadas.Relatorios
{
    public partial class uc_RelatorioFluxoSaida : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        private decimal total = 0;

        public uc_RelatorioFluxoSaida(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, string _telaCarregamento)
        {
            InitializeComponent();

            painelTelaInicial = _painelTelaInicial;

            Layout();

            PreencherFilial();

            if (_telaCarregamento == "PDV")
            {
                TelaCarregamentoPDV();
            }

            // Desabilita a edição para todas as colunas
            GridView view = grdFluxoSaida.MainView as GridView;
            if (view != null)
            {
                view.OptionsBehavior.Editable = false;
            }
        }

        private void TelaCarregamentoPDV()
        {
            cmbFilial.ReadOnly = true;

            cmbFilial.EditValue = VariaveisGlobais.FilialLogada.id_ator;
        }

        private void PreencherFilial()
        {
            try
            {
                using (Session session = new Session())
                {
                    var filial = session.Query<tb_ator>()
                        .Where(x => x.at_desat == 0 && x.at_atorTipo == 11)
                        .Select(x => new
                        {
                            x.id_ator,
                            x.at_nomeFant,
                            x.at_cnpj
                        })
                        .ToList();

                    cmbFilial.Properties.DataSource = filial;
                    cmbFilial.Properties.DisplayMember = "at_nomeFant";
                    cmbFilial.Properties.ValueMember = "id_ator";
                    cmbFilial.Properties.NullText = "Selecione a Filial";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher filial no relatorio de fluxo de saida: {ex.Message}");
            }
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
            painelTelaInicial.Controls.Clear();
            uc_TelaInicial ucTelaInicial = new uc_TelaInicial();
            painelTelaInicial.Controls.Add(ucTelaInicial);
            painelTelaInicial.Tag = ucTelaInicial;

            ucTelaInicial.Show();
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

                    lblValotTotalFluxoSaida.Text = total.ToString("C2");
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
                          && movimentacao.fk_tb_ator_emit.id_ator == Convert.ToInt32(cmbFilial.EditValue)
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
                    long idFilial = Convert.ToInt32(cmbFilial.EditValue);

                    rp_ImpressaoRelatorioFluxoSaida relatorio =
                        new rp_ImpressaoRelatorioFluxoSaida(dataInicio, dataFinal, idFilial);
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
            if (string.IsNullOrEmpty(cmbFilial.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Filial.");
                cmbFilial.Focus();
                return false;
            }

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