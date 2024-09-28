namespace DXApplicationPDV
{
    partial class uc_VendasPDV
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
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnVisualizar = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaVendas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMovimentacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtCri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumNFe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtdItens = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnNovoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.uc_TituloTelas1 = new DXApplicationPDV.uc_TituloTelas();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
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
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
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
            this.btnExcluir.TabIndex = 32;
            this.btnExcluir.Text = "excluir";
            this.btnExcluir.ToolTip = "Clique para remover o registro selecionado.";
            this.btnExcluir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExcluir.ToolTipTitle = "Excluir:";
            this.btnExcluir.Visible = false;
            // 
            // btnVisualizar
            // 
            this.btnVisualizar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizar.Appearance.Options.UseFont = true;
            this.btnVisualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVisualizar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVisualizar.Location = new System.Drawing.Point(7, 518);
            this.btnVisualizar.Name = "btnVisualizar";
            this.btnVisualizar.Size = new System.Drawing.Size(58, 54);
            this.btnVisualizar.TabIndex = 31;
            this.btnVisualizar.Text = "visualizar";
            this.btnVisualizar.ToolTip = "Visualizar informações do registro selecionado.";
            this.btnVisualizar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVisualizar.ToolTipTitle = "Visualizar Venda:";
            this.btnVisualizar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // grdListaVendas
            // 
            this.grdListaVendas.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdListaVendas.Location = new System.Drawing.Point(24, 45);
            this.grdListaVendas.MainView = this.gridView1;
            this.grdListaVendas.Name = "grdListaVendas";
            this.grdListaVendas.Size = new System.Drawing.Size(1219, 353);
            this.grdListaVendas.TabIndex = 33;
            this.grdListaVendas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idMovimentacao,
            this.dtCri,
            this.Vendedor,
            this.NumNFe,
            this.QtdItens,
            this.VlrTot,
            this.VlrDesconto});
            this.gridView1.GridControl = this.grdListaVendas;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            // 
            // idMovimentacao
            // 
            this.idMovimentacao.FieldName = "id_movimentacao";
            this.idMovimentacao.Name = "idMovimentacao";
            // 
            // dtCri
            // 
            this.dtCri.Caption = "Dt. Venda";
            this.dtCri.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.dtCri.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtCri.FieldName = "mv_dtCri";
            this.dtCri.Name = "dtCri";
            this.dtCri.OptionsColumn.ReadOnly = true;
            this.dtCri.Visible = true;
            this.dtCri.VisibleIndex = 0;
            this.dtCri.Width = 154;
            // 
            // Vendedor
            // 
            this.Vendedor.Caption = "Nome Vendedor";
            this.Vendedor.FieldName = "at_razSoc";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.OptionsColumn.ReadOnly = true;
            this.Vendedor.Visible = true;
            this.Vendedor.VisibleIndex = 1;
            this.Vendedor.Width = 348;
            // 
            // NumNFe
            // 
            this.NumNFe.Caption = "Nº Nota Fiscal";
            this.NumNFe.FieldName = "nf_nfe1ResProtNFeInfProt0ChNFe";
            this.NumNFe.Name = "NumNFe";
            this.NumNFe.Visible = true;
            this.NumNFe.VisibleIndex = 2;
            this.NumNFe.Width = 358;
            // 
            // QtdItens
            // 
            this.QtdItens.Caption = "Qtd. Itens";
            this.QtdItens.FieldName = "mv_qtdItens";
            this.QtdItens.Name = "QtdItens";
            this.QtdItens.OptionsColumn.ReadOnly = true;
            this.QtdItens.Visible = true;
            this.QtdItens.VisibleIndex = 3;
            this.QtdItens.Width = 106;
            // 
            // VlrTot
            // 
            this.VlrTot.Caption = "Vlr. Total";
            this.VlrTot.DisplayFormat.FormatString = "C2";
            this.VlrTot.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrTot.FieldName = "mv_nfeVlrTotNF";
            this.VlrTot.Name = "VlrTot";
            this.VlrTot.OptionsColumn.ReadOnly = true;
            this.VlrTot.Visible = true;
            this.VlrTot.VisibleIndex = 4;
            this.VlrTot.Width = 103;
            // 
            // VlrDesconto
            // 
            this.VlrDesconto.Caption = "Vlr. Desconto";
            this.VlrDesconto.DisplayFormat.FormatString = "C2";
            this.VlrDesconto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrDesconto.FieldName = "mv_nfeVlrTotDesc";
            this.VlrDesconto.Name = "VlrDesconto";
            this.VlrDesconto.Visible = true;
            this.VlrDesconto.VisibleIndex = 5;
            this.VlrDesconto.Width = 116;
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
            this.btnNovoRegistro.TabIndex = 35;
            this.btnNovoRegistro.Text = "novo";
            this.btnNovoRegistro.ToolTip = "Clique aqui para adicionar um novo registro.";
            this.btnNovoRegistro.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnNovoRegistro.ToolTipTitle = "Novo Registro:";
            this.btnNovoRegistro.Click += new System.EventHandler(this.btnNovoRegistro_Click);
            // 
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 32);
            this.uc_TituloTelas1.TabIndex = 36;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdListaVendas);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1267, 422);
            this.layoutControl1.TabIndex = 38;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1267, 422);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1247, 402);
            this.layoutControlGroup1.Text = "Aqui você pode visualizar todas as vendas realizadas na filial.";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdListaVendas;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1223, 357);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // uc_VendasPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnNovoRegistro);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnVisualizar);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Name = "uc_VendasPDV";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_VendasPDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnVisualizar;
        private DevExpress.XtraGrid.GridControl grdListaVendas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idMovimentacao;
        private DevExpress.XtraGrid.Columns.GridColumn dtCri;
        private DevExpress.XtraGrid.Columns.GridColumn Vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn QtdItens;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTot;
        private DevExpress.XtraGrid.Columns.GridColumn VlrDesconto;
        private DevExpress.XtraGrid.Columns.GridColumn NumNFe;
        private DevExpress.XtraEditors.SimpleButton btnNovoRegistro;
        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
