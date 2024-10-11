using App_TelasCompartilhadas.Produtos;
using DevExpress.XtraBars.Alerter;
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

namespace App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito
{
    public partial class uc_MensagemEstoqueMaximo : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_MensagemEstoqueMaximo(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial)
        {
            InitializeComponent();

            painelTelaInicial = _painelTelaInicial;

            timer1.Stop();
            timer1.Start();

            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = painelTelaInicial.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcEstoqueMaximo.Show(parentForm, info);
            }
        }

        public void TelaProduto(string _formaOrdenarGrid)
        {
            painelTelaInicial.Controls.Clear();
            uc_Produto ucProdutos = new uc_Produto(painelTelaInicial, _formaOrdenarGrid);
            painelTelaInicial.Controls.Add(ucProdutos);
            painelTelaInicial.Tag = ucProdutos;
            ucProdutos.Show();
        }

        private void alcEstoqueBaixo_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            if (e.ElementId == "dialogresult-verificar")
            {
                TelaProduto("EstoqueMaximo");
            }
            else if (e.ElementId == "dialogresult-cancelar")
            {
                alcEstoqueMaximo.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcEstoqueMaximo.Dispose();
            }
        }
    }
}