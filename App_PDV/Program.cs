using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Xpo.DB;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace App_PDV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);

            #region Aplicacao/selecao dos temas

            // Habilita skins de formulário e skins de usuário se necessário
            SkinManager.EnableFormSkins();
            BonusSkins.Register();

            // Define o tema padrão"
            UserLookAndFeel.Default.SetSkinStyle("Basic");

            // Registrar apenas os temas permitidos
            var allowedSkins = new string[]
            {
                "Basic",
                //"High Contrast",
                "McSkin",
                "The Asphalt World",
                "Office 2019 Colorful",
                "Seven Classic",
                "Sharp Plus"
            };
            var skinContainerList = SkinManager.Default.Skins;
            for (int i = skinContainerList.Count - 1; i >= 0; i--)
            {
                var skinName = skinContainerList[i].SkinName;
                if (Array.IndexOf(allowedSkins, skinName) < 0)
                {
                    skinContainerList.RemoveAt(i);
                }
            }

            #endregion Aplicacao/selecao dos temas

            #region Definicao de fonte

            //// Defina a fonte padrão para todos os controles DevExpress
            Font minhaFonte = new Font("Exo 2", 8);
            DevExpress.Utils.AppearanceObject.DefaultFont = minhaFonte;

            #endregion Definicao de fonte

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTelaInicial());

            App_TelasCompartilhadas.frmLogin frmTelaInicial = new App_TelasCompartilhadas.frmLogin();
            frmTelaInicial.ShowDialog();

            if (App_TelasCompartilhadas.Classes.VariaveisGlobais.isInicializarSistema)
            {
                Application.Run(new frmTelaInicialPDV());
            }
        }
    }
}