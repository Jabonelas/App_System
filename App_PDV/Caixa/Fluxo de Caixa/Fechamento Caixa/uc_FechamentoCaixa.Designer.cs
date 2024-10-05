using App_TelasCompartilhadas;

namespace App_PDV.FechamentoCaixa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_FechamentoCaixa));
            this.btnSalvar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVoltar = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaVendas = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMovimentacao = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Data = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frmPagamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VlrDesconto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uc_TituloTelas1 = new App_TelasCompartilhadas.uc_TituloTelas();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.alcConfirmacao = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Appearance.Options.UseFont = true;
            this.btnSalvar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnSalvar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnSalvar.Location = new System.Drawing.Point(71, 39);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(58, 54);
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
            this.btnVoltar.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnVoltar.Location = new System.Drawing.Point(7, 39);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(58, 54);
            this.btnVoltar.TabIndex = 38;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.ToolTip = "Clique para retornar à tela anterior.";
            this.btnVoltar.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.btnVoltar.ToolTipTitle = "Voltar:";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // grdListaVendas
            // 
            this.grdListaVendas.Location = new System.Drawing.Point(24, 45);
            this.grdListaVendas.MainView = this.gridView1;
            this.grdListaVendas.Name = "grdListaVendas";
            this.grdListaVendas.Size = new System.Drawing.Size(1219, 353);
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
            // uc_TituloTelas1
            // 
            this.uc_TituloTelas1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uc_TituloTelas1.Location = new System.Drawing.Point(0, 0);
            this.uc_TituloTelas1.Name = "uc_TituloTelas1";
            this.uc_TituloTelas1.Size = new System.Drawing.Size(1259, 32);
            this.uc_TituloTelas1.TabIndex = 49;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdListaVendas);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 95);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1267, 422);
            this.layoutControl1.TabIndex = 50;
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
            this.layoutControlGroup1.Text = "Aqui você pode realizar o fechamento do caixa.";
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
            // btnImprimir
            // 
            this.btnImprimir.Appearance.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Appearance.Options.UseFont = true;
            this.btnImprimir.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnImprimir.ImageOptions.SvgImageSize = new System.Drawing.Size(40, 40);
            this.btnImprimir.Location = new System.Drawing.Point(7, 518);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(58, 54);
            this.btnImprimir.TabIndex = 51;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            this.btnExcel.TabIndex = 52;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // alcConfirmacao
            // 
            this.alcConfirmacao.HtmlImages = this.svgImageCollection1;
            this.alcConfirmacao.HtmlTemplate.Styles = resources.GetString("alertControl1.HtmlTemplate.Styles");
            this.alcConfirmacao.HtmlTemplate.Template = resources.GetString("alertControl1.HtmlTemplate.Template");
            this.alcConfirmacao.HtmlElementMouseClick += new DevExpress.XtraBars.Alerter.AlertHtmlElementMouseClickEventHandler(this.alcConfirmacao_HtmlElementMouseClick);
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("State_Validation_Invalid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Invalid"))));
            this.svgImageCollection1.Add("State_Validation_Valid", ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("svgImageCollection1.State_Validation_Valid"))));
            // 
            // uc_FechamentoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.uc_TituloTelas1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnVoltar);
            this.Name = "uc_FechamentoCaixa";
            this.Size = new System.Drawing.Size(1259, 579);
            this.Load += new System.EventHandler(this.uc_FechamentoCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListaVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
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
        private uc_TituloTelas uc_TituloTelas1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraBars.Alerter.AlertControl alcConfirmacao;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
    }
}
