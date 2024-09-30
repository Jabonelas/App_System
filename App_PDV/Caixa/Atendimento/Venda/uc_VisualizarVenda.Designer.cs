namespace App_PDV
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
            this.btnImprimirCupomFiscal = new DevExpress.XtraEditors.SimpleButton();
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtTotalDesconto = new DevExpress.XtraEditors.TextEdit();
            this.txtValorPago = new DevExpress.XtraEditors.TextEdit();
            this.txtTroco = new DevExpress.XtraEditors.TextEdit();
            this.txtQuantlProduto = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalProduto = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTotalGeral = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnEnvioEmail = new DevExpress.XtraEditors.SimpleButton();
            this.uc_TituloTelas1 = new App_PDV.uc_TituloTelas();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.txtCPFCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNomeCliente = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControl3 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCPFCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).BeginInit();
            this.layoutControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImprimirCupomFiscal
            // 
            this.btnImprimirCupomFiscal.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimirCupomFiscal.Appearance.Options.UseFont = true;
            this.btnImprimirCupomFiscal.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnImprimirCupomFiscal.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnImprimirCupomFiscal.Location = new System.Drawing.Point(71, 39);
            this.btnImprimirCupomFiscal.Name = "btnImprimirCupomFiscal";
            this.btnImprimirCupomFiscal.Size = new System.Drawing.Size(58, 54);
            this.btnImprimirCupomFiscal.TabIndex = 17;
            this.btnImprimirCupomFiscal.Text = "Imprimir";
            this.btnImprimirCupomFiscal.ToolTip = "Clique para imprimir o cupom fiscal.";
            this.btnImprimirCupomFiscal.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnImprimirCupomFiscal.ToolTipTitle = "Imprimir:";
            this.btnImprimirCupomFiscal.Click += new System.EventHandler(this.btnReimprimirCupomFiscal_Click);
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
            this.btnVoltar.TabIndex = 18;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // grdListaProdutosVendidos
            // 
            this.grdListaProdutosVendidos.Location = new System.Drawing.Point(24, 45);
            this.grdListaProdutosVendidos.MainView = this.gridView1;
            this.grdListaProdutosVendidos.Name = "grdListaProdutosVendidos";
            this.grdListaProdutosVendidos.Size = new System.Drawing.Size(1218, 236);
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtTotalDesconto);
            this.layoutControl1.Controls.Add(this.txtValorPago);
            this.layoutControl1.Controls.Add(this.txtTroco);
            this.layoutControl1.Controls.Add(this.txtQuantlProduto);
            this.layoutControl1.Controls.Add(this.txtTotalProduto);
            this.layoutControl1.Location = new System.Drawing.Point(335, 396);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(916, 272, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(570, 190);
            this.layoutControl1.TabIndex = 36;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtTotalDesconto
            // 
            this.txtTotalDesconto.EditValue = "R$ 0,00";
            this.txtTotalDesconto.Location = new System.Drawing.Point(24, 101);
            this.txtTotalDesconto.Name = "txtTotalDesconto";
            this.txtTotalDesconto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalDesconto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalDesconto.Properties.ReadOnly = true;
            this.txtTotalDesconto.Size = new System.Drawing.Size(252, 20);
            this.txtTotalDesconto.StyleController = this.layoutControl1;
            this.txtTotalDesconto.TabIndex = 4;
            // 
            // txtValorPago
            // 
            this.txtValorPago.EditValue = "R$ 0,00";
            this.txtValorPago.Location = new System.Drawing.Point(280, 101);
            this.txtValorPago.Name = "txtValorPago";
            this.txtValorPago.Properties.Appearance.Options.UseTextOptions = true;
            this.txtValorPago.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtValorPago.Properties.ReadOnly = true;
            this.txtValorPago.Size = new System.Drawing.Size(266, 20);
            this.txtValorPago.StyleController = this.layoutControl1;
            this.txtValorPago.TabIndex = 4;
            // 
            // txtTroco
            // 
            this.txtTroco.EditValue = "R$ 0,00";
            this.txtTroco.Location = new System.Drawing.Point(280, 141);
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTroco.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTroco.Properties.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(266, 20);
            this.txtTroco.StyleController = this.layoutControl1;
            this.txtTroco.TabIndex = 4;
            // 
            // txtQuantlProduto
            // 
            this.txtQuantlProduto.EditValue = "0";
            this.txtQuantlProduto.Location = new System.Drawing.Point(24, 61);
            this.txtQuantlProduto.Name = "txtQuantlProduto";
            this.txtQuantlProduto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQuantlProduto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQuantlProduto.Properties.ReadOnly = true;
            this.txtQuantlProduto.Size = new System.Drawing.Size(252, 20);
            this.txtQuantlProduto.StyleController = this.layoutControl1;
            this.txtQuantlProduto.TabIndex = 5;
            // 
            // txtTotalProduto
            // 
            this.txtTotalProduto.EditValue = "R$ 0,00";
            this.txtTotalProduto.Location = new System.Drawing.Point(280, 61);
            this.txtTotalProduto.Name = "txtTotalProduto";
            this.txtTotalProduto.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalProduto.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalProduto.Properties.ReadOnly = true;
            this.txtTotalProduto.Size = new System.Drawing.Size(266, 20);
            this.txtTotalProduto.StyleController = this.layoutControl1;
            this.txtTotalProduto.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(570, 190);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(550, 170);
            this.layoutControlGroup2.Text = "Dados da Venda";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtTotalProduto;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem3.Location = new System.Drawing.Point(256, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 40);
            this.layoutControlItem3.Text = "TOTAL DOS PRODUTOS";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtTotalDesconto;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(256, 85);
            this.layoutControlItem2.Text = "TOTAL DO DESCONTO";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtValorPago;
            this.layoutControlItem5.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem5.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem5.Location = new System.Drawing.Point(256, 40);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(270, 40);
            this.layoutControlItem5.Text = "VALOR PAGO";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.txtTroco;
            this.layoutControlItem6.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem6.CustomizationFormText = "TOTAL DO DESCONTO";
            this.layoutControlItem6.Location = new System.Drawing.Point(256, 80);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(270, 45);
            this.layoutControlItem6.Text = "TROCO";
            this.layoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem6.TextSize = new System.Drawing.Size(114, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtQuantlProduto;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(256, 40);
            this.layoutControlItem4.Text = "QUANT. PRODUTOS";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 13);
            // 
            // lblTotalGeral
            // 
            this.lblTotalGeral.Appearance.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGeral.Appearance.Options.UseFont = true;
            this.lblTotalGeral.Location = new System.Drawing.Point(925, 498);
            this.lblTotalGeral.Name = "lblTotalGeral";
            this.lblTotalGeral.Size = new System.Drawing.Size(164, 58);
            this.lblTotalGeral.TabIndex = 38;
            this.lblTotalGeral.Text = "R$ 0,00";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(925, 485);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(63, 13);
            this.labelControl1.TabIndex = 37;
            this.labelControl1.Text = "TOTAL PAGO";
            // 
            // btnEnvioEmail
            // 
            this.btnEnvioEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnvioEmail.Appearance.Options.UseFont = true;
            this.btnEnvioEmail.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnEnvioEmail.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnEnvioEmail.Location = new System.Drawing.Point(135, 39);
            this.btnEnvioEmail.Name = "btnEnvioEmail";
            this.btnEnvioEmail.Size = new System.Drawing.Size(58, 54);
            this.btnEnvioEmail.TabIndex = 39;
            this.btnEnvioEmail.Text = "Enviar\r\nE-mail";
            this.btnEnvioEmail.ToolTip = "Clique para enviar o cupom fiscal por e-mail.";
            this.btnEnvioEmail.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnEnvioEmail.ToolTipTitle = "Enviar por E-mail:";
            this.btnEnvioEmail.Visible = false;
            this.btnEnvioEmail.Click += new System.EventHandler(this.btnEnvioEmail_Click);
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 33);
            this.uc_TituloTelas1.TabIndex = 40;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.txtCPFCliente);
            this.layoutControl2.Controls.Add(this.txtNomeCliente);
            this.layoutControl2.Location = new System.Drawing.Point(-2, 397);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.Root;
            this.layoutControl2.Size = new System.Drawing.Size(330, 188);
            this.layoutControl2.TabIndex = 43;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // txtCPFCliente
            // 
            this.txtCPFCliente.EditValue = "C.P.F não cadastrado";
            this.txtCPFCliente.Location = new System.Drawing.Point(24, 101);
            this.txtCPFCliente.Name = "txtCPFCliente";
            this.txtCPFCliente.Properties.ReadOnly = true;
            this.txtCPFCliente.Size = new System.Drawing.Size(282, 20);
            this.txtCPFCliente.StyleController = this.layoutControl2;
            this.txtCPFCliente.TabIndex = 8;
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.EditValue = "Cliente não cadastrado";
            this.txtNomeCliente.Location = new System.Drawing.Point(24, 61);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Properties.ReadOnly = true;
            this.txtNomeCliente.Size = new System.Drawing.Size(282, 20);
            this.txtNomeCliente.StyleController = this.layoutControl2;
            this.txtNomeCliente.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(330, 188);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem7});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Size = new System.Drawing.Size(310, 168);
            this.layoutControlGroup3.Text = "Dados do Cliente";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtNomeCliente;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(286, 40);
            this.layoutControlItem1.Text = "NOME";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(31, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.txtCPFCliente;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 40);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(286, 83);
            this.layoutControlItem7.Text = "C.P.F.";
            this.layoutControlItem7.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem7.TextSize = new System.Drawing.Size(31, 13);
            // 
            // layoutControl3
            // 
            this.layoutControl3.Controls.Add(this.grdListaProdutosVendidos);
            this.layoutControl3.Location = new System.Drawing.Point(-3, 96);
            this.layoutControl3.Name = "layoutControl3";
            this.layoutControl3.Root = this.layoutControlGroup4;
            this.layoutControl3.Size = new System.Drawing.Size(1266, 305);
            this.layoutControl3.TabIndex = 44;
            this.layoutControl3.Text = "layoutControl3";
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup5});
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Size = new System.Drawing.Size(1266, 305);
            this.layoutControlGroup4.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Size = new System.Drawing.Size(1246, 285);
            this.layoutControlGroup5.Text = "Aqui você pode visualizar todos os produtos vendidos na venda selecionada.";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdListaProdutosVendidos;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(1222, 240);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // uc_VisualizarVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl3);
            this.Controls.Add(this.layoutControl2);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.btnEnvioEmail);
            this.Controls.Add(this.lblTotalGeral);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnImprimirCupomFiscal);
            this.Controls.Add(this.layoutControl1);
            this.Name = "uc_VisualizarVenda";
            this.Size = new System.Drawing.Size(1259, 579);
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
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCPFCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNomeCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl3)).EndInit();
            this.layoutControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnImprimirCupomFiscal;
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
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtTotalDesconto;
        private DevExpress.XtraEditors.TextEdit txtValorPago;
        private DevExpress.XtraEditors.TextEdit txtTroco;
        private DevExpress.XtraEditors.TextEdit txtQuantlProduto;
        private DevExpress.XtraEditors.TextEdit txtTotalProduto;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.LabelControl lblTotalGeral;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn VlrProd;
        private DevExpress.XtraGrid.Columns.GridColumn Marca;
        private DevExpress.XtraEditors.SimpleButton btnEnvioEmail;
        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit txtCPFCliente;
        private DevExpress.XtraEditors.TextEdit txtNomeCliente;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl3;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}
