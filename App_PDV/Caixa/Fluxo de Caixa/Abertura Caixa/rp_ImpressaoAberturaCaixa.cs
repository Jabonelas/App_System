using System;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;

namespace App_PDV.AberturaCaixa
{
    public partial class rp_ImpressaoAberturaCaixa : DevExpress.XtraReports.UI.XtraReport
    {
        private tb_movimentacao caixaAberto;

        private long idCaixaAberto;

        public rp_ImpressaoAberturaCaixa(long _idCaixaAberto)

        {
            InitializeComponent();

            idCaixaAberto = _idCaixaAberto;

            PreencherCabecario();

            PegarDadosCaixaAberto();

            PreencherRodaPe();
        }

        private void PegarDadosCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //mv_movTipo = 1 é abertura de caixa e mv_cxAberto = 1 é caixa aberto

                    //caixaAberto = uow.Query<tb_movimentacao>().FirstOrDefault(x => x.mv_movTipo == 1 && x.mv_cxAberto == 1);

                    caixaAberto = uow.GetObjectByKey<tb_movimentacao>(idCaixaAberto);

                    lblAberturaResMov.Text = caixaAberto.mv_nfeVlrTotNF.ToString("C2");
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto impressao de abertura de caixa: {ex.Message}");
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
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher cabeçalho no relatório de abertura de caixa: {ex.Message}");
            }
        }

        private void PreencherRodaPe()
        {
            try
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    string dataAbertura = _jornada.jo_dtCri.ToString("dd/MM/yyyy");

                    lblPeriodo.Text = $"{dataAbertura} - {dataAbertura}";

                    lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Ocorreu um erro ao preencher as datas do rodapé na impressão do abertura de caixa: {exception}");
            }
        }
    }
}