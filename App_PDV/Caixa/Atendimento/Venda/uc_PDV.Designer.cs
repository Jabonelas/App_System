namespace App_PDV
{
    partial class uc_PDV
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
            this.cmbProdutos = new DevExpress.XtraEditors.LookUpEdit();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnSelecionarProduto = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaProdutos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idProduto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescCurta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.qtd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.vlrTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnPagamento = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalGeral = new DevExpress.XtraEditors.LabelControl();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uc_TituloTelas1 = new App_PDV.uc_TituloTelas();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdutos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProdutos
            // 
            this.cmbProdutos.Location = new System.Drawing.Point(24, 61);
            this.cmbProdutos.Name = "cmbProdutos";
            this.cmbProdutos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProdutos.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_produto_filial", "idProd", 15, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pf_codRef", "Cód. Réf.", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pf_descCurta", "Descrição. curta", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pf_desc", "Descrição", 45, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("mp_desc", "Marca"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pf_vlrUnCom", "Vlr. un. Prod.", 10, DevExpress.Utils.FormatType.Custom, "c2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("pf_est", "Est. Total", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cmbProdutos.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbProdutos.Size = new System.Drawing.Size(1216, 20);
            this.cmbProdutos.StyleController = this.dataLayoutControl1;
            this.cmbProdutos.TabIndex = 0;
            this.cmbProdutos.ToolTip = "Escolha o produto que será incluído na venda.";
            this.cmbProdutos.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.cmbProdutos.ToolTipTitle = "Seleção de produtos:";
            this.cmbProdutos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbProdutos_KeyPress);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.cmbProdutos);
            this.dataLayoutControl1.Location = new System.Drawing.Point(-3, 96);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.OptionsView.RightToLeftMirroringApplied = true;
            this.dataLayoutControl1.Root = this.Root;
            this.dataLayoutControl1.Size = new System.Drawing.Size(1264, 121);
            this.dataLayoutControl1.TabIndex = 2;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1264, 121);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 85);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1244, 16);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1244, 85);
            this.layoutControlGroup1.Text = "Selecione o produto e clique em adicionar.";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cmbProdutos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1220, 40);
            this.layoutControlItem1.Text = "Lista produtos";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // btnSelecionarProduto
            // 
            this.btnSelecionarProduto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnSelecionarProduto.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSelecionarProduto.Location = new System.Drawing.Point(71, 39);
            this.btnSelecionarProduto.Name = "btnSelecionarProduto";
            this.btnSelecionarProduto.Size = new System.Drawing.Size(58, 54);
            this.btnSelecionarProduto.TabIndex = 1;
            this.btnSelecionarProduto.Text = "selecionar";
            this.btnSelecionarProduto.ToolTip = "Clique aqui para selecionar o produto e adicionar à sua venda.";
            this.btnSelecionarProduto.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSelecionarProduto.ToolTipTitle = "Adicionar:";
            this.btnSelecionarProduto.Click += new System.EventHandler(this.btnSelecionarProduto_Click);
            // 
            // grdListaProdutos
            // 
            this.grdListaProdutos.Location = new System.Drawing.Point(24, 45);
            this.grdListaProdutos.MainView = this.gridView1;
            this.grdListaProdutos.Name = "grdListaProdutos";
            this.grdListaProdutos.Size = new System.Drawing.Size(1219, 243);
            this.grdListaProdutos.TabIndex = 3;
            this.grdListaProdutos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idProduto,
            this.CodRef,
            this.DescCurta,
            this.Descricao,
            this.Marca,
            this.qtd,
            this.vlrTotal});
            this.gridView1.GridControl = this.grdListaProdutos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // idProduto
            // 
            this.idProduto.FieldName = "idProdutoFilial";
            this.idProduto.Name = "idProduto";
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Ref.";
            this.CodRef.FieldName = "codRef";
            this.CodRef.Name = "CodRef";
            this.CodRef.OptionsColumn.ReadOnly = true;
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 0;
            this.CodRef.Width = 93;
            // 
            // DescCurta
            // 
            this.DescCurta.Caption = "Descrição Curta";
            this.DescCurta.FieldName = "descCurta";
            this.DescCurta.Name = "DescCurta";
            this.DescCurta.OptionsColumn.ReadOnly = true;
            this.DescCurta.Width = 355;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descrição";
            this.Descricao.FieldName = "desc";
            this.Descricao.Name = "Descricao";
            this.Descricao.OptionsColumn.ReadOnly = true;
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 1;
            this.Descricao.Width = 429;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "marca";
            this.Marca.Name = "Marca";
            this.Marca.OptionsColumn.ReadOnly = true;
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 2;
            this.Marca.Width = 143;
            // 
            // qtd
            // 
            this.qtd.Caption = "Quant.";
            this.qtd.FieldName = "quantidade";
            this.qtd.Name = "qtd";
            this.qtd.Visible = true;
            this.qtd.VisibleIndex = 3;
            this.qtd.Width = 72;
            // 
            // vlrTotal
            // 
            this.vlrTotal.Caption = "Vlr. Total";
            this.vlrTotal.DisplayFormat.FormatString = "c2";
            this.vlrTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.vlrTotal.FieldName = "vlrUnCom";
            this.vlrTotal.Name = "vlrTotal";
            this.vlrTotal.OptionsColumn.ReadOnly = true;
            this.vlrTotal.Visible = true;
            this.vlrTotal.VisibleIndex = 4;
            this.vlrTotal.Width = 93;
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
            this.btnExcluir.TabIndex = 10;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.ToolTip = "Clique para remover o registro selecionado.";
            this.btnExcluir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExcluir.ToolTipTitle = "Excluir:";
            this.btnExcluir.Visible = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPagamento
            // 
            this.btnPagamento.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagamento.Appearance.Options.UseFont = true;
            this.btnPagamento.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnPagamento.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnPagamento.Location = new System.Drawing.Point(7, 518);
            this.btnPagamento.Name = "btnPagamento";
            this.btnPagamento.Size = new System.Drawing.Size(58, 54);
            this.btnPagamento.TabIndex = 11;
            this.btnPagamento.Text = "pagamento";
            this.btnPagamento.ToolTip = "Clique para realizar o pagamento.";
            this.btnPagamento.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnPagamento.ToolTipTitle = "Pagamento:";
            this.btnPagamento.Click += new System.EventHandler(this.btnPagamento_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(918, 511);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "TOTAL GERAL";
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.Appearance.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeral.Appearance.Options.UseFont = true;
            this.lblTotalGeral.Location = new System.Drawing.Point(918, 523);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(164, 58);
            this.lblTotalGeral.TabIndex = 13;
            this.lblTotalGeral.Text = "R$ 0,00";
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
            this.btnVoltar.TabIndex = 15;
            this.btnVoltar.Text = "voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(132, 36);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(217, 20);
            this.buttonEdit1.TabIndex = 6;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(50, 20);
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 33);
            this.uc_TituloTelas1.TabIndex = 16;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdListaProdutos);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 203);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup2;
            this.layoutControl1.Size = new System.Drawing.Size(1267, 312);
            this.layoutControl1.TabIndex = 17;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1267, 312);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(1247, 292);
            this.layoutControlGroup3.Text = "Lista de produtos adicionados";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdListaProdutos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1223, 247);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // uc_PDV
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnPagamento);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.btnSelecionarProduto);
            this.Name = "uc_PDV";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_PDV_Load);
            this.Leave += new System.EventHandler(this.uc_PDV_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdutos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cmbProdutos;
        private DevExpress.XtraEditors.SimpleButton btnSelecionarProduto;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.GridControl grdListaProdutos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idProduto;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn DescCurta;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraGrid.Columns.GridColumn qtd;
        private DevExpress.XtraGrid.Columns.GridColumn vlrTotal;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnPagamento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblTotalGeral;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}
