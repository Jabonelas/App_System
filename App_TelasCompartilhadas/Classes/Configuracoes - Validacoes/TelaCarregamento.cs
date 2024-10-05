using DevExpress.XtraSplashScreen;
using System.Drawing;
using System.Windows.Forms;

namespace App_TelasCompartilhadas.Classes
{
    public static class TelaCarregamento
    {
        private static IOverlaySplashScreenHandle _overlayHandle;

        public static void ExibirCarregamentoForm(System.Windows.Forms.Form form)
        {
            OverlayWindowOptions options = new OverlayWindowOptions(
                startupDelay: 0,
                backColor: Color.Gray,
                opacity: 0.5,
                fadeIn: true,
                fadeOut: true,
                imageSize: new Size(70, 70)
            );

            _overlayHandle = SplashScreenManager.ShowOverlayForm(form, options);
        }

        public static void ExibirCarregamentoUserControl(UserControl userControl)
        {
            OverlayWindowOptions options = new OverlayWindowOptions(
                startupDelay: 0,
                backColor: Color.Gray,
                opacity: 0.5,
                fadeIn: true,
                fadeOut: true,
                imageSize: new Size(70, 70)
            );

            _overlayHandle = SplashScreenManager.ShowOverlayForm(userControl, options);
        }

        public static void EsconderCarregamento()
        {
            if (_overlayHandle != null)
            {
                SplashScreenManager.CloseOverlayForm(_overlayHandle);
                _overlayHandle = null;
            }
        }
    }
}