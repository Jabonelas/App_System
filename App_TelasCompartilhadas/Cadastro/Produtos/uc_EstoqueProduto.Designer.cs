using App_TelasCompartilhadas;

namespace App_TelasCompartilhadas.Produtos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_EstoqueProduto));
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdListaProdutos = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.id_produto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CnpjFilial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Filial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescCurta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qtd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vlrUn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.LayoutEstoqueFiliais = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.alcConfirmacao = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEstoqueFiliais)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
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
            this.layoutControl1.Controls.Add(this.grdListaProdutos);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1265, 421);
            this.layoutControl1.TabIndex = 48;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdListaProdutos
            // 
            this.grdListaProdutos.Location = new System.Drawing.Point(24, 45);
            this.grdListaProdutos.MainView = this.gridView3;
            this.grdListaProdutos.Name = "grdListaProdutos";
            this.grdListaProdutos.Size = new System.Drawing.Size(1217, 352);
            this.grdListaProdutos.TabIndex = 51;
            this.grdListaProdutos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            this.grdListaProdutos.DoubleClick += new System.EventHandler(this.grdListaProdutos_DoubleClick);
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.id_produto1,
            this.CnpjFilial,
            this.Filial,
            this.CodRef,
            this.Descricao,
            this.DescCurta,
            this.qtd,
            this.vlrUn});
            this.gridView3.GridControl = this.grdListaProdutos;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView3.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView3_RowUpdated);
            this.gridView3.RowEditCanceled += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView3_RowEditCanceled);
            // 
            // id_produto1
            // 
            this.id_produto1.Caption = "id_produto";
            this.id_produto1.FieldName = "idProdutoFilial";
            this.id_produto1.Name = "id_produto1";
            // 
            // CnpjFilial
            // 
            this.CnpjFilial.Caption = "C.N.P.J.";
            this.CnpjFilial.FieldName = "cnpjFilial";
            this.CnpjFilial.Name = "CnpjFilial";
            this.CnpjFilial.OptionsColumn.ReadOnly = true;
            this.CnpjFilial.Visible = true;
            this.CnpjFilial.VisibleIndex = 0;
            this.CnpjFilial.Width = 123;
            // 
            // Filial
            // 
            this.Filial.Caption = "Filial";
            this.Filial.FieldName = "filial";
            this.Filial.Name = "Filial";
            this.Filial.OptionsColumn.ReadOnly = true;
            this.Filial.Visible = true;
            this.Filial.VisibleIndex = 1;
            this.Filial.Width = 291;
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Ref. Pod.";
            this.CodRef.FieldName = "codRef";
            this.CodRef.Name = "CodRef";
            this.CodRef.OptionsColumn.ReadOnly = true;
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 2;
            this.CodRef.Width = 93;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descrição";
            this.Descricao.FieldName = "desc";
            this.Descricao.Name = "Descricao";
            this.Descricao.OptionsColumn.ReadOnly = true;
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 3;
            this.Descricao.Width = 505;
            // 
            // DescCurta
            // 
            this.DescCurta.Caption = "descCurta";
            this.DescCurta.FieldName = "descCurta";
            this.DescCurta.Name = "DescCurta";
            this.DescCurta.OptionsColumn.ReadOnly = true;
            this.DescCurta.Width = 355;
            // 
            // qtd
            // 
            this.qtd.Caption = "Quant. Estq.";
            this.qtd.FieldName = "quantidade";
            this.qtd.Name = "qtd";
            this.qtd.Visible = true;
            this.qtd.VisibleIndex = 4;
            this.qtd.Width = 74;
            // 
            // vlrUn
            // 
            this.vlrUn.Caption = "Vlr. un. Prod.";
            this.vlrUn.DisplayFormat.FormatString = "c2";
            this.vlrUn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.vlrUn.FieldName = "vlrUnCom";
            this.vlrUn.Name = "vlrUn";
            this.vlrUn.OptionsColumn.ReadOnly = true;
            this.vlrUn.Visible = true;
            this.vlrUn.VisibleIndex = 5;
            this.vlrUn.Width = 99;
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
            this.layoutControlItem1});
            this.LayoutEstoqueFiliais.Location = new System.Drawing.Point(0, 0);
            this.LayoutEstoqueFiliais.Name = "LayoutEstoqueFiliais";
            this.LayoutEstoqueFiliais.Size = new System.Drawing.Size(1245, 401);
            this.LayoutEstoqueFiliais.Text = "Aqui você pode visualizar o estoque geral em todas as filiais.";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdListaProdutos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1221, 356);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
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
            // alcConfirmacao
            // 
            this.alcConfirmacao.HtmlImages = this.svgImageCollection1;
            this.alcConfirmacao.HtmlTemplate.Styles = resources.GetString("alcConfirmacao.HtmlTemplate.Styles");
            this.alcConfirmacao.HtmlTemplate.Template = resources.GetString("alcConfirmacao.HtmlTemplate.Template");
            this.alcConfirmacao.HtmlElementMouseClick += new DevExpress.XtraBars.Alerter.AlertHtmlElementMouseClickEventHandler(this.alcConfirmacao_HtmlElementMouseClick);
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("State_Validation_Invalid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Invalid"))));
            this.svgImageCollection1.Add("State_Validation_Valid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Valid"))));
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
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LayoutEstoqueFiliais)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup LayoutEstoqueFiliais;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraGrid.GridControl grdListaProdutos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn DescCurta;
        private DevExpress.XtraGrid.Columns.GridColumn qtd;
        private DevExpress.XtraGrid.Columns.GridColumn vlrUn;
        private DevExpress.XtraGrid.Columns.GridColumn id_produto1;
        private DevExpress.XtraGrid.Columns.GridColumn CnpjFilial;
        private DevExpress.XtraGrid.Columns.GridColumn Filial;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.Alerter.AlertControl alcConfirmacao;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
