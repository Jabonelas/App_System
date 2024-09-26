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

namespace DXApplicationPDV.Caixa.Relatorios
{
    public partial class uc_RelatorioFluxoSaida : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicial _frmTelaInicial;

        public uc_RelatorioFluxoSaida(frmTelaInicial _form)
        {
            InitializeComponent();

            _frmTelaInicial = _form;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ribbonControl1.Minimized = false;
            this.Dispose();
        }

        private void uc_RelatorioFluxoSaida_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }
    }
}