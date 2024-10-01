using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using App_TelasCompartilhadas.bancoSQLite;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;
using App_TelasCompartilhadas.Classes;

namespace App_ERP
{
    public partial class frmEntradaXML : DevExpress.XtraEditors.XtraForm
    {
        public static long idProd = 0;
        private long idAtor = 0;

        private string cnpjFornecedor = "";
        private string nomeFornecedor = "";
        private string cnpjDestinatario = null;

        public static bool confirmarEntradaXML = false;

        public frmEntradaXML()
        {
            InitializeComponent();

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void buttonEdit2_Properties_ButtonPressed_1(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            // Usando XtraOpenFileDialog da DevExpress
            DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog = new DevExpress.XtraEditors.XtraOpenFileDialog();
            xtraOpenFileDialog.Filter = "Arquivos XML (*.xml)|*.xml";
            xtraOpenFileDialog.Title = "Selecione um arquivo XML";

            if (xtraOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string localArquivo = xtraOpenFileDialog.FileName;

                var doc = new XmlDocument();
                try
                {
                    doc.Load(localArquivo);

                    txtCaminhoArquivo.Text = localArquivo;
                }
                catch (Exception exception)
                {
                    MensagensDoSistema.MensagemErroOk($"Erro ao carregar o arquivo XML. Verifique se o arquivo está no formato correto: {exception}");

                    TelaCarregamento.EsconderCarregamento();

                    return;
                }

                dynamic des;

                try
                {
                    des = XMLUtility.Deserializar<NfeProc>(doc);
                }
                catch (Exception exception)
                {
                    MensagensDoSistema.MensagemErroOk($"Erro ao deserializar o XML. Verifique se o arquivo está no formato correto: {exception}");

                    TelaCarregamento.EsconderCarregamento();

                    return;
                }

                var nfeproc = des as NfeProc;

                #region Validações básicas

                var n = nfeproc?.NFe?.InfNFe[0];

                if (n == null)
                {
                    TelaCarregamento.EsconderCarregamento();

                    return;
                }

                if (doc.GetElementsByTagName("NFe").Count == 0) { return; }
                try
                {
                    if (Regex.Replace(n.Versao, "[^0-9]+", string.Empty) != "400")
                    {
                        MensagensDoSistema.MensagemAtencaoOk("Este XML não corresponde a uma versão 4.00 da Nota Fiscal Eletrônica (NFe).");

                        TelaCarregamento.EsconderCarregamento();

                        return;
                    }
                }
                catch { }

                if (n.Ide.TpAmb != TipoAmbiente.Producao)
                {
                    MensagensDoSistema.MensagemAtencaoOk("Este XML ainda não está sendo utilizado em ambiente de produção.");

                    TelaCarregamento.EsconderCarregamento();

                    return;
                }

                if (n.Ide.Mod != ModeloDFe.NFe)
                {
                    MensagensDoSistema.MensagemAtencaoOk("Este XML não corresponde a uma Nota Fiscal Eletrônica (NFe).");

                    TelaCarregamento.EsconderCarregamento();

                    return;
                }

                #endregion Validações básicas

                if (SxVerificarCadastroProduto(nfeproc))
                {
                    ImportarXml(nfeproc);

                    PreencherCampos(nfeproc);

                    long idMovimentacao = CadastrarMovimentacao(nfeproc);

                    PreencherTabelaComXml(nfeproc, idMovimentacao);

                    MensagensDoSistema.MensagemInformacaoOk("Sucesso: Operação realizada com sucesso.");
                }
                else
                {
                    LimparCampos();
                }
            }

            TelaCarregamento.EsconderCarregamento();
        }

        public void PreencherTabelaComXml(NfeProc nfeproc, long _idMovimentacao)
        {
            try
            {
                // Supondo que nfeproc é seu objeto deserializado da XML e tem a estrutura necessária
                var n = nfeproc?.NFe?.InfNFe[0];

                if (n != null)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        tb_movimentacao movimentacao = uow.GetObjectByKey<tb_movimentacao>(_idMovimentacao);

                        tb_nfe nfe = new tb_nfe(uow)
                        {
                            // Preenchendo os campos com os dados do XML
                            nf_nfeServico = Convert.ToInt32(n.Ide.TpAmb),
                            nf_dtCri = DateTime.Now,
                            nf_dtAlt = DateTime.Now,
                            nf_desat = 0,
                            nf_prontoEnviar = 0,
                            nf_nfeNatOp = n.Ide.NatOp,
                            nf_nfeTipoAmb = Convert.ToByte(n.Ide.TpAmb),
                            nf_nfeDtEmis = Convert.ToDateTime(n.Ide.DhEmi),
                            //nf_nfeDtAut = n.Ide.DtAut,
                            //nf_nfeCfop = Convert.ToInt32(n.Ide.CFOP),
                            //nf_nfeCst = Convert.ToInt32(n.Ide.CST),
                            //nf_nfeCsosn = Convert.ToInt32(n.Ide.CSOSN),
                            //nf_nfeNumProtAut = n.Ide.NumProtAut,
                            //nf_nfeUf = Convert.ToInt32(n.Ide.UF),
                            //nf_nfeCod = Convert.ToInt32(n.Ide.Cod),
                            //nf_nfeChave = n.Ide.Chave,
                            //nf_nfeVersao = Convert.ToDecimal(n.Ide.Versao),
                            nf_nfeMod = Convert.ToByte(n.Ide.Mod),
                            nf_nfeTipoEmis = Convert.ToByte(n.Ide.TpEmis),
                            //nf_nfeTipo = Convert.ToInt32(n.Ide.Tipo),
                            //nf_nfeSit = Convert.ToInt32(n.Ide.Situacao),
                            //nf_nfeIdentLocDestOp = Convert.ToInt32(n.Ide.IdentLocDestOp),
                            //nf_nfeCodMunFg = Convert.ToInt32(n.Ide.CodMunFg),
                            //nf_nfeTipoImpDanfe = Convert.ToInt32(n.Ide.TipoImpDanfe),
                            //nf_nfeChaveDv = int.TryParse(n.Ide.ChaveDv, out var chaveDv) ? chaveDv : (int?)null,
                            //nf_nfeTipoDfe = Convert.ToInt32(n.Ide.TipoDfe),
                            //nf_nfeFinEmis = Convert.ToInt32(n.Ide.FinEmis),
                            //nf_nfeIndOpConsumFin = Convert.ToInt32(n.Ide.IndOpConsumFin),
                            //nf_nfeIndPresCompEstMomOp = Convert.ToInt32(n.Ide.IndPresCompEstMomOp),
                            //nf_nfeXmlArqAutPath = n.Ide.XmlArqAutPath,
                            //nf_nfeXmlAutBkp = n.Ide.XmlAutBkp,
                            nf_nfeIndInterm = Convert.ToInt32(n.Ide.IndIntermed),
                            nf_nfeProcEmis = Convert.ToByte(n.Ide.ProcEmi),
                            //nf_nfeVerProcEmis = n.Ide.VerProcEmis,
                            //nf_nfeInfoCompl = n.Ide.InfoCompl,
                            //nf_nfeBcIcms = Convert.ToDecimal(n.Total.ICMSTot.BCICMS),
                            nf_nfeVlrTotIcms = Convert.ToDecimal(n.Total.ICMSTot.VICMS),
                            nf_nfeVlrIcmsDeson = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson),
                            //nf_nfeVlrTotIcmsFcp = Convert.ToDecimal(n.Total.ICMSTot.VICMSFCP),
                            //nf_nfeVlrTotIcmsInterUfDest = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFDEST),
                            //nf_nfeVlrTotIcmsInterUfRem = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFRM),
                            nf_nfeVlrTotFcp = Convert.ToDecimal(n.Total.ICMSTot.VFCP),
                            //nf_nfeVlrBcIcmsSt = Convert.ToDecimal(n.Total.ICMSTot.BCICMSST),
                            //nf_nfeVlrTotIcmsSt = Convert.ToDecimal(n.Total.ICMSTot.VICMSST),
                            nf_nfeVlrTotFcpSt = Convert.ToDecimal(n.Total.ICMSTot.VFCPST),
                            nf_nfeVlrTotFcpRetSt = Convert.ToDecimal(n.Total.ICMSTot.VFCPST),
                            nf_nfeVlrTotProd = Convert.ToDecimal(n.Total.ICMSTot.VProd),
                            //nf_vlrTotPag = Convert.ToDecimal(n.Total.ICMSTot.VPag),
                            nf_nfeVlrTotFrete = Convert.ToDecimal(n.Total.ICMSTot.VFrete),
                            nf_nfeVlrTotSeg = Convert.ToDecimal(n.Total.ICMSTot.VSeg),
                            nf_nfeVlrTotDesc = Convert.ToDecimal(n.Total.ICMSTot.VDesc),
                            //nf_nfeVlrTotImpImp = Convert.ToDecimal(n.Total.ICMSTot.VImpImp),
                            nf_nfeVlrTotIpi = Convert.ToDecimal(n.Total.ICMSTot.VIPI),
                            nf_nfeVlrTotIpiDevol = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol),
                            nf_nfeVlrTotPis = Convert.ToDecimal(n.Total.ICMSTot.VPIS),
                            nf_nfeVlrTotCofins = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS),
                            nf_nfeVlrTotOutro = Convert.ToDecimal(n.Total.ICMSTot.VOutro),
                            nf_nfeVlrTotNF = Convert.ToDecimal(n.Total.ICMSTot.VNF),
                            nf_nfeVlrTotTrib = Convert.ToDecimal(n.Total.ICMSTot.VTotTrib),
                            //nf_nfeModFrete = Convert.ToInt32(n.Ide.ModFrete),
                            //nf_nfeCstat = Convert.ToInt32(n.Ide.CSat),
                            //nf_nfeSerieProd = Convert.ToInt32(n.Ide.SerieProd),
                            //nf_nfeSerieHom = Convert.ToInt32(n.Ide.SerieHom),
                            //nf_nfeNumProd = Convert.ToInt32(n.Ide.NumProd),
                            //nf_nfeNumHom = Convert.ToInt32(n.Ide.NumHom),
                            //nf_nfeNum = Convert.ToInt32(n.Ide.Num),
                            //nf_nfeSerie = Convert.ToInt32(n.Ide.Serie),
                            //nf_nfeSolTransm = Convert.ToInt32(n.Ide.SolTransm),
                            //nf_nfeSolTransmDt = n.Ide.SolTransmDt,
                            //nf_nfeTransmStatus = Convert.ToInt32(n.Ide.TransmStatus),
                            //nf_nfeXmlAutErro = Convert.ToInt32(n.Ide.XmlAutErro),
                            //nf_nfeXmlCancErro = Convert.ToInt32(n.Ide.XmlCancErro),
                            //nf_nfeEnvSfz = Convert.ToInt32(n.Ide.EnvSfz),
                            //nf_nfeTransmCorrigir = n.Ide.TransmCorrigir,
                            //nf_nfeTransmLog = n.Ide.TransmLog,
                            //nf_nfeDhRecbto = n.Ide.DhRecbto,
                            //nf_nfeProcAutExHRes = Convert.ToInt32(n.Ide.ProcAutExHRes),
                            //nf_nfeProcAutExMsg = n.Ide.ProcAutExMsg,
                            //nf_nfeHaProtSfz = Convert.ToInt32(n.Ide.HaProtSfz),
                            //nf_nfeRejSfz = Convert.ToInt32(n.Ide.RejSfz),
                            //nf_nfeXmlEnv = n.Ide.XmlEnv,
                            //nf_nfeXmlCorrigir = n.Ide.XmlCorrigir,
                            //nf_nfeArqProcAutDist = n.Ide.ArqProcAutDist,
                            //nf_nfeCamArqProcAutDist = n.Ide.CamArqProcAutDist,
                            //nf_nfeNomeArqProcAutDist = n.Ide.NomeArqProcAutDist,
                            //nf_nfeXmlOrig = n.Ide.XmlOrig,
                            //nf_nfeXmlAss = n.Ide.XmlAss,
                            //nf_nfeXmlRetWs = n.Ide.XmlRetWs,
                            //nf_nfeXmlProcRes = n.Ide.XmlProcRes,
                            //nf_nfeXmlProcAutDist = n.Ide.XmlProcAutDist,
                            nf_nfeXmlEvtCancDist = "",
                            //nf_nfeXmlEvtCancDist = n.Ide.XmlEvtCancDist,
                            //nf_nfeTipoAmb_ImpXml = Convert.ToInt32(n.Ide.TipoAmb_ImpXml),
                            //nf_nfeDtEmis_ImpXml = n.Ide.DtEmis_ImpXml,
                            //nf_nfeDtAut_ImpXml = n.Ide.DtAut_ImpXml,
                            //nf_nfeCfop_ImpXml = Convert.ToInt32(n.Ide.Cfop_ImpXml),
                            //nf_nfeCst_ImpXml = Convert.ToInt32(n.Ide.Cst_ImpXml),
                            //nf_nfeCsosn_ImpXml = Convert.ToInt32(n.Ide.Csosn_ImpXml),
                            //nf_nfeNumProtAut_ImpXml = n.Ide.NumProtAut_ImpXml,
                            //nf_nfeUf_ImpXml = Convert.ToInt32(n.Ide.Uf_ImpXml),
                            //nf_nfeCod_ImpXml = Convert.ToInt32(n.Ide.Cod_ImpXml),
                            //nf_nfeChave_ImpXml = n.Ide.Chave_ImpXml,
                            //nf_nfeVersao_ImpXml = Convert.ToDecimal(n.Ide.Versao_ImpXml),
                            //nf_nfeMod_ImpXml = Convert.ToInt32(n.Ide.Mod_ImpXml),
                            //nf_nfeTipoEmis_ImpXml = Convert.ToInt32(n.Ide.TipoEmis_ImpXml),
                            //nf_nfeTipo_ImpXml = Convert.ToInt32(n.Ide.Tipo_ImpXml),
                            //nf_nfeSit_ImpXml = Convert.ToInt32(n.Ide.Sit_ImpXml),
                            //nf_nfeIdentLocDestOp_ImpXml = Convert.ToInt32(n.Ide.IdentLocDestOp_ImpXml),
                            //nf_nfeCodMunFg_ImpXml = Convert.ToInt32(n.Ide.CodMunFg_ImpXml),
                            //nf_nfeTipoImpDanfe_ImpXml = Convert.ToInt32(n.Ide.TipoImpDanfe_ImpXml),
                            //nf_nfeChaveDv_ImpXml = int.TryParse(n.Ide.ChaveDv_ImpXml, out var chaveDv) ? chaveDv : (int?)null,
                            //nf_nfeTipoDfe_ImpXml = Convert.ToInt32(n.Ide.TipoDfe_ImpXml),
                            //nf_nfeFinEmis_ImpXml = Convert.ToInt32(n.Ide.FinEmis_ImpXml),
                            //nf_nfeIndOpConsumFin_ImpXml = Convert.ToInt32(n.Ide.IndOpConsumFin),
                            //nf_nfeIndPresCompEstMomOp_ImpXml = Convert.ToInt32(n.Ide.IndPresCompEstMomOp),
                            //nf_nfeXmlArqAutPath_ImpXml = n.Ide.XmlArqAutPath,
                            //nf_nfeXmlAutBkp_ImpXml = n.Ide.XmlAutBkp,
                            //nf_nfeIndInterm_ImpXml = Convert.ToInt32(n.Ide.IndInterm),
                            //nf_nfeProcEmis_ImpXml = Convert.ToInt32(n.Ide.ProcEmis),
                            //nf_nfeVerProcEmis_ImpXml = n.Ide.VerProcEmis,
                            //nf_nfeInfoCompl_ImpXml = n.Ide.InfoCompl,
                            //nf_nfeBcIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.BCICMS),
                            nf_nfeVlrTotIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMS),
                            nf_nfeVlrIcmsDeson_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson),
                            //nf_nfeVlrTotIcmsFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSFCP),
                            //nf_nfeVlrTotIcmsInterUfDest_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFDEST),
                            //nf_nfeVlrTotIcmsInterUfRem_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFRM),
                            nf_nfeVlrTotFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCP),
                            //nf_nfeVlrBcIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.BCICMSST),
                            //nf_nfeVlrTotIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSST),
                            nf_nfeVlrTotFcpSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPST),
                            nf_nfeVlrTotFcpRetSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPST),
                            nf_nfeVlrTotProd_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VProd),
                            //nf_vlrTotPag_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VPag),
                            nf_nfeVlrTotFrete_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFrete),
                            nf_nfeVlrTotSeg_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VSeg),
                            nf_nfeVlrTotDesc_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VDesc),
                            //nf_nfeVlrTotImpImp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VImpImp),
                            nf_nfeVlrTotIpi_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPI),
                            nf_nfeVlrTotIpiDevol_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol),
                            nf_nfeVlrTotPis_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VPIS),
                            nf_nfeVlrTotCofins_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS),
                            nf_nfeVlrTotOutro_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VOutro),
                            nf_nfeVlrTotNF_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VNF),
                            nf_nfeVlrTotTrib_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VTotTrib),
                            //nf_nfeModFrete_ImpXml = Convert.ToInt32(n.Ide.ModFrete),
                            //nf_nfeCstat_ImpXml = Convert.ToInt32(n.Ide.CStat),
                            //nf_nfeSerieProd_ImpXml = Convert.ToInt32(n.Ide.SerieProd),
                            //nf_nfeSerieHom_ImpXml = Convert.ToInt32(n.Ide.SerieHom),
                            //nf_nfeNumProd_ImpXml = Convert.ToInt32(n.Ide.NumProd),
                            //nf_nfeNumHom_ImpXml = Convert.ToInt32(n.Ide.NumHom),
                            //nf_nfeNum_ImpXml = Convert.ToInt32(n.Ide.Num),
                            //nf_nfeSerie_ImpXml = Convert.ToInt32(n.Ide.Serie),
                            //nf_nfeSolTransm_ImpXml = Convert.ToInt32(n.Ide.SolTransm),
                            //nf_nfeSolTransmDt_ImpXml = n.Ide.SolTransmDt,
                            //nf_nfeTransmStatus_ImpXml = Convert.ToInt32(n.Ide.TransmStatus),
                            //nf_nfeXmlAutErro_ImpXml = Convert.ToInt32(n.Ide.XmlAutErro),
                            //nf_nfeXmlCancErro_ImpXml = Convert.ToInt32(n.Ide.XmlCancErro),
                            //nf_nfeEnvSfz_ImpXml = Convert.ToInt32(n.Ide.EnvSfz),
                            //nf_nfeTransmCorrigir_ImpXml = n.Ide.TransmCorrigir,
                            //nf_nfeTransmLog_ImpXml = n.Ide.TransmLog,
                            //nf_nfeDhRecbto_ImpXml = n.Ide.DhRecbto,
                            //nf_nfeProcAutExHRes_ImpXml = Convert.ToInt32(n.Ide.ProcAutExHRes),
                            //nf_nfeProcAutExMsg_ImpXml = n.Ide.ProcAutExMsg,
                            //nf_nfeHaProtSfz_ImpXml = Convert.ToInt32(n.Ide.HaProtSfz),
                            //nf_nfeRejSfz_ImpXml = Convert.ToInt32(n.Ide.RejSfz),
                            //nf_nfeXmlEnv_ImpXml = n.Ide.XmlEnv,
                            //nf_nfeXmlCorrigir_ImpXml = n.Ide.XmlCorrigir,
                            //nf_nfeArqProcAutDist_ImpXml = n.Ide.ArqProcAutDist,
                            //nf_nfeCamArqProcAutDist_ImpXml = n.Ide.CamArqProcAutDist,
                            //nf_nfeNomeArqProcAutDist_ImpXml = n.Ide.NomeArqProcAutDist,
                            //nf_nfeXmlOrig_ImpXml = n.Ide.XmlOrig,
                            //nf_nfeXmlAss_ImpXml = n.Ide.XmlAss,
                            //nf_nfeXmlRetWs_ImpXml = n.Ide.XmlRetWs,
                            //nf_nfeXmlProcRes_ImpXml = n.Ide.XmlProcRes,
                            //nf_nfeXmlProcAutDist_ImpXml = n.Ide.XmlProcAutDist,
                            nf_nfeXmlEvtCancDist_ImpXml = "",
                            //nf_nfeXmlEvtCancDist_ImpXml = n.Ide.XmlEvtCancDist,
                            //nf_nfeVlrTroco_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VTroco),
                            //nf_nfe1DhRecbto = n.Ide.DhRecbto,
                            //nf_nfe1CStat = Convert.ToInt32(n.Ide.CStat),
                            //nf_nfe1XMotivo = n.Ide.XMotivo,
                            //nf_nfe1RetornoWSString = n.Ide.RetornoWSString,
                            //nf_nfe1WSXMLInnerText = n.Ide.WSXMLInnerText,
                            //nf_nfe1ConteudoXMLOriginalOuterXml = n.Ide.ConteudoXMLOriginalOuterXml,
                            //nf_nfe1ResProtNFeInfProt0CStat = Convert.ToInt32(n.Ide.ResProtNFeInfProt0CStat),
                            //nf_nfe1ResProtNFeInfProt0ChNFe = n.Ide.ResProtNFeInfProt0ChNFe,
                            nf_nfe1ResProtNFeInfProt0ChNFe = n.Id.Replace("NFe", ""),
                            //nf_nfe1ResProtNFeInfProt0XMotivo = n.Ide.ResProtNFeInfProt0XMotivo,
                            //nf_nfe1ResProtNFeInfProt0NProt = n.Ide.ResProtNFeInfProt0NProt,
                            //nf_nfe1ResProtNFeInfProt0DhRecbto = n.Ide.ResProtNFeInfProt0DhRecbto,
                            //nf_nfe2ConteudoXMLOuterXml = n.Ide.ConteudoXMLOuterXml,
                            //nf_nfe2RetornoWSString = n.Ide.RetornoWSString,
                            //nf_nfe2RetornoWSXMLInnerText = n.Ide.RetornoWSXMLInnerText,
                            //nf_nfe2ResCStat = Convert.ToInt32(n.Ide.ResCStat),
                            //nf_nfe2ResDhRecbto = n.Ide.ResDhRecbto,
                            //nf_nfe2Renf_nRec = n.Ide.Renf_nRec,
                            //nf_nfe2ResProtNFeInfProt0CStat = Convert.ToInt32(n.Ide.ResProtNFeInfProt0CStat),
                            //nf_nfe2ResProtNFeInfProt0ChNFe = n.Ide.ResProtNFeInfProt0ChNFe,
                            //nf_nfe2ResProtNFeInfProt0XMotivo = n.Ide.ResProtNFeInfProt0XMotivo,
                            //nf_nfe2ResProtNFeInfProt0DhRecbto = n.Ide.ResProtNFeInfProt0DhRecbto,
                            //nf_nfeProcResultsXMLDist = n.Ide.ProcResultsXMLDist,
                            //nf_nfeProdNumPulo = Convert.ToInt32(n.Prod.NumPulo),

                            fk_tb_movimentacao = movimentacao // Supondo que `FkTbMovimentacao` seja a chave estrangeira
                        };

                        nfe.Save();
                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar Nfe na entrada de XML: {ex.Message}");
            }
        }

        private long CadastrarMovimentacao(NfeProc nfeproc)
        {
            try
            {
                var n = nfeproc?.NFe?.InfNFe[0];  // Acessando a primeira nota fiscal no XML

                if (n != null)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        tb_ator emissor = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cnpj == n.Emit.CNPJ);

                        tb_ator destinatario = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cnpj == n.Dest.CNPJ);

                        var movimentacao = new tb_movimentacao(uow)
                        {
                            mv_nfeTipoAmb = Convert.ToByte(n.Ide.TpAmb), // Tipo de ambiente

                            mv_dtCri = DateTime.Now, // Data de criação da movimentação (agora)
                            mv_dtAlt = DateTime.Now, // Data de alteração (agora)
                            mv_dtAcs = DateTime.Now, // Data de acesso (agora)
                            mv_qtdItens = n.Det.Count, // Quantidade de itens na NFe
                            mv_numSeq = Convert.ToInt32(n.Ide.CNF), // Número sequencial da NFe
                            mv_canc = 0, // Exemplo, cancelado (0 - não cancelado)
                            mv_conc = 0, // Exemplo, concluído (0 - não concluído)
                            mv_quit = 0, // Exemplo, quitado (0 - não quitado)
                            mv_movTipo = Convert.ToByte(n.Ide.Mod), // Tipo de movimentação, baseado no modelo da NFe
                            mv_codSeqAbertFechCx = 0, // Exemplo: código da sequência de abertura/fechamento de caixa
                            mv_movAbertCx = 0, // Exemplo: identificação da abertura de caixa
                            mv_cxAberto = 0, // Caixa aberto (0 - fechado)
                            mv_nfeEnfilGer = Convert.ToInt32(n.Ide.FinNFe), // Finalidade de emissão da NFe
                            mv_nfeNatOp = n.Ide.NatOp, // Natureza da operação
                            mv_nfeVlrTotProd = Convert.ToDecimal(n.Total.ICMSTot.VProd), // Valor total dos produtos
                            mv_nfeVlrTotNF = Convert.ToDecimal(n.Total.ICMSTot.VNF), // Valor total da NFe
                            mv_nfeVlrTotDesc = Convert.ToDecimal(n.Total.ICMSTot.VDesc), // Valor total de descontos
                            mv_nfeVlrIcmsDeson = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson), // Valor total de ICMS desonerado
                            mv_nfeVlrTotIcmsSt = Convert.ToDecimal(n.Total.ICMSTot.VST), // Valor total de ICMS ST
                            mv_nfeVlrTotFcpRetSt = Convert.ToDecimal(n.Total.ICMSTot.VFCP), // Valor total do FCP retido por substituição tributária
                            mv_nfeVlrTotFrete = Convert.ToDecimal(n.Total.ICMSTot.VFrete), // Valor total do frete
                            mv_nfeVlrTotSeg = Convert.ToDecimal(n.Total.ICMSTot.VSeg), // Valor total do seguro
                            mv_nfeVlrTotOutro = Convert.ToDecimal(n.Total.ICMSTot.VOutro), // Valor total de outras despesas
                            mv_nfeVlrTotImpImp = Convert.ToDecimal(n.Total.ICMSTot.VII), // Valor total do imposto de importação
                            mv_nfeVlrTotIpi = Convert.ToDecimal(n.Total.ICMSTot.VIPI), // Valor total de IPI
                            mv_nfeVlrTotIpiDevol = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol), // Valor total do IPI devolvido
                            mv_nfeVlrTroco = 0, // Exemplo: Valor do troco
                            mv_nfeBcIcms = Convert.ToDecimal(n.Total.ICMSTot.VBC), // Base de cálculo do ICMS
                            mv_nfeVlrBcIcmsSt = Convert.ToDecimal(n.Total.ICMSTot.VBCST), // Base de cálculo do ICMS ST
                            mv_nfeVlrTotTrib = Convert.ToDecimal(n.Total.ICMSTot.VTotTrib), // Valor total dos tributos
                            //mv_nfeChave = n.InfProt.chNFe, // Chave de acesso da NFe
                            mv_nfeVlrTotCofins = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS), // Valor total do COFINS
                            mv_nfeVlrTotFcp = Convert.ToDecimal(n.Total.ICMSTot.VFCP), // Valor total do FCP
                            mv_nfeVlrTotFcpSt = Convert.ToDecimal(n.Total.ICMSTot.VFCPST), // Valor total do FCP ST
                            mv_nfeVlrTotIcms = Convert.ToDecimal(n.Total.ICMSTot.VICMS), // Valor total do ICMS
                            mv_nfeVlrTotPis = Convert.ToDecimal(n.Total.ICMSTot.VPIS), // Valor total do PIS
                            mv_nfeIdentLocDestOp = Convert.ToByte(n.Ide.IdDest), // Identificador de localização do destinatário
                            mv_nfeMod = Convert.ToByte(n.Ide.Mod), // Modelo da NFe
                            mv_nfeIndOpConsumFin = Convert.ToByte(n.Ide.IndFinal), // Indicador de operação com consumidor final
                            mv_nfeFinEmis = Convert.ToByte(n.Ide.FinNFe), // Finalidade de emissão da NFe
                            mv_nfeIndInterm = Convert.ToInt32(n.Ide.IndIntermed), // Indicador de intermediador
                            mv_nfeIndPresCompEstMomOp = Convert.ToByte(n.Ide.IndPres), // Indicador de presença do comprador no estabelecimento
                            mv_nfeTipo = Convert.ToByte(n.Ide.TpNF), // Tipo da NFe (entrada ou saída)
                            mv_nfeTipoImpDanfe = Convert.ToByte(n.Ide.TpImp), // Tipo de impressão do DANFE
                            mv_nfeCfop = n.Det[0].Prod.CFOP, // CFOP do primeiro item
                            mv_nfeProcEmis = Convert.ToByte(n.Ide.ProcEmi), // Processo de emissão
                            mv_nfeVerProcEmis = n.Ide.VerProc, // Versão do processo de emissão
                            mv_nfeModFrete = Convert.ToByte(n.Transp.ModFrete), // Modalidade do frete
                            mv_nfeDtEmis = Convert.ToDateTime(n.Ide.DhEmi), // Data de emissão da NFe
                            mv_nfeTipoEmis = Convert.ToByte(n.Ide.TpEmis), // Tipo de emissão
                            mv_nfeTipoDfe = Convert.ToByte(n.Ide.TpNF), // Tipo de documento fiscal eletrônico
                            //mv_nfeXmlProcRes = n.infProt.digVal, // XML do processamento da resposta da NFe
                            mv_vlrTotPag = Convert.ToDecimal(n.Pag.DetPag[0].VPag), // Valor total de pagamentos
                            mv_cpf_tmp = n.Emit.CPF, // CPF temporário, caso aplicável
                            fk_tb_clasCont2 = null, // Relacionamento com outra tabela (definir conforme necessário)
                            fk_tb_jornada = null, // Relacionamento com outra tabela (definir conforme necessário)
                            fk_tb_ator_atend = VariaveisGlobais.UsuarioLogado, // Relacionamento com outra tabela (definir conforme necessário)
                            fk_tb_ator_emit = emissor, // Relacionamento com outra tabela (definir conforme necessário)
                            fk_tb_ator_dest = destinatario, // Relacionamento com outra tabela (definir conforme necessário)
                        };

                        movimentacao.Save();
                        uow.CommitChanges();

                        return movimentacao.id_movimentacao;
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar movimentação na entrada de XML: {ex.Message}");
            }

            return 0;
        }

        private static string FormatarCnpj(string cnpj)
        {
            // Formatação do CNPJ: XX.XXX.XXX/XXXX-XX
            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12)}";
        }

        private tb_ator BuscarCadastroFilial(string _cnpjDestinatario)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator cadastroFilial = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cnpj == _cnpjDestinatario);

                    return cadastroFilial;
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar cadastro filial: {exception}");

                return null;
            }
        }

        private tb_matriz BuscarCadastroMAtriz(string _cnpjDestinatario)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //Verificar se o CNPJ do destinatário está cadastrado como Matriz
                    tb_matriz cadastroMatriz = uow.Query<tb_matriz>().FirstOrDefault(x => x.mt_cnpj == _cnpjDestinatario);

                    return cadastroMatriz;
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar cadastro da matriz: {exception}");

                return null;
            }
        }

        private tb_relacao_produto_cadastro_XML buscaRelacaoProdutoCadastroXml(long _idAtor, string _descricaoProduto, long _codigoProduto, string _cnpjFornecedor)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator cadastro = uow.GetObjectByKey<tb_ator>(_idAtor);

                    tb_relacao_produto_cadastro_XML relacaoProdutoCadastroXml = uow.Query<tb_relacao_produto_cadastro_XML>()
                        .FirstOrDefault(x => x.rpc_desc == _descricaoProduto
                                             && x.rpc_codRef == _codigoProduto
                                             && x.rpc_cnpj_fornecedor == _cnpjFornecedor
                                             && x.fk_tb_ator == cadastro);

                    return relacaoProdutoCadastroXml;
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar cadastro de produto na relação da XML: {exception}");

                return null;
            }
        }

        private bool IsNfeExiste(NfeProc nfeproc)
        {
            try
            {
                var n = nfeproc?.NFe?.InfNFe[0];

                string numeroNfe = n.Id.Replace("NFe", "");

                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isCadastroExiste = uow.Query<tb_nfe>().Any(x => x.nf_nfe1ResProtNFeInfProt0ChNFe == numeroNfe);

                    return isCadastroExiste;
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar Nfe para verificar existencia de cadastro: {exception}");

                return false;
            }
        }

        private bool SxVerificarCadastroProduto(NfeProc nfeproc)
        {
            var n = nfeproc?.NFe?.InfNFe[0];

            cnpjFornecedor = FormatarCnpj(n.Emit.CNPJ);
            nomeFornecedor = n.Emit.XNome;

            //Verificar se a XML possui campo de destinatario
            if (n != null && n.Dest != null && n.Dest.CNPJ != null)
            {
                cnpjDestinatario = FormatarCnpj(n.Dest.CNPJ);
            }

            if (cnpjDestinatario == null)
            {
                MensagensDoSistema.MensagemAtencaoOk("Atenção, XML fornecida não contém informações sobre o destinatário.");

                return false;
            }

            tb_ator cadastroFilial = BuscarCadastroFilial(cnpjDestinatario);

            tb_matriz cadastroMatriz = null;

            //Verificar se o CNPJ do destinatário está cadastrado como filial
            if (cadastroFilial != null)
            {
                idAtor = cadastroFilial.id_ator;
            }
            else
            {
                cadastroMatriz = BuscarCadastroMAtriz(cnpjDestinatario);

                if (cadastroMatriz == null)
                {
                    // Se o destinatário não estiver cadastrado, exibir um aviso e interromper o processamento
                    MensagensDoSistema.MensagemAtencaoOk("Destinatário não cadastrado.");

                    return false;
                }
            }

            if (IsNfeExiste(nfeproc))
            {
                MensagensDoSistema.MensagemAtencaoOk("NF-e já cadastrada.");

                return false;
            }

            //Faz a primeira verificação da existência de itens que não possuem cadastro com relação
            foreach (var item in n.Det)
            {
                string descricaoProduto = item.Prod.XProd;
                string codigoProduto = item.Prod.CProd;

                tb_relacao_produto_cadastro_XML relacaoProdutoCadastroXml = buscaRelacaoProdutoCadastroXml(idAtor, descricaoProduto, Convert.ToInt64(codigoProduto), cnpjFornecedor);

                if (relacaoProdutoCadastroXml == null)
                {
                    bool isDadosPreenchidos = false;

                    while (isDadosPreenchidos == false)
                    {
                        frmRelacionarProdEntradaXML _frmRelacionarProdEntradaXML = new frmRelacionarProdEntradaXML(FormatarCnpj(cnpjFornecedor), nomeFornecedor, codigoProduto, descricaoProduto);
                        _frmRelacionarProdEntradaXML.ShowDialog();

                        if (confirmarEntradaXML == true)
                        {
                            if (frmRelacionarProdEntradaXML.isProdutoSelecionado == true)
                            {
                                CadastrarProdutoRelacaoXML(cnpjDestinatario, descricaoProduto, codigoProduto, cnpjFornecedor);

                                isDadosPreenchidos = true;
                            }
                            else
                            {
                                MensagensDoSistema.MensagemAtencaoOk("Por favor, selecione um produto.");
                            }
                        }
                        else
                        {
                            return false;

                            isDadosPreenchidos = true;
                        }
                    }
                }
            }

            return true;
        }

        private void CadastrarProdutoRelacaoXML(string _cnpjDestinatario, string _descricaoProduto, string _codigoProduto, string _cnpjFornecedor)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                tb_produto produtoCadastrado = uow.GetObjectByKey<tb_produto>(idProd);

                tb_produto_filial produtoCadastradoSProFil = uow.Query<tb_produto_filial>().FirstOrDefault(x => x.fk_tb_produto.id_produto == produtoCadastrado.id_produto);

                tb_ator cadastroFilial = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cnpj == _cnpjDestinatario);

                tb_relacao_produto_cadastro_XML produtoRelacaoXML = new tb_relacao_produto_cadastro_XML(uow);

                produtoRelacaoXML.rpc_desc = _descricaoProduto;
                produtoRelacaoXML.rpc_codRef = Convert.ToInt64(_codigoProduto);
                produtoRelacaoXML.rpc_dtCri = DateTime.Now;
                produtoRelacaoXML.rpc_dtAlt = DateTime.Now;
                produtoRelacaoXML.rpc_cnpj_fornecedor = _cnpjFornecedor;
                produtoRelacaoXML.fk_tb_produto = produtoCadastrado;
                produtoRelacaoXML.fk_tb_produto_filial = produtoCadastradoSProFil;
                produtoRelacaoXML.fk_tb_ator = cadastroFilial;

                uow.Save(produtoRelacaoXML);
                uow.CommitChanges();
            }
        }

        public void ImportarXml(NfeProc nfeproc)
        {
            bool isDadosPreenchidos = false;

            while (isDadosPreenchidos == false)
            {
                var dadosNFe = nfeproc.NFe?.InfNFe[0];

                if (!string.IsNullOrEmpty(dadosNFe.ToString()))
                {
                    isDadosPreenchidos = true;

                    List<ConteudoXML> listaConteudoXML = new List<ConteudoXML>();

                    //Faz a segunda verificação da existência de itens que não possuem cadastro com relação
                    foreach (var item in dadosNFe.Det)
                    {
                        string descricaoProduto = item.Prod.XProd;
                        long codigoProduto = Convert.ToInt64(item.Prod.CProd);
                        string cnpjFornecedor = FormatarCnpj(dadosNFe.Emit.CNPJ);

                        tb_relacao_produto_cadastro_XML cadastroProduto = buscaRelacaoProdutoCadastroXml(idAtor, descricaoProduto, codigoProduto, cnpjFornecedor);

                        if (cadastroProduto == null)
                        {
                            MensagensDoSistema.MensagemAtencaoOk("Atenção: Produtos Não Relacionados Foram Identificados.");

                            isDadosPreenchidos = true;

                            break;
                        }
                        else
                        {
                            listaConteudoXML.Add(new ConteudoXML
                            {
                                descricaoProduto = descricaoProduto,
                                codigoProduto = codigoProduto,
                                cnpjFornecedor = cnpjFornecedor,
                                quantidade = item.Prod.QCom,
                                idProd = cadastroProduto.fk_tb_produto == null ? 0 : cadastroProduto.fk_tb_produto.id_produto,
                                idProdFil = cadastroProduto.fk_tb_produto_filial == null ? 0 : cadastroProduto.fk_tb_produto_filial.id_produto_filial,
                                idAtor = cadastroProduto.fk_tb_ator == null ? 0 : cadastroProduto.fk_tb_ator.id_ator,
                            });
                        }
                    }

                    //Altera a quantidade do estoque nas tabelas tb_produto e tb_produto_filial
                    if (isDadosPreenchidos == true)
                    {
                        string cnpjDest = FormatarCnpj(dadosNFe.Dest.CNPJ);

                        InserirQuantidadeEstoque(cnpjDest, listaConteudoXML);
                    }
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Por favor, selecione o arquivo XML da Nota Fiscal Eletrônica (NF-e).");

                    isDadosPreenchidos = false;
                }
            }
        }

        private void InserirQuantidadeEstoque(string _cnpjDest, List<ConteudoXML> _listaConteudoXML)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator cadastroDestinatario = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cnpj == _cnpjDest);

                    long idAtor = 0;

                    if (cadastroDestinatario != null)
                    {
                        idAtor = cadastroDestinatario.id_ator;
                    }

                    foreach (var item in _listaConteudoXML)
                    {
                        decimal quantidade = item.quantidade;
                        long oidSPro = item.idProd;
                        long oidSProFil = item.idProdFil;

                        tb_produto_filial produtoCadastradoSProFil = uow.Query<tb_produto_filial>().FirstOrDefault(x => x.id_produto_filial == oidSProFil && x.fk_tb_ator.id_ator == idAtor);

                        if (produtoCadastradoSProFil != null)
                        {
                            produtoCadastradoSProFil.pf_est += quantidade;
                        }

                        tb_produto produtoCadastradoSPro = uow.Query<tb_produto>().FirstOrDefault(x => x.id_produto == oidSPro);

                        if (produtoCadastradoSPro != null)
                        {
                            produtoCadastradoSPro.pd_estTot += quantidade;
                        }

                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao inserir quantidades no estoque total e no estoque das filiais: {exception}");
            }
        }

        public struct ConteudoXML
        {
            public string descricaoProduto;
            public long codigoProduto;
            public string cnpjFornecedor;
            public long idProd;
            public long idProdFil;
            public long idAtor;
            public decimal quantidade;

            public ConteudoXML(string _descricaoProduto, long _codigoProduto, string _cnpjFornecedor, decimal _quantidade, long _idProd, long _idProdFil, long _idAtor)
            {
                descricaoProduto = _descricaoProduto;
                codigoProduto = _codigoProduto;
                cnpjFornecedor = _cnpjFornecedor;
                quantidade = _quantidade;
                idProd = _idProd;
                idProdFil = _idProdFil;
                idAtor = _idAtor;
            }
        }

        private void frmEntradaXML_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void LimparCampos()
        {
            txtNomeEmitente.Text = "";
            txtCNPJEmitente.Text = "";
            txtUF.Text = "";
            txtNomeDestinatario.Text = "";
            txtCNPJDestinatario.Text = "";
            txtNaturezaOperacao.Text = "";
            txtNumeroNota.Text = "";
            txtTipoNota.Text = "";
            txtModeloNota.Text = "";
            txtSerieNota.Text = "";
            txtDataEmissao.Text = "";
            txtDataEntrada.Text = "";
            txtValorTotal.Text = "";
            txtInfoCompl.Text = "";
        }

        private void PreencherCampos(NfeProc nfeproc)
        {
            var n = nfeproc?.NFe?.InfNFe[0];

            //preencher os campos
            txtNomeEmitente.Text = n.Emit.XNome;
            txtCNPJEmitente.Text = FormatarCnpj(n.Emit.CNPJ);
            txtNumNfe.Text = n.Id.Replace("NFe", "");
            txtUF.Text = n.Emit.EnderEmit.UF.ToString();
            txtNomeDestinatario.Text = n.Dest.XNome;
            txtCNPJDestinatario.Text = FormatarCnpj(n.Dest.CNPJ);
            txtNaturezaOperacao.Text = n.Ide.NatOp;
            txtNumeroNota.Text = n.Ide.NNF.ToString();
            txtTipoNota.Text = $"{n.Ide.TpNF}";
            txtModeloNota.Text = $"{n.Ide.Mod}";
            txtSerieNota.Text = n.Ide.Serie.ToString();
            txtDataEmissao.Text = n.Ide.DhEmi.ToString();
            txtDataEntrada.Text = DateTime.Now.ToString();
            txtValorTotal.Text = n.Total.ICMSTot.VNF.ToString("c2");
            txtInfoCompl.Text = n.InfAdic?.InfCpl;
        }
    }
}