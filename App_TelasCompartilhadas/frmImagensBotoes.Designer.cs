namespace App_TelasCompartilhadas
{
    partial class frmImagensBotoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImagensBotoes));
            this.colecaoImagens = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagens)).BeginInit();
            this.SuspendLayout();
            // 
            // colecaoImagens
            // 
            this.colecaoImagens.Add("alterar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.alterar"))));
            this.colecaoImagens.Add("exporta_Excel", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.exporta_Excel"))));
            this.colecaoImagens.Add("enviar_email", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.enviar_email"))));
            this.colecaoImagens.Add("deletar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.deletar"))));
            this.colecaoImagens.Add("buscar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.buscar"))));
            this.colecaoImagens.Add("voltar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.voltar"))));
            this.colecaoImagens.Add("finalizar_venda", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.finalizar_venda"))));
            this.colecaoImagens.Add("selecionar_produto", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.selecionar_produto"))));
            this.colecaoImagens.Add("visualizar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.visualizar"))));
            this.colecaoImagens.Add("imprimir", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.imprimir"))));
            this.colecaoImagens.Add("pagar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.pagar"))));
            this.colecaoImagens.Add("salvar", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.salvar"))));
            this.colecaoImagens.Add("novo", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.novo"))));
            this.colecaoImagens.Add("adiconar_carrinho", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("colecaoImagens.adiconar_carrinho"))));
            // 
            // frmImagensBotoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 104);
            this.Name = "frmImagensBotoes";
            this.Text = "XtraForm2";
            ((System.ComponentModel.ISupportInitialize)(this.colecaoImagens)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.Utils.SvgImageCollection colecaoImagens;
    }
}