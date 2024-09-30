namespace App_ERP
{
    partial class uc_Categoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_Categoria));
            this.grdCategorias = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoSecao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAlterar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCadastrar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCategorias
            // 
            this.grdCategorias.Location = new System.Drawing.Point(27, 188);
            this.grdCategorias.MainView = this.gridView1;
            this.grdCategorias.Name = "grdCategorias";
            this.grdCategorias.Size = new System.Drawing.Size(1603, 726);
            this.grdCategorias.TabIndex = 17;
            this.grdCategorias.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.DescricaoSecao,
            this.DescricaoCategoria});
            this.gridView1.GridControl = this.grdCategorias;
            this.gridView1.GroupPanelText = "Buscar...";
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "ID_Prim";
            this.gridColumn6.FieldName = "id_categoria_produto";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // DescricaoSecao
            // 
            this.DescricaoSecao.Caption = "Seção";
            this.DescricaoSecao.FieldName = "sp_desc";
            this.DescricaoSecao.Name = "DescricaoSecao";
            this.DescricaoSecao.Visible = true;
            this.DescricaoSecao.VisibleIndex = 0;
            // 
            // DescricaoCategoria
            // 
            this.DescricaoCategoria.Caption = "Categoria";
            this.DescricaoCategoria.FieldName = "cp_desc";
            this.DescricaoCategoria.Name = "DescricaoCategoria";
            this.DescricaoCategoria.Visible = true;
            this.DescricaoCategoria.VisibleIndex = 1;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.Appearance.Options.UseFont = true;
            this.btnExcluir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExcluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExcluir.ImageOptions.SvgImage")));
            this.btnExcluir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnExcluir.Location = new System.Drawing.Point(140, 954);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(106, 68);
            this.btnExcluir.TabIndex = 16;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.ToolTip = "Clique para remover o registro selecionado.";
            this.btnExcluir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExcluir.ToolTipTitle = "Excluir:";
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Appearance.Options.UseFont = true;
            this.btnAlterar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAlterar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAlterar.ImageOptions.SvgImage")));
            this.btnAlterar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAlterar.Location = new System.Drawing.Point(28, 954);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(106, 68);
            this.btnAlterar.TabIndex = 15;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTip = "Clique para modificar o registro selecionado.";
            this.btnAlterar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnAlterar.ToolTipTitle = "Alterar:";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(28, 72);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(106, 68);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(28, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 25);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Categorias";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 169);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Categorias cadastradas";
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrar.Appearance.Options.UseFont = true;
            this.btnCadastrar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnCadastrar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCadastrar.ImageOptions.SvgImage")));
            this.btnCadastrar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnCadastrar.Location = new System.Drawing.Point(140, 72);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(106, 68);
            this.btnCadastrar.TabIndex = 23;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.ToolTip = "Clique aqui para adicionar um novo registro.";
            this.btnCadastrar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnCadastrar.ToolTipTitle = "Cadastrar:";
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click_2);
            // 
            // uc_Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdCategorias);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.labelControl1);
            this.Name = "uc_Categoria";
            this.Size = new System.Drawing.Size(1658, 1048);
            this.Load += new System.EventHandler(this.uc_Categoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCategorias;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnAlterar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoSecao;
        private DevExpress.XtraEditors.SimpleButton btnCadastrar;
    }
}
