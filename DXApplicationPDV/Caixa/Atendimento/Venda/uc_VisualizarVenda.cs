using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DXApplicationPDV.bancoSQLite;
using DXApplicationPDV.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.NFe;
using static DXApplicationPDV.Classes.DadosGeralNfe;
using static DXApplicationPDV.frmPagamentoPDV;
using static DXApplicationPDV.uc_PDV;
using DANFe = Unimake.Unidanfe;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;

using XmlNFe = Unimake.Business.DFe.Xml.NFe;
using Unimake.Business.DFe.Servicos;

using Unimake.Business.DFe.Servicos.NFe;

using Unimake.Business.DFe.Xml.NFe;

using Unimake.Business.DFe.Xml.GNRE;
using System.Net.Mail;

using System;

using System.IO;

using System.Net;

namespace DXApplicationPDV
{
    public partial class uc_VisualizarVenda : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicial _frmTelaInicial;

        private tb_movimentacao movimentacao;
        private tb_ator dadosEmitente;
        private tb_pdv dadosPDV;

        private List<long> idMovimentacaoProdutos = new List<long>();
        private List<long> idMovimentoPagamento = new List<long>();

        private int idMovimentacaoSelecionado = 0;
        private int numeroNota = 0;
        private int serie = 0;

        public uc_VisualizarVenda(frmTelaInicial _form, int _idMovimentacao)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            idMovimentacaoSelecionado = _idMovimentacao;

            PreencherDadosMovimentacao();

            CarregarGridProdutosVendaRealizada();

            dadosEmitente = VariaveisGlobais.FilialLogada;
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoImprimir(btnImprimirCupomFiscal);
            configBotoes.BotaoEnviarEmail(btnEnvioEmail);

            uc_TituloTelas1.lblTituloTela.Text = "Visualizar Venda";
            
        }

        private void CarregarGridProdutosVendaRealizada()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mp_numItem ASC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosMovimentacaoCadastradosAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdListaProdutosVendidos.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMovimentacaoCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryVendasRealizadas =
                    from movimentacaoProduto in session.Query<tb_movimentacao_produto>()
                    join produto in session.Query<tb_produto>()
                        on movimentacaoProduto.fk_tb_produto.id_produto equals produto.id_produto
                    join marca in session.Query<tb_marca_produto>()
                        on produto.fk_tb_marca_produto.id_marca_produto equals marca.id_marca_produto
                    where movimentacaoProduto.fk_tb_movimentacao.id_movimentacao == idMovimentacaoSelecionado
                    orderby movimentacaoProduto.mp_numItem ascending
                    select new
                    {
                        produto.id_produto,
                        produto.pd_codRef,
                        produto.pd_descCurta,
                        produto.pd_desc,
                        marca.mp_desc,
                        movimentacaoProduto.mp_qtdCom,
                        produto.pd_vlrUnComBase,
                        movimentacaoProduto.mp_vlrProdTot,
                        movimentacaoProduto.mp_vlrDesc,
                        movimentacaoProduto.mp_numItem
                    };

                e.QueryableSource = queryVendasRealizadas;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com produto que foram vendidos: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void PreencherDadosMovimentacao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(idMovimentacaoSelecionado));

                    txtQuantlProduto.Text = _movimentacao.mv_qtdItens.ToString();
                    txtTotalDesconto.Text = _movimentacao.mv_nfeVlrTotDesc.ToString("C2");
                    txtTroco.Text = _movimentacao.mv_nfeVlrTroco.ToString("C2");
                    txtValorPago.Text = _movimentacao.mv_vlrTotPag.ToString("C2");
                    txtTotalProduto.Text = _movimentacao.mv_nfeVlrTotProd.ToString("C2");
                    lblTotalGeral.Text = (_movimentacao.mv_nfeVlrTotProd - _movimentacao.mv_nfeVlrTotDesc).ToString("C2");

                    if (_movimentacao.fk_tb_ator_dest != null)
                    {
                        tb_ator dadosCleinte = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(_movimentacao.fk_tb_ator_dest.id_ator));

                        txtCPFCliente.Text = dadosCleinte.at_cpf;
                        txtNomeCliente.Text = dadosCleinte.at_razSoc;
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar dados da movimentao para preenchimentos dos campos: {ex.Message}");
            }
        }

        private void SxDanfe(string SNfeXmlProcRes)
        {
            bool visualizar = false;

            var config = new DANFe.Configurations.UnidanfeConfiguration
            {
                Arquivo = SNfeXmlProcRes,
                Visualizar = !visualizar,
                Imprimir = visualizar,
                EnviaEmail = false,
                Configuracao = "PAISAGEM",
                AnexarDFe = true
                //Impressora = nomeImpressora,
                //Copias = 1,
            };

            DANFe.UnidanfeServices.Execute(config);
        }

        private void PegarNumeroNota()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    dadosPDV = uow.Query<tb_pdv>().FirstOrDefault(x => x.id_pdv == VariaveisGlobais.PDVLogado.id_pdv);

                    if (VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1)
                    {
                        numeroNota = Convert.ToInt32(++dadosPDV.pdv_nfeProdNum);

                        dadosPDV.pdv_nfeProdNum = numeroNota;
                        serie = dadosPDV.pdv_nfeProdSerie;
                    }
                    else
                    {
                        numeroNota = Convert.ToInt32(++dadosPDV.pdv_nfeHomNum);
                        dadosPDV.pdv_nfeHomNum = numeroNota;

                        serie = dadosPDV.pdv_nfeHomSerie;
                    }

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao pegar os dados do PDV." + ex.Message);
            }
        }

        public X509Certificate2 CarregarCertificaDigitaldoDoBanco()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_certificado_digital teste = uow.Query<tb_certificado_digital>()
                        .FirstOrDefault(x => x.cd_cnpj == Regex.Replace(dadosEmitente.at_cnpj, @"[^\d]", ""));

                    // Recuperar os dados do certificado
                    byte[] rawData = (byte[])teste.cd_rawData;
                    string senha = teste.cd_pwd.ToString();

                    return new X509Certificate2(rawData, senha, X509KeyStorageFlags.MachineKeySet);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao carregar o certificado digital." + ex.Message);

                return null;
            }
        }

        private bool IsSefazEstavel()
        {
            try
            {
                var xml = new ConsStatServ
                {
                    Versao = "4.00",
                    CUF = UFBrasil.SP,
                    TpAmb = VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
                };

                var CertificadoSelecionado = CarregarCertificaDigitaldoDoBanco();

                var configuracao = new Configuracao
                {
                    TipoDFe = TipoDFe.NFe,
                    TipoEmissao = TipoEmissao.Normal,
                    CertificadoDigital = CertificadoSelecionado,
                };

                var statusServico = new ServicoNFCe.StatusServico(xml, configuracao);
                statusServico.Executar();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private int GerarNFCe()
        {
            try
            {
                var xml = new XmlNFe.EnviNFe

                {
                    Versao = "4.00",
                    IdLote = "000000000000001",
                    IndSinc = SimNao.Sim,
                    NFe = new List<XmlNFe.NFe>
                    {
                    new XmlNFe.NFe
                        {
                        InfNFe = new List<XmlNFe.InfNFe>
                        {
                            new XmlNFe.InfNFe
                            {
                                Versao = "4.00",

                                Ide =  CampoIdeXml(),

                                Emit =  CampoEmitXml(),

                                Dest = CampoDestXml(),

                                Det = CampoDetXml(),

                                Total = CampoTotalXml(),

                                Transp = CampoTranspXml(),

                                Pag = CampoPagXml(),

                                InfAdic =CampoInfAdicXml(),

                                InfRespTec = CampoInfRespTecXml(),
                            }
                        }
                        }
                    }
                };

                var CertificadoSelecionado = CarregarCertificaDigitaldoDoBanco();

                var configuracao = new Configuracao
                {
                    TipoDFe = TipoDFe.NFCe,
                    CertificadoDigital = CertificadoSelecionado,

                    CSC = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? dadosEmitente.at_nfeCscTokenProd : dadosEmitente.at_nfeCscTokenHom,
                    CSCIDToken = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? Convert.ToInt32(dadosEmitente.at_nfeCscIdProd) : Convert.ToInt32(dadosEmitente.at_nfeCscIdHom)
                };

                var autorizacao = new ServicoNFCe.Autorizacao(xml, configuracao);
                autorizacao.Executar();

                //caso a nota seja rejeitada por duplicidade, incrementa o número da nota ate que seja autorizada
                if (autorizacao.Result.ProtNFe.InfProt.CStat != null && (autorizacao.Result.ProtNFe.InfProt.CStat == 204 || autorizacao.Result.ProtNFe.InfProt.CStat == 539)) // 204: Rejeição por duplicação de nnf (Já foi emitido por outro PDV)
                {
                    serie = ++serie;
                    numeroNota = ++numeroNota;

                    return GerarNFCe();
                }

                if (autorizacao.Result.ProtNFe != null)
                {
                    switch (autorizacao.Result.ProtNFe.InfProt.CStat)
                    {
                        case 100: //Autorizado o uso da NFe
                        case 110: //Uso Denegado
                        case 150: //Autorizado o uso da NF-e, autorização fora de prazo
                        case 205: //NF-e está denegada na base de dados da SEFAZ [nRec:999999999999999]
                        case 301: //Uso Denegado: Irregularidade fiscal do emitente
                        case 302: //Uso Denegado: Irregularidade fiscal do destinatário
                        case 303: //Uso Denegado: Destinatário não habilitado a operar na UF
                            autorizacao.GravarXmlDistribuicao(@"C:\Users\israe\Desktop\XML - teste");
                            //var docProcNFe = autorizacao.NfeProcResult.GerarXML(); //Gerar o Objeto para pegar a string e gravar em banco de dados

                            //Como é assíncrono, tenho que prever a possibilidade de ter mais de uma NFe no lote, então teremos vários XMLs com protocolos.
                            //Se no seu caso vc enviar sempre uma única nota, só vai passar uma única vez no foreach
                            foreach (var item in autorizacao.NfeProcResults.Values)
                            {
                                var docProcNFe = item.GerarXML();
                                var stringXml = docProcNFe.OuterXml;
                            }

                            break;

                        default:
                            //NF Rejeitada
                            break;
                    }
                }

                SalvarXMLPasta(autorizacao);

                ImprimirCupomFiscal(autorizacao);

                if (autorizacao.Result.ProtNFe.InfProt.CStat == 100)
                {
                    AlterarDadosMovimentacaoConcluida(autorizacao);
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk($"Não foi possível gerar a NFC-e./n Cód.: {autorizacao.Result.ProtNFe.InfProt.CStat} /n Motivo: {autorizacao.Result.ProtNFe.InfProt.XMotivo} ");
                }

                SalvaNfe(autorizacao);
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao gerar NFC-e: {ex.Message}");
            }

            return 0;
        }

        private void SalvarXMLPasta(ServicoNFCe.Autorizacao autorizacao)
        {
            try
            {
                var destinoArqXml =
                    $@"C:\Users\israe\Desktop\XML - teste\{Regex.Replace(movimentacao.fk_tb_ator_emit.at_cnpj, @"[.\-/]", "")}\{(int)movimentacao.mv_nfeTipoAmb}\{serie:000}\";

                var SNfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.Result.ProtNFe?.InfProt?.ChNFe]?.GerarXML()
                    ?.OuterXml;
                string NArquivo = "";

                if (autorizacao.EnviNFe.NFe[0].InfNFe[0].Ide.TpImp.ToString() == "NFCe")
                {
                    NArquivo = $"NFCe - {autorizacao.Result.ProtNFe?.InfProt?.ChNFe}.xml";
                }
                else
                {
                    NArquivo = $"NFe - {autorizacao.Result.ProtNFe?.InfProt?.ChNFe}.xml";
                }

                var dir = PegandoDiretorio(destinoArqXml);

                File.WriteAllText(Path.Combine(dir.FullName, NArquivo), SNfeXmlProcRes);
            }
            catch (Exception ex)
            {
            }
        }

        private void AlterarDadosMovimentacaoConcluida(ServicoNFCe.Autorizacao autorizacao)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(movimentacao.id_movimentacao));

                    _movimentacao.mv_conc = 1;
                    _movimentacao.mv_quit = 1;
                    _movimentacao.mv_nfeChave = autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave;
                    _movimentacao.mv_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;

                    uow.Save(_movimentacao);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar dados da movimentação após finalização da venda: {ex.Message}");
            }
        }

        private void ImprimirCupomFiscal(ServicoNFCe.Autorizacao autorizacao)
        {
            try
            {
                bool visualizar = false;

                var config = new DANFe.Configurations.UnidanfeConfiguration
                {
                    Arquivo = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml,
                    Visualizar = !visualizar,
                    Imprimir = !visualizar,
                    EnviaEmail = false,
                    Configuracao = "PAISAGEM"
                };

                DANFe.UnidanfeServices.Execute(config);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Esta funcao contem esta inserindo dados em 3 tabelas:
        /// tb_nfe = inserindo os dados.
        /// tb_movimentacao = indicando que foi concluida a venda.
        /// tb_pdv = alterando o numero da seguencia da nf.
        /// </summary>
        private void SalvaNfe(ServicoNFCe.Autorizacao autorizacao)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(movimentacao.id_movimentacao));

                    tb_pdv pdv = uow.GetObjectByKey<tb_pdv>(Convert.ToInt64(VariaveisGlobais.PDVLogado.id_pdv));

                    tb_nfe nfe = new tb_nfe(uow);

                    nfe.nf_desat = 0;
                    nfe.nf_dtCri = DateTime.Now;
                    nfe.nf_dtAlt = DateTime.Now;
                    nfe.fk_tb_movimentacao = _movimentacao;
                    nfe.nf_nfeServico = 0;
                    nfe.nf_prontoEnviar = 0;
                    nfe.nf_nfeTipoAmb = Convert.ToByte(VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao);
                    nfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                    nfe.nf_nfeTipoDfe_ImpXml = Convert.ToByte(SEnNfeTipoDfe.nd255);
                    nfe.nf_nfeVlrTotNF_ImpXml = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF);
                    nfe.nf_nfe1CStat = autorizacao.Result.CStat;
                    nfe.nf_nfe1XMotivo = autorizacao.Result.XMotivo;
                    nfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                    nfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                    nfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                    nfe.nf_nfe1ResProtNFeInfProt0CStat = Convert.ToInt64(autorizacao.Result.ProtNFe?.InfProt?.CStat);
                    nfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                    nfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                    nfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                    nfe.nf_nfe1ResProtNFeInfProt0DhRecbto = Convert.ToDateTime(autorizacao.Result.ProtNFe?.InfProt?.DhRecbto.DateTime);
                    nfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                    nfe.nf_nfeVlrTotTrib_ImpXml = 0;
                    nfe.nf_nfe1DhRecbto = autorizacao.Result.DhRecbto.DateTime;
                    nfe.nf_nfe1CStat = Convert.ToInt32(autorizacao.Result?.CStat);
                    nfe.nf_nfe1XMotivo = autorizacao.Result?.XMotivo;
                    nfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                    nfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                    nfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                    nfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                    nfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                    nfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                    nfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;
                    nfe.nf_nfe2ConteudoXMLOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                    nfe.nf_nfe2RetornoWSString = autorizacao.RetornoWSString;
                    nfe.nf_nfe2RetornoWSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                    nfe.nf_nfe2ResCStat = autorizacao.Result.CStat;
                    nfe.nf_nfe2ResDhRecbto = autorizacao.Result.DhRecbto.DateTime;
                    nfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                    nfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe.InfProt.NProt;
                    nfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe.InfProt.XMotivo;
                    nfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;
                    nfe.nf_nfeChave = autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave;
                    nfe.nf_nfeDtEmis = autorizacao.EnviNFe.NFe[0].InfNFe[0].Ide.DhEmi.DateTime;
                    nfe.nf_nfeVlrTotProd = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VProd);
                    nfe.nf_nfeVlrTotNF = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF);
                    nfe.nf_nfeVlrTotDesc = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VDesc);
                    nfe.nf_nfeVlrTotFrete = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VFrete);
                    nfe.nf_nfeVlrTotSeg = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VSeg);
                    nfe.nf_nfeVlrTotOutro = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VOutro);
                    nfe.nf_nfeVlrTotIpi = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VIPI);
                    nfe.nf_nfeVlrTotIpiDevol = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VIPIDevol);
                    nfe.nf_vlrTotPag = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF);
                    nfe.nf_nfeVlrTotPis = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VPIS);
                    nfe.nf_nfeVlrTotCofins = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VCOFINS);
                    nfe.nf_nfeVlrTotTrib = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VTotTrib);
                    nfe.nf_nfeVlrTotIcms = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VICMS);
                    nfe.nf_nfeVlrTotIcmsSt = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VST);
                    nfe.nf_nfeVlrTotIcmsFcp = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VFCP);
                    nfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                    nfe.nf_nfeSerie = Convert.ToInt16(serie);

                    if (VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1)
                    {
                        pdv.pdv_nfeProdNum = numeroNota;
                    }
                    else
                    {
                        pdv.pdv_nfeHomNum = numeroNota;
                    }

                    if (autorizacao.Result.ProtNFe.InfProt.CStat == 100)
                    {
                        nfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                    }

                    _movimentacao.mv_conc = 1;

                    uow.Save(pdv);
                    uow.Save(_movimentacao);
                    uow.Save(nfe);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar dados da movimentação após finalização da venda: {ex.Message}");
            }
        }

        #region CamposXML

        private Ide CampoIdeXml()
        {
            try
            {
                Ide ide = new Ide();

                ide.CUF = (Unimake.Business.DFe.Servicos.UFBrasil)Enum.Parse(typeof(Unimake.Business.DFe.Servicos.UFBrasil),
                    dadosEmitente.fk_tb_estados_br.eb_id.ToString());
                ide.NatOp = "VENDA DE MERCADORIA ADQUIRIDA OU RECEBIDA DE TERCEIROS";
                ide.Mod = ModeloDFe.NFCe;
                ide.Serie = serie;
                ide.NNF = numeroNota;
                ide.DhEmi = DateTime.Now;
                ide.DhSaiEnt = DateTime.Now;
                ide.TpNF = TipoOperacao.Saida;
                ide.IdDest = DestinoOperacao.OperacaoInterna;
                ide.CMunFG = Convert.ToInt32(dadosEmitente.fk_tb_municipio.mu_id);
                ide.TpImp = FormatoImpressaoDANFE.NFCe;
                ide.TpEmis = TipoEmissao.Normal;
                ide.TpAmb = VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1
                    ? TipoAmbiente.Producao
                    : TipoAmbiente.Homologacao;
                ide.FinNFe = FinalidadeNFe.Normal;
                ide.IndFinal = SimNao.Sim;
                ide.IndPres = IndicadorPresenca.OperacaoPresencial;
                ide.ProcEmi = ProcessoEmissao.AplicativoContribuinte;
                ide.VerProc = "TESTE 1.00";

                return ide;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo Ide XML: {ex.Message}");

                return null;
            }
        }

        private Emit CampoEmitXml()
        {
            try
            {
                Emit emit = new Emit();

                emit.CNPJ = Regex.Replace(dadosEmitente.at_cnpj, @"[^\d]", "");
                emit.XNome = dadosEmitente.at_razSoc;
                emit.XFant = dadosEmitente.at_nomeFant;
                emit.EnderEmit = new XmlNFe.EnderEmit
                {
                    XLgr = dadosEmitente.at_end_Logr,
                    Nro = dadosEmitente.at_end_Num,
                    XBairro = dadosEmitente.at_end_Bairro,
                    CMun = Convert.ToInt32(dadosEmitente.fk_tb_municipio.mu_id),
                    XMun = dadosEmitente.fk_tb_estados_br.eb_nome,
                    UF = (Unimake.Business.DFe.Servicos.UFBrasil)Enum.Parse(typeof(Unimake.Business.DFe.Servicos.UFBrasil),
                        dadosEmitente.fk_tb_estados_br.eb_id.ToString()),
                    CEP = dadosEmitente.at_end_Cep.Replace("-", ""),
                    Fone = dadosEmitente.at_telFixo
                };
                emit.IE = dadosEmitente.at_inscEst;
                emit.IM = dadosEmitente.at_inscMun;
                emit.CNAE = Regex.Replace(dadosEmitente.at_cnae, @"[^\d]", "");
                emit.CRT = CRT.SimplesNacional;

                return emit;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo Emit XML: {ex.Message}");

                return null;
            }
        }

        private Dest CampoDestXml()
        {
            try
            {
                //Dest dest = new Dest();

                //tb_ator cliente = null;

                //if (!string.IsNullOrWhiteSpace(txtCPF.Text))
                //{
                //    string cpf = Regex.Replace(txtCPF.Text, @"[^\d]", "");

                //    using (UnitOfWork uow = new UnitOfWork())
                //    {
                //        cliente = uow.Query<tb_ator>().FirstOrDefault(x => x.at_cpf == cpf);
                //    }

                //    dest.CPF = cpf;
                //    dest.IndIEDest = IndicadorIEDestinatario.NaoContribuinte;

                //    // Preencher o nome do destinatário para ambiente de homologação
                //    if (VariaveisGlobais.FilialLogada.at_nfeTipoAmb == (int)SEnNfeTipoAmb.Hom2)
                //    {
                //        dest.XNome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";
                //    }

                //    if (cliente != null)
                //    {
                //        dest.XNome = cliente.at_razSoc;

                //        // Nome do destinatário
                //        //// Caso contrário, verifica se é pessoa jurídica com CNPJ
                //        //else if (!string.IsNullOrWhiteSpace(txtCNPJ.Text))
                //        //{
                //        //    string cnpj = Regex.Replace(txtCNPJ.Text, @"[^\d]", "");
                //        //    dest.CNPJ = cnpj;
                //        //    dest.IndIEDest = IndicadorIEDestinatario.ContribuinteICMS; // Define o indicador do destinatário
                //        //    dest.XNome = txtRazaoSocial.Text; // Razão social da empresa
                //        //    dest.IE = txtIE.Text; // Inscrição Estadual
                //        //}

                //        // Preencher o endereço completo do destinatário
                //        dest.EnderDest = new EnderDest
                //        {
                //            XLgr = cliente.at_end_Logr,
                //            Nro = cliente.at_end_Num,
                //            XBairro = cliente.at_end_Bairro,
                //            CMun = Convert.ToInt16(cliente.fk_tb_municipio.mu_id),
                //            XMun = cliente.fk_tb_municipio.mu_nome,
                //            UF = (Unimake.Business.DFe.Servicos.UFBrasil)Enum.Parse(typeof(Unimake.Business.DFe.Servicos.UFBrasil),
                //                cliente.fk_tb_estados_br.eb_sigla),

                //            CEP = Regex.Replace(cliente.at_end_Cep, @"[^\d]", ""),
                //            CPais = 1058,
                //            XPais = "BRASIL",
                //            Fone = Regex.Replace(cliente.at_telFixo, @"[^\d]", "")
                //        };
                //    }
                //}
                //return dest;

                return null;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campos Dest XML: {ex.Message}");

                return null;
            }
        }

        private List<Det> CampoDetXml()
        {
            try
            {
                var dets = new List<Det>();
                short numItem = 1;
                foreach (var idMovimentacaoProduto in idMovimentacaoProdutos)
                {
                    tb_movimentacao_produto p;

                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        p = uow.GetObjectByKey<tb_movimentacao_produto>(idMovimentacaoProduto);
                    }

                    Det d = new Det();
                    d.NItem = numItem; // p.SNumItem;

                    #region Prod

                    d.Prod = new Prod();

                    d.Prod.CProd = Convert.ToString(p.mp_codRef);
                    d.Prod.CEAN =
                        string.IsNullOrWhiteSpace(p.fk_tb_produto.pd_barras) || p.fk_tb_produto.pd_barras.Length < 8
                            ? "SEM GTIN"
                            : p.fk_tb_produto.pd_barras; //Codigo EAN de barras
                    d.Prod.XProd = string.IsNullOrWhiteSpace(p.mp_desc) ? p.mp_descCurta : p.mp_desc;
                    d.Prod.NCM = "39269090"; // p.SNcm != null ? p.SNcm?.SNcmFull : p.SNfeNcm;
                                             //d.Prod.CFOP = ((short)p.SNfeCfop).ToString();
                    d.Prod.CFOP = Convert.ToInt32(p.mp_nfeCfop).ToString("0000");
                    d.Prod.UCom = ConverterUnidadeMedia(p.mp_unMedCom);
                    //d.Prod.UCom = Regex.Replace(Convert.ToString(p.mp_unMedCom), @"[^[A-Z]", string.Empty);
                    d.Prod.QCom = p.mp_qtdCom; //ok
                    d.Prod.VUnCom = p.mp_vlrUnCom; //ok
                    d.Prod.VProd = Convert.ToDouble(p.mp_vlrProdTot); //ok
                    d.Prod.CEANTrib =
                        string.IsNullOrWhiteSpace(p.fk_tb_produto.pd_barras) || p.fk_tb_produto.pd_barras.Length < 8
                            ? "SEM GTIN"
                            : p.fk_tb_produto.pd_barras;
                    d.Prod.UTrib = ConverterUnidadeMedia(p.mp_unMedCom);
                    //d.Prod.UTrib = Regex.Replace(Convert.ToString(p.mp_unMedCom), @"[^[A-Z]", string.Empty);
                    d.Prod.QTrib = p.mp_qtdCom;
                    d.Prod.VUnTrib = p.mp_vlrUnCom;
                    d.Prod.IndTot = SimNao.Sim;
                    //d.Prod.NItemPed = Convert.ToInt32(p.StProdCod);
                    d.Prod.VDesc = Convert.ToDouble(p.mp_vlrDesc);
                    //d.Prod.CEST = p.SCest;
                    if (VariaveisGlobais.FilialLogada.at_nfeTipoAmb == Convert.ToByte(SEnNfeTipoAmb.Hom2) && numItem == 1)
                        d.Prod.XProd = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";

                    #endregion Prod

                    #region Imposto

                    d.Imposto = new Imposto();
                    d.Imposto.VTotTrib = Convert.ToDouble(movimentacao.mv_nfeVlrTotTrib);

                    #region PIS

                    d.Imposto.PIS = new PIS();
                    d.Imposto.PIS.PISOutr = new PISOutr();
                    d.Imposto.PIS.PISOutr.CST = "99";
                    d.Imposto.PIS.PISOutr.VBC = d.Prod.VProd;
                    d.Imposto.PIS.PISOutr.PPIS = 0;
                    d.Imposto.PIS.PISOutr.VPIS = 0;

                    #endregion PIS

                    #region COFINS

                    d.Imposto.COFINS = new COFINS();
                    d.Imposto.COFINS.COFINSAliq = new COFINSAliq();
                    d.Imposto.COFINS.COFINSAliq.CST = "01";
                    d.Imposto.COFINS.COFINSAliq.VBC = d.Prod.VProd;
                    d.Imposto.COFINS.COFINSAliq.VCOFINS = 0;
                    d.Imposto.COFINS.COFINSAliq.PCOFINS = 0;

                    #endregion COFINS

                    #region IPI

                    /*d.Imposto.IPI = new XmlNFe.Imposto();
                        d.Imposto.IPI.CNPJProd = 1;
                        d.Imposto.IPI.CSelo = "971001";
                        d.Imposto.IPI.QSelo = 1;
                        d.Imposto.IPI.Cenq = "001";
                        d.Imposto.IPI.IPINT = new XmlNFe.IPINT();
                        d.Imposto.IPI.IPINT.CST = p.SMov.SNfeCst;

                        d.Imposto.IPI.IPITrib = new XmlNFe.IPITrib();
                            d.Imposto.IPI.IPITrib.CST = "49";
                    */

                    #endregion IPI

                    #region ICMS

                    d.Imposto.ICMS = new ICMS();
                    //d.Imposto.ICMS.Add(new());
                    if (VariaveisGlobais.FilialLogada.at_nfeCodRegTrib == Convert.ToByte(SEnNfeCodRegTrib.SimplesNacional1))
                    {
                        //if (p.SNfeCsosn == SEnNfeCsosn.nd0)
                        {
                            d.Imposto.ICMS.ICMSSN102 = new XmlNFe.ICMSSN102
                            {
                                Orig = (OrigemMercadoria)(int)p.mp_nfeProdOrigem,
                                CSOSN = "102",
                            };
                        }
                        /*else
                            switch (p.SNfeCsosn)
                            {
                                case SEnNfeCsosn.TribSnPermCred101:
                                    d.Imposto.ICMS.ICMSSN101 = new XmlNFe.ICMSSN101
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                        PCredSN = Convert.ToDouble(p.SNfePercAliqCredSn),
                                        VCredICMSSN = Convert.ToDouble(p.SNfeVlrCredIcmsSn),
                                    };
                                    break;

                                case SEnNfeCsosn.TribSnSemPermCred102:
                                    d.Imposto.ICMS.ICMSSN102 = new XmlNFe.ICMSSN102
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                    };
                                    break;

                                case SEnNfeCsosn.TribSnComPermCredCobSt201:
                                    d.Imposto.ICMS.ICMSSN201 = new XmlNFe.ICMSSN201
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                        ModBCST = (ModalidadeBaseCalculoICMSST)(int)p.SNfeModBcSt,
                                        PMVAST = Convert.ToDouble(p.SNfePercMvaSt),
                                        PRedBCST = Convert.ToDouble(p.SNfePercRedBcIcmsSt),
                                        VBCST = Convert.ToDouble(p.SNfeVlrBcIcmsSt),
                                        PICMSST = Convert.ToDouble(p.SNfeAliqIcmsSt),
                                        VICMSST = Convert.ToDouble(p.SNfeVlrIcmsSt),
                                        VBCFCPST = Convert.ToDouble(p.SNfeVlrBcFcpRetSt),
                                        PFCPST = Convert.ToDouble(p.SNfePercFcpRetSt),
                                        VFCPST = Convert.ToDouble(p.SNfeVlrFcpRetSt),
                                        PCredSN = Convert.ToDouble(p.SNfePercAliqCredSn),
                                        VCredICMSSN = Convert.ToDouble(p.SNfeVlrCredIcmsSn),
                                    };
                                    break;

                                case SEnNfeCsosn.TribSnSemPermCredCobIcmsSt202:
                                    d.Imposto.ICMS.ICMSSN202 = new XmlNFe.ICMSSN202
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                        ModBCST = (ModalidadeBaseCalculoICMSST)(int)p.SNfeModBcSt,
                                        PMVAST = Convert.ToDouble(p.SNfePercMvaSt),
                                        PRedBCST = Convert.ToDouble(p.SNfePercRedBcIcmsSt),
                                        VBCST = Convert.ToDouble(p.SNfeVlrBcIcmsSt),
                                        PICMSST = Convert.ToDouble(p.SNfeAliqIcmsSt),
                                        VICMSST = Convert.ToDouble(p.SNfeVlrIcmsSt),
                                        VBCFCPST = Convert.ToDouble(p.SNfeVlrBcFcpRetSt),
                                        PFCPST = Convert.ToDouble(p.SNfePercFcpRetSt),
                                        VFCPST = Convert.ToDouble(p.SNfeVlrFcpRetSt),
                                    };
                                    break;

                                case SEnNfeCsosn.IcmsCobrAntPorStOuAnt500:
                                    d.Imposto.ICMS.ICMSSN500 = new XmlNFe.ICMSSN500
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                        VBCSTRet = Convert.ToDouble(p.SNfeVlrBcIcmsStRet),
                                        PST = Convert.ToDouble(p.SNfePercAliqSuportada),
                                        VICMSSubstituto = Convert.ToDouble(p.SNfeVlrIcmsPropSubst),
                                        VICMSSTRet = Convert.ToDouble(p.SNfeVlrIcmsStRet),
                                        VBCFCPSTRet = Convert.ToDouble(p.SNfeBcFcpRetAnt),
                                        PFCPSTRet = Convert.ToDouble(p.SNfePercFcpRetAntSt),
                                        VFCPSTRet = Convert.ToDouble(p.SNfeVlrFcpRetSt),
                                        PRedBCEfet = Convert.ToDouble(p.SNfePercRedBcEfet),
                                        VBCEfet = Convert.ToDouble(p.SNfeVlrBcEfet),
                                        PICMSEfet = Convert.ToDouble(p.SNfePercAliqIcmsEfet),
                                        VICMSEfet = Convert.ToDouble(p.SNfeVlrIcmsEfet),
                                    };
                                    break;

                                case SEnNfeCsosn.Outros900:
                                    d.Imposto.ICMS.ICMSSN900 = new XmlNFe.ICMSSN900
                                    {
                                        Orig = (OrigemMercadoria)(int)p.SNfeProdOrigem,
                                        CSOSN = Convert.ToString((int)p.SNfeCsosn),
                                        ModBC = (ModalidadeBaseCalculoICMS)(int)p.SNfeModBc,
                                        VBC = Convert.ToDouble(p.SNfeVlrBcIcms),
                                        PRedBC = Convert.ToDouble(p.SNfePercRedBcIcms),
                                        PICMS = Convert.ToDouble(p.SNfeAliqIcms),
                                        VICMS = Convert.ToDouble(p.SNfeVlrTotIcms),
                                        ModBCST = (ModalidadeBaseCalculoICMSST)(int)p.SNfeModBcSt,
                                        PMVAST = Convert.ToDouble(p.SNfePercMvaSt),
                                        PRedBCST = Convert.ToDouble(p.SNfePercRedBcIcmsSt),
                                        VBCST = Convert.ToDouble(p.SNfeVlrBcIcmsSt),
                                        PICMSST = Convert.ToDouble(p.SNfeAliqIcmsSt),
                                        VICMSST = Convert.ToDouble(p.SNfeVlrIcmsSt),
                                        VBCFCPST = Convert.ToDouble(p.SNfeVlrBcFcpRetSt),
                                        PFCPST = Convert.ToDouble(p.SNfePercFcpRetSt),
                                        VFCPST = Convert.ToDouble(p.SNfeVlrFcpRetSt),
                                        PCredSN = Convert.ToDouble(p.SNfePercAliqCredSn),
                                        VCredICMSSN = Convert.ToDouble(p.SNfeVlrCredIcmsSn),
                                    };
                                    break;
                            }
                        */
                    }
                    else
                    {
                        if (p.mp_nfeCst == Convert.ToInt32(SEnNfeCst.nd32767))
                        {
                            //SxNfe.SMov.SNfeTransmStatus_ = SxNfe.SEnNfeTransmStatus.Corrigir5;
                            //SxNfe.SMov.SNfeTransmCorrigir_ = $"Reg. trib. do emit. não é S.N. e CST do item não foi definido!<br>{SxText[SxETranslatedText.EstaEmImpressoesPendentes]}";
                            return null;
                        }

                        switch (p.mp_nfeCst)
                        {
                            case (int)SEnNfeCst.TribInt00:
                                d.Imposto.ICMS.ICMS00 = new XmlNFe.ICMS00
                                {
                                    Orig = (OrigemMercadoria)(int)p.mp_nfeProdOrigem,
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)(int)p.mp_nfeModBc,
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                };
                                break;

                            case (int)SEnNfeCst.TribCobrIcmsSubstTrib10:
                                d.Imposto.ICMS.ICMS10 = new XmlNFe.ICMS10
                                {
                                    Orig = (OrigemMercadoria)(int)p.mp_nfeProdOrigem,
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)Convert.ToInt32(p.mp_nfeModBc),
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    VBCFCP = Convert.ToDouble(p.mp_nfeVlrBcFcp),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                    ModBCST = (ModalidadeBaseCalculoICMSST)Convert.ToInt32(p.mp_nfeModBcSt),
                                    PMVAST = Convert.ToDouble(p.mp_nfePercMvaSt),
                                    PRedBCST = Convert.ToDouble(p.mp_nfePercRedBcIcmsSt),
                                    VBCST = Convert.ToDouble(p.mp_nfeVlrBcIcmsSt),
                                    PICMSST = Convert.ToDouble(p.mp_nfeAliqIcmsSt),
                                    VICMSST = Convert.ToDouble(p.mp_nfeVlrIcmsSt),
                                    VBCFCPST = Convert.ToDouble(p.mp_nfeVlrBcFcpRetSt),
                                    PFCPST = Convert.ToDouble(p.mp_nfePercFcpRetSt),
                                    VFCPST = Convert.ToDouble(p.mp_nfeVlrFcpRetSt)
                                };
                                break;

                            case (int)SEnNfeCst.RedBC20:
                                d.Imposto.ICMS.ICMS20 = new XmlNFe.ICMS20
                                {
                                    Orig = (OrigemMercadoria)(int)p.mp_nfeProdOrigem,
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)(int)(p.mp_nfeModBc),
                                    PRedBC = Convert.ToDouble(p.mp_nfePercRedBcIcms),
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    VBCFCP = Convert.ToDouble(p.mp_nfeVlrBcFcp),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.IsentaOuNaoTrib30:
                                d.Imposto.ICMS.ICMS30 = new XmlNFe.ICMS30
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBCST = (ModalidadeBaseCalculoICMSST)Convert.ToInt32(p.mp_nfeModBcSt),
                                    PMVAST = Convert.ToDouble(p.mp_nfePercMvaSt),
                                    PRedBCST = Convert.ToDouble(p.mp_nfePercRedBcIcmsSt),
                                    VBCST = Convert.ToDouble(p.mp_nfeVlrBcIcmsSt),
                                    PICMSST = Convert.ToDouble(p.mp_nfeAliqIcmsSt),
                                    VICMSST = Convert.ToDouble(p.mp_nfeVlrIcmsSt),
                                    VBCFCPST = Convert.ToDouble(p.mp_nfeVlrBcFcpRetSt),
                                    PFCPST = Convert.ToDouble(p.mp_nfePercFcpRetSt),
                                    VFCPST = Convert.ToDouble(p.mp_nfeVlrFcpRetSt),
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.Isenta40: // 41 e 50 são dentro de 40
                                d.Imposto.ICMS.ICMS40 = new XmlNFe.ICMS40
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")), // 40, 41 ou 50
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.NaoTrib41:
                                d.Imposto.ICMS.ICMS40 = new XmlNFe.ICMS40
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")), // 40, 41 ou 50
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.Suspensao50:
                                d.Imposto.ICMS.ICMS40 = new XmlNFe.ICMS40
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")), // 40, 41 ou 50
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.Diferimento51:
                                d.Imposto.ICMS.ICMS51 = new XmlNFe.ICMS51
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)Convert.ToInt32(p.mp_nfeModBc),
                                    PRedBC = Convert.ToDouble(p.mp_nfePercRedBcIcms),
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMSOp = Convert.ToDouble(p.mp_nfeVlrIcmsOp),
                                    PDif = Convert.ToDouble(p.mp_nfePercDif),
                                    VICMSDif = Convert.ToDouble(p.mp_nfeVlrIcmsDif),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    VBCFCP = Convert.ToDouble(p.mp_nfeVlrBcFcp),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                };
                                break;

                            case (int)SEnNfeCst.CobrAntSubsTrib60:
                                d.Imposto.ICMS.ICMS60 = new XmlNFe.ICMS60
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    VBCSTRet = Convert.ToDouble(p.mp_nfeVlrBcIcmsStRet),
                                    PST = Convert.ToDouble(p.mp_nfePercAliqSuportada),
                                    VICMSSubstituto = Convert.ToDouble(p.mp_nfeVlrIcmsPropSubst),
                                    VICMSSTRet = Convert.ToDouble(p.mp_nfeVlrIcmsStRet),
                                    VBCFCPSTRet = Convert.ToDouble(p.mp_nfeBcFcpRetAnt),
                                    PFCPSTRet = Convert.ToDouble(p.mp_nfePercFcpRetAntSt),
                                    VFCPSTRet = Convert.ToDouble(p.mp_nfeVlrFcpRetSt),
                                    PRedBCEfet = Convert.ToDouble(p.mp_nfePercRedBcEfet),
                                    VBCEfet = Convert.ToDouble(p.mp_nfeVlrBcEfet),
                                    PICMSEfet = Convert.ToDouble(p.mp_nfePercAliqIcmsEfet),
                                    VICMSEfet = Convert.ToDouble(p.mp_nfeVlrIcmsEfet),
                                };
                                break;

                            case (int)SEnNfeCst.RedBcCobrIcmsST70:
                                d.Imposto.ICMS.ICMS70 = new XmlNFe.ICMS70
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)Convert.ToInt32(p.mp_nfeModBc),
                                    PRedBC = Convert.ToDouble(p.mp_nfePercRedBcIcms),
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    VBCFCP = Convert.ToDouble(p.mp_nfeVlrBcFcp),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                    ModBCST = (ModalidadeBaseCalculoICMSST)Convert.ToInt32(p.mp_nfeModBcSt),
                                    PMVAST = Convert.ToDouble(p.mp_nfePercMvaSt),
                                    PRedBCST = Convert.ToDouble(p.mp_nfePercRedBcIcmsSt),
                                    VBCST = Convert.ToDouble(p.mp_nfeVlrBcIcmsSt),
                                    PICMSST = Convert.ToDouble(p.mp_nfeAliqIcmsSt),
                                    VICMSST = Convert.ToDouble(p.mp_nfeVlrIcmsSt),
                                    VBCFCPST = Convert.ToDouble(p.mp_nfeVlrBcFcpRetSt),
                                    PFCPST = Convert.ToDouble(p.mp_nfePercFcpRetSt),
                                    VFCPST = Convert.ToDouble(p.mp_nfeVlrFcpRetSt),
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;

                            case (int)SEnNfeCst.Outros90:
                                d.Imposto.ICMS.ICMS90 = new XmlNFe.ICMS90
                                {
                                    Orig = (OrigemMercadoria)Convert.ToInt32(p.mp_nfeProdOrigem),
                                    CST = Convert.ToString(((int)p.mp_nfeCst).ToString("00")),
                                    ModBC = (ModalidadeBaseCalculoICMS)Convert.ToInt32(p.mp_nfeModBc),
                                    VBC = Convert.ToDouble(p.mp_nfeVlrBcIcms),
                                    PRedBC = Convert.ToDouble(p.mp_nfePercRedBcIcms),
                                    PICMS = Convert.ToDouble(p.mp_nfeAliqIcms),
                                    VICMS = Convert.ToDouble(p.mp_nfeVlrTotIcms),
                                    VBCFCP = Convert.ToDouble(p.mp_nfeVlrBcFcp),
                                    PFCP = Convert.ToDouble(p.mp_nfePercFcp),
                                    VFCP = Convert.ToDouble(p.mp_nfeVlrFcp),
                                    ModBCST = (ModalidadeBaseCalculoICMSST)Convert.ToInt32(p.mp_nfeModBcSt),
                                    PMVAST = Convert.ToDouble(p.mp_nfePercMvaSt),
                                    PRedBCST = Convert.ToDouble(p.mp_nfePercRedBcIcmsSt),
                                    VBCST = Convert.ToDouble(p.mp_nfeVlrBcIcmsSt),
                                    PICMSST = Convert.ToDouble(p.mp_nfeAliqIcmsSt),
                                    VICMSST = Convert.ToDouble(p.mp_nfeVlrIcmsSt),
                                    VBCFCPST = Convert.ToDouble(p.mp_nfeVlrBcFcpRetSt),
                                    PFCPST = Convert.ToDouble(p.mp_nfePercFcpRetSt),
                                    VFCPST = Convert.ToDouble(p.mp_nfeVlrFcpRetSt),
                                    VICMSDeson = Convert.ToDouble(p.mp_nfeVlrIcmsDeson),
                                    MotDesICMS = (MotivoDesoneracaoICMS)Convert.ToInt32(p.mp_nfeMotDesonIcms),
                                };
                                break;
                        }
                    }

                    #endregion ICMS

                    #endregion Imposto

                    dets.Add(d);
                    numItem++;
                }

                return dets;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao campo Det da XML: {ex.Message}");

                return null;
            }
        }

        private Total CampoTotalXml()
        {
            try
            {
                Total total = new Total();
                total.ICMSTot = new ICMSTot();

                total.ICMSTot.VBC = Convert.ToDouble(movimentacao.mv_nfeBcIcms);
                total.ICMSTot.VICMS = Convert.ToDouble(movimentacao.mv_nfeVlrTotIcms);
                total.ICMSTot.VICMSDeson = Convert.ToDouble(movimentacao.mv_nfeVlrIcmsDeson);
                total.ICMSTot.VFCP = Convert.ToDouble(movimentacao.mv_nfeVlrTotFcp);
                total.ICMSTot.VBCST = Convert.ToDouble(movimentacao.mv_nfeVlrBcIcmsSt);
                total.ICMSTot.VST = Convert.ToDouble(movimentacao.mv_nfeVlrTotIcmsSt);
                total.ICMSTot.VFCPST = Convert.ToDouble(movimentacao.mv_nfeVlrTotFcpSt);
                total.ICMSTot.VFCPSTRet = Convert.ToDouble(movimentacao.mv_nfeVlrTotFcpRetSt);
                total.ICMSTot.VProd = Convert.ToDouble(movimentacao.mv_nfeVlrTotProd);
                total.ICMSTot.VFrete = Convert.ToDouble(movimentacao.mv_nfeVlrTotFrete);
                total.ICMSTot.VSeg = Convert.ToDouble(movimentacao.mv_nfeVlrTotSeg);
                total.ICMSTot.VDesc = Convert.ToDouble(movimentacao.mv_nfeVlrTotDesc);
                total.ICMSTot.VII = Convert.ToDouble(movimentacao.mv_nfeVlrTotImpImp);
                total.ICMSTot.VIPI = Convert.ToDouble(movimentacao.mv_nfeVlrTotIpi);
                total.ICMSTot.VIPIDevol = Convert.ToDouble(movimentacao.mv_nfeVlrTotIpiDevol);
                total.ICMSTot.VPIS = Convert.ToDouble(movimentacao.mv_nfeVlrTotPis);
                total.ICMSTot.VCOFINS = Convert.ToDouble(movimentacao.mv_nfeVlrTotCofins);
                total.ICMSTot.VOutro = Convert.ToDouble(movimentacao.mv_nfeVlrTotOutro);
                total.ICMSTot.VNF = Convert.ToDouble(movimentacao.mv_nfeVlrTotNF);
                total.ICMSTot.VTotTrib = Convert.ToDouble(movimentacao.mv_nfeVlrTotTrib);

                return total;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo Total XML: {ex.Message}");

                return null;
            }
        }

        private Transp CampoTranspXml()
        {
            try
            {
                Transp transp = new Transp();
                transp.ModFrete = ModalidadeFrete.SemOcorrenciaTransporte;

                return transp;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo Transp XML: {ex.Message}");

                return null;
            }
        }

        private Pag CampoPagXml()
        {
            try
            {
                Pag pag = new Pag();
                pag.DetPag = new List<DetPag>();

                foreach (var item in idMovimentoPagamento)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        tb_movimentacao_pagamento movimentacaoPagamento =
                            uow.GetObjectByKey<tb_movimentacao_pagamento>(Convert.ToInt64(item));

                        tb_movimentacao movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao));

                        DetPag detPag = new DetPag();

                        detPag.IndPag = IndicadorPagamento.PagamentoVista;
                        detPag.TPag = (MeioPagamento)(int)movimentacaoPagamento.fk_tb_sub_forma_pagamento.fk_tb_forma_pagamento.fp_nfeTipoPag;
                        detPag.VPag = Convert.ToDouble(movimentacaoPagamento.mpg_nfeVlrPag);

                        pag.VTroco = Convert.ToDouble(movimentacao.mv_nfeVlrTroco);

                        pag.DetPag.Add(detPag);
                    }
                }

                return pag;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo Pag da XML: {ex.Message}");

                return null;
            }
        }

        private InfAdic CampoInfAdicXml()
        {
            try
            {
                InfAdic infAdic = new InfAdic
                {
                    InfCpl = VariaveisGlobais.FilialLogada.at_nfeCodRegTrib ==
                             Convert.ToByte(SEnNfeCodRegTrib.SimplesNacional1)
                        ? "Empresa optante pelo simples nacional, conforme lei compl. 128 de 19/12/2008;"
                        : null,
                };

                return infAdic;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo InfAdic XML: {ex.Message}");

                return null;
            }
        }

        private InfRespTec CampoInfRespTecXml()
        {
            try
            {
                InfRespTec infRespTec = new InfRespTec
                {
                    CNPJ = "06117473000150",
                    XContato = "Wandrey Mundin Ferreira",
                    Email = "wandrey@unimake.com.br",
                    Fone = "04431414900"
                };

                return infRespTec;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campo InfRespTec XML: {ex.Message}");

                return null;
            }
        }

        #endregion CamposXML

        private string ConverterUnidadeMedia(int _tipoUnMedia)
        {
            switch (_tipoUnMedia)
            {
                case 0: return "nd";
                case 1: return "UN";
                case 2: return "PC";
                case 3: return "PT";
                case 4: return "RL";
                case 5: return "BN";
                case 6: return "BL";
                case 7: return "CO";
                case 10: return "KG";
                case 11: return "KT";
                case 20: return "MT";
                case 21: return "M2";
                case 22: return "M3";
                case 30: return "LT";
                case 31: return "ML";
                case 32: return "FL";
                case 42: return "MW";
                case 50: return "PR";
                case 51: return "DZ";
                case 52: return "CJ";
                case 53: return "CX";
                case 54: return "FD";
                case 55: return "SC";
                case 56: return "JG";
                case 57: return "FR";
                case 58: return "TB";
                case 59: return "BD";
                case 60: return "FC";
                case 61: return "TU";
                case 62: return "GL";
                case 63: return "LA";
                case 64: return "MI";
                default:

                    return "";
            }
        }

        private void btnReimprimirCupomFiscal_Click(object sender, EventArgs e)
        {
            if (IsNfeExiste())
            {
                ReemprimirCupomFiscal();
            }
            else
            {
                PegarNumeroNota();

                if (IsSefazEstavel())
                {
                    PegandoMovimentacao();

                    PegandoMovimentacaoProduto();

                    PegandoMovimentacaoPagamento();

                    GerarNFCe();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Estamos enfrentando uma instabilidade momentânea na conexão com a SEFAZ.");
                }
            }
            _frmTelaInicial.TelaVendasPDV();

            this.Visible = false;
        }

        private void ReemprimirCupomFiscal()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var _movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(idMovimentacaoSelecionado));

                    var nfe = uow.Query<tb_nfe>()
                        .Where(x => x.fk_tb_movimentacao == _movimentacao)
                        .Select(x => new { x.nf_nfeXmlProcRes, x.fk_tb_movimentacao })
                        .FirstOrDefault();

                    if (nfe != null)
                    {
                        SxDanfe(nfe.nf_nfeXmlProcRes);
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar dados da NFC-e: {ex.Message}");
            }
        }

        private bool IsNfeExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var nfe = uow.Query<tb_nfe>()
                        .Any(x => x.fk_tb_movimentacao.id_movimentacao == Convert.ToInt64(idMovimentacaoSelecionado));

                    return nfe;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar se a venda já existe cupom fiscal gerado: {ex.Message}");

                return false;
            }

            return false;
        }

        private void PegandoMovimentacaoProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var movimentacaoProdutos = uow.Query<tb_movimentacao_produto>()
                        .Where(x => x.fk_tb_movimentacao.id_movimentacao == Convert.ToInt64(idMovimentacaoSelecionado))
                        .Select(x => new { x.id_movimentacao_produto });

                    foreach (var item in movimentacaoProdutos)
                    {
                        idMovimentacaoProdutos.Add(Convert.ToInt64(item.id_movimentacao_produto));
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao busca movimentação de produtos que foram selecionados nesta venda: {ex.Message}");
            }
        }

        private void PegandoMovimentacao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var movimentacaoProdutos = uow.Query<tb_movimentacao>()
                        .FirstOrDefault(x => x.id_movimentacao == Convert.ToInt64(idMovimentacaoSelecionado));

                    movimentacao = movimentacaoProdutos;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao busca a movimentação que realizada nesta venda: {ex.Message}");
            }
        }

        private void PegandoMovimentacaoPagamento()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var movimentacaoPagamentoRealizados = uow.Query<tb_movimentacao_pagamento>()
                        .Where(x => x.fk_tb_movimentacao.id_movimentacao == Convert.ToInt64(idMovimentacaoSelecionado))
                        .Select(x => new { x.id_movimentacao_pagamento });

                    foreach (var item in movimentacaoPagamentoRealizados)
                    {
                        idMovimentoPagamento.Add(Convert.ToInt64(item.id_movimentacao_pagamento));
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao busca movimentação de produtos que foram selecionados nesta venda: {ex.Message}");
            }
        }

        private void uc_VisualizarVenda_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaVendasPDV(); ;
        }

        private void btnEnvioEmail_Click(object sender, EventArgs e)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao movimentacao = uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(idMovimentacaoSelecionado));

                    tb_ator dadosClienteCadastrado = uow.Query<tb_ator>()
                        .FirstOrDefault(x => x.id_ator == movimentacao.fk_tb_ator_dest.id_ator);

                    string email = dadosClienteCadastrado.at_email;

                    //if (string.IsNullOrEmpty(email))
                    //{
                    //    MensagensDoSistema.MensagemAtencaoOk("O cliente não possui e-mail cadastrado.");
                    //}
                    //else
                    //{
                    //    if (IsNfeExiste())
                    //    {
                    //        EnviarEmail(email);
                    //    }
                    //    else
                    //    {
                    //        PegarNumeroNota();

                    //        if (IsSefazEstavel())
                    //        {
                    //            PegandoMovimentacao();

                    //            PegandoMovimentacaoProduto();

                    //            PegandoMovimentacaoPagamento();

                    //            GerarNFCe();

                    //            EnviarEmail(email);
                    //        }
                    //        else
                    //        {
                    //            MensagensDoSistema.MensagemAtencaoOk("Estamos enfrentando uma instabilidade momentânea na conexão com a SEFAZ.");
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}