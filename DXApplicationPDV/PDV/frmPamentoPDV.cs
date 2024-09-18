using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;
using DXApplicationPDV.Classes;
using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;
using static DXApplicationPDV.uc_PDV;
using static DXApplicationPDV.Classes.DadosGeralNfe;
using Unimake.Business.DFe.Xml.NFe;
using Unimake.Business.DFe.Xml.SNCM;
using Unimake.Business.DFe.Servicos;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SQLite;

using System.Drawing;

using System.IO;

using System.Linq;

using System.Runtime.InteropServices.ComTypes;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

using DevExpress.Data.Filtering;

using DevExpress.Xpo;
using DevExpress.XtraEditors;

using DevExpress.XtraPrinting;

using DXApplicationPDV.bancoSQLite;
using DXApplicationPDV.Classes;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Xml.NFe;

using Unimake.Business.Security;
using ServicoNFCe = Unimake.Business.DFe.Servicos.NFCe;
using DANFe = Unimake.Unidanfe;

using XmlNFe = Unimake.Business.DFe.Xml.NFe;

using Unimake.Business.DFe.Xml.SNCM;
using System.Text.RegularExpressions;

namespace DXApplicationPDV
{
    public partial class frmPamentoPDV : DevExpress.XtraEditors.XtraForm
    {
        public string descontoBruto = "";

        public List<PamentosRealizados> listaPagamentosRealizados = new List<PamentosRealizados>();

        public frmPamentoPDV()
        {
            InitializeComponent();

            PreencherCampos();

            PreencherFormaPagamento();

            PreencherVendedor();
        }

        private void ValidarDigitos(KeyPressEventArgs e)
        {
            // Verificar se o caractere digitado é um número, a vírgula, o caractere '%' ou a tecla "Backspace"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '%' && e.KeyChar != '\b')
            {
                // Cancelar a entrada
                e.Handled = true;
            }
        }

        private decimal valorDesconto = 0;

        public void Desconto()
        {
            decimal valorTotalProdutos = 0;

            decimal valorTotal = 0;

            decimal valorTotalDesconto = 0;

            foreach (var item in uc_PDV.listaProdutoSelecionado)
            {
                valorTotalProdutos += item.vlrUnCom * item.quantidade;
            }

            if (descontoBruto.Contains("%"))
            {
                decimal pocentagemDesconto = decimal.Parse(descontoBruto.Replace("%", ""));

                valorDesconto =
                    Math.Round(decimal.Divide(decimal.Multiply(pocentagemDesconto, valorTotalProdutos), 100), 2);

                CalcularDescontoPorProduto(valorDesconto, valorTotalProdutos);
            }
            else
            {
                valorDesconto = Math.Round(decimal.Parse(descontoBruto), 2);

                CalcularDescontoPorProduto(valorDesconto, valorTotalProdutos);
            }

            valorTotal = decimal.Subtract(valorTotalProdutos, valorDesconto);

            if (valorDesconto > valorTotal)
            {
                MensagensDoSistema.MensagemAtencaoOk("O valor do desconto excede o valor do produto.");

                txtDesconto.Focus();

                return;
            }

            lblTotalGeral.Text = valorTotal.ToString("C2");

            valorTotalDesconto = valorDesconto;

            txtTotalDesconto.Text = valorTotalDesconto.ToString("C2");

            descontoBruto = txtDesconto.Text;

            descontoBruto = "";
        }

        private void CalcularDescontoPorProduto(decimal valorDesconto, decimal _valorTotalProdutos)
        {
            foreach (var item in uc_PDV.listaProdutoSelecionado)
            {
                //Porcentagem do produto no valor total da venda
                decimal porcentagemProdutoVenda =
                    decimal.Divide(decimal.Multiply((item.vlrUnCom * item.quantidade), 100), _valorTotalProdutos);

                decimal valorDescontoProduto =
                    decimal.Divide(decimal.Multiply(porcentagemProdutoVenda, valorDesconto), 100);
            }
        }

        private void PreencherVendedor()
        {
            try
            {
                using (Session session = new Session())
                {
                    var vendedor = session.Query<tb_ator>()
                        .Where(x => x.at_atorTipo == 100 || x.at_atorTipo == 101 || x.at_atorTipo == 102)
                        .Select(x => new
                        {
                            x.id_ator,
                            x.at_razSoc,
                            x.at_nomeUsuario
                        }).ToList();

                    cmbVendedor.Properties.DataSource = vendedor;
                    cmbVendedor.Properties.DisplayMember = "at_razSoc";
                    cmbVendedor.Properties.ValueMember = "id_ator";
                    cmbVendedor.Properties.NullText = "Selecione o vendedor";

                    cmbVendedor.EditValue = VariaveisGlobais.UsuarioLogado == null
                        ? 0
                        : VariaveisGlobais.UsuarioLogado.id_ator;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher vendedor: {ex.Message}");
            }
        }

        private void PreencherFormaPagamento()
        {
            try
            {
                using (Session session = new Session())
                {
                    var formaPagamento = session.Query<tb_sub_forma_pagamento>()
                        //.Where(x => x.eb_desat == 0)
                        .Select(x => new
                        {
                            x.id_sub_forma_pagamento,
                            x.sfp_desc,
                        }).ToList();

                    cmbFormaPagamento.Properties.DataSource = formaPagamento;
                    cmbFormaPagamento.Properties.DisplayMember = "sfp_desc";
                    cmbFormaPagamento.Properties.ValueMember = "id_sub_forma_pagamento";
                    cmbFormaPagamento.Properties.NullText = "Selecione a forma de pagamento";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher forma pagamento: {ex.Message}");
            }
        }

        private void PreencherCampos()
        {
            decimal valorTotal = 0;
            int quantidadeTotal = 0;

            foreach (var item in uc_PDV.listaProdutoSelecionado)
            {
                valorTotal += (item.quantidade * item.vlrUnCom);

                quantidadeTotal += item.quantidade;

                txtQuantlProduto.Text = quantidadeTotal.ToString();
                lblTotalGeral.Text = valorTotal.ToString("C2");
                txtTotalProduto.Text = valorTotal.ToString("C2");
            }
        }

        private void frmPamentoPDV_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos(e);
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            descontoBruto = txtDesconto.Text;

            if (!string.IsNullOrEmpty(descontoBruto))
            {
                Desconto();
            }
        }

        public class PamentosRealizados
        {
            public int _idPagamento { get; set; }
            public string _pagamentoDescricao { get; set; }
            public decimal _vlrPagamento { get; set; }
        }

        private void btnConfirmarPagamento_Click(object sender, EventArgs e)
        {
            if (cmbVendedor.Text == "Selecione o vendedor")
            {
                MensagensDoSistema.MensagemAtencaoOk("Selecione o vendedor.");

                cmbVendedor.Focus();

                return;
            }

            decimal valorPago = decimal.Parse(txtValorPago.Text.Replace("R$", ""));
            decimal valorTotal = decimal.Parse(lblTotalGeral.Text.Replace("R$", ""));

            if (!string.IsNullOrEmpty(txtValorPagamento.Text) &&
                cmbFormaPagamento.Text != "Selecione a forma de pagamento" && valorPago < valorTotal)
            {
                PreencherGrid();

                PreencherCampoPagamentoRealizado();
            }
        }

        private void PreencherGrid()
        {
            int idPaamento = Convert.ToInt16(cmbFormaPagamento.EditValue);

            string descricaoPagamento = cmbFormaPagamento.Text;

            decimal valorPagamento = decimal.Parse(txtValorPagamento.Text.Replace("R$", ""));

            listaPagamentosRealizados.Add(new PamentosRealizados
            {
                _idPagamento = idPaamento,
                _pagamentoDescricao = descricaoPagamento,
                _vlrPagamento = valorPagamento
            });

            grdPagamentos.DataSource = null;

            grdPagamentos.DataSource = listaPagamentosRealizados;
        }

        private void PreencherCampoPagamentoRealizado()
        {
            decimal valorTotalPago = 0;

            foreach (var item in listaPagamentosRealizados)
            {
                valorTotalPago += item._vlrPagamento;
            }

            txtValorPago.Text = valorTotalPago.ToString("C2");

            txtTroco.Text = Math.Abs(decimal.Parse(lblTotalGeral.Text.Replace("R$", "")) - valorTotalPago)
                .ToString("C2");

            cmbFormaPagamento.Clear();

            txtValorPagamento.Text = "";
        }

        private tb_movimentacao movimentacao;

        private void SalvarMovimentacao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    movimentacao = new tb_movimentacao(uow);

                    movimentacao.mv_nfeTipo = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb;
                    movimentacao.mv_dtCri = DateTime.Now;
                    movimentacao.mv_dtAlt = DateTime.Now;
                    movimentacao.mv_qtdItens = listaProdutoSelecionado.Sum(x => x.quantidade);
                    movimentacao.fk_tb_ator_atend = VariaveisGlobais.UsuarioLogado;
                    movimentacao.fk_tb_ator_emit = VariaveisGlobais.UsuarioLogado;
                    movimentacao.mv_movTipo = Convert.ToByte(SEnMovTipo.VendaNfce150);
                    movimentacao.mv_nfeNatOp = "VENDA DE MERCADORIA ADQUIRIDA OU RECEBIDA DE TERCEIROS";
                    movimentacao.mv_nfeVlrTotProd = listaProdutoSelecionado.Sum(x => x.vlrUnCom);
                    movimentacao.mv_nfeVlrTotDesc = valorDesconto;
                    movimentacao.mv_nfeVlrTotNF = listaProdutoSelecionado.Sum(x => x.vlrUnCom) - valorDesconto;
                    movimentacao.mv_nfeTipo = Convert.ToByte(SEnNfeTipo.Saida1);
                    movimentacao.mv_nfeTipoImpDanfe = Convert.ToByte(SEnNfeTipoImpDanfe.NFCe4);
                    movimentacao.mv_nfeFinEmis = Convert.ToByte(SEnNfeFinEmis.Normal1);
                    movimentacao.mv_nfeIndInterm = Convert.ToByte(SEnNfeIndInterm.SemIntermediador0);
                    movimentacao.mv_nfeIndOpConsumFin = Convert.ToByte(SEnNfeIndOpConsumFin.Final1);
                    movimentacao.mv_nfeIndPresCompEstMomOp = Convert.ToByte(SEnNfeIndPresCompEstMomOp.Presencial1);
                    movimentacao.mv_nfeMod = Convert.ToByte(SEnNfeMod.NFCe65);
                    movimentacao.mv_nfeModFrete = Convert.ToByte(SEnNfeModFrete.SemFrete9);
                    movimentacao.mv_nfeTipoDfe = Convert.ToByte(SEnNfeTipoDfe.NFe0);
                    movimentacao.mv_nfeTipoEmis = Convert.ToByte(SEnNfeTipoEmis.Normal1);
                    movimentacao.mv_nfeCfop = SEnNfeCfop.CompraPComercializacao1102.ToString();
                    movimentacao.mv_vlrTotPag = listaProdutoSelecionado.Sum(x => x.vlrUnCom) - valorDesconto;

                    uow.Save(movimentacao);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao salvar movimentação: {ex.Message}");
            }
        }

        private void SalvarMovimentacaoPagamento()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    foreach (var item in listaPagamentosRealizados)
                    {
                        tb_sub_forma_pagamento subFormaPagamento =
                            uow.GetObjectByKey<tb_sub_forma_pagamento>(item._idPagamento);

                        tb_movimentacao_pagamento movimentacaoPagamento = new tb_movimentacao_pagamento(uow);

                        movimentacaoPagamento.mpg_dtCri = DateTime.Now;
                        movimentacaoPagamento.mpg_dtAlt = DateTime.Now;
                        movimentacaoPagamento.mpg_nfeVlrPag = item._vlrPagamento;
                        movimentacaoPagamento.fk_tb_movimentacao = movimentacao;
                        movimentacaoPagamento.fk_tb_sub_forma_pagamento = subFormaPagamento;

                        uow.Save(movimentacaoPagamento);
                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao salvar movimentação pagamento: {ex.Message}");
            }
        }

        private void AlterarEstoqueProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    foreach (var item in listaProdutoSelecionado)
                    {
                        tb_produto_filial produtoFilial = uow.GetObjectByKey<tb_produto_filial>(item.idProdutoFilial);

                        produtoFilial.pf_est = produtoFilial.pf_est - item.quantidade;

                        tb_produto produto = uow.GetObjectByKey<tb_produto>(produtoFilial.fk_tb_produto.id_produto);

                        produto.pd_estTot = produto.pd_estTot - item.quantidade;

                        uow.Save(produtoFilial);
                        uow.Save(produto);
                    }

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                {
                    MensagensDoSistema.MensagemErroOk($"Alterar estoque de produto: {ex.Message}");
                }
            }
        }

        private tb_nfe SxNfe;

        private void teun()
        {
            //SxNfe.nf_desat = 0;
            //SxNfe.nf_dtCri = DateTime.Now;
            //SxNfe.nf_dtAlt = DateTime.Now;
            //SxNfe.fk_tb_movimentacao = movimentacao;
            //SxNfe.nf_nfeServico = 0;
            //SxNfe.nf_prontoEnviar = 0;
            //SxNfe.nf_nfeTipoAmb = Convert.ToByte(VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao);
            //SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
            //SxNfe.nf_nfeTipoDfe_ImpXml = Convert.ToByte(SEnNfeTipoDfe.nd255);
            //SxNfe.nf_nfeVlrTotNF_ImpXml = autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF;
            //SxNfe.nf_nfe1CStat = autorizacao.Result.CStat;
            //SxNfe.nf_nfe1XMotivo = autorizacao.Result.XMotivo;
            //SxNfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
            //SxNfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
            //SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
            //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe?.InfProt?.CStat;
            //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
            //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
            //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
            //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe?.InfProt?.DhRecbto.DateTime;
            //SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
            //SxNfe.nf_nfeBcIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBC);
            //SxNfe.nf_nfeVlrTotIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMS);
            //SxNfe.nf_nfeVlrIcmsDeson_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson);
            //SxNfe.nf_nfeVlrTotIcmsFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPUFDest);
            //SxNfe.nf_nfeVlrTotIcmsInterUfDest_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFDest);
            //SxNfe.nf_nfeVlrTotIcmsInterUfRem_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFRemet);
            //SxNfe.nf_nfeVlrTotFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCP);
            //SxNfe.nf_nfeVlrBcIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBCST);
            //SxNfe.nf_nfeVlrTotIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VST);
            //SxNfe.nf_nfeVlrTotFcpSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPST);
            //SxNfe.nf_nfeVlrTotFcpRetSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPSTRet);
            //SxNfe.nf_nfeVlrTotProd_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VProd);
            //SxNfe.nf_nfeVlrTotFrete_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFrete);
            //SxNfe.nf_nfeVlrTotFrete_ImpXml = nfe.SNfeVlrTotFrete_ImpXml;
            //SxNfe.nf_nfeVlrTotSeg_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VSeg);
            //SxNfe.nf_nfeVlrTotDesc_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VDesc);
            //SxNfe.nf_nfeVlrTotImpImp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VII);
            //SxNfe.nf_nfeVlrTotIpi_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPI);
            //SxNfe.nf_nfeVlrTotIpiDevol_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol);
            //SxNfe.nf_nfeVlrTotPis_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VPIS);
            //SxNfe.nf_nfeVlrTotCofins_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS);
            //SxNfe.nf_nfeVlrTotOutro_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VOutro);
            //SxNfe.nf_nfeVlrTotTrib_ImpXml = 0;    // Convert.ToDecimal(n.Total.ICMSTot.VTotTrib);
            //SxNfe.nf_nfe1DhRecbto = aut.Result?.DhRecbto.DateTime;
            //SxNfe.nf_nfe1CStat = aut.Result?.CStat;
            //SxNfe.nf_nfe1XMotivo = aut.Result?.XMotivo;
            //SxNfe.nf_nfe1RetornoWSString = aut.RetornoWSString;
            //SxNfe.nf_nfe1WSXMLInnerText = aut.RetornoWSXML.InnerText;
            //SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = aut.ConteudoXMLOriginal.OuterXml;
            //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = aut.Result.ProtNFe?.InfProt?.CStat;
            //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = aut.Result.ProtNFe?.InfProt?.ChNFe;
            //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = aut.Result.ProtNFe?.InfProt?.NProt;
            //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = aut.Result.ProtNFe?.InfProt?.XMotivo;
            //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = aut.Result.ProtNFe?.InfProt?.DhRecbto.DateTime;
            //SxNfe.nf_nfe2ConteudoXMLOuterXml = retAutorizacao.ConteudoXMLOriginal.OuterXml;
            //SxNfe.nf_nfe2RetornoWSString = retAutorizacao.RetornoWSString;
            //SxNfe.nf_nfe2RetornoWSXMLInnerText = retAutorizacao.RetornoWSXML.InnerText;
            //SxNfe.nf_nfe2ResCStat = retAutorizacao.Result.CStat;
            //SxNfe.nf_nfe2ResDhRecbto = retAutorizacao.Result.DhRecbto.DateTime;
            //SxNfe.nf_nfe2ResNRec = retAutorizacao.Result.NRec;
            //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = retAutorizacao.Result.ProtNFe[0].InfProt?.CStat;
            //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = retAutorizacao.Result.ProtNFe[0].InfProt?.ChNFe;
            //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = retAutorizacao.Result.ProtNFe[0].InfProt?.NProt;
            //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = retAutorizacao.Result.ProtNFe[0].InfProt?.XMotivo;
            //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = retAutorizacao.Result.ProtNFe[0].InfProt?.DhRecbto.DateTime;

            //SxNfe.nf_nfeXmlProcRes = aut.NfeProcResults[aut.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;

            //serie = (short)aut.NfeProcResults[SxNfe.SNfe1ResProtNFeInfProt0ChNFe].NFe.InfNFe[0].Ide.Serie;
            //nnf = aut.NfeProcResults[SxNfe.SNfe1ResProtNFeInfProt0ChNFe].NFe.InfNFe[0].Ide.NNF;

            //SxNfe.nf_nfeSerie = serie;
            //SxNfe.nf_nfeNum = nnf;
        }

        private void teste()
        {
            SalvarMovimentacao();

            SalvarMovimentacaoPagamento();

            AlterarEstoqueProduto();

            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var item in listaProdutoSelecionado)
                {
                    //Porcentagem do produto no valor total da venda
                    decimal porcentagemProdutoVenda = decimal.Divide(decimal.Multiply((item.vlrUnCom * item.quantidade), 100), item.vlrUnCom);

                    decimal valorDescontoProduto = decimal.Divide(decimal.Multiply(porcentagemProdutoVenda, valorDesconto), 100);

                    tb_produto_filial produtoFilial = uow.GetObjectByKey<tb_produto_filial>(item.idProdutoFilial);

                    tb_produto produto = uow.GetObjectByKey<tb_produto>(produtoFilial.fk_tb_produto.id_produto);

                    tb_movimentacao_produto movimentacaoProduto = new tb_movimentacao_produto(uow);

                    movimentacaoProduto.mp_desc = produtoFilial.pf_desc;
                    movimentacaoProduto.mp_descCurta = produtoFilial.pf_descCurta;
                    movimentacaoProduto.mp_dtAlt = DateTime.Now;
                    movimentacaoProduto.mp_dtCri = DateTime.Now;
                    movimentacaoProduto.mp_qtdCom = item.quantidade;
                    movimentacaoProduto.mp_vlrUnCom = item.vlrUnCom;
                    movimentacaoProduto.mp_vlrProdTot = item.quantidade * item.vlrUnCom;
                    movimentacaoProduto.mp_vlrDesc = valorDescontoProduto;
                    movimentacaoProduto.mp_nfeCfop = 5102;
                    movimentacaoProduto.fk_tb_atorAtend = VariaveisGlobais.UsuarioLogado;
                    movimentacaoProduto.fk_tb_produto = produto;
                    movimentacaoProduto.fk_tb_movimentacao = movimentacao;

                    uow.Save(movimentacaoProduto);
                }

                uow.CommitChanges();
            }
        }

        private tb_ator dadosEmitente;

        private tb_pdv dadosPDV;

        private int numeroNota = 0;
        private int serie = 0;

        public X509Certificate2 CarregarCertificadoDoBanco()
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

        private void PegarNumeroNota()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    dadosPDV = uow.Query<tb_pdv>().FirstOrDefault(x => x.id_pdv == VariaveisGlobais.PDVLogado.id_pdv);

                    if (VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1)
                    {
                        numeroNota = Convert.ToInt32(dadosPDV.pdv_nfeProdNum + 1);

                        serie = dadosPDV.pdv_nfeProdSerie;
                    }
                    else
                    {
                        numeroNota = Convert.ToInt32(dadosPDV.pdv_nfeHomNum + 1);

                        serie = dadosPDV.pdv_nfeHomSerie;
                    }

                    dadosPDV.pdv_nfeProdNum = numeroNota;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao pegar os dados do PDV." + ex.Message);
            }
        }

        private void PreencherCampoEmitente()
        {
            try
            {
                long idPDV = VariaveisGlobais.PDVLogado.fk_tb_ator.id_ator;

                using (UnitOfWork uow = new UnitOfWork())
                {
                    dadosEmitente = uow.Query<tb_ator>().FirstOrDefault(x => x.id_ator == idPDV);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao preencher os dados do emitente." + ex.Message);
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            PegarNumeroNota();

            PreencherCampoEmitente();

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
                                Ide = new XmlNFe.Ide
                                {
                                    CUF = (Unimake.Business.DFe.Servicos.UFBrasil)Enum.Parse(typeof(Unimake.Business.DFe.Servicos.UFBrasil), dadosEmitente.fk_tb_estados_br.eb_id.ToString()),
                                    NatOp = "VENDA DE MERCADORIA ADQUIRIDA OU RECEBIDA DE TERCEIROS",
                                    Mod = ModeloDFe.NFCe,
                                    Serie = 99,
                                    NNF = numeroNota,
                                    DhEmi = DateTime.Now,
                                    DhSaiEnt = DateTime.Now,
                                    TpNF = TipoOperacao.Saida,
                                    IdDest = DestinoOperacao.OperacaoInterna,
                                    CMunFG =  Convert.ToInt32(dadosEmitente.fk_tb_municipio.mu_id),
                                    TpImp = FormatoImpressaoDANFE.NFCe,
                                    TpEmis = TipoEmissao.Normal,
                                    TpAmb = VariaveisGlobais.FilialLogada.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao,
                                    FinNFe = FinalidadeNFe.Normal,
                                    IndFinal = SimNao.Sim,
                                    IndPres = IndicadorPresenca.OperacaoPresencial,
                                    ProcEmi = ProcessoEmissao.AplicativoContribuinte,
                                    VerProc = "TESTE 1.00"
                                },

                                Emit = new XmlNFe.Emit
                                {
                                    CNPJ = Regex.Replace(dadosEmitente.at_cnpj, @"[^\d]", ""),
                                    XNome = dadosEmitente.at_razSoc,
                                    XFant = dadosEmitente.at_nomeFant,
                                    EnderEmit = new XmlNFe.EnderEmit
                                    {
                                        XLgr = dadosEmitente.at_end_Logr,
                                        Nro = dadosEmitente.at_end_Num,
                                        XBairro = dadosEmitente.at_end_Bairro,
                                        CMun = Convert.ToInt32(dadosEmitente.fk_tb_municipio.mu_id),
                                        XMun = dadosEmitente.fk_tb_estados_br.eb_nome,
                                        UF = (Unimake.Business.DFe.Servicos.UFBrasil)Enum.Parse(typeof(Unimake.Business.DFe.Servicos.UFBrasil), dadosEmitente.fk_tb_estados_br.eb_id.ToString()),
                                        CEP = dadosEmitente.at_end_Cep.Replace("-", ""),
                                        Fone = dadosEmitente.at_telFixo
                                    },
                                    IE = dadosEmitente.at_inscEst,
                                    IM = dadosEmitente.at_inscMun,
                                    CNAE = Regex.Replace(dadosEmitente.at_cnae, @"[^\d]", ""),
                                    CRT = CRT.SimplesNacional
                                },
                //Det = new List<XmlNFe.Det> {
                //    new XmlNFe.Det
                //    {
                //        NItem = 1,
                //        Prod = new XmlNFe.Prod
                //        {
                //            CProd = "01042",
                //            CEAN = "SEM GTIN",
                //            XProd = "NOTA FISCAL EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
                //            NCM = "84714900",
                //            CFOP = "5101",
                //            UCom = "LU",
                //            QCom = 1.00m,
                //            VUnCom = 84.9000000000M,
                //            VProd = 84.90,
                //            CEANTrib = "SEM GTIN",
                //            UTrib = "LU",
                //            QTrib = 1.00m,
                //            VUnTrib = 84.9000000000M,
                //            IndTot = SimNao.Sim,
                //            XPed = "300474",
                //            NItemPed = "1"
                //        },
                //        Imposto = new XmlNFe.Imposto
                //        {
                //            VTotTrib = 12.63,
                //            ICMS = new XmlNFe.ICMS
                //            {
                //                ICMSSN102 = new XmlNFe.ICMSSN102
                //                {
                //                    Orig = OrigemMercadoria.Nacional,
                //                    CSOSN = "102"
                //                }
                //            },
                //            PIS = new XmlNFe.PIS
                //            {
                //                PISOutr = new XmlNFe.PISOutr
                //                {
                //                    CST = "99",
                //                    VBC = 0.00,
                //                    PPIS = 0.00,
                //                    VPIS = 0.00
                //                }
                //            },
                //            COFINS = new XmlNFe.COFINS
                //            {
                //                COFINSOutr = new XmlNFe.COFINSOutr
                //                {
                //                    CST = "99",
                //                    VBC = 0.00,
                //                    PCOFINS = 0.00,
                //                    VCOFINS = 0.00
                //                }
                //            }
                //        }
                //    }
                //},

                Total = new XmlNFe.Total
                {
                    ICMSTot = new XmlNFe.ICMSTot
                    {
                        VBC = 0,
                        VICMS = 0,
                        VICMSDeson = 0,
                        VFCP = 0,
                        VBCST = 0,
                        VST = 0,
                        VFCPST = 0,
                        VFCPSTRet = 0,
                        VProd = 84.90,
                        VFrete = 0,
                        VSeg = 0,
                        VDesc = 0,
                        VII = 0,
                        VIPI = 0,
                        VIPIDevol = 0,
                        VPIS = 0,
                        VCOFINS = 0,
                        VOutro = 0,
                        VNF = 84.90,
                        VTotTrib = 12.63
                    }
                },
                                Transp = new XmlNFe.Transp
                                {
                                    ModFrete = ModalidadeFrete.SemOcorrenciaTransporte
                                },
                                //Cobr = new XmlNFe.Cobr()
                                //{
                                //    Fat = new XmlNFe.Fat
                                //    {
                                //        NFat = "057910",
                                //        VOrig = 84.90,
                                //        VDesc = 0,
                                //        VLiq = 84.90
                                //    },
                                //    Dup = new List<XmlNFe.Dup>
                                //    {
                                //        new XmlNFe.Dup
                                //        {
                                //            NDup = "001",
                                //            DVenc = DateTime.Now,
                                //            VDup = 84.90
                                //        }
                                //    }
                                //},
                                Pag = new XmlNFe.Pag
                                {
                                    DetPag = new List<XmlNFe.DetPag>
                                    {
                                            new XmlNFe.DetPag
                                            {
                                                IndPag = IndicadorPagamento.PagamentoVista,
                                                TPag = MeioPagamento.PagamentoInstantaneo,
                                                VPag = 84.90,
                                                Card = new Card()
                                                {
                                                    TpIntegra = TipoIntegracaoPagamento.PagamentoNaoIntegrado
                                                }
                                            }
                                    }
                                },
                                InfAdic = new XmlNFe.InfAdic
                                {
                                    InfCpl = ";CONTROLE: 0000241197;PEDIDO(S) ATENDIDO(S): 300474;Empresa optante pelo simples nacional, conforme lei compl. 128 de 19/12/2008;Permite o aproveitamento do credito de ICMS no valor de R$ 2,40, correspondente ao percentual de 2,83% . Nos termos do Art. 23 - LC 123/2006 (Resolucoes CGSN n. 10/2007 e 53/2008);Voce pagou aproximadamente: R$ 6,69 trib. federais / R$ 5,94 trib. estaduais / R$ 0,00 trib. municipais. Fonte: IBPT/empresometro.com.br 18.2.B A3S28F;",
                                },
                                InfRespTec = new XmlNFe.InfRespTec
                                {
                                    CNPJ = "06117473000150",
                                    XContato = "Wandrey Mundin Ferreira",
                                    Email = "wandrey@unimake.com.br",
                                    Fone = "04431414900"
                                }
                            }
    }
    }
}
                };

                var CertificadoSelecionado = CarregarCertificadoDoBanco();

                var configuracao = new Configuracao
                {
                    TipoDFe = TipoDFe.NFCe,
                    CertificadoDigital = CertificadoSelecionado,

                    CSC = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? dadosEmitente.at_nfeCscTokenProd : dadosEmitente.at_nfeCscTokenHom,
                    CSCIDToken = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? Convert.ToInt32(dadosEmitente.at_nfeCscIdProd) : Convert.ToInt32(dadosEmitente.at_nfeCscIdHom)
                };

                var autorizacao = new ServicoNFCe.Autorizacao(xml, configuracao);
                autorizacao.Executar();

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

                            MessageBox.Show(autorizacao.NfeProcResult.NomeArquivoDistribuicao);

                            break;

                        default:
                            //NF Rejeitada
                            break;
                    }
                }

                var config = new DANFe.Configurations.UnidanfeConfiguration
                {
                    Arquivo = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml,
                    Visualizar = true,
                    Imprimir = false,
                    EnviaEmail = false,
                    Configuracao = "PAISAGEM"
                };

                DANFe.UnidanfeServices.Execute(config);

                if (autorizacao.Result.ProtNFe.InfProt.CStat == 100)
                {
                    teste();
                }

                //---------------------------------------------------------------------------------------------------------------------------------------

                SxNfe.nf_desat = 0;
                SxNfe.nf_dtCri = DateTime.Now;
                SxNfe.nf_dtAlt = DateTime.Now;
                SxNfe.fk_tb_movimentacao = movimentacao;
                SxNfe.nf_nfeServico = 0;
                SxNfe.nf_prontoEnviar = 0;
                SxNfe.nf_nfeTipoAmb = Convert.ToByte(VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao);
                SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                SxNfe.nf_nfeTipoDfe_ImpXml = Convert.ToByte(SEnNfeTipoDfe.nd255);
                SxNfe.nf_nfeVlrTotNF_ImpXml = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF);
                SxNfe.nf_nfe1CStat = autorizacao.Result.CStat;
                SxNfe.nf_nfe1XMotivo = autorizacao.Result.XMotivo;
                SxNfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                SxNfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                SxNfe.nf_nfe1ResProtNFeInfProt0CStat = Convert.ToInt64(autorizacao.Result.ProtNFe?.InfProt?.CStat);
                SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = Convert.ToDateTime(autorizacao.Result.ProtNFe?.InfProt?.DhRecbto.DateTime);
                SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                //SxNfe.nf_nfeBcIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBC);
                //SxNfe.nf_nfeVlrTotIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMS);
                //SxNfe.nf_nfeVlrIcmsDeson_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson);
                //SxNfe.nf_nfeVlrTotIcmsFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPUFDest);
                //SxNfe.nf_nfeVlrTotIcmsInterUfDest_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFDest);
                //SxNfe.nf_nfeVlrTotIcmsInterUfRem_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFRemet);
                //SxNfe.nf_nfeVlrTotFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCP);
                //SxNfe.nf_nfeVlrBcIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBCST);
                //SxNfe.nf_nfeVlrTotIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VST);
                //SxNfe.nf_nfeVlrTotFcpSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPST);
                //SxNfe.nf_nfeVlrTotFcpRetSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPSTRet);
                //SxNfe.nf_nfeVlrTotProd_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VProd);
                //SxNfe.nf_nfeVlrTotFrete_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFrete);
                //SxNfe.nf_nfeVlrTotFrete_ImpXml = nfe.SNfeVlrTotFrete_ImpXml;
                //SxNfe.nf_nfeVlrTotSeg_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VSeg);
                //SxNfe.nf_nfeVlrTotDesc_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VDesc);
                //SxNfe.nf_nfeVlrTotImpImp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VII);
                //SxNfe.nf_nfeVlrTotIpi_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPI);
                //SxNfe.nf_nfeVlrTotIpiDevol_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol);
                //SxNfe.nf_nfeVlrTotPis_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VPIS);
                //SxNfe.nf_nfeVlrTotCofins_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS);
                //SxNfe.nf_nfeVlrTotOutro_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VOutro);
                SxNfe.nf_nfeVlrTotTrib_ImpXml = 0;    // Convert.ToDecimal(n.Total.ICMSTot.VTotTrib);
                SxNfe.nf_nfe1DhRecbto = autorizacao.Result.DhRecbto.DateTime;
                SxNfe.nf_nfe1CStat = Convert.ToInt32(autorizacao.Result?.CStat);
                SxNfe.nf_nfe1XMotivo = autorizacao.Result?.XMotivo;
                SxNfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                SxNfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                SxNfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;
                SxNfe.nf_nfe2ConteudoXMLOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                SxNfe.nf_nfe2RetornoWSString = autorizacao.RetornoWSString;
                SxNfe.nf_nfe2RetornoWSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                SxNfe.nf_nfe2ResCStat = autorizacao.Result.CStat;
                SxNfe.nf_nfe2ResDhRecbto = autorizacao.Result.DhRecbto.DateTime;
                //SxNfe.nf_nfe2ResNRec = autorizacao.Result.NRec;
                SxNfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe.InfProt.ChNFe;
                SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe.InfProt.NProt;
                SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe.InfProt.XMotivo;
                SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;

                SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;

                SxNfe.nf_nfeSerie = Convert.ToInt16(serie);
                SxNfe.nf_nfeNum = numeroNota;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}