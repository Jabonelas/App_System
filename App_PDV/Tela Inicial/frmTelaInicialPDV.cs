using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using App_PDV.AberturaCaixa;
using App_PDV.FechamentoCaixa;
using App_PDV.Fluxo_de_Caixa.Entrada_Caixa;
using App_PDV.Fluxo_de_Caixa.Saida_Caixa;
using App_TelasCompartilhadas;
using App_TelasCompartilhadas.Login;
using App_TelasCompartilhadas.Produtos;
using App_TelasCompartilhadas.Relatorios;
using DevExpress.XtraBars.FluentDesignSystem;
using UserControl = System.Windows.Forms.UserControl;
using Unimake.Business.DFe.Servicos;

namespace App_PDV
{
    public partial class frmTelaInicialPDV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTelaInicialPDV()
        {
            InitializeComponent();

            // Expandir o RibbonControl
            ribbonControl1.Minimized = true;

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ExibirPainelCentral();

            RotaPe();
        }

        private void ExibirPainelCentral()
        {
            this.pnlTelaPrincipal.Controls.Clear();
            uc_TelaInicialPDV ucTelaInicial = new uc_TelaInicialPDV();
            this.pnlTelaPrincipal.Controls.Add(ucTelaInicial);
            this.pnlTelaPrincipal.Tag = ucTelaInicial;
            ucTelaInicial.Show();
        }

        private void RotaPe()
        {
            if (VariaveisGlobais.FilialLogada != null && VariaveisGlobais.PDVLogado != null)
            {
                barStatusFilail.Caption = $"C.N.P.J: {VariaveisGlobais.FilialLogada.at_cnpj} - Filial: {VariaveisGlobais.FilialLogada.at_nomeFant}";
                barStatusPDV.Caption = $"PDV: {VariaveisGlobais.PDVLogado.pdv_pdvNum}";
            }
            barStatusVendedor.Caption = $"Vendedor: {VariaveisGlobais.UsuarioLogado.at_razSoc}";
            barStatusUsuario.Caption = $"Usuário: {VariaveisGlobais.UsuarioLogado.at_nomeUsuario}";
        }

        public void ExibirTelaInicial(UserControl userControl)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(userControl);

            this.pnlTelaPrincipal.Controls.Clear();
            uc_TelaInicialPDV ucTelaInicial = new uc_TelaInicialPDV();
            this.pnlTelaPrincipal.Controls.Add(ucTelaInicial);
            this.pnlTelaPrincipal.Tag = ucTelaInicial;
            userControl.Dispose();
            ucTelaInicial.Show();
        }

        #region Caixa

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
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

                if (IsCaixaAberto())
                {
                    TelaVisualizarEntradaCaixa();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
                }
            }
        }

        private void TelaAutenticacaoUsuario()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            frmAutenticacaoUsuario frmAutenticacaoUsuario = new frmAutenticacaoUsuario();
            frmAutenticacaoUsuario.ShowDialog();
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
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

                TelaAberturaCaixa();
            }
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
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

                if (IsCaixaAberto())
                {
                    TelaFechamentoCaixa();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
                }
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
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

                if (IsCaixaAberto())
                {
                    TelaVisualizarSaidaCaixa();
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Por favor, proceda com a abertura do caixa.");
                }
            }
        }

        public void TelaRelatorioFluxoSaida()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_RelatorioFluxoSaida ucRelatorioFluxoSaida = new uc_RelatorioFluxoSaida(pnlTelaPrincipal, "PDV");
            pnlTelaPrincipal.Controls.Add(ucRelatorioFluxoSaida);
            pnlTelaPrincipal.Tag = ucRelatorioFluxoSaida;
            ucRelatorioFluxoSaida.Show();
        }

        private void btnRelatorioFluxoSaida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaRelatorioFluxoSaida();
        }

        #endregion Caixa

        #region Sistema

        private void btnDeslogar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você realmente deseja trocar de usuário?");

            if (dialog == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        #endregion Sistema

        public void TelaProduto(string _formaOrdenarGrid)
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Produto ucProduto = new uc_Produto(pnlTelaPrincipal, _formaOrdenarGrid);
            pnlTelaPrincipal.Controls.Add(ucProduto);
            pnlTelaPrincipal.Tag = ucProduto;
            ucProduto.Show();
        }

        private void btnProdutos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaProduto("CodigoRef");
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
            App_TelasCompartilhadas.Ator.uc_Ator ucAtor = new App_TelasCompartilhadas.Ator.uc_Ator(pnlTelaPrincipal, _tipoAtor);
            pnlTelaPrincipal.Controls.Add(ucAtor);
            pnlTelaPrincipal.Tag = ucAtor;

            ucAtor.Show();
        }

        private void btnConsumidores_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaAtor(1);
        }

        private void btnEmpresas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaAtor(10);
        }
    }
}