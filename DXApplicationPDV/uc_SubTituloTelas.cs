using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.UserSkins;

namespace DXApplicationPDV
{
    public partial class uc_SubTituloTelas : DevExpress.XtraEditors.XtraUserControl
    {
        public uc_SubTituloTelas()
        {
            InitializeComponent();

            lblSubTituloTela.Font = new Font("Exo 2", 9, FontStyle.Bold);



            //// Obter o tema bônus ativo (se você estiver usando skins bônus)
            //Skin currentSkin = CommonSkins.GetSkin(UserLookAndFeel.Default);

            //// Acessar a cor de destaque do tema atual (por exemplo, "Highlight")
            //Color primaryColor = currentSkin.Colors.GetColor("Highlight");

            //// Aplicar a cor ao seu painel
            //panel1.BackColor = primaryColor;
            //lblSubTituloTela.BackColor = primaryColor;
        }
    }
}