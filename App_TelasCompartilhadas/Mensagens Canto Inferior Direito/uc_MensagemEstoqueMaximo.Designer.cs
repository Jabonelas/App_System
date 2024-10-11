namespace App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito
{
    partial class uc_MensagemEstoqueMaximo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_MensagemEstoqueMaximo));
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.alcEstoqueMaximo = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("State_Validation_Invalid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Invalid"))));
            // 
            // alcEstoqueMaximo
            // 
            this.alcEstoqueMaximo.HtmlImages = this.svgImageCollection1;
            this.alcEstoqueMaximo.HtmlTemplate.Styles = resources.GetString("alcEstoqueBaixo.HtmlTemplate.Styles");
            this.alcEstoqueMaximo.HtmlTemplate.Template = resources.GetString("alcEstoqueBaixo.HtmlTemplate.Template");
            this.alcEstoqueMaximo.HtmlElementMouseClick += new DevExpress.XtraBars.Alerter.AlertHtmlElementMouseClickEventHandler(this.alcEstoqueBaixo_HtmlElementMouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 7000;
            // 
            // uc_MensagemEstoqueMaximo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "uc_MensagemEstoqueMaximo";
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.Alerter.AlertControl alcEstoqueMaximo;
        private System.Windows.Forms.Timer timer1;
    }
}
