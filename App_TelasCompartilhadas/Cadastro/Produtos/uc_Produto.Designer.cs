using App_TelasCompartilhadas;

namespace App_TelasCompartilhadas.Produtos
{
    partial class uc_Produto
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
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNovoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAlterar = new DevExpress.XtraEditors.SimpleButton();
            this.grdProdutos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_produto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoCurta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Categoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sucategoria = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrUnProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 33);
            this.uc_TituloTelas1.TabIndex = 37;
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
            // btnNovoRegistro
            // 
            this.btnNovoRegistro.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoRegistro.Appearance.Options.UseFont = true;
            this.btnNovoRegistro.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNovoRegistro.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnNovoRegistro.Location = new System.Drawing.Point(71, 39);
            this.btnNovoRegistro.Name = "btnNovoRegistro";
            this.btnNovoRegistro.Size = new System.Drawing.Size(58, 54);
            this.btnNovoRegistro.TabIndex = 39;
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
            this.btnExcluir.TabIndex = 43;
            this.btnExcluir.Text = "excluir";
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
            this.btnAlterar.TabIndex = 42;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // grdProdutos
            // 
            this.grdProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProdutos.Location = new System.Drawing.Point(24, 45);
            this.grdProdutos.MainView = this.gridView1;
            this.grdProdutos.Name = "grdProdutos";
            this.grdProdutos.Size = new System.Drawing.Size(1217, 352);
            this.grdProdutos.TabIndex = 44;
            this.grdProdutos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_produto,
            this.CodRef,
            this.DescricaoCurta,
            this.Descricao,
            this.Marca,
            this.Categoria,
            this.Sucategoria,
            this.VlrUnProd,
            this.EstTotal});
            this.gridView1.GridControl = this.grdProdutos;
            this.gridView1.GroupPanelText = "Buscar...";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // id_produto
            // 
            this.id_produto.Caption = "id_produto";
            this.id_produto.FieldName = "id_produto";
            this.id_produto.Name = "id_produto";
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Ref.";
            this.CodRef.FieldName = "pd_codRef";
            this.CodRef.Name = "CodRef";
            this.CodRef.OptionsColumn.ReadOnly = true;
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 0;
            this.CodRef.Width = 57;
            // 
            // DescricaoCurta
            // 
            this.DescricaoCurta.Caption = "Descrição Curta";
            this.DescricaoCurta.FieldName = "pd_descCurta";
            this.DescricaoCurta.Name = "DescricaoCurta";
            this.DescricaoCurta.OptionsColumn.ReadOnly = true;
            this.DescricaoCurta.Visible = true;
            this.DescricaoCurta.VisibleIndex = 1;
            this.DescricaoCurta.Width = 183;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descrição";
            this.Descricao.FieldName = "pd_desc";
            this.Descricao.Name = "Descricao";
            this.Descricao.OptionsColumn.ReadOnly = true;
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 2;
            this.Descricao.Width = 272;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "mp_desc";
            this.Marca.Name = "Marca";
            this.Marca.OptionsColumn.ReadOnly = true;
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 3;
            this.Marca.Width = 73;
            // 
            // Categoria
            // 
            this.Categoria.Caption = "Categoria";
            this.Categoria.FieldName = "cp_desc";
            this.Categoria.Name = "Categoria";
            this.Categoria.OptionsColumn.ReadOnly = true;
            this.Categoria.Visible = true;
            this.Categoria.VisibleIndex = 4;
            this.Categoria.Width = 78;
            // 
            // Sucategoria
            // 
            this.Sucategoria.Caption = "Sucategoria";
            this.Sucategoria.FieldName = "scp_desc";
            this.Sucategoria.Name = "Sucategoria";
            this.Sucategoria.OptionsColumn.ReadOnly = true;
            this.Sucategoria.Visible = true;
            this.Sucategoria.VisibleIndex = 5;
            this.Sucategoria.Width = 72;
            // 
            // VlrUnProd
            // 
            this.VlrUnProd.Caption = "Vlr. un. Prod.";
            this.VlrUnProd.DisplayFormat.FormatString = "c2";
            this.VlrUnProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrUnProd.FieldName = "pd_vlrUnComBase";
            this.VlrUnProd.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VlrUnProd.Name = "VlrUnProd";
            this.VlrUnProd.OptionsColumn.ReadOnly = true;
            this.VlrUnProd.Visible = true;
            this.VlrUnProd.VisibleIndex = 6;
            this.VlrUnProd.Width = 62;
            // 
            // EstTotal
            // 
            this.EstTotal.Caption = "Est. Total";
            this.EstTotal.FieldName = "pd_estTot";
            this.EstTotal.Name = "EstTotal";
            this.EstTotal.OptionsColumn.ReadOnly = true;
            this.EstTotal.Visible = true;
            this.EstTotal.VisibleIndex = 7;
            this.EstTotal.Width = 94;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdProdutos);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1265, 421);
            this.layoutControl1.TabIndex = 45;
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
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1245, 401);
            this.layoutControlGroup1.Text = "Aqui você pode visualizar todos os produtos cadastrados na filial.";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdProdutos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1221, 356);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Appearance.Options.UseFont = true;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVisualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVisualizar.Location = new System.Drawing.Point(135, 39);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(58, 54);
            this.btnVisualizar.TabIndex = 46;
            this.btnVisualizar.Text = "Visualizar";
            this.btnVisualizar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // uc_Produto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnNovoRegistro);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Name = "uc_Produto";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_Produto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnNovoRegistro;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnAlterar;
        private DevExpress.XtraGrid.GridControl grdProdutos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id_produto;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoCurta;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraGrid.Columns.GridColumn Categoria;
        private DevExpress.XtraGrid.Columns.GridColumn Sucategoria;
        private DevExpress.XtraGrid.Columns.GridColumn VlrUnProd;
        private DevExpress.XtraGrid.Columns.GridColumn EstTotal;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private System.Windows.Forms.Timer timer1;
    }
}
