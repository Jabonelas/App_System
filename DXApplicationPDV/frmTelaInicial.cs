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
    public partial class frmTelaInicial : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmTelaInicial()
        {
            InitializeComponent();

            // Deixar o Ribbon fixo, sem a opção de minimizar
            ribbonControl1.AllowMinimizeRibbon = false;
        }

        public void TelaVendasPDV()
        {
            TelaDeCarregamento.ExibirCarregamentoForm(this);

            pnlTelaPrincipal.Controls.Clear();
            uc_VendasPDV ucVendasPDV = new uc_VendasPDV(this);
            pnlTelaPrincipal.Controls.Add(ucVendasPDV);
            pnlTelaPrincipal.Tag = ucVendasPDV;
            ucVendasPDV.Show();
        }

        private void btnVenda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TelaVendasPDV();
        }

        private void btnEntrada_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }
    }
}