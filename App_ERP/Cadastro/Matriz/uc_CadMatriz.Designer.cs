namespace App_ERP
{
    partial class uc_CadMatriz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_CadMatriz));
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitulo = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbRede = new DevExpress.XtraEditors.LookUpEdit();
            this.txtRazaoSocial = new DevExpress.XtraEditors.TextEdit();
            this.txtNomeFant = new DevExpress.XtraEditors.TextEdit();
            this.txtCNPJ = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazaoSocial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeFant.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCNPJ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Appearance.Options.UseFont = true;
            this.btnSalvar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSalvar.Location = new System.Drawing.Point(139, 65);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(106, 68);
            this.btnSalvar.TabIndex = 14;
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
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(27, 65);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(106, 68);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Appearance.Options.UseFont = true;
            this.lblTitulo.Location = new System.Drawing.Point(27, 19);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(168, 25);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Cadastro de Matriz";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cmbRede);
            this.layoutControl1.Controls.Add(this.txtRazaoSocial);
            this.layoutControl1.Controls.Add(this.txtNomeFant);
            this.layoutControl1.Controls.Add(this.txtCNPJ);
            this.layoutControl1.Location = new System.Drawing.Point(16, 150);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1624, 193);
            this.layoutControl1.TabIndex = 15;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cmbRede
            // 
            this.cmbRede.Location = new System.Drawing.Point(12, 28);
            this.cmbRede.Name = "cmbRede";
            this.cmbRede.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRede.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("re_desc", "Descrição da Rede")});
            this.cmbRede.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbRede.Size = new System.Drawing.Size(798, 20);
            this.cmbRede.StyleController = this.layoutControl1;
            this.cmbRede.TabIndex = 14;
            this.cmbRede.ToolTip = "Selecione o nome da rede de lojas associada ou a empresa responsável pela loja.";
            this.cmbRede.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmbRede.ToolTipTitle = "Rede:";
            // 
            // txtRazaoSocial
            // 
            this.txtRazaoSocial.Location = new System.Drawing.Point(12, 68);
            this.txtRazaoSocial.Name = "txtRazaoSocial";
            this.txtRazaoSocial.Properties.MaxLength = 50;
            this.txtRazaoSocial.Size = new System.Drawing.Size(798, 20);
            this.txtRazaoSocial.StyleController = this.layoutControl1;
            this.txtRazaoSocial.TabIndex = 5;
            this.txtRazaoSocial.ToolTip = "Informe a razão social da empresa ou o nome completo da pessoa física.";
            this.txtRazaoSocial.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtRazaoSocial.ToolTipTitle = "Razão social ou Nome completo:";
            // 
            // txtNomeFant
            // 
            this.txtNomeFant.Location = new System.Drawing.Point(814, 68);
            this.txtNomeFant.Name = "txtNomeFant";
            this.txtNomeFant.Properties.MaxLength = 50;
            this.txtNomeFant.Size = new System.Drawing.Size(798, 20);
            this.txtNomeFant.StyleController = this.layoutControl1;
            this.txtNomeFant.TabIndex = 6;
            this.txtNomeFant.ToolTip = "Informe o nome fantasia da empresa ou o nome abreviado para pessoa física.";
            this.txtNomeFant.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtNomeFant.ToolTipTitle = "Nome fantasia ou Nome abreviado:";
            // 
            // txtCNPJ
            // 
            this.txtCNPJ.EditValue = "45.997.418/0017-10";
            this.txtCNPJ.Location = new System.Drawing.Point(814, 28);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.txtCNPJ.Properties.MaskSettings.Set("mask", "00\\.000\\.000\\/0000\\-00");
            this.txtCNPJ.Size = new System.Drawing.Size(798, 20);
            this.txtCNPJ.StyleController = this.layoutControl1;
            this.txtCNPJ.TabIndex = 12;
            this.txtCNPJ.ToolTip = "Informe o CNPJ da empresa. O CNPJ é o Cadastro Nacional da Pessoa Jurídica e iden" +
    "tifica a empresa perante a Receita Federal.";
            this.txtCNPJ.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtCNPJ.ToolTipTitle = "C.N.P.J. (Cadastro Nacional da Pessoa Jurídica):";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem7,
            this.layoutControlItem4,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1624, 193);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtRazaoSocial;
            this.layoutControlItem1.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem1.CustomizationFormText = "Razão social ou Nome completo";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(802, 133);
            this.layoutControlItem1.Text = "Razão social ";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtCNPJ;
            this.layoutControlItem7.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem7.CustomizationFormText = "C.N.P.J.";
            this.layoutControlItem7.Location = new System.Drawing.Point(802, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(802, 40);
            this.layoutControlItem7.Text = "C.N.P.J.";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtNomeFant;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem4.CustomizationFormText = "Nome fantasia ou Nome abreviado";
            this.layoutControlItem4.Location = new System.Drawing.Point(802, 40);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(802, 133);
            this.layoutControlItem4.Text = "Nome fantasia";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(69, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbRede;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(802, 40);
            this.layoutControlItem2.Text = "Rede ";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(69, 13);
            // 
            // uc_CadMatriz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lblTitulo);
            this.Name = "uc_CadMatriz";
            this.Size = new System.Drawing.Size(1658, 1048);
            this.Load += new System.EventHandler(this.uc_CadMatriz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbRede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRazaoSocial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeFant.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCNPJ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.LabelControl lblTitulo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtRazaoSocial;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.TextEdit txtNomeFant;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.TextEdit txtCNPJ;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.LookUpEdit cmbRede;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
