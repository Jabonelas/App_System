namespace DXApplicationPDV.Caixa.Relatorios
{
    partial class uc_RelatorioFluxoSaida
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
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.dtFinal = new DevExpress.XtraEditors.DateEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.uc_SubTituloTelas1 = new DXApplicationPDV.uc_SubTituloTelas();
            this.uc_TituloTelas1 = new DXApplicationPDV.uc_TituloTelas();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.grdFluxoSaida = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Produto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtdItens = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTotProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTotPag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTotDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uc_SubTituloTelas2 = new DXApplicationPDV.uc_SubTituloTelas();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoSaida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnImprimir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnImprimir.Location = new System.Drawing.Point(7, 518);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(58, 54);
            this.btnImprimir.TabIndex = 52;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnVoltar.TabIndex = 51;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dtInicio);
            this.layoutControl1.Controls.Add(this.dtFinal);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 119);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(488, 73);
            this.layoutControl1.TabIndex = 55;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dtInicio
            // 
            this.dtInicio.EditValue = null;
            this.dtInicio.Location = new System.Drawing.Point(12, 28);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Size = new System.Drawing.Size(227, 20);
            this.dtInicio.StyleController = this.layoutControl1;
            this.dtInicio.TabIndex = 4;
            // 
            // dtFinal
            // 
            this.dtFinal.EditValue = null;
            this.dtFinal.Location = new System.Drawing.Point(243, 28);
            this.dtFinal.Name = "dtFinal";
            this.dtFinal.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinal.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFinal.Size = new System.Drawing.Size(233, 20);
            this.dtFinal.StyleController = this.layoutControl1;
            this.dtFinal.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(488, 73);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dtInicio;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(231, 53);
            this.layoutControlItem1.Text = "De:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(21, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtFinal;
            this.layoutControlItem2.Location = new System.Drawing.Point(231, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(237, 53);
            this.layoutControlItem2.Text = "Até:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(21, 13);
            // 
            // uc_SubTituloTelas1
            // 
            this.uc_SubTituloTelas1.Location = new System.Drawing.Point(4, 102);
            this.uc_SubTituloTelas1.Name = "uc_SubTituloTelas1";
            this.uc_SubTituloTelas1.Size = new System.Drawing.Size(1261, 25);
            this.uc_SubTituloTelas1.TabIndex = 53;
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 32);
            this.uc_TituloTelas1.TabIndex = 50;
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnExcel.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnExcel.Location = new System.Drawing.Point(71, 518);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(58, 54);
            this.btnExcel.TabIndex = 56;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnBuscar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnBuscar.Location = new System.Drawing.Point(71, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(58, 54);
            this.btnBuscar.TabIndex = 57;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdFluxoSaida
            // 
            this.grdFluxoSaida.Location = new System.Drawing.Point(7, 215);
            this.grdFluxoSaida.MainView = this.gridView1;
            this.grdFluxoSaida.Name = "grdFluxoSaida";
            this.grdFluxoSaida.Size = new System.Drawing.Size(1246, 287);
            this.grdFluxoSaida.TabIndex = 58;
            this.grdFluxoSaida.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CodRef,
            this.Produto,
            this.QtdItens,
            this.VlrTotProd,
            this.VlrTotPag,
            this.VlrTotDesc});
            this.gridView1.GridControl = this.grdFluxoSaida;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Réf.";
            this.CodRef.FieldName = "CodProduto";
            this.CodRef.Name = "CodRef";
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 0;
            this.CodRef.Width = 84;
            // 
            // Produto
            // 
            this.Produto.Caption = "Desc. Produto";
            this.Produto.FieldName = "Produto";
            this.Produto.Name = "Produto";
            this.Produto.Visible = true;
            this.Produto.VisibleIndex = 1;
            this.Produto.Width = 733;
            // 
            // QtdItens
            // 
            this.QtdItens.Caption = "Qtd. Itens";
            this.QtdItens.FieldName = "SomaQuantidadeItens";
            this.QtdItens.Name = "QtdItens";
            this.QtdItens.OptionsColumn.ReadOnly = true;
            this.QtdItens.Visible = true;
            this.QtdItens.VisibleIndex = 2;
            this.QtdItens.Width = 79;
            // 
            // VlrTotProd
            // 
            this.VlrTotProd.Caption = "Vlr. Total Prod.";
            this.VlrTotProd.DisplayFormat.FormatString = "C2";
            this.VlrTotProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrTotProd.FieldName = "SomaValorTotalProd";
            this.VlrTotProd.Name = "VlrTotProd";
            this.VlrTotProd.Visible = true;
            this.VlrTotProd.VisibleIndex = 3;
            this.VlrTotProd.Width = 101;
            // 
            // VlrTotPag
            // 
            this.VlrTotPag.Caption = "Vlr. Total Pag.";
            this.VlrTotPag.DisplayFormat.FormatString = "C2";
            this.VlrTotPag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrTotPag.FieldName = "SomaValorTotalNF";
            this.VlrTotPag.Name = "VlrTotPag";
            this.VlrTotPag.OptionsColumn.ReadOnly = true;
            this.VlrTotPag.Visible = true;
            this.VlrTotPag.VisibleIndex = 5;
            this.VlrTotPag.Width = 87;
            // 
            // VlrTotDesc
            // 
            this.VlrTotDesc.Caption = "Vlr. Total Desc.";
            this.VlrTotDesc.DisplayFormat.FormatString = "C2";
            this.VlrTotDesc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrTotDesc.FieldName = "SomaValorTotalDesc";
            this.VlrTotDesc.Name = "VlrTotDesc";
            this.VlrTotDesc.Visible = true;
            this.VlrTotDesc.VisibleIndex = 4;
            this.VlrTotDesc.Width = 101;
            // 
            // uc_SubTituloTelas2
            // 
            this.uc_SubTituloTelas2.Location = new System.Drawing.Point(6, 187);
            this.uc_SubTituloTelas2.Name = "uc_SubTituloTelas2";
            this.uc_SubTituloTelas2.Size = new System.Drawing.Size(1261, 25);
            this.uc_SubTituloTelas2.TabIndex = 59;
            // 
            // uc_RelatorioFluxoSaida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdFluxoSaida);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.uc_SubTituloTelas1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.uc_SubTituloTelas2);
            this.Name = "uc_RelatorioFluxoSaida";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_RelatorioFluxoSaida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFinal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFluxoSaida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private uc_TituloTelas uc_TituloTelas1;
        private uc_SubTituloTelas uc_SubTituloTelas1;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.DateEdit dtFinal;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl grdFluxoSaida;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn QtdItens;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTotPag;
        private uc_SubTituloTelas uc_SubTituloTelas2;
        private DevExpress.XtraGrid.Columns.GridColumn Produto;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTotProd;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTotDesc;
    }
}
