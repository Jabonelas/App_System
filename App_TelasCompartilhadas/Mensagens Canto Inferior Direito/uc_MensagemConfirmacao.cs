using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Alerter;

namespace App_TelasCompartilhadas
{
    public partial class uc_MensagemConfirmacao : DevExpress.XtraEditors.XtraUserControl
    {
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_MensagemConfirmacao(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial)
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
                alcConfirmacao.Show(parentForm, info);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            this.Dispose();
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            // Verifica qual elemento foi clicado pelo 'id'
            if (e.ElementId == "dialogresult-ok")
            {
                alcConfirmacao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcConfirmacao.Dispose();
            }
        }
    }
}