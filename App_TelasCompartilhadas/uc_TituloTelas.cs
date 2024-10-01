using DevExpress.LookAndFeel;
using DevExpress.Skins;
using System.Drawing;

namespace App_TelasCompartilhadas
{
    public partial class uc_TituloTelas : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_TituloTelas()
        {
            InitializeComponent();

            lblTituloTela.Font = new Font("Exo 2", 11, FontStyle.Bold);

            // Obter o tema bônus ativo (se você estiver usando skins bônus)
            Skin currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);

            // Acessar a cor de destaque do tema atual (por exemplo, "Highlight")
            Color primaryColor = currentSkin.Colors.GetColor("Highlight");

            // Aplicar a cor ao seu painel
            panel1.BackColor = primaryColor;
            lblTituloTela.BackColor = primaryColor;
        }
    }
}