namespace DXApplicationPDV.Consultas.Itens.Produtos
{
    partial class uc_EstoqueProduto
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCadastrarProdutos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_produto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CNPJ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NomeFanta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoCurta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrUnProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.EstTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutEstoqueFiliais = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCadastrarProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEstoqueFiliais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 33);
            this.uc_TituloTelas1.TabIndex = 38;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCadastrarProdutos);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1265, 421);
            this.layoutControl1.TabIndex = 48;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCadastrarProdutos
            // 
            this.grdCadastrarProdutos.Location = new System.Drawing.Point(24, 45);
            this.grdCadastrarProdutos.MainView = this.gridView1;
            this.grdCadastrarProdutos.Name = "grdCadastrarProdutos";
            this.grdCadastrarProdutos.Size = new System.Drawing.Size(1217, 352);
            this.grdCadastrarProdutos.TabIndex = 46;
            this.grdCadastrarProdutos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_produto,
            this.CNPJ,
            this.NomeFanta,
            this.CodRef,
            this.DescricaoCurta,
            this.Descricao,
            this.VlrUnProd,
            this.EstTotal});
            this.gridView1.GridControl = this.grdCadastrarProdutos;
            this.gridView1.GroupPanelText = "Buscar...";
            this.gridView1.Name = "gridView1";
            // 
            // id_produto
            // 
            this.id_produto.Caption = "id_produto";
            this.id_produto.FieldName = "id_produto_filial";
            this.id_produto.Name = "id_produto";
            // 
            // CNPJ
            // 
            this.CNPJ.Caption = "C.N.P.J.";
            this.CNPJ.FieldName = "at_cnpj";
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.Visible = true;
            this.CNPJ.VisibleIndex = 0;
            this.CNPJ.Width = 128;
            // 
            // NomeFanta
            // 
            this.NomeFanta.Caption = "Filial";
            this.NomeFanta.FieldName = "at_nomeFant";
            this.NomeFanta.Name = "NomeFanta";
            this.NomeFanta.Visible = true;
            this.NomeFanta.VisibleIndex = 1;
            this.NomeFanta.Width = 280;
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Ref. Pod.";
            this.CodRef.FieldName = "pf_codRef";
            this.CodRef.Name = "CodRef";
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 2;
            this.CodRef.Width = 94;
            // 
            // DescricaoCurta
            // 
            this.DescricaoCurta.Caption = "Descrição Curta";
            this.DescricaoCurta.FieldName = "pf_descCurta";
            this.DescricaoCurta.Name = "DescricaoCurta";
            this.DescricaoCurta.Width = 282;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descrição";
            this.Descricao.FieldName = "pf_desc";
            this.Descricao.Name = "Descricao";
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 3;
            this.Descricao.Width = 506;
            // 
            // VlrUnProd
            // 
            this.VlrUnProd.Caption = "Vlr. un. Prod.";
            this.VlrUnProd.DisplayFormat.FormatString = "c2";
            this.VlrUnProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrUnProd.FieldName = "pf_vlrUnCom";
            this.VlrUnProd.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.VlrUnProd.Name = "VlrUnProd";
            this.VlrUnProd.Visible = true;
            this.VlrUnProd.VisibleIndex = 4;
            this.VlrUnProd.Width = 97;
            // 
            // EstTotal
            // 
            this.EstTotal.Caption = "Est. Total";
            this.EstTotal.FieldName = "pf_est";
            this.EstTotal.Name = "EstTotal";
            this.EstTotal.Visible = true;
            this.EstTotal.VisibleIndex = 5;
            this.EstTotal.Width = 80;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.LayoutEstoqueFiliais});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1265, 421);
            this.Root.TextVisible = false;
            // 
            // LayoutEstoqueFiliais
            // 
            this.LayoutEstoqueFiliais.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.LayoutEstoqueFiliais.Location = new System.Drawing.Point(0, 0);
            this.LayoutEstoqueFiliais.Name = "LayoutEstoqueFiliais";
            this.LayoutEstoqueFiliais.Size = new System.Drawing.Size(1245, 401);
            this.LayoutEstoqueFiliais.Text = "Aqui você pode visualizar o estoque geral em todas as filiais.";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdCadastrarProdutos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1221, 356);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
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
            this.btnVoltar.TabIndex = 49;
            this.btnVoltar.Text = "voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // uc_EstoqueProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Name = "uc_EstoqueProduto";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_EstoqueProduto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCadastrarProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEstoqueFiliais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdCadastrarProdutos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn id_produto;
        private DevExpress.XtraGrid.Columns.GridColumn CNPJ;
        private DevExpress.XtraGrid.Columns.GridColumn NomeFanta;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoCurta;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraGrid.Columns.GridColumn VlrUnProd;
        private DevExpress.XtraGrid.Columns.GridColumn EstTotal;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutEstoqueFiliais;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
    }
}
