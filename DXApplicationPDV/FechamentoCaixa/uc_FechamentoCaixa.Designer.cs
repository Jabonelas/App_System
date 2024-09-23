namespace DXApplicationPDV.FechamentoCaixa
{
    partial class uc_FechamentoCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_FechamentoCaixa));
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaVendas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMovimentacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Data = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frmPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Appearance.Options.UseFont = true;
            this.btnSalvar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSalvar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSalvar.ImageOptions.SvgImage")));
            this.btnSalvar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSalvar.Location = new System.Drawing.Point(95, 11);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(83, 68);
            this.btnSalvar.TabIndex = 39;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.ToolTip = "Clique para salvar as alterações.";
            this.btnSalvar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnSalvar.ToolTipTitle = "Salvar:";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Appearance.Options.UseFont = true;
            this.btnVoltar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnVoltar.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVoltar.ImageOptions.SvgImage")));
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(6, 11);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(83, 68);
            this.btnVoltar.TabIndex = 38;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // grdListaVendas
            // 
            this.grdListaVendas.Location = new System.Drawing.Point(6, 96);
            this.grdListaVendas.MainView = this.gridView1;
            this.grdListaVendas.Name = "grdListaVendas";
            this.grdListaVendas.Size = new System.Drawing.Size(1246, 323);
            this.grdListaVendas.TabIndex = 40;
            this.grdListaVendas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idMovimentacao,
            this.Data,
            this.frmPagamento,
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
            // 
            // frmPagamento
            // 
            this.frmPagamento.Caption = "Forma de pagamento";
            this.frmPagamento.FieldName = "sfp_desc";
            this.frmPagamento.Name = "frmPagamento";
            this.frmPagamento.OptionsColumn.ReadOnly = true;
            this.frmPagamento.Visible = true;
            this.frmPagamento.VisibleIndex = 1;
            this.frmPagamento.Width = 106;
            // 
            // VlrDesconto
            // 
            this.VlrDesconto.Caption = "Valor (R$)";
            this.VlrDesconto.DisplayFormat.FormatString = "C2";
            this.VlrDesconto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.VlrDesconto.FieldName = "mpg_nfeVlrPag";
            this.VlrDesconto.Name = "VlrDesconto";
            this.VlrDesconto.OptionsColumn.ReadOnly = true;
            this.VlrDesconto.Visible = true;
            this.VlrDesconto.VisibleIndex = 2;
            this.VlrDesconto.Width = 116;
            // 
            // uc_FechamentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdListaVendas);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_FechamentoCaixa";
            this.Size = new System.Drawing.Size(1258, 515);
            this.Load += new System.EventHandler(this.uc_FechamentoCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSalvar;
        private DevExpress.XtraEditors.SimpleButton btnVoltar;
        private DevExpress.XtraGrid.GridControl grdListaVendas;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn idMovimentacao;
        private DevExpress.XtraGrid.Columns.GridColumn frmPagamento;
        private DevExpress.XtraGrid.Columns.GridColumn VlrDesconto;
        private DevExpress.XtraGrid.Columns.GridColumn Data;
    }
}
