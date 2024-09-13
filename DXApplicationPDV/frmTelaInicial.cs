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

using System.Security.Cryptography.X509Certificates;

using DevExpress.Internal.WinApi;
using static DevExpress.Utils.HashCodeHelper.Primitives;
using System.Diagnostics;

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

        private void btnEntrada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
    }
}