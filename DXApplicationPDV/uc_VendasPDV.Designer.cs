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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_VendasPDV));
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcluir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAlterar = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaVendas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMovimentacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtCri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Vendedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumNFe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QtdItens = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrTot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnNovoRegistro = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
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
            this.btnVoltar.TabIndex = 16;
            this.btnVoltar.Text = "Voltar";
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
            this.btnExcluir.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExcluir.ImageOptions.SvgImage")));
            this.btnExcluir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnExcluir.Location = new System.Drawing.Point(104, 461);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(83, 68);
            this.btnExcluir.TabIndex = 32;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.ToolTip = "Clique para remover o registro selecionado.";
            this.btnExcluir.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnExcluir.ToolTipTitle = "Excluir:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Appearance.Options.UseFont = true;
            this.btnAlterar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnAlterar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAlterar.ImageOptions.SvgImage")));
            this.btnAlterar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnAlterar.Location = new System.Drawing.Point(15, 461);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(83, 68);
            this.btnAlterar.TabIndex = 31;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.ToolTip = "Clique para modificar o registro selecionado.";
            this.btnAlterar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnAlterar.ToolTipTitle = "Alterar:";
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // grdListaVendas
            // 
            this.grdListaVendas.Location = new System.Drawing.Point(16, 112);
            this.grdListaVendas.MainView = this.gridView1;
            this.grdListaVendas.Name = "grdListaVendas";
            this.grdListaVendas.Size = new System.Drawing.Size(1246, 336);
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
            this.dtCri.FieldName = "mv_dtCri";
            this.dtCri.Name = "dtCri";
            this.dtCri.OptionsColumn.ReadOnly = true;
            this.dtCri.Visible = true;
            this.dtCri.VisibleIndex = 0;
            this.dtCri.Width = 94;
            // 
            // Vendedor
            // 
            this.Vendedor.Caption = "Nome Vendedor";
            this.Vendedor.FieldName = "at_nomeFant";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.OptionsColumn.ReadOnly = true;
            this.Vendedor.Visible = true;
            this.Vendedor.VisibleIndex = 1;
            this.Vendedor.Width = 375;
            // 
            // NumNFe
            // 
            this.NumNFe.Caption = "Nº Nota Fiscal";
            this.NumNFe.FieldName = "nf_nfe1ResProtNFeInfProt0ChNFe";
            this.NumNFe.Name = "NumNFe";
            this.NumNFe.Visible = true;
            this.NumNFe.VisibleIndex = 2;
            this.NumNFe.Width = 378;
            // 
            // QtdItens
            // 
            this.QtdItens.Caption = "Qtd. Itens";
            this.QtdItens.FieldName = "mv_qtdItens";
            this.QtdItens.Name = "QtdItens";
            this.QtdItens.OptionsColumn.ReadOnly = true;
            this.QtdItens.Visible = true;
            this.QtdItens.VisibleIndex = 3;
            this.QtdItens.Width = 115;
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
            this.VlrTot.Width = 109;
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
            this.VlrDesconto.Width = 114;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Lista de vendas";
            // 
            // btnNovoRegistro
            // 
            this.btnNovoRegistro.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoRegistro.Appearance.Options.UseFont = true;
            this.btnNovoRegistro.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnNovoRegistro.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNovoRegistro.ImageOptions.SvgImage")));
            this.btnNovoRegistro.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnNovoRegistro.Location = new System.Drawing.Point(104, 11);
            this.btnNovoRegistro.Name = "btnNovoRegistro";
            this.btnNovoRegistro.Size = new System.Drawing.Size(83, 68);
            this.btnNovoRegistro.TabIndex = 35;
            this.btnNovoRegistro.Text = "Novo Registro";
            this.btnNovoRegistro.ToolTip = "Clique aqui para adicionar um novo registro.";
            this.btnNovoRegistro.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnNovoRegistro.ToolTipTitle = "Novo Registro:";
            this.btnNovoRegistro.Click += new System.EventHandler(this.btnNovoRegistro_Click);
            // 
            // uc_VendasPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNovoRegistro);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.grdListaVendas);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_VendasPDV";
            this.Size = new System.Drawing.Size(1278, 561);
            this.Load += new System.EventHandler(this.uc_VendasPDV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnExcluir;
        private DevExpress.XtraEditors.SimpleButton btnAlterar;
        private DevExpress.XtraGrid.GridControl grdListaVendas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idMovimentacao;
        private DevExpress.XtraGrid.Columns.GridColumn dtCri;
        private DevExpress.XtraGrid.Columns.GridColumn Vendedor;
        private DevExpress.XtraGrid.Columns.GridColumn QtdItens;
        private DevExpress.XtraGrid.Columns.GridColumn VlrTot;
        private DevExpress.XtraGrid.Columns.GridColumn VlrDesconto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn NumNFe;
        private DevExpress.XtraEditors.SimpleButton btnNovoRegistro;
    }
}
