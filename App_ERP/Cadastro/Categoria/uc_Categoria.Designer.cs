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
            this.grdCategorias = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoSecao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoCategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAlterar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNovo = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCategorias
            // 
            this.grdCategorias.Location = new System.Drawing.Point(24, 45);
            this.grdCategorias.MainView = this.gridView1;
            this.grdCategorias.Name = "grdCategorias";
            this.grdCategorias.Size = new System.Drawing.Size(1217, 352);
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
            this.btnExcluir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnExcluir.Location = new System.Drawing.Point(71, 518);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(58, 54);
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
            this.btnAlterar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAlterar.Location = new System.Drawing.Point(7, 518);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(58, 54);
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
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(7, 39);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(58, 54);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.Appearance.Options.UseFont = true;
            this.btnNovo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNovo.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnNovo.Location = new System.Drawing.Point(71, 39);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(58, 54);
            this.btnNovo.TabIndex = 23;
            this.btnNovo.Text = "Novo";
            this.btnNovo.ToolTip = "Clique aqui para adicionar um novo registro.";
            this.btnNovo.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnNovo.ToolTipTitle = "Cadastrar:";
            this.btnNovo.Click += new System.EventHandler(this.btnCadastrar_Click_2);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCategorias);
            this.layoutControl1.Location = new System.Drawing.Point(-4, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1265, 421);
            this.layoutControl1.TabIndex = 24;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1265, 421);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1245, 401);
            this.layoutControlGroup1.Text = "Aqui você pode visualizar todas as categorias cadastradas.";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdCategorias;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1221, 356);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 33);
            this.uc_TituloTelas1.TabIndex = 25;
            // 
            // uc_Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_Categoria";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_Categoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCategorias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdCategorias;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnAlterar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoCategoria;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoSecao;
        private DevExpress.XtraEditors.SimpleButton btnNovo;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private App_TelasCompartilhadas.uc_TituloTelas uc_TituloTelas1;
    }
}
