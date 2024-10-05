namespace App_ERP.Cadastro.PDV
{
    partial class uc_CadPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_CadPDV));
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbFilial = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPDVNum = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            this.alcConfirmacao = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDVNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
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
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.ToolTip = "Clique para salvar as alterações.";
            this.btnSalvar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSalvar.ToolTipTitle = "Salvar:";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            this.btnVoltar.TabIndex = 10;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbFilial);
            this.layoutControl1.Controls.Add(this.txtPDVNum);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1266, 124);
            this.layoutControl1.TabIndex = 12;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbFilial
            // 
            this.cmbFilial.Location = new System.Drawing.Point(24, 61);
            this.cmbFilial.Name = "cmbFilial";
            this.cmbFilial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFilial.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("at_cnpj", "C.N.P.J."),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("at_nomeFant", "Nome Fantasia")});
            this.cmbFilial.Size = new System.Drawing.Size(576, 20);
            this.cmbFilial.StyleController = this.layoutControl1;
            this.cmbFilial.TabIndex = 13;
            this.cmbFilial.ToolTip = resources.GetString("cmbFilial.ToolTip");
            this.cmbFilial.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmbFilial.ToolTipTitle = "Filial:";
            // 
            // txtPDVNum
            // 
            this.txtPDVNum.Location = new System.Drawing.Point(604, 61);
            this.txtPDVNum.Name = "txtPDVNum";
            this.txtPDVNum.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtPDVNum.Properties.MaskSettings.Set("mask", "d");
            this.txtPDVNum.Properties.MaxLength = 3;
            this.txtPDVNum.Size = new System.Drawing.Size(638, 20);
            this.txtPDVNum.StyleController = this.layoutControl1;
            this.txtPDVNum.TabIndex = 5;
            this.txtPDVNum.ToolTip = resources.GetString("txtPDVNum.ToolTip");
            this.txtPDVNum.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtPDVNum.ToolTipTitle = "Núm. PDV:";
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
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1246, 104);
            this.layoutControlGroup1.Text = "Aqui você pode realizar o  cadastro do ponto de venda (PDV).";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cmbFilial;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(580, 59);
            this.layoutControlItem1.Text = "Filial";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(62, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtPDVNum;
            this.layoutControlItem2.Location = new System.Drawing.Point(580, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(642, 59);
            this.layoutControlItem2.Text = "Núm. do PDV";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(62, 13);
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 31);
            this.uc_TituloTelas1.TabIndex = 43;
            // 
            // alcConfirmacao
            // 
            this.alcConfirmacao.HtmlImages = this.svgImageCollection1;
            this.alcConfirmacao.HtmlTemplate.Styles = resources.GetString("alertControl1.HtmlTemplate.Styles");
            this.alcConfirmacao.HtmlTemplate.Template = resources.GetString("alertControl1.HtmlTemplate.Template");
            this.alcConfirmacao.HtmlElementMouseClick += new DevExpress.XtraBars.Alerter.AlertHtmlElementMouseClickEventHandler(this.alcConfirmacao_HtmlElementMouseClick);
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("State_Validation_Invalid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Invalid"))));
            this.svgImageCollection1.Add("State_Validation_Valid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Valid"))));
            // 
            // uc_CadPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_CadPDV";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_CadPDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbFilial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPDVNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtPDVNum;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.LookUpEdit cmbFilial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private App_TelasCompartilhadas.uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Alerter.AlertControl alcConfirmacao;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
