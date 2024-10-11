using App_TelasCompartilhadas.Produtos;
using DevExpress.XtraBars.Alerter;
using System.Windows.Forms;

namespace App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito
{
    public partial class uc_MensagemEstoqueBaixo : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_MensagemEstoqueBaixo(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial)
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
                alcEstoqueBaixo.Show(parentForm, info);
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
                TelaProduto("Estoque");
            }
            else if (e.ElementId == "dialogresult-cancelar")
            {
                alcEstoqueBaixo.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcEstoqueBaixo.Dispose();
            }
        }
    }
}