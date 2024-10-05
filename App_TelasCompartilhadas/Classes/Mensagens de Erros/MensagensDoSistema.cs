using System.Windows.Forms;
using DevExpress.XtraEditors;
using DialogResult = System.Windows.Forms.DialogResult;

namespace App_TelasCompartilhadas.Classes
{
    public static class MensagensDoSistema
    {
        #region Atenção

        public static DialogResult MensagemAtencaoYesNo(string _mensagem)
        {
            return XtraMessageBox.Show(_mensagem, "Atenção!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        public static void MensagemAtencaoOk(string _mensagem)
        {
            XtraMessageBox.Show(_mensagem, "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion Atenção

        #region Informação

        public static void MensagemInformacaoOk(string _mensagem)
        {
            XtraMessageBox.Show(_mensagem, "Informação!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion Informação

        #region Erro

        public static void MensagemErroOk(string _mensagem)
        {
            LogErros.GravarLog(_mensagem);

            XtraMessageBox.Show(_mensagem, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion Erro
    }
}