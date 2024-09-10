using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DXApplicationPDV.Classes;

namespace DXApplicationPDV
{
    public partial class frmTelaInicial : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTelaInicial()
        {
            InitializeComponent();
        }

        public void TelaProduto()
        {
            TelaDeCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_PDV ucProdutos = new uc_PDV();
            pnlTelaPrincipal.Controls.Add(ucProdutos);
            pnlTelaPrincipal.Tag = ucProdutos;
            ucProdutos.Show();
        }

        private void btnVenda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaProduto();
        }
    }
}