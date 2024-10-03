using App_TelasCompartilhadas;

namespace App_PDV.AberturaCaixa
{
    partial class uc_AberturaCaixa
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
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtFormaPagamento = new DevExpress.XtraEditors.TextEdit();
            this.txtValorPagamento = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(7, 39);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(58, 54);
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Appearance.Options.UseFont = true;
            this.btnSalvar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSalvar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSalvar.Location = new System.Drawing.Point(71, 39);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(58, 54);
            this.btnSalvar.TabIndex = 37;
            this.btnSalvar.Text = "salvar";
            this.btnSalvar.ToolTip = "Clique para salvar as alterações.";
            this.btnSalvar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSalvar.ToolTipTitle = "Salvar:";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtFormaPagamento);
            this.layoutControl1.Controls.Add(this.txtValorPagamento);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1266, 124);
            this.layoutControl1.TabIndex = 38;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.EditValue = "DINHEIRO";
            this.txtFormaPagamento.Location = new System.Drawing.Point(24, 61);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.Properties.ReadOnly = true;
            this.txtFormaPagamento.Size = new System.Drawing.Size(607, 20);
            this.txtFormaPagamento.StyleController = this.layoutControl1;
            this.txtFormaPagamento.TabIndex = 6;
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.EditValue = "";
            this.txtValorPagamento.Location = new System.Drawing.Point(635, 61);
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtValorPagamento.Properties.MaskSettings.Set("mask", "c");
            this.txtValorPagamento.Size = new System.Drawing.Size(607, 20);
            this.txtValorPagamento.StyleController = this.layoutControl1;
            this.txtValorPagamento.TabIndex = 7;
            this.txtValorPagamento.ToolTip = "digite o montante para a abertura do caixa.";
            this.txtValorPagamento.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtValorPagamento.ToolTipTitle = "Valor do pagamento da abertura: ";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1266, 124);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1246, 104);
            this.layoutControlGroup1.Text = "Aqui você pode abrir o caixa para iniciar as vendas.";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtFormaPagamento;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(611, 59);
            this.layoutControlItem3.Text = "Forma de pagamento";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtValorPagamento;
            this.layoutControlItem4.Location = new System.Drawing.Point(611, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(611, 59);
            this.layoutControlItem4.Text = "Valor do pagamento";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(102, 13);
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 31);
            this.uc_TituloTelas1.TabIndex = 39;
            // 
            // uc_AberturaCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_AberturaCaixa";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_AberturaCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFormaPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtFormaPagamento;
        private DevExpress.XtraEditors.TextEdit txtValorPagamento;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}
