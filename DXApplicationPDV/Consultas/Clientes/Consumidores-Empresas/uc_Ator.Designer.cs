namespace DXApplicationPDV.Consultas.Itens.Consumidores
{
    partial class uc_Ator
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
            this.uc_TituloTelas1 = new DXApplicationPDV.uc_TituloTelas();
            this.btnNovoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.uc_SubTituloTelas1 = new DXApplicationPDV.uc_SubTituloTelas();
            this.grdAtor = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CNPJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RazaoSocialNome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NomeFantasia = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdAtor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 32);
            this.uc_TituloTelas1.TabIndex = 37;
            // 
            // btnNovoRegistro
            // 
            this.btnNovoRegistro.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoRegistro.Appearance.Options.UseFont = true;
            this.btnNovoRegistro.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNovoRegistro.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnNovoRegistro.Location = new System.Drawing.Point(71, 39);
            this.btnNovoRegistro.Name = "btnNovoRegistro";
            this.btnNovoRegistro.Size = new System.Drawing.Size(58, 54);
            this.btnNovoRegistro.TabIndex = 41;
            this.btnNovoRegistro.Text = "novo";
            this.btnNovoRegistro.ToolTip = "Clique aqui para adicionar um novo registro.";
            this.btnNovoRegistro.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnNovoRegistro.ToolTipTitle = "Novo Registro:";
            this.btnNovoRegistro.Click += new System.EventHandler(this.btnNovoRegistro_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Appearance.Options.UseFont = true;
            this.btnExcluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExcluir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnExcluir.Location = new System.Drawing.Point(71, 518);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(58, 54);
            this.btnExcluir.TabIndex = 40;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.ToolTip = "Clique para remover o registro selecionado.";
            this.btnExcluir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExcluir.ToolTipTitle = "Excluir:";
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Appearance.Options.UseFont = true;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVisualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVisualizar.Location = new System.Drawing.Point(7, 518);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(58, 54);
            this.btnVisualizar.TabIndex = 39;
            this.btnVisualizar.Text = "alterar";
            this.btnVisualizar.ToolTip = "Visualizar informações do registro selecionado.";
            this.btnVisualizar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVisualizar.ToolTipTitle = "Visualizar Venda:";
            this.btnVisualizar.Click += new System.EventHandler(this.btnVisualizar_Click);
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
            this.btnVoltar.TabIndex = 38;
            this.btnVoltar.Text = "voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // uc_SubTituloTelas1
            // 
            this.uc_SubTituloTelas1.Location = new System.Drawing.Point(4, 102);
            this.uc_SubTituloTelas1.Name = "uc_SubTituloTelas1";
            this.uc_SubTituloTelas1.Size = new System.Drawing.Size(1261, 33);
            this.uc_SubTituloTelas1.TabIndex = 42;
            // 
            // grdAtor
            // 
            this.grdAtor.Location = new System.Drawing.Point(7, 133);
            this.grdAtor.MainView = this.gridView1;
            this.grdAtor.Name = "grdAtor";
            this.grdAtor.Size = new System.Drawing.Size(1244, 373);
            this.grdAtor.TabIndex = 43;
            this.grdAtor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.CNPJ,
            this.RazaoSocialNome,
            this.CPF,
            this.NomeFantasia});
            this.gridView1.GridControl = this.grdAtor;
            this.gridView1.GroupPanelText = "Buscar...";
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID_Prim";
            this.gridColumn6.FieldName = "id_ator";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // CNPJ
            // 
            this.CNPJ.Caption = "C.N.P.J.";
            this.CNPJ.FieldName = "at_cnpj";
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Visible = true;
            this.CNPJ.VisibleIndex = 0;
            // 
            // RazaoSocialNome
            // 
            this.RazaoSocialNome.Caption = "Razão Social / Nome Completo";
            this.RazaoSocialNome.FieldName = "at_razSoc";
            this.RazaoSocialNome.Name = "RazaoSocialNome";
            this.RazaoSocialNome.Visible = true;
            this.RazaoSocialNome.VisibleIndex = 1;
            // 
            // CPF
            // 
            this.CPF.Caption = "C.P.F.";
            this.CPF.FieldName = "at_cpf";
            this.CPF.Name = "CPF";
            this.CPF.Visible = true;
            this.CPF.VisibleIndex = 2;
            // 
            // NomeFantasia
            // 
            this.NomeFantasia.Caption = "Nome Fantasia / Nome Abreviado";
            this.NomeFantasia.FieldName = "at_nomeFant";
            this.NomeFantasia.Name = "NomeFantasia";
            this.NomeFantasia.Visible = true;
            this.NomeFantasia.VisibleIndex = 3;
            // 
            // uc_Consumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdAtor);
            this.Controls.Add(this.btnNovoRegistro);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.uc_SubTituloTelas1);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Name = "uc_Consumidor";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_Consumidor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAtor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraEditors.SimpleButton btnNovoRegistro;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private uc_SubTituloTelas uc_SubTituloTelas1;
        private DevExpress.XtraGrid.GridControl grdAtor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn CNPJ;
        private DevExpress.XtraGrid.Columns.GridColumn RazaoSocialNome;
        private DevExpress.XtraGrid.Columns.GridColumn CPF;
        private DevExpress.XtraGrid.Columns.GridColumn NomeFantasia;
    }
}
