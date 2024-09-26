namespace DXApplicationPDV
{
    partial class uc_SubTituloTelas
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
            this.lblSubTituloTela = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblSubTituloTela
            // 
            this.lblSubTituloTela.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTituloTela.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTituloTela.Appearance.Options.UseBackColor = true;
            this.lblSubTituloTela.Appearance.Options.UseFont = true;
            this.lblSubTituloTela.Location = new System.Drawing.Point(3, 6);
            this.lblSubTituloTela.Name = "lblSubTituloTela";
            this.lblSubTituloTela.Size = new System.Drawing.Size(59, 16);
            this.lblSubTituloTela.TabIndex = 2;
            this.lblSubTituloTela.Text = "SubTitulo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(136)))), ((int)(((byte)(213)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(257, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 28);
            this.panel1.TabIndex = 3;
            this.panel1.Visible = false;
            // 
            // uc_SubTituloTelas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSubTituloTela);
            this.Controls.Add(this.panel1);
            this.Name = "uc_SubTituloTelas";
            this.Size = new System.Drawing.Size(1268, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LabelControl lblSubTituloTela;
        private System.Windows.Forms.Panel panel1;
    }
}
