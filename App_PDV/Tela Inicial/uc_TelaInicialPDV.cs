﻿using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraCharts;
using App_TelasCompartilhadas.Classes;
using System;
using System.Drawing;
using System.Linq;
using App_TelasCompartilhadas.bancoSQLite;

namespace App_PDV
{
    public partial class uc_TelaInicialPDV : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_TelaInicialPDV()
        {
            InitializeComponent();

            LayoutBotoes();

            CarregandoDadosGrafico();
        }

        private void LayoutBotoes()
        {
            lblBemVindoUsuario.Font = new Font("Exo 2", 20);
            lblBemVindoUsuario.Text = $"Bem-vindo(a), {App_TelasCompartilhadas.Classes.VariaveisGlobais.UsuarioLogado.at_razSoc}!";
            lblFraseVenda.Font = new Font("Exo 2", 10, FontStyle.Bold);
            lblFraseDenifa.Font = new Font("Exo 2", 10);
        }

        private void uc_TelaInicial_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        public void CarregandoDadosGrafico()
        {
            try
            {
                UnitOfWork uow = new UnitOfWork();

                #region Retrieve sample data

                // Define o início e o fim do mês atual
                DateTime dtFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Primeiro dia do mês atual
                DateTime dtTo = DateTime.Now; // Último dia até o momento atual (hoje)

                // Gera todas as datas do mês atual até o dia atual
                var datasDoMes = Enumerable.Range(1, dtTo.Day)
                                           .Select(day => new DateTime(dtFrom.Year, dtFrom.Month, day))
                                           .ToList();

                // Recupera os movimentos registrados dentro do intervalo do mês atual
                var movimentacao = new XPCollection<tb_movimentacao>(uow, CriteriaOperator.FromLambda<tb_movimentacao>(w => w.mv_dtCri >= dtFrom && w.mv_dtCri <= dtTo && w.mv_movTipo == 150));// movTipo 150 é venda

                // Agrupa os valores por dia, garantindo que dias sem movimento sejam exibidos com valor 0
                var valores = from data in datasDoMes
                              join mov in movimentacao on data.Date equals mov.mv_dtCri.Date into movGroup
                              from subMov in movGroup.DefaultIfEmpty() // Se não houver registro, subMov será null
                              select new
                              {
                                  SDtCri = data,
                                  SNfeVersao = movGroup.Sum(m => m?.mv_nfeVlrTotNF ?? 0),
                                  Qtd = movGroup.Count() // Se não houver registro, considera 0
                              };

                //Valor total vendido
                decimal totalVendido = movimentacao.Sum(m => m?.mv_nfeVlrTotNF ?? 0);
                lblValorTotalVendidoMes.Text = totalVendido.ToString("C2");
                int totalVendas = movimentacao.Count();//150 é o tipo de movimento de venda;
                lblQdtVendasMes.Text = $"{totalVendas} vendas";

                foreach (var item in valores)
                {
                    if (item.SDtCri == DateTime.Today)
                    {
                        lblValorTotalVendidoDia.Text = item.SNfeVersao.ToString("C2");
                        lblQdtVendasDia.Text = $"{item.Qtd} vendas";
                    }
                }

                // Verifica se há uma série existente, se não, cria uma nova
                if (chartControl1.Series.Count == 0)
                {
                    // Cria uma nova série e define o tipo como gráfico de linha
                    Series series = new Series("Vendas", ViewType.Line);
                    chartControl1.Series.Add(series);
                }

                // Acessa a primeira série do ChartControl
                Series currentSeries = chartControl1.Series[0];

                // Define a fonte de dados da série
                currentSeries.DataSource = valores;
                currentSeries.ArgumentDataMember = "SDtCri";
                currentSeries.ValueDataMembers.AddRange(new string[] { "SNfeVersao" });

                // Configura o eixo Y para exibir valores como moeda (R$)
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                diagram.AxisY.Label.TextPattern = "{V:C}"; // Define o padrão como moeda

                // Configura o eixo X para exibir apenas o dia e o mês
                diagram.AxisX.DateTimeScaleOptions.MeasureUnit = DateTimeMeasureUnit.Day; // Configura a escala como diária
                diagram.AxisX.Label.TextPattern = "{A:dd/MM}"; // Define o padrão para mostrar apenas o dia e o mês

                // Limpa títulos antigos, se necessário
                chartControl1.Titles.Clear();

                // Adiciona o título principal do gráfico
                ChartTitle title = new ChartTitle();
                title.Text = "<b>Gráfico de acompanhamento da meta mensal</b>";
                chartControl1.Titles.Add(title);

                decimal metaDoMes = VariaveisGlobais.FilialLogada == null ? 0 : (decimal)VariaveisGlobais.FilialLogada.at_metaMensal;

                if (metaDoMes > 0)
                {
                    decimal vendidoAteAgora = movimentacao.Sum(m => m?.mv_nfeVlrTotNF ?? 0);
                    int diasNoMes = DateTime.DaysInMonth(dtTo.Year, dtTo.Month);
                    decimal metaDiaria = metaDoMes / diasNoMes;
                    decimal realizadoPorc = vendidoAteAgora / metaDoMes * 100;
                    decimal acimaDaMetaPorc = (vendidoAteAgora - metaDoMes) / metaDoMes * 100;
                    decimal abaixoDaMetaPorc = (metaDoMes - vendidoAteAgora) / metaDoMes * 100;
                    decimal metaDeHoje = metaDiaria * dtTo.Day;
                    decimal abaixoDaMeta = metaDeHoje - vendidoAteAgora;
                    decimal acimaDaMeta = vendidoAteAgora - metaDeHoje;
                    abaixoDaMetaPorc *= -1;
                    decimal restanteParaMeta = (metaDoMes - vendidoAteAgora) / (diasNoMes - dtTo.Day + 1);

                    // Adiciona informações complementares no título do gráfico
                    chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13>Projeção R$ {metaDoMes:C2}" });
                    chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13>Realizada {vendidoAteAgora:C2} ({realizadoPorc:N1}%) até {dtTo:dd/MM/yy}" });

                    if (acimaDaMetaPorc > 0)
                    {
                        chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13><color=darkgreen>Dentro da meta {acimaDaMeta:C2} ({acimaDaMetaPorc:N1}%)</color>" });
                    }
                    else
                    {
                        chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13><color=red>Abaixo da meta {abaixoDaMeta:C2} ({abaixoDaMetaPorc:N1}%)</color>" });
                    }

                    chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13>Venda diária para atingir a meta {restanteParaMeta:C2}" });
                }
                else
                {
                    chartControl1.Titles.Add(new ChartTitle { Text = $"<size=13>Meta não definida para essa loja!" });
                }

                #endregion Retrieve sample data
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
    }
}