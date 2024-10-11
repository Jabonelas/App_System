using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using DevExpress.Xpo;
using System;
using System.Linq;

namespace App_PDV.Caixa.Atendimento.Venda
{
    public partial class rp_ImpressaoCupomNaoFiscal : DevExpress.XtraReports.UI.XtraReport
    {
        private long idMovimentacao = 0;

        public rp_ImpressaoCupomNaoFiscal(string _nomeCliente, string _nomeVendedor, long _idMovimentacao)
        {
            InitializeComponent();

            PreencherCabecario();

            lblNomeVendedor.Text = _nomeVendedor;
            lblNomeCliente.Text = _nomeCliente;
            lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");

            idMovimentacao = _idMovimentacao;

            PreencherProdutos();

            PreencherFormaPagamento();

            ValoresTotaisRodaPe();
        }

        private void ValoresTotaisRodaPe()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _movimentacao = uow.GetObjectByKey<tb_movimentacao>(idMovimentacao);

                    lblTotalPedido.Text = _movimentacao.mv_nfeVlrTotProd.ToString("C");
                    lblTotalDesconto.Text = _movimentacao.mv_nfeVlrTotDesc.ToString("C");
                    lblTotalFinal.Text = _movimentacao.mv_nfeVlrTotNF.ToString("C");
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher valor total do cupom não fiscal: {ex.Message}");
            }
        }

        private void PreencherFormaPagamento()
        {
            try
            {
                Session session = new Session();

                var queryMovimentacoesAtivas =
                    from movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                    join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                        on movimentacaoPagamento.fk_tb_sub_forma_pagamento equals subFormaPagamento
                    where movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao == idMovimentacao // Corrigir a chave estrangeira, se necessário
                    select new
                    {
                        formaPagamento = subFormaPagamento.sfp_desc,
                        valorPagamento = movimentacaoPagamento.mpg_nfeVlrMov
                    };

                DetailReport1.DataSource = queryMovimentacoesAtivas;

                lblFormaPagamento.DataBindings.Clear();
                lblFormaPagamento.DataBindings.Add("Text", null, "formaPagamento");

                lblValorPagamento.DataBindings.Clear();
                lblValorPagamento.DataBindings.Add("Text", null, "valorPagamento");
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher forma de pagamento do cupom não fiscal: {ex.Message}");
            }
        }

        private void PreencherProdutos()
        {
            try
            {
                Session session = new Session();

                var queryMovimentacoesAtivas =
                    from movimentacaoProduto in session.Query<tb_movimentacao_produto>()
                    where movimentacaoProduto.fk_tb_movimentacao.id_movimentacao == idMovimentacao // Corrigir a chave estrangeira, se necessário
                    select new
                    {
                        codRef = movimentacaoProduto.mp_codRef,
                        descricaoProduto = movimentacaoProduto.mp_desc,
                        quantidade = movimentacaoProduto.mp_qtdCom,
                        valorUnitario = movimentacaoProduto.mp_vlrUnCom,
                        valorSubTotal = movimentacaoProduto.mp_vlrProdTot - movimentacaoProduto.mp_vlrDesc,
                        valorDesconto = movimentacaoProduto.mp_vlrDesc
                    };

                DetailReport.DataSource = queryMovimentacoesAtivas;

                lblCodRef.DataBindings.Clear();
                lblCodRef.DataBindings.Add("Text", null, "codRef");

                lblDescProd.DataBindings.Clear();
                lblDescProd.DataBindings.Add("Text", null, "descricaoProduto");

                lblQtdProd.DataBindings.Clear();
                lblQtdProd.DataBindings.Add("Text", null, "quantidade");

                lvlValorUn.DataBindings.Clear();
                lvlValorUn.DataBindings.Add("Text", null, "valorUnitario");

                lblVlrSubTotal.DataBindings.Clear();
                lblVlrSubTotal.DataBindings.Add("Text", null, "valorSubTotal");

                lblValorDesconto.DataBindings.Clear();
                lblValorDesconto.DataBindings.Add("Text", null, "valorDesconto");
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher produtos do cupom não fiscal: {ex.Message}");
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
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher cabeçalho do cupom não fiscal: {ex.Message}");
            }
        }
    }
}