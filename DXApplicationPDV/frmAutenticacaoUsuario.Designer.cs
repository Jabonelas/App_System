namespace DXApplicationPDV
{
    partial class frmAutenticacaoUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutenticacaoUsuario));
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtSenha = new DevExpress.UITemplates.Collection.Editors.PasswordBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnLogar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(59, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(197, 25);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Autenticação Usuário";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtUsuario);
            this.layoutControl1.Controls.Add(this.txtSenha);
            this.layoutControl1.Location = new System.Drawing.Point(1, 42);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(322, 157);
            this.layoutControl1.TabIndex = 10;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtUsuario
            // 
            this.txtUsuario.EditValue = "geral";
            this.txtUsuario.Location = new System.Drawing.Point(24, 61);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Properties.ContextImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("txtUsuario.Properties.ContextImageOptions.SvgImage")));
            this.txtUsuario.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.txtUsuario.Size = new System.Drawing.Size(274, 20);
            this.txtUsuario.StyleController = this.layoutControl1;
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.ToolTip = "Digite seu nome de usuário cadastrado.";
            this.txtUsuario.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtUsuario.ToolTipTitle = "Usuário:";
            // 
            // txtSenha
            // 
            this.txtSenha.EditValue = "123456789";
            this.txtSenha.Location = new System.Drawing.Point(24, 101);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Placeholder = "Digite a sua senha...";
            this.txtSenha.Size = new System.Drawing.Size(274, 20);
            this.txtSenha.StyleController = this.layoutControl1;
            this.txtSenha.TabIndex = 0;
            this.txtSenha.ToolTip = "Insira sua senha com pelo menos 8 caracteres.";
            this.txtSenha.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.txtSenha.ToolTipTitle = "Senha:";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(322, 157);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtSenha;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(278, 52);
            this.layoutControlItem1.Text = "Senha";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(36, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUsuario;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(278, 40);
            this.layoutControlItem2.Text = "Usuário";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(36, 13);
            // 
            // btnLogar
            // 
            this.btnLogar.Location = new System.Drawing.Point(105, 195);
            this.btnLogar.Name = "btnLogar";
            this.btnLogar.Size = new System.Drawing.Size(104, 41);
            this.btnLogar.TabIndex = 11;
            this.btnLogar.Text = "Acessar";
            this.btnLogar.Click += new System.EventHandler(this.btnLogar_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(302, 137);
            this.layoutControlGroup1.Text = "Informe suas credenciais de acesso.";
            // 
            // frmAutenticacaoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 246);
            this.Controls.Add(this.btnLogar);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.labelControl4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAutenticacaoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAutenticacaoUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSenha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.UITemplates.Collection.Editors.PasswordBox txtSenha;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnLogar;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}