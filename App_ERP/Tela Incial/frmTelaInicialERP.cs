﻿using DevExpress.XtraBars;
using App_ERP.Cadastro.Marca;
using App_ERP.Cadastro.Matriz;
using App_ERP.Cadastro.PDV;
using App_ERP.Cadastro.Rede;
using App_ERP.Cadastro.Secao;
using App_TelasCompartilhadas.Classes;
using App_ERP.Subcategoria;
using System.Windows.Forms;
using App_TelasCompartilhadas;
using App_TelasCompartilhadas.Produtos;

namespace App_ERP
{
    public partial class frmTelaInicialERP : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTelaInicialERP()
        {
            InitializeComponent();

            // Expandir o RibbonControl
            ribbon.Minimized = true;

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            ExibirPainelCentral();

            RotaPe();
        }

        private void ExibirPainelCentral()
        {
            this.pnlTelaPrincipal.Controls.Clear();
            uc_TelaInicialERP ucTelaInicial = new uc_TelaInicialERP();
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

        public void TelaProduto()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Produto ucProdutos = new uc_Produto(pnlTelaPrincipal);
            pnlTelaPrincipal.Controls.Add(ucProdutos);
            pnlTelaPrincipal.Tag = ucProdutos;
            ucProdutos.Show();
        }

        private void btnCadastrarProduto_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaProduto();
        }

        public void TelaCategoria()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Categoria ucCategoria = new uc_Categoria(this);
            pnlTelaPrincipal.Controls.Add(ucCategoria);
            pnlTelaPrincipal.Tag = ucCategoria;
            ucCategoria.Show();
        }

        private void btnCadastrarCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaCategoria();
        }

        public void TelaSubcategoria()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_SubCategoria ucSubCategoria = new uc_SubCategoria(this);
            pnlTelaPrincipal.Controls.Add(ucSubCategoria);
            pnlTelaPrincipal.Tag = ucSubCategoria;
            ucSubCategoria.Show();
        }

        private void btnCadastrarSubCategoria_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaSubcategoria();
        }

        public void TelaSecao()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Secao ucSecao = new uc_Secao(this);
            pnlTelaPrincipal.Controls.Add(ucSecao);
            pnlTelaPrincipal.Tag = ucSecao;
            ucSecao.Show();
        }

        private void btnCadastrarSecao_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaSecao();
        }

        public void TelaMarca()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Marca ucMarca = new uc_Marca(this);
            pnlTelaPrincipal.Controls.Add(ucMarca);
            pnlTelaPrincipal.Tag = ucMarca;
            ucMarca.Show();
        }

        private void btnCadastrarMarca_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaMarca();
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

        private void btnCadastrarConsumidor_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(1);
        }

        private void btnCadastrarEmpresa_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(10);
        }

        private void btnCadastrarFornecedor_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(20);
        }

        private void btnCadastrarTransportadora_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(30);
        }

        private void btnCadastrarFuncionario_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(100);
        }

        private void btnCadastrarFilial_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaAtor(11);
        }

        public void TelaMatriz()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Matriz ucMatriz = new uc_Matriz(this);
            pnlTelaPrincipal.Controls.Add(ucMatriz);
            pnlTelaPrincipal.Tag = ucMatriz;
            ucMatriz.Show();
        }

        private void btnCadastrarMatriz_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaMatriz();
        }

        public void TelaRede()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_Rede ucRede = new uc_Rede(this);
            pnlTelaPrincipal.Controls.Add(ucRede);
            pnlTelaPrincipal.Tag = ucRede;
            ucRede.Show();
        }

        private void btnCadastrarRede_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaRede();
        }

        public void TelaPDV()
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_PDV ucPDV = new uc_PDV(this);
            pnlTelaPrincipal.Controls.Add(ucPDV);
            pnlTelaPrincipal.Tag = ucPDV;
            ucPDV.Show();
        }

        private void btnCadastrarPDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaPDV();
        }

        private void btnCompra_ItemClick(object sender, ItemClickEventArgs e)
        {
            TelaCarregamento.ExibirCarregamentoForm(this);

            frmEntradaXML ucEntradaXml = new frmEntradaXML();
            ucEntradaXml.ShowDialog();
        }

        private void btnDeslogar_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você realmente deseja trocar de usuário?");

            if (dialog == DialogResult.Yes)
            {
                this.Hide();
                frmLogin _frmLogin = new frmLogin();
                _frmLogin.Show();
            }
        }
    }
}