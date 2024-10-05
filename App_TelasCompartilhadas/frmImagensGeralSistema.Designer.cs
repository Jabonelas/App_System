namespace App_TelasCompartilhadas
{
    partial class frmImagensGeralSistema
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagensGeralSistema));
            this.colecaoImagensBotoesSVG = new DevExpress.Utils.SvgImageCollection(this.components);
            this.colecaoImagensAlertaPNG = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagensBotoesSVG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagensAlertaPNG)).BeginInit();
            this.SuspendLayout();
            // 
            // colecaoImagensBotoesSVG
            // 
            this.colecaoImagensBotoesSVG.Add("alterar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.alterar"))));
            this.colecaoImagensBotoesSVG.Add("exporta_Excel", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.exporta_Excel"))));
            this.colecaoImagensBotoesSVG.Add("enviar_email", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.enviar_email"))));
            this.colecaoImagensBotoesSVG.Add("deletar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.deletar"))));
            this.colecaoImagensBotoesSVG.Add("buscar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.buscar"))));
            this.colecaoImagensBotoesSVG.Add("voltar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.voltar"))));
            this.colecaoImagensBotoesSVG.Add("finalizar_venda", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.finalizar_venda"))));
            this.colecaoImagensBotoesSVG.Add("selecionar_produto", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.selecionar_produto"))));
            this.colecaoImagensBotoesSVG.Add("visualizar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.visualizar"))));
            this.colecaoImagensBotoesSVG.Add("imprimir", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.imprimir"))));
            this.colecaoImagensBotoesSVG.Add("pagar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.pagar"))));
            this.colecaoImagensBotoesSVG.Add("salvar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.salvar"))));
            this.colecaoImagensBotoesSVG.Add("novo", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.novo"))));
            this.colecaoImagensBotoesSVG.Add("adiconar_carrinho", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagensBotoesSVG.adiconar_carrinho"))));
            // 
            // colecaoImagensAlertaPNG
            // 
            this.colecaoImagensAlertaPNG.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("colecaoImagensAlertaPNG.ImageStream")));
            this.colecaoImagensAlertaPNG.Images.SetKeyName(0, "abrir_pasta.png");
            this.colecaoImagensAlertaPNG.Images.SetKeyName(1, "cuidado.png");
            // 
            // frmImagensGeralSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 104);
            this.Name = "frmImagensGeralSistema";
            this.Text = "XtraForm2";
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagensBotoesSVG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagensAlertaPNG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.Utils.SvgImageCollection colecaoImagensBotoesSVG;
        public DevExpress.Utils.ImageCollection colecaoImagensAlertaPNG;
    }
}