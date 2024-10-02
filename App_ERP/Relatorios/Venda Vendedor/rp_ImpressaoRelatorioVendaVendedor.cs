using System;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System.Linq;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraGrid.Views.Grid;

namespace App_ERP.Relatorios
{
    public partial class rp_ImpressaoRelatorioVendaVendedor : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_ImpressaoRelatorioVendaVendedor(DateTime dataInicio, DateTime dataFinal)
        {
            InitializeComponent();

            PreencherCabecario();

            PreencherCorpo(dataInicio, dataFinal);

            PreencherRodaPe(dataInicio, dataFinal);
        }

        private void PreencherCorpo(DateTime dataInicio, DateTime dataFinal)
        {
            Session session = new Session();

            var queryMovimentacoesAtivas = session.Query<tb_movimentacao>()
                .Join(session.Query<tb_movimentacao_produto>(),
                    movimentacao => movimentacao.id_movimentacao,
                    produto => produto.fk_tb_movimentacao.id_movimentacao,
                    (movimentacao, produto) => new { movimentacao, produto })
                .Where(x => x.movimentacao.mv_dtCri.Date >= dataInicio.Date
                            && x.movimentacao.mv_dtCri.Date <= dataFinal.Date
                            && x.movimentacao.mv_movTipo == 150)
                .GroupBy(x => new { x.movimentacao.fk_tb_ator_atend })
                .Select(grupoAtendente => new
                {
                    VendedorCPF = grupoAtendente.Key.fk_tb_ator_atend.at_cpf,
                    Vendedor = grupoAtendente.Key.fk_tb_ator_atend.at_razSoc,
                    SomaQuantidadeItens = grupoAtendente.Sum(m => m.produto.fk_tb_movimentacao.mv_qtdItens),
                    SomaValorTotalNF = grupoAtendente.Sum(m => m.produto.fk_tb_movimentacao.mv_nfeVlrTotNF),
                    //SomaValorTotalProd = grupoAtendente.Sum(m => m.produto.fk_tb_movimentacao.mv_nfeVlrTotProd),
                    //SomaValorTotalDesc = grupoAtendente.Sum(m => m.produto.fk_tb_movimentacao.mv_nfeVlrTotDesc)
                })
                // Ordenação pelo CPF do Vendedor
                .OrderBy(grupoAtendente => grupoAtendente.Vendedor);

            this.DataSource = queryMovimentacoesAtivas;

            lblCPF.DataBindings.Clear();
            lblCPF.DataBindings.Add("Text", null, "VendedorCPF");

            lblNomeVendedor.DataBindings.Clear();
            lblNomeVendedor.DataBindings.Add("Text", null, "Vendedor");

            lblQtdTotal.DataBindings.Clear();
            lblQtdTotal.DataBindings.Add("Text", null, "SomaQuantidadeItens");

            lblVlrTotalVendido.DataBindings.Clear();
            lblVlrTotalVendido.DataBindings.Add("Text", null, "SomaValorTotalNF");

            decimal total = 0;

            foreach (var item in queryMovimentacoesAtivas)
            {
                total += item.SomaValorTotalNF;
            }

            lblTotal.DataBindings.Clear();
            lblTotal.Text = total.ToString("C2");
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

        private void PreencherRodaPe(DateTime dataInicio, DateTime dataFina)
        {
            lblPeriodo.Text = $"{dataInicio.ToString("dd/MM/yyyy")} - {dataFina.ToString("dd/MM/yyyy")}";
            lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}