using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationPDV.Classes;
using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;
using static DXApplicationPDV.uc_PDV;

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

        //private decimal valorTotal = 0;

        //private decimal valorTotalDesconto = 0;

        public void Desconto()
        {
            decimal valorTotalProdutos = 0;

            decimal valorTotal = 0;

            decimal valorTotalDesconto = 0;

            decimal valorDesconto = 0;

            foreach (var item in uc_PDV.listaProdutoSelecionado)
            {
                valorTotalProdutos += item.vlrUnCom * item.quantidade;
            }

            if (descontoBruto.Contains("%"))
            {
                decimal pocentagemDesconto = decimal.Parse(descontoBruto.Replace("%", ""));

                valorDesconto = Math.Round(decimal.Divide(decimal.Multiply(pocentagemDesconto, valorTotalProdutos), 100), 2);

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
                decimal porcentagemProdutoVenda = decimal.Divide(decimal.Multiply((item.vlrUnCom * item.quantidade), 100), _valorTotalProdutos);

                decimal valorDescontoProduto = decimal.Divide(decimal.Multiply(porcentagemProdutoVenda, valorDesconto), 100);
            }
        }

        private void PreencherVendedor()
        {
            try
            {
                using (Session session = new Session())
                {
                    var formaPagamento = session.Query<tb_ator>()
                        .Where(x => x.at_atorTipo == 100 || x.at_atorTipo == 101 || x.at_atorTipo == 102)
                        .Select(x => new
                        {
                            x.id_ator,
                            x.at_razSoc,
                            x.at_nomeUsuario
                        }).ToList();

                    cmbVendedor.Properties.DataSource = formaPagamento;
                    cmbVendedor.Properties.DisplayMember = "at_razSoc";
                    cmbVendedor.Properties.ValueMember = "id_ator";
                    cmbVendedor.Properties.NullText = "Selecione o vendedor";
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

            if (!string.IsNullOrEmpty(txtValorPagamento.Text) && cmbFormaPagamento.Text != "Selecione a forma de pagamento" && valorPago < valorTotal)
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

            listaPagamentosRealizados.Add(new PamentosRealizados { _idPagamento = idPaamento, _pagamentoDescricao = descricaoPagamento, _vlrPagamento = valorPagamento });

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

            txtTroco.Text = Math.Abs(decimal.Parse(lblTotalGeral.Text.Replace("R$", "")) - valorTotalPago).ToString("C2");

            cmbFormaPagamento.Clear();

            txtValorPagamento.Text = "";
        }
    }
}