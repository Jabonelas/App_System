using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.DataAccess.Native.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;
using Unimake.Business.DFe.Xml.SNCM;

using System.Collections.Generic;
using System.ComponentModel;

using System.Data;

using System.Drawing;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;

using DXApplicationPDV.Classes;
using DevExpress.Data.Linq;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraGrid.Columns;
using DevExpress.XtraReports.UI;

using System.IO;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraScheduler.Outlook.Interop;

namespace DXApplicationPDV.Caixa.Relatorios
{
    public partial class rp_ImpressaoRelatorioFluxoSaida : DevExpress.XtraReports.UI.XtraReport
    {
        public rp_ImpressaoRelatorioFluxoSaida(DateTime dataInicio, DateTime dataFinal)
        {
            InitializeComponent();

            PreencherCabecario();

            PreencherCorpo(dataInicio, dataFinal);

            PreencherRodaPe(dataInicio, dataFinal);
        }

        private void PreencherCorpo(DateTime dataInicio, DateTime dataFinal)
        {
            Session session = new Session();

            var queryMovimentacoesAtivas =
                from movimentacao in session.Query<tb_movimentacao>()
                join produto in session.Query<tb_movimentacao_produto>()
                    on movimentacao.id_movimentacao equals produto.fk_tb_movimentacao.id_movimentacao
                where movimentacao.mv_dtCri.Date >= dataInicio.Date
                      && movimentacao.mv_dtCri.Date <= dataFinal.Date
                      && movimentacao.mv_movTipo == 150
                group produto by new { produto.mp_desc, produto.fk_tb_produto.pd_codRef } into grupoAtendente
                select new
                {
                    CodProduto = grupoAtendente.Key.pd_codRef,
                    Produto = grupoAtendente.Key.mp_desc,
                    SomaQuantidadeItens = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_qtdItens),
                    SomaValorTotalNF = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotNF),
                    SomaValorTotalProd = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotProd),
                    SomaValorTotalDesc = grupoAtendente.Sum(m => m.fk_tb_movimentacao.mv_nfeVlrTotDesc)
                };

            this.DataSource = queryMovimentacoesAtivas;

            lblCodRef.DataBindings.Clear();
            lblCodRef.DataBindings.Add("Text", null, "CodProduto");

            lblDescProd.DataBindings.Clear();
            lblDescProd.DataBindings.Add("Text", null, "Produto");

            lblQtdTotalProd.DataBindings.Clear();
            lblQtdTotalProd.DataBindings.Add("Text", null, "SomaQuantidadeItens");

            lblVlrTotalProd.DataBindings.Clear();
            lblVlrTotalProd.DataBindings.Add("Text", null, "SomaValorTotalProd");

            decimal total = 0;

            foreach (var item in queryMovimentacoesAtivas)
            {
                total += item.SomaValorTotalProd;
            }

            lblTotal.DataBindings.Clear();
            lblTotal.Text = total.ToString("C2");
        }

        private void PreencherCabecario()
        {
            var dadosFilial = VariaveisGlobais.FilialLogada;

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

        private void PreencherRodaPe(DateTime dataInicio, DateTime dataFina)
        {
            lblPeriodo.Text = $"{dataInicio.ToString("dd/MM/yyyy")} - {dataFina.ToString("dd/MM/yyyy")}";
            lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}