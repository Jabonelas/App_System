namespace DXApplicationPDV.Fluxo_de_Caixa.Entrada_Caixa
{
    partial class uc_VisualizarEntradasCaixa
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
            this.grdListaEntradasCaixa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMovimentacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Data = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frmPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNovoRegistro = new DevExpress.XtraEditors.SimpleButton();
            this.uc_TituloTelas1 = new DXApplicationPDV.uc_TituloTelas();
            this.uc_SubTituloTelas1 = new DXApplicationPDV.uc_SubTituloTelas();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaEntradasCaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdListaEntradasCaixa
            // 
            this.grdListaEntradasCaixa.Location = new System.Drawing.Point(7, 133);
            this.grdListaEntradasCaixa.MainView = this.gridView1;
            this.grdListaEntradasCaixa.Name = "grdListaEntradasCaixa";
            this.grdListaEntradasCaixa.Size = new System.Drawing.Size(1246, 323);
            this.grdListaEntradasCaixa.TabIndex = 43;
            this.grdListaEntradasCaixa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idMovimentacao,
            this.Data,
            this.frmPagamento,
            this.VlrDesconto});
            this.gridView1.GridControl = this.grdListaEntradasCaixa;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditFormInplace;
            // 
            // idMovimentacao
            // 
            this.idMovimentacao.FieldName = "id_movimentacao";
            this.idMovimentacao.Name = "idMovimentacao";
            // 
            // Data
            // 
            this.Data.Caption = "Data";
            this.Data.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.Data.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Data.FieldName = "mv_dtCri";
            this.Data.Name = "Data";
            this.Data.OptionsColumn.ReadOnly = true;
            this.Data.Visible = true;
            this.Data.VisibleIndex = 0;
            this.Data.Width = 237;
            // 
            // frmPagamento
            // 
            this.frmPagamento.Caption = "Forma de pagamento";
            this.frmPagamento.FieldName = "sfp_desc";
            this.frmPagamento.Name = "frmPagamento";
            this.frmPagamento.OptionsColumn.ReadOnly = true;
            this.frmPagamento.Visible = true;
            this.frmPagamento.VisibleIndex = 1;
            this.frmPagamento.Width = 698;
            // 
            // VlrDesconto
            // 
            this.VlrDesconto.Caption = "Valor (R$)";
            this.VlrDesconto.DisplayFormat.FormatString = "C2";
            this.VlrDesconto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrDesconto.FieldName = "mpg_nfeVlrMov";
            this.VlrDesconto.Name = "VlrDesconto";
            this.VlrDesconto.OptionsColumn.ReadOnly = true;
            this.VlrDesconto.Visible = true;
            this.VlrDesconto.VisibleIndex = 2;
            this.VlrDesconto.Width = 250;
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
            this.btnVoltar.TabIndex = 41;
            this.btnVoltar.Text = "Voltar";
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
            this.btnNovoRegistro.TabIndex = 44;
            this.btnNovoRegistro.Text = "Novo ";
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
            this.uc_TituloTelas1.TabIndex = 45;
            // 
            // uc_SubTituloTelas1
            // 
            this.uc_SubTituloTelas1.Location = new System.Drawing.Point(4, 102);
            this.uc_SubTituloTelas1.Name = "uc_SubTituloTelas1";
            this.uc_SubTituloTelas1.Size = new System.Drawing.Size(1261, 33);
            this.uc_SubTituloTelas1.TabIndex = 46;
            // 
            // uc_VisualizarEntradasCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdListaEntradasCaixa);
            this.Controls.Add(this.uc_SubTituloTelas1);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.btnNovoRegistro);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_VisualizarEntradasCaixa";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_VisualizarEntradasCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaEntradasCaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdListaEntradasCaixa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idMovimentacao;
        private DevExpress.XtraGrid.Columns.GridColumn Data;
        private DevExpress.XtraGrid.Columns.GridColumn frmPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn VlrDesconto;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraEditors.SimpleButton btnNovoRegistro;
        private uc_TituloTelas uc_TituloTelas1;
        private uc_SubTituloTelas uc_SubTituloTelas1;
    }
}
