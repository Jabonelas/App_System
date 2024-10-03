using System;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System.Linq;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Linq;
using DevExpress.Utils.StructuredStorage.Internal;
using Unimake.Business.DFe.Xml.SNCM;
using Unimake.Business.DFe.Xml.GNRE;

namespace App_PDV.FechamentoCaixa
{
    public partial class rp_ImpressaoFechamentoCaixa : DevExpress.XtraReports.UI.XtraReport
    {
        private tb_movimentacao caixaAberto;

        public rp_ImpressaoFechamentoCaixa()
        {
            InitializeComponent();

            PreencherCabecario();

            PegarDadosCaixaAberto();

            PegarValoresReforcoCaixa();

            PegarValoresSaidaCaixa();

            PreencherResumoVendas();

            PegarDadosPagamentosRealizados();

            PreencherRodaPe();
        }

        private void PreencherResumoVendas()
        {
            try
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    var queryMovimentacoesAtivas =
                        from movimentacao in session.Query<tb_movimentacao>()
                        join movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                            on movimentacao.id_movimentacao equals movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao
                        join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                            on movimentacaoPagamento.fk_tb_sub_forma_pagamento.id_sub_forma_pagamento equals subFormaPagamento.id_sub_forma_pagamento
                        where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 150
                        group movimentacaoPagamento by movimentacao.fk_tb_jornada into grupoAtendente
                        select new
                        {
                            quantidadeItens = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_qtdItens),
                            valorTotalMovimentacao = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotProd),      // Soma dos valores de movimentação
                            valorTotalReal = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotNF), // Soma dos valores reais de nota fiscal
                            valorTotalDesconto = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotDesc) // Somando os descontos, se houver
                        };

                    // Obtemos o primeiro resultado ou null
                    var resultado = queryMovimentacoesAtivas.FirstOrDefault();

                    if (resultado != null)
                    {
                        lblSubTotalResVen.Text = resultado.valorTotalMovimentacao.ToString("C2");
                        lblDescontoResVen.Text = resultado.valorTotalDesconto.ToString("C2");
                        lblTotalResVen.Text = resultado.valorTotalReal.ToString("C2");
                        lblTotalItensResVen.Text = resultado.quantidadeItens.ToString();
                    }
                    else
                    {
                        // Caso não haja resultado, você pode definir valores padrão
                        lblSubTotalResVen.Text = "R$ 0,00";
                        lblDescontoResVen.Text = "R$ 0,00";
                        lblTotalResVen.Text = "R$ 0,00";
                        lblTotalItensResVen.Text = "0";
                    }

                    var queryQtdVendasRealizadas =
                        (from movimentacao in session.Query<tb_movimentacao>()
                         where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 150
                         select movimentacao.id_movimentacao).Distinct(); // Obtém IDs únicos de movimentações

                    // Obtemos a quantidade total de movimentações distintas
                    var quantidadeVendas = queryQtdVendasRealizadas.Count();

                    // Exibe a quantidade de vendas na label
                    lblQtdVendasResVen.Text = quantidadeVendas.ToString();
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher com vendas realizadas na impressao: {exception}");
            }
        }

        private void PegarValoresReforcoCaixa()
        {
            try
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    var queryMovimentacoesAtivas =
                        from movimentacao in session.Query<tb_movimentacao>()
                        join movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                            on movimentacao.id_movimentacao equals movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao
                        join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                            on movimentacaoPagamento.id_movimentacao_pagamento equals subFormaPagamento
                                .fk_tb_forma_pagamento.id_forma_pagamento
                        where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 11 // 11 é entrada de caixa
                        select movimentacaoPagamento.mpg_nfeVlrMov;

                    // Calcula a soma dos valores da coluna 'mpg_nfeVlrMov'
                    decimal somaValores = queryMovimentacoesAtivas.Sum();

                    // Exibe o valor no label
                    lblReforcoResMov.Text = somaValores.ToString("C2");
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher com entradas realizadas na impressao: {exception}");
            }
        }

        private void PegarValoresSaidaCaixa()
        {
            try
            {
                using (Session session = new Session())
                {
                    // Obtém o objeto jornada
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    // Realiza a consulta para filtrar as movimentações e pagamentos
                    var queryMovimentacoesAtivas =
                        from movimentacao in session.Query<tb_movimentacao>()
                        join movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                            on movimentacao.id_movimentacao equals movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao
                        join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                            on movimentacaoPagamento.id_movimentacao_pagamento equals subFormaPagamento
                                .fk_tb_forma_pagamento.id_forma_pagamento
                        where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 12 // 12 é o código para entrada de caixa, modifique conforme necessário
                        orderby movimentacao.mv_dtCri descending
                        select movimentacaoPagamento.mpg_nfeVlrMov;

                    // Calcula a soma dos valores de 'mpg_nfeVlrMov'
                    decimal somaValores = queryMovimentacoesAtivas.Sum();

                    // Exibe o valor total no label
                    lblRetiradaResMov.Text = Math.Abs(somaValores).ToString("C2"); // Exibe com duas casas decimais em formato de moeda
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher com retiradas realizadas na impressao: {exception}");
            }
        }

        private void PegarDadosCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //mv_movTipo = 1 é abertura de caixa e mv_cxAberto = 1 é caixa aberto

                    caixaAberto = uow.Query<tb_movimentacao>().FirstOrDefault(x => x.mv_movTipo == 1 && x.mv_cxAberto == 1);

                    lblAberturaResMov.Text = caixaAberto.mv_nfeVlrTotNF.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto impressao de fechamento de caixa: {ex.Message}");
            }
        }

        private void PegarDadosPagamentosRealizados()
        {
            try
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    var movimentacoes =
                        from movimentacao in session.Query<tb_movimentacao>()
                        join movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                            on movimentacao.id_movimentacao equals movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao
                        join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                            on movimentacaoPagamento.id_movimentacao_pagamento equals subFormaPagamento.fk_tb_forma_pagamento.id_forma_pagamento
                        where movimentacao.fk_tb_jornada == _jornada
                        select new
                        {
                            ValorMovimentacao = movimentacaoPagamento.mpg_nfeVlrMov,
                            SubFormaPagamentoDesc = movimentacaoPagamento.fk_tb_sub_forma_pagamento.sfp_desc
                        };

                    var queryAgrupada =
                        from mov in movimentacoes.ToList() // Carregar os dados antes de agrupar (evita o erro)
                        group mov by mov.SubFormaPagamentoDesc into grupo
                        select new
                        {
                            TipoPagamento = grupo.Key,
                            ValorTotal = grupo.Sum(m => m.ValorMovimentacao),
                            QuantidadeMovimentacoes = grupo.Count()
                        };

                    var resultados = queryAgrupada.ToList();

                    this.DataSource = resultados;

                    lblFormaPagamento.DataBindings.Clear();
                    lblFormaPagamento.DataBindings.Add("Text", null, "TipoPagamento");

                    lblVlrPagamento.DataBindings.Clear();
                    lblVlrPagamento.DataBindings.Add("Text", null, "ValorTotal");

                    var total = queryAgrupada.Sum(x => x.ValorTotal);

                    lblTotal.Text = total.ToString("C2");
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk(
                    $"Erro ao preencher formas de pagamento e valores que foram realizados os pagamentos: {exception}");
            }
        }

        private void PreencherCabecario()
        {
            try
            {
                tb_ator dadosFilial = VariaveisGlobais.FilialLogada;

                var SNome = !string.IsNullOrWhiteSpace(dadosFilial.at_razSoc) ? dadosFilial.at_razSoc : dadosFilial.at_nomeFant;

                lblNomeFilial.Text = SNome;

                var compl = !string.IsNullOrWhiteSpace(dadosFilial.at_end_Compl) ? $"{dadosFilial.at_end_Compl}" : string.Empty;
                var linha1 = string.Empty;
                var linha2 = string.Empty;
                var linha3 = string.Empty;
                var linha4 = string.Empty;
                var linhaComCmpl = string.Empty;
                linha1 += $"{dadosFilial.at_end_Logr}, {dadosFilial.at_end_Num}";
                linhaComCmpl += $"{dadosFilial.at_end_Logr}, {dadosFilial.at_end_Num}{compl}";
                if (linhaComCmpl.Length <= 50)
                    linha1 += $" - {compl} - {dadosFilial.at_end_Bairro}";
                else
                    linha2 += $" {compl} - {dadosFilial.at_end_Bairro}";
                linha3 += $" CEP: {dadosFilial.at_end_Cep} - {dadosFilial.fk_tb_municipio?.mu_nome} - {dadosFilial.fk_tb_estados_br?.eb_sigla}";
                linha4 += $"CNPJ: {dadosFilial.at_cnpj} - IE:{dadosFilial.at_inscEst}";
                var SEnd = "";
                if (string.IsNullOrWhiteSpace(linha2))
                    SEnd += $"{linha1}{Environment.NewLine}{linha3}{Environment.NewLine}{linha4}".ToUpper();
                else
                    SEnd += $"{linha1}{Environment.NewLine}{linha2}{Environment.NewLine}{linha3}{Environment.NewLine}{linha4}".ToUpper();

                lblDadosFilial.Text = SEnd;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher cabeçalho no relatório de venda vendedor: {ex.Message}");
            }
        }

        private void PreencherRodaPe()
        {
            try
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    string dataAbertura = _jornada.jo_dtCri.ToString("dd/MM/yyyy HH:mm:ss");

                    string dataFechamento = _jornada.jo_dtAlt.ToString("dd/MM/yyyy HH:mm:ss");

                    if (dataFechamento == dataAbertura)
                    {
                        dataFechamento = DateTime.Now.ToString("dd/MM/yyyy");
                    }

                    lblPeriodo.Text = $"{Convert.ToDateTime(dataAbertura).ToString("dd/MM/yyyy")} - {Convert.ToDateTime(dataFechamento).ToString("dd/MM/yyyy")}";

                    lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Ocorreu um erro ao preencher as datas do rodapé na impressão do fechamento de caixa: {exception}");
            }
        }
    }
}