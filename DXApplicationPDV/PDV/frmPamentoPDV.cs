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
                    tb_ator usuarioLogado = uow.GetObjectByKey<tb_ator>(VariaveisGlobais.UsuarioLogado.id_ator);

                    tb_ator filialLogada = uow.GetObjectByKey<tb_ator>(VariaveisGlobais.FilialLogada.id_ator);

                    movimentacao = new tb_movimentacao(uow);

                    movimentacao.mv_nfeTipo = VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb;
                    movimentacao.mv_dtCri = DateTime.Now;
                    movimentacao.mv_dtAlt = DateTime.Now;
                    movimentacao.mv_qtdItens = listaProdutoSelecionado.Sum(x => x.quantidade);
                    movimentacao.fk_tb_ator_atend = usuarioLogado;
                    movimentacao.fk_tb_ator_emit = filialLogada;
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

        private List<long> idMovimentoPagamento = new List<long>();

        private void SalvarMovimentacaoPagamento()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    foreach (var item in listaPagamentosRealizados)
                    {
                        tb_sub_forma_pagamento subFormaPagamento =
                            uow.GetObjectByKey<tb_sub_forma_pagamento>(Convert.ToInt64(item._idPagamento));

                        tb_movimentacao _movimentacao =
                            uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(movimentacao.id_movimentacao));

                        tb_movimentacao_pagamento movimentacaoPagamento = new tb_movimentacao_pagamento(uow);

                        movimentacaoPagamento.mpg_dtCri = DateTime.Now;
                        movimentacaoPagamento.mpg_dtAlt = DateTime.Now;
                        movimentacaoPagamento.mpg_nfeVlrPag = item._vlrPagamento;
                        movimentacaoPagamento.fk_tb_movimentacao = _movimentacao;
                        movimentacaoPagamento.fk_tb_sub_forma_pagamento = subFormaPagamento;

                        uow.Save(movimentacaoPagamento);
                        uow.CommitChanges();

                        idMovimentoPagamento.Add(movimentacaoPagamento.id_movimentacao_pagamento);
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

        private List<long> idMovimentacaoProdutos = new List<long>();

        private void teste()
        {
            SalvarMovimentacao();

            SalvarMovimentacaoPagamento();

            //AlterarEstoqueProduto();

            using (UnitOfWork uow = new UnitOfWork())
            {
                foreach (var item in listaProdutoSelecionado)
                {
                    short cont = 1;

                    //Porcentagem do produto no valor total da venda
                    decimal porcentagemProdutoVenda =
                        decimal.Divide(decimal.Multiply((item.vlrUnCom * item.quantidade), 100), item.vlrUnCom);

                    decimal valorDescontoProduto =
                        decimal.Divide(decimal.Multiply(porcentagemProdutoVenda, valorDesconto), 100);

                    tb_produto_filial produtoFilial =
                        uow.GetObjectByKey<tb_produto_filial>(Convert.ToInt64(item.idProdutoFilial));

                    tb_produto produto = uow.GetObjectByKey<tb_produto>(produtoFilial.fk_tb_produto.id_produto);

                    tb_movimentacao _movimentacao =
                        uow.GetObjectByKey<tb_movimentacao>(Convert.ToInt64(movimentacao.id_movimentacao));

                    tb_ator usuarioLogado = uow.GetObjectByKey<tb_ator>(VariaveisGlobais.UsuarioLogado.id_ator);

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
                    movimentacaoProduto.mp_numItem = cont;
                    movimentacaoProduto.mp_unMedCom = produto.pd_unMedCom;
                    movimentacaoProduto.fk_tb_atorAtend = usuarioLogado;
                    movimentacaoProduto.fk_tb_produto = produto;
                    movimentacaoProduto.fk_tb_movimentacao = _movimentacao;

                    uow.Save(movimentacaoProduto);
                    uow.CommitChanges();

                    idMovimentacaoProdutos.Add(movimentacaoProduto.id_movimentacao_produto);

                    cont++;
                }
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

        private Ide CampoIdeXml()
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

        private Emit CampoEmitXml()
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

        private List<Det> CampoDetXml()
        {
            //List<Det> SGetDets()
            //{
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
            //}
            //return null;
        }

        private Total CampoTotalXml()
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

        private Transp CampoTranspXml()
        {
            Transp transp = new Transp();
            transp.ModFrete = ModalidadeFrete.SemOcorrenciaTransporte;

            return transp;
        }

        private Pag CampoPagXml()
        {
            Pag pag = new Pag();
            pag.DetPag = new List<DetPag>();

            foreach (var item in idMovimentoPagamento)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao_pagamento movimentacaoPagamento =
                        uow.GetObjectByKey<tb_movimentacao_pagamento>(Convert.ToInt64(item));

                    DetPag detPag = new DetPag();

                    detPag.IndPag = IndicadorPagamento.PagamentoVista;
                    detPag.TPag = (MeioPagamento)(int)movimentacaoPagamento.fk_tb_sub_forma_pagamento
                        .fk_tb_forma_pagamento.fp_nfeTipoPag;
                    detPag.VPag = Convert.ToDouble(movimentacaoPagamento.mpg_nfeVlrPag);

                    pag.DetPag.Add(detPag);
                }
            }

            return pag;
        }

        private InfAdic CampoInfAdicXml()
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

        private InfRespTec CampoInfRespTecXml()
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

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            teste();

            PegarNumeroNota();

            PreencherCampoEmitente();

            string cpfNaNota = "";

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
                    //teste();
                }

                //---------------------------------------------------------------------------------------------------------------------------------------

                //SxNfe.nf_desat = 0;
                //SxNfe.nf_dtCri = DateTime.Now;
                //SxNfe.nf_dtAlt = DateTime.Now;
                //SxNfe.fk_tb_movimentacao = movimentacao;
                //SxNfe.nf_nfeServico = 0;
                //SxNfe.nf_prontoEnviar = 0;
                //SxNfe.nf_nfeTipoAmb = Convert.ToByte(VariaveisGlobais.UsuarioLogado.at_nfeTipoAmb == 1 ? TipoAmbiente.Producao : TipoAmbiente.Homologacao);
                //SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                //SxNfe.nf_nfeTipoDfe_ImpXml = Convert.ToByte(SEnNfeTipoDfe.nd255);
                //SxNfe.nf_nfeVlrTotNF_ImpXml = Convert.ToDecimal(autorizacao.EnviNFe.NFe[0].InfNFe[0].Total.ICMSTot.VNF);
                //SxNfe.nf_nfe1CStat = autorizacao.Result.CStat;
                //SxNfe.nf_nfe1XMotivo = autorizacao.Result.XMotivo;
                //SxNfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                //SxNfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                //SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = Convert.ToInt64(autorizacao.Result.ProtNFe?.InfProt?.CStat);
                //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = Convert.ToDateTime(autorizacao.Result.ProtNFe?.InfProt?.DhRecbto.DateTime);
                //SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;
                ////SxNfe.nf_nfeBcIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBC);
                ////SxNfe.nf_nfeVlrTotIcms_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMS);
                ////SxNfe.nf_nfeVlrIcmsDeson_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSDeson);
                ////SxNfe.nf_nfeVlrTotIcmsFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPUFDest);
                ////SxNfe.nf_nfeVlrTotIcmsInterUfDest_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFDest);
                ////SxNfe.nf_nfeVlrTotIcmsInterUfRem_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VICMSUFRemet);
                ////SxNfe.nf_nfeVlrTotFcp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCP);
                ////SxNfe.nf_nfeVlrBcIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VBCST);
                ////SxNfe.nf_nfeVlrTotIcmsSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VST);
                ////SxNfe.nf_nfeVlrTotFcpSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPST);
                ////SxNfe.nf_nfeVlrTotFcpRetSt_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFCPSTRet);
                ////SxNfe.nf_nfeVlrTotProd_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VProd);
                ////SxNfe.nf_nfeVlrTotFrete_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VFrete);
                ////SxNfe.nf_nfeVlrTotFrete_ImpXml = nfe.SNfeVlrTotFrete_ImpXml;
                ////SxNfe.nf_nfeVlrTotSeg_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VSeg);
                ////SxNfe.nf_nfeVlrTotDesc_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VDesc);
                ////SxNfe.nf_nfeVlrTotImpImp_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VII);
                ////SxNfe.nf_nfeVlrTotIpi_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPI);
                ////SxNfe.nf_nfeVlrTotIpiDevol_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VIPIDevol);
                ////SxNfe.nf_nfeVlrTotPis_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VPIS);nf_nfeNum
                ////SxNfe.nf_nfeVlrTotCofins_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VCOFINS);
                ////SxNfe.nf_nfeVlrTotOutro_ImpXml = Convert.ToDecimal(n.Total.ICMSTot.VOutro);
                //SxNfe.nf_nfeVlrTotTrib_ImpXml = 0;    // Convert.ToDecimal(n.Total.ICMSTot.VTotTrib);
                //SxNfe.nf_nfe1DhRecbto = autorizacao.Result.DhRecbto.DateTime;
                //SxNfe.nf_nfe1CStat = Convert.ToInt32(autorizacao.Result?.CStat);
                //SxNfe.nf_nfe1XMotivo = autorizacao.Result?.XMotivo;
                //SxNfe.nf_nfe1RetornoWSString = autorizacao.RetornoWSString;
                //SxNfe.nf_nfe1WSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                //SxNfe.nf_nfe1ConteudoXMLOriginalOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe?.InfProt?.ChNFe;
                //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe?.InfProt?.NProt;
                //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe?.InfProt?.XMotivo;
                //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;
                //SxNfe.nf_nfe2ConteudoXMLOuterXml = autorizacao.ConteudoXMLOriginal.OuterXml;
                //SxNfe.nf_nfe2RetornoWSString = autorizacao.RetornoWSString;
                //SxNfe.nf_nfe2RetornoWSXMLInnerText = autorizacao.RetornoWSXML.InnerText;
                //SxNfe.nf_nfe2ResCStat = autorizacao.Result.CStat;
                //SxNfe.nf_nfe2ResDhRecbto = autorizacao.Result.DhRecbto.DateTime;
                ////SxNfe.nf_nfe2ResNRec = autorizacao.Result.NRec;
                //SxNfe.nf_nfe1ResProtNFeInfProt0CStat = autorizacao.Result.ProtNFe.InfProt.CStat;
                //SxNfe.nf_nfe1ResProtNFeInfProt0ChNFe = autorizacao.Result.ProtNFe.InfProt.ChNFe;
                //SxNfe.nf_nfe1ResProtNFeInfProt0NProt = autorizacao.Result.ProtNFe.InfProt.NProt;
                //SxNfe.nf_nfe1ResProtNFeInfProt0XMotivo = autorizacao.Result.ProtNFe.InfProt.XMotivo;
                //SxNfe.nf_nfe1ResProtNFeInfProt0DhRecbto = autorizacao.Result.ProtNFe.InfProt.DhRecbto.DateTime;

                //SxNfe.nf_nfeXmlProcRes = autorizacao.NfeProcResults[autorizacao.EnviNFe.NFe[0].InfNFe[0].Chave].GerarXML().OuterXml;

                //SxNfe.nf_nfeSerie = Convert.ToInt16(serie);
                //SxNfe.nf_nfeNum = numeroNota;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }
}