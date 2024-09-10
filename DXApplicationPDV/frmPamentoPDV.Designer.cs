namespace DXApplicationPDV
{
    partial class frmPamentoPDV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPamentoPDV));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdPagamentos = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.cmbVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDesconto = new DevExpress.XtraEditors.TextEdit();
            this.cmbFormaPagamento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtValorPagamento = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTotalDesconto = new DevExpress.XtraEditors.TextEdit();
            this.txtValorPago = new DevExpress.XtraEditors.TextEdit();
            this.txtTroco = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantlProduto = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalProduto = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTotalGeral = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnFinalizarVenda = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmarPagamento = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdPagamentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPagamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDesconto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTroco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantlProduto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalProduto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(367, 106);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Pagamentos";
            // 
            // grdPagamentos
            // 
            this.grdPagamentos.Location = new System.Drawing.Point(367, 125);
            this.grdPagamentos.MainView = this.gridView2;
            this.grdPagamentos.Name = "grdPagamentos";
            this.grdPagamentos.Size = new System.Drawing.Size(298, 140);
            this.grdPagamentos.TabIndex = 14;
            this.grdPagamentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idPagamento,
            this.DescricaoPagamento,
            this.VlrPagamento});
            this.gridView2.GridControl = this.grdPagamentos;
            this.gridView2.Name = "gridView2";
            // 
            // idPagamento
            // 
            this.idPagamento.Caption = "IdPagamento";
            this.idPagamento.FieldName = "_idPagamento";
            this.idPagamento.Name = "idPagamento";
            // 
            // DescricaoPagamento
            // 
            this.DescricaoPagamento.Caption = "Desc. Pagamento";
            this.DescricaoPagamento.FieldName = "_pagamentoDescricao";
            this.DescricaoPagamento.Name = "DescricaoPagamento";
            this.DescricaoPagamento.OptionsColumn.ReadOnly = true;
            this.DescricaoPagamento.Visible = true;
            this.DescricaoPagamento.VisibleIndex = 0;
            this.DescricaoPagamento.Width = 893;
            // 
            // VlrPagamento
            // 
            this.VlrPagamento.Caption = "Vlr. Pago";
            this.VlrPagamento.DisplayFormat.FormatString = "c2";
            this.VlrPagamento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrPagamento.FieldName = "_vlrPagamento";
            this.VlrPagamento.Name = "VlrPagamento";
            this.VlrPagamento.OptionsColumn.ReadOnly = true;
            this.VlrPagamento.Visible = true;
            this.VlrPagamento.VisibleIndex = 1;
            this.VlrPagamento.Width = 292;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.cmbVendedor);
            this.layoutControl2.Controls.Add(this.txtDesconto);
            this.layoutControl2.Controls.Add(this.cmbFormaPagamento);
            this.layoutControl2.Controls.Add(this.txtValorPagamento);
            this.layoutControl2.Location = new System.Drawing.Point(6, 97);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(345, 184);
            this.layoutControl2.TabIndex = 16;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.Location = new System.Drawing.Point(12, 28);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbVendedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("at_razSoc", "Nome Vendedor"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("at_nomeUsuario", "Usuário")});
            this.cmbVendedor.Size = new System.Drawing.Size(321, 20);
            this.cmbVendedor.StyleController = this.layoutControl2;
            this.cmbVendedor.TabIndex = 6;
            // 
            // txtDesconto
            // 
            this.txtDesconto.Location = new System.Drawing.Point(12, 68);
            this.txtDesconto.Name = "txtDesconto";
            this.txtDesconto.Properties.MaxLength = 9;
            this.txtDesconto.Size = new System.Drawing.Size(321, 20);
            this.txtDesconto.StyleController = this.layoutControl2;
            this.txtDesconto.TabIndex = 7;
            this.txtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesconto_KeyPress);
            this.txtDesconto.Leave += new System.EventHandler(this.txtDesconto_Leave);
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.Location = new System.Drawing.Point(12, 108);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFormaPagamento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("id_sub_forma_pagamento", "idFormaPagamento", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sfp_desc", "Forma Pagamento")});
            this.cmbFormaPagamento.Size = new System.Drawing.Size(321, 20);
            this.cmbFormaPagamento.StyleController = this.layoutControl2;
            this.cmbFormaPagamento.TabIndex = 6;
            // 
            // txtValorPagamento
            // 
            this.txtValorPagamento.Location = new System.Drawing.Point(12, 148);
            this.txtValorPagamento.Name = "txtValorPagamento";
            this.txtValorPagamento.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtValorPagamento.Properties.MaskSettings.Set("mask", "c");
            this.txtValorPagamento.Properties.MaxLength = 8;
            this.txtValorPagamento.Size = new System.Drawing.Size(321, 20);
            this.txtValorPagamento.StyleController = this.layoutControl2;
            this.txtValorPagamento.TabIndex = 8;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem9,
            this.layoutControlItem8,
            this.layoutControlItem10});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(345, 184);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmbVendedor;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(325, 40);
            this.layoutControlItem7.Text = "Vendedor";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.txtDesconto;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(325, 40);
            this.layoutControlItem9.Text = "Desconto (% / R$)";
            this.layoutControlItem9.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem9.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.cmbFormaPagamento;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(325, 40);
            this.layoutControlItem8.Text = "Forma de pagamento";
            this.layoutControlItem8.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem8.TextSize = new System.Drawing.Size(102, 13);
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.txtValorPagamento;
            this.layoutControlItem10.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(325, 44);
            this.layoutControlItem10.Text = "Valor do pagamento";
            this.layoutControlItem10.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(102, 13);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(18, 11);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(83, 80);
            this.btnVoltar.TabIndex = 17;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTotalDesconto);
            this.layoutControl1.Controls.Add(this.txtValorPago);
            this.layoutControl1.Controls.Add(this.txtTroco);
            this.layoutControl1.Controls.Add(this.txtQuantlProduto);
            this.layoutControl1.Controls.Add(this.txtTotalProduto);
            this.layoutControl1.Location = new System.Drawing.Point(6, 276);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(916, 272, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(345, 148);
            this.layoutControl1.TabIndex = 18;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTotalDesconto
            // 
            this.txtTotalDesconto.EditValue = "R$ 0,00";
            this.txtTotalDesconto.Enabled = false;
            this.txtTotalDesconto.Location = new System.Drawing.Point(12, 68);
            this.txtTotalDesconto.Name = "txtTotalDesconto";
            this.txtTotalDesconto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalDesconto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalDesconto.Size = new System.Drawing.Size(156, 20);
            this.txtTotalDesconto.StyleController = this.layoutControl1;
            this.txtTotalDesconto.TabIndex = 4;
            // 
            // txtValorPago
            // 
            this.txtValorPago.EditValue = "R$ 0,00";
            this.txtValorPago.Enabled = false;
            this.txtValorPago.Location = new System.Drawing.Point(172, 68);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Properties.Appearance.Options.UseTextOptions = true;
            this.txtValorPago.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorPago.Size = new System.Drawing.Size(161, 20);
            this.txtValorPago.StyleController = this.layoutControl1;
            this.txtValorPago.TabIndex = 4;
            // 
            // txtTroco
            // 
            this.txtTroco.EditValue = "R$ 0,00";
            this.txtTroco.Enabled = false;
            this.txtTroco.Location = new System.Drawing.Point(12, 108);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTroco.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTroco.Size = new System.Drawing.Size(321, 20);
            this.txtTroco.StyleController = this.layoutControl1;
            this.txtTroco.TabIndex = 4;
            // 
            // txtQuantlProduto
            // 
            this.txtQuantlProduto.EditValue = "0";
            this.txtQuantlProduto.Enabled = false;
            this.txtQuantlProduto.Location = new System.Drawing.Point(12, 28);
            this.txtQuantlProduto.Name = "txtQuantlProduto";
            this.txtQuantlProduto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQuantlProduto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQuantlProduto.Size = new System.Drawing.Size(156, 20);
            this.txtQuantlProduto.StyleController = this.layoutControl1;
            this.txtQuantlProduto.TabIndex = 5;
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.EditValue = "R$ 0,00";
            this.txtTotalProduto.Enabled = false;
            this.txtTotalProduto.Location = new System.Drawing.Point(172, 28);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalProduto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalProduto.Size = new System.Drawing.Size(161, 20);
            this.txtTotalProduto.StyleController = this.layoutControl1;
            this.txtTotalProduto.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem6});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(345, 148);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTotalDesconto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(160, 40);
            this.layoutControlItem2.Text = "TOTAL DO DESCONTO";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtQuantlProduto;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem4.CustomizationFormText = "TOTAL DOS PRODUTOS";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(160, 40);
            this.layoutControlItem4.Text = "QUANT. PRODUTOS";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTotalProduto;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem3.Location = new System.Drawing.Point(160, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(165, 40);
            this.layoutControlItem3.Text = "TOTAL DOS PRODUTOS";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtValorPago;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem5.Location = new System.Drawing.Point(160, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(165, 40);
            this.layoutControlItem5.Text = "VALOR PAGO";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTroco;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(325, 48);
            this.layoutControlItem6.Text = "TROCO";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(114, 13);
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeral.Appearance.Options.UseFont = true;
            this.lblTotalGeral.Location = new System.Drawing.Point(402, 329);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(217, 45);
            this.lblTotalGeral.TabIndex = 20;
            this.lblTotalGeral.Text = "R$ 00.000,00";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(402, 312);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "TOTAL GERAL";
            // 
            // btnFinalizarVenda
            // 
            this.btnFinalizarVenda.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenda.Appearance.Options.UseFont = true;
            this.btnFinalizarVenda.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnFinalizarVenda.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFinalizarVenda.ImageOptions.SvgImage")));
            this.btnFinalizarVenda.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnFinalizarVenda.Location = new System.Drawing.Point(18, 430);
            this.btnFinalizarVenda.Name = "btnFinalizarVenda";
            this.btnFinalizarVenda.Size = new System.Drawing.Size(83, 80);
            this.btnFinalizarVenda.TabIndex = 21;
            this.btnFinalizarVenda.Text = "Finalizar \r\nVenda";
            this.btnFinalizarVenda.ToolTip = "Clique aqui para concluir a sua compra e finalizar o processo de venda.";
            this.btnFinalizarVenda.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnFinalizarVenda.ToolTipTitle = "Finalizar Venda:";
            // 
            // btnConfirmarPagamento
            // 
            this.btnConfirmarPagamento.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarPagamento.Appearance.Options.UseFont = true;
            this.btnConfirmarPagamento.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnConfirmarPagamento.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConfirmarPagamento.ImageOptions.SvgImage")));
            this.btnConfirmarPagamento.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnConfirmarPagamento.Location = new System.Drawing.Point(107, 11);
            this.btnConfirmarPagamento.Name = "btnConfirmarPagamento";
            this.btnConfirmarPagamento.Size = new System.Drawing.Size(83, 80);
            this.btnConfirmarPagamento.TabIndex = 22;
            this.btnConfirmarPagamento.Text = "Confirmar\r\nPagamento";
            this.btnConfirmarPagamento.ToolTip = "Confirme o pagamento para completar a transação.";
            this.btnConfirmarPagamento.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnConfirmarPagamento.ToolTipTitle = "Confirmar Pagamento:";
            this.btnConfirmarPagamento.Click += new System.EventHandler(this.btnConfirmarPagamento_Click);
            // 
            // frmPamentoPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 526);
            this.Controls.Add(this.btnConfirmarPagamento);
            this.Controls.Add(this.btnFinalizarVenda);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdPagamentos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPamentoPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPamentoPDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPagamentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesconto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFormaPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPagamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDesconto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTroco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuantlProduto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalProduto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdPagamentos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbVendedor;
        private DevExpress.XtraEditors.TextEdit txtDesconto;
        private DevExpress.XtraEditors.LookUpEdit cmbFormaPagamento;
        private DevExpress.XtraEditors.TextEdit txtValorPagamento;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTotalDesconto;
        private DevExpress.XtraEditors.TextEdit txtValorPago;
        private DevExpress.XtraEditors.TextEdit txtTroco;
        private DevExpress.XtraEditors.TextEdit txtQuantlProduto;
        private DevExpress.XtraEditors.TextEdit txtTotalProduto;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl lblTotalGeral;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnFinalizarVenda;
        private DevExpress.XtraEditors.SimpleButton btnConfirmarPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn idPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn VlrPagamento;
    }
}