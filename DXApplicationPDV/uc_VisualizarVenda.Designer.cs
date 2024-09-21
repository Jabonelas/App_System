namespace DXApplicationPDV
{
    partial class uc_VisualizarVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_VisualizarVenda));
            this.btnReimprimirCupomFiscal = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaProdutosVendidos = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idProduto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CodRef = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DescricaoCurta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Descricao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtdItens = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrProd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTotalDesconto = new DevExpress.XtraEditors.TextEdit();
            this.txtValorPago = new DevExpress.XtraEditors.TextEdit();
            this.txtTroco = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantlProduto = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalProduto = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTotalGeral = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutosVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReimprimirCupomFiscal
            // 
            this.btnReimprimirCupomFiscal.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReimprimirCupomFiscal.Appearance.Options.UseFont = true;
            this.btnReimprimirCupomFiscal.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnReimprimirCupomFiscal.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReimprimirCupomFiscal.ImageOptions.SvgImage")));
            this.btnReimprimirCupomFiscal.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnReimprimirCupomFiscal.Location = new System.Drawing.Point(15, 461);
            this.btnReimprimirCupomFiscal.Name = "btnReimprimirCupomFiscal";
            this.btnReimprimirCupomFiscal.Size = new System.Drawing.Size(83, 68);
            this.btnReimprimirCupomFiscal.TabIndex = 17;
            this.btnReimprimirCupomFiscal.Text = "Imprimir";
            this.btnReimprimirCupomFiscal.ToolTip = "Clique para reimprimir o cupom fiscal.";
            this.btnReimprimirCupomFiscal.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnReimprimirCupomFiscal.ToolTipTitle = "Imprimir:";
            this.btnReimprimirCupomFiscal.Click += new System.EventHandler(this.btnReimprimirCupomFiscal_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(15, 11);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(83, 68);
            this.btnVoltar.TabIndex = 18;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // grdListaProdutosVendidos
            // 
            this.grdListaProdutosVendidos.Location = new System.Drawing.Point(16, 115);
            this.grdListaProdutosVendidos.MainView = this.gridView1;
            this.grdListaProdutosVendidos.Name = "grdListaProdutosVendidos";
            this.grdListaProdutosVendidos.Size = new System.Drawing.Size(1246, 278);
            this.grdListaProdutosVendidos.TabIndex = 34;
            this.grdListaProdutosVendidos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idProduto,
            this.CodRef,
            this.DescricaoCurta,
            this.Descricao,
            this.Marca,
            this.QtdItens,
            this.VlrProd,
            this.VlrTot,
            this.VlrDesconto});
            this.gridView1.GridControl = this.grdListaProdutosVendidos;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            // 
            // idProduto
            // 
            this.idProduto.FieldName = "id_produto";
            this.idProduto.Name = "idProduto";
            // 
            // CodRef
            // 
            this.CodRef.Caption = "Cód. Ref.";
            this.CodRef.FieldName = "pd_codRef";
            this.CodRef.Name = "CodRef";
            this.CodRef.OptionsColumn.ReadOnly = true;
            this.CodRef.Visible = true;
            this.CodRef.VisibleIndex = 0;
            this.CodRef.Width = 83;
            // 
            // DescricaoCurta
            // 
            this.DescricaoCurta.Caption = "Descrição Curta";
            this.DescricaoCurta.FieldName = "pd_descCurta";
            this.DescricaoCurta.Name = "DescricaoCurta";
            this.DescricaoCurta.OptionsColumn.ReadOnly = true;
            this.DescricaoCurta.Visible = true;
            this.DescricaoCurta.VisibleIndex = 1;
            this.DescricaoCurta.Width = 256;
            // 
            // Descricao
            // 
            this.Descricao.Caption = "Descrição";
            this.Descricao.FieldName = "pd_desc";
            this.Descricao.Name = "Descricao";
            this.Descricao.Visible = true;
            this.Descricao.VisibleIndex = 2;
            this.Descricao.Width = 370;
            // 
            // Marca
            // 
            this.Marca.Caption = "Marca";
            this.Marca.FieldName = "mp_desc";
            this.Marca.Name = "Marca";
            this.Marca.Visible = true;
            this.Marca.VisibleIndex = 3;
            this.Marca.Width = 110;
            // 
            // QtdItens
            // 
            this.QtdItens.Caption = "Qtd. Itens";
            this.QtdItens.FieldName = "mp_qtdCom";
            this.QtdItens.Name = "QtdItens";
            this.QtdItens.OptionsColumn.ReadOnly = true;
            this.QtdItens.Visible = true;
            this.QtdItens.VisibleIndex = 4;
            this.QtdItens.Width = 74;
            // 
            // VlrProd
            // 
            this.VlrProd.Caption = "Vlr. Prod.";
            this.VlrProd.DisplayFormat.FormatString = "C2";
            this.VlrProd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrProd.FieldName = "pd_vlrUnComBase";
            this.VlrProd.Name = "VlrProd";
            this.VlrProd.Visible = true;
            this.VlrProd.VisibleIndex = 5;
            this.VlrProd.Width = 94;
            // 
            // VlrTot
            // 
            this.VlrTot.Caption = "Vlr. Total";
            this.VlrTot.DisplayFormat.FormatString = "C2";
            this.VlrTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrTot.FieldName = "mp_vlrProdTot";
            this.VlrTot.Name = "VlrTot";
            this.VlrTot.OptionsColumn.ReadOnly = true;
            this.VlrTot.Visible = true;
            this.VlrTot.VisibleIndex = 6;
            this.VlrTot.Width = 88;
            // 
            // VlrDesconto
            // 
            this.VlrDesconto.Caption = "Vlr. Desconto";
            this.VlrDesconto.DisplayFormat.FormatString = "C2";
            this.VlrDesconto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrDesconto.FieldName = "mp_vlrDesc";
            this.VlrDesconto.Name = "VlrDesconto";
            this.VlrDesconto.Visible = true;
            this.VlrDesconto.VisibleIndex = 7;
            this.VlrDesconto.Width = 110;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Lista de vendas";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTotalDesconto);
            this.layoutControl1.Controls.Add(this.txtValorPago);
            this.layoutControl1.Controls.Add(this.txtTroco);
            this.layoutControl1.Controls.Add(this.txtQuantlProduto);
            this.layoutControl1.Controls.Add(this.txtTotalProduto);
            this.layoutControl1.Location = new System.Drawing.Point(228, 399);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(916, 272, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(660, 148);
            this.layoutControl1.TabIndex = 36;
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
            this.txtTotalDesconto.Size = new System.Drawing.Size(310, 20);
            this.txtTotalDesconto.StyleController = this.layoutControl1;
            this.txtTotalDesconto.TabIndex = 4;
            // 
            // txtValorPago
            // 
            this.txtValorPago.EditValue = "R$ 0,00";
            this.txtValorPago.Enabled = false;
            this.txtValorPago.Location = new System.Drawing.Point(326, 68);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Properties.Appearance.Options.UseTextOptions = true;
            this.txtValorPago.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorPago.Size = new System.Drawing.Size(322, 20);
            this.txtValorPago.StyleController = this.layoutControl1;
            this.txtValorPago.TabIndex = 4;
            // 
            // txtTroco
            // 
            this.txtTroco.EditValue = "R$ 0,00";
            this.txtTroco.Enabled = false;
            this.txtTroco.Location = new System.Drawing.Point(326, 108);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTroco.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTroco.Size = new System.Drawing.Size(322, 20);
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
            this.txtQuantlProduto.Size = new System.Drawing.Size(310, 20);
            this.txtQuantlProduto.StyleController = this.layoutControl1;
            this.txtQuantlProduto.TabIndex = 5;
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.EditValue = "R$ 0,00";
            this.txtTotalProduto.Enabled = false;
            this.txtTotalProduto.Location = new System.Drawing.Point(326, 28);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalProduto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalProduto.Size = new System.Drawing.Size(322, 20);
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
            this.layoutControlItem6,
            this.layoutControlItem3,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(660, 148);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTotalDesconto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(314, 88);
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
            this.layoutControlItem4.Size = new System.Drawing.Size(314, 40);
            this.layoutControlItem4.Text = "QUANT. PRODUTOS";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTroco;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem6.Location = new System.Drawing.Point(314, 80);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(326, 48);
            this.layoutControlItem6.Text = "TROCO";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTotalProduto;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem3.Location = new System.Drawing.Point(314, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(326, 40);
            this.layoutControlItem3.Text = "TOTAL DOS PRODUTOS";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtValorPago;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem5.Location = new System.Drawing.Point(314, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(326, 40);
            this.layoutControlItem5.Text = "VALOR PAGO";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(114, 13);
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.Appearance.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeral.Appearance.Options.UseFont = true;
            this.lblTotalGeral.Location = new System.Drawing.Point(949, 461);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(164, 58);
            this.lblTotalGeral.TabIndex = 38;
            this.lblTotalGeral.Text = "R$ 0,00";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(949, 444);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "TOTAL PAGO";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.simpleButton1.Location = new System.Drawing.Point(104, 461);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(83, 68);
            this.simpleButton1.TabIndex = 39;
            this.simpleButton1.Text = "Imprimir";
            this.simpleButton1.ToolTip = "Clique para reimprimir o cupom fiscal.";
            this.simpleButton1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.simpleButton1.ToolTipTitle = "Imprimir:";
            // 
            // uc_VisualizarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdListaProdutosVendidos);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnReimprimirCupomFiscal);
            this.Name = "uc_VisualizarVenda";
            this.Size = new System.Drawing.Size(1278, 561);
            this.Load += new System.EventHandler(this.uc_VisualizarVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaProdutosVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnReimprimirCupomFiscal;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraGrid.GridControl grdListaProdutosVendidos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idProduto;
        private DevExpress.XtraGrid.Columns.GridColumn CodRef;
        private DevExpress.XtraGrid.Columns.GridColumn DescricaoCurta;
        private DevExpress.XtraGrid.Columns.GridColumn Descricao;
        private DevExpress.XtraGrid.Columns.GridColumn QtdItens;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTot;
        private DevExpress.XtraGrid.Columns.GridColumn VlrDesconto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
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
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn VlrProd;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
