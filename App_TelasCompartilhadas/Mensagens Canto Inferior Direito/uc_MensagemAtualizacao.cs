using App_TelasCompartilhadas.Classes;
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
    public partial class uc_MensagemAtualizacao : DevExpress.XtraEditors.XtraUserControl
    {
        private Form form;

        public uc_MensagemAtualizacao(Form _form)
        {
            InitializeComponent();

            form = _form;

            timer1.Stop();
            timer1.Start();

            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = form.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcAtualizacao.Show(parentForm, info);
            }
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            if (e.ElementId == "dialogresult-atualizar")
            {
                Atualizacao.ExecutarAtualizacao(form);
            }
            else if (e.ElementId == "dialogresult-cancelar")
            {
                alcAtualizacao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcAtualizacao.Dispose();
            }
        }
    }
}