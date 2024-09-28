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
using DXApplicationPDV.AberturaCaixa;
using DXApplicationPDV.FechamentoCaixa;
using DXApplicationPDV.Fluxo_de_Caixa.Entrada_Caixa;
using DXApplicationPDV.Fluxo_de_Caixa.Saida_Caixa;
using DevExpress.XtraBars.FluentDesignSystem;
using DXApplicationPDV.Caixa.Relatorios;
using DXApplicationPDV.Consultas.Itens.Consumidores;
using DXApplicationPDV.Consultas.Itens.Produtos;

namespace DXApplicationPDV
{
    public partial class frmTelaInicial : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTelaInicial()
        {
            InitializeComponent();

            // Deixar o Ribbon fixo, sem a opção de minimizar
            //ribbonControl1.AllowMinimizeRibbon = false;

            // Expandir o RibbonControl
            ribbonControl1.Minimized = false;

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (VariaveisGlobais.FilialLogada != null && VariaveisGlobais.PDVLogado != null)
            {
                barStatusFilail.Caption = $"C.N.P.J: {VariaveisGlobais.FilialLogada.at_cnpj} - Filial: {VariaveisGlobais.FilialLogada.at_nomeFant}";
                barStatusPDV.Caption = $"PDV: {VariaveisGlobais.PDVLogado.pdv_pdvNum}";
            }
            barStatusVendedor.Caption = $"Vendedor: {VariaveisGlobais.UsuarioLogado.at_razSoc}";
            barStatusUsuario.Caption = $"Usuário: {VariaveisGlobais.UsuarioLogado.at_nomeUsuario}";
        }

        #region Caixa

        private void RedirecionamentoPainel()
        {
            // Minimizar o RibbonControl
            ribbonControl1.Minimized = true;

            pnlTelaPrincipal.SuspendLayout(); // Desabilitar layout automático

            pnlTelaPrincipal.Size = new Size(1278, 622);

            pnlTelaPrincipal.BringToFront();
            pnlTelaPrincipal.Visible = true;
            pnlTelaPrincipal.Location = new Point(0, 28);

            pnlTelaPrincipal.ResumeLayout(false); // Reabilitar layout sem forçar realocação
        }

        public void TelaVendasPDV()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_VendasPDV ucVendasPDV = new uc_VendasPDV(this);
            pnlTelaPrincipal.Controls.Add(ucVendasPDV);
            pnlTelaPrincipal.Tag = ucVendasPDV;
            ucVendasPDV.Show();
        }

        private bool IsCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //mv_movTipo = 1 é abertura de caixa e mv_cxAberto = 1 é caixa aberto

                    var isCaixaAberto = uow.Query<tb_movimentacao>().Any(x => x.mv_movTipo == 1 && x.mv_cxAberto == 1);

                    return isCaixaAberto;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto: {ex.Message}");

                return false;
            }
        }

        private void btnVenda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsCaixaAberto())
            {
                RedirecionamentoPainel();

                TelaVendasPDV();
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
            }
        }

        public void TelaVisualizarEntradaCaixa()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_VisualizarEntradasCaixa ucVisualizarEntradasCaixaEntradaCaixa = new uc_VisualizarEntradasCaixa(this);
            pnlTelaPrincipal.Controls.Add(ucVisualizarEntradasCaixaEntradaCaixa);
            pnlTelaPrincipal.Tag = ucVisualizarEntradasCaixaEntradaCaixa;
            ucVisualizarEntradasCaixaEntradaCaixa.Show();
        }

        private void btnEntrada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsCaixaAberto())
            {
                RedirecionamentoPainel();

                TelaVisualizarEntradaCaixa();
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
            }
        }

        public void TelaAberturaCaixa()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_AberturaCaixa ucAberturaCaixa = new uc_AberturaCaixa(this);
            pnlTelaPrincipal.Controls.Add(ucAberturaCaixa);
            pnlTelaPrincipal.Tag = ucAberturaCaixa;
            ucAberturaCaixa.Show();
        }

        private void btnAberturaCaixa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RedirecionamentoPainel();

            TelaAberturaCaixa();
        }

        public void TelaFechamentoCaixa()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_FechamentoCaixa ucFechamentoCaixa = new uc_FechamentoCaixa(this);
            pnlTelaPrincipal.Controls.Add(ucFechamentoCaixa);
            pnlTelaPrincipal.Tag = ucFechamentoCaixa;
            ucFechamentoCaixa.Show();
        }

        private void btnFechamentoCaixa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsCaixaAberto())
            {
                RedirecionamentoPainel();

                TelaFechamentoCaixa();
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
            }
        }

        public void TelaVisualizarSaidaCaixa()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_VisualizarSaidaCaixa ucVisualizarSaidaCaixa = new uc_VisualizarSaidaCaixa(this);
            pnlTelaPrincipal.Controls.Add(ucVisualizarSaidaCaixa);
            pnlTelaPrincipal.Tag = ucVisualizarSaidaCaixa;
            ucVisualizarSaidaCaixa.Show();
        }

        private void btnSaida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (IsCaixaAberto())
            {
                RedirecionamentoPainel();

                TelaVisualizarSaidaCaixa();
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
            }
        }

        public void TelaRelatorioFluxoSaida()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_RelatorioFluxoSaida ucRelatorioFluxoSaida = new uc_RelatorioFluxoSaida(this);
            pnlTelaPrincipal.Controls.Add(ucRelatorioFluxoSaida);
            pnlTelaPrincipal.Tag = ucRelatorioFluxoSaida;
            ucRelatorioFluxoSaida.Show();
        }

        private void btnRelatorioFluxoSaida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RedirecionamentoPainel();

            TelaRelatorioFluxoSaida();
        }

        #endregion Caixa

        #region Sistema

        private void btnDeslogar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você realmente deseja trocar de usuário?");

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                frmLogin _frmLogin = new frmLogin();
                _frmLogin.Show();
            }
        }

        #endregion Sistema

        public void TelaProduto()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Produto ucProduto = new uc_Produto(this);
            pnlTelaPrincipal.Controls.Add(ucProduto);
            pnlTelaPrincipal.Tag = ucProduto;
            ucProduto.Show();
        }

        private void btnProdutos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RedirecionamentoPainel();

            TelaProduto();
        }

        //Tipos Ator

        //(1, 'Consumidor'),
        //(10, 'Empresa'),
        //(11, 'Filial'),
        //(20, 'Fornecedor'),
        //(30, 'Transporte'),
        //(40, 'Intermediador'),
        //(100, 'Funcionário'),
        //(101, 'Vendedor'),
        //(102, 'Gerente');

        public void TelaAtor(int _tipoAtor)
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Ator ucAtor = new uc_Ator(this, _tipoAtor);
            pnlTelaPrincipal.Controls.Add(ucAtor);
            pnlTelaPrincipal.Tag = ucAtor;
            ucAtor.Show();
        }

        private void btnConsumidores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RedirecionamentoPainel();

            TelaAtor(1);
        }

        private void btnEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RedirecionamentoPainel();

            TelaAtor(10);
        }
    }
}