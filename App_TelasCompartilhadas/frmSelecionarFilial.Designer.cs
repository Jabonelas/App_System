namespace App_TelasCompartilhadas
{
    partial class frmSelecionarFilial
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
            this.grdPDV = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idAtor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Matriz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Filial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NumPDV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfimar = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdPDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPDV
            // 
            this.grdPDV.Location = new System.Drawing.Point(24, 45);
            this.grdPDV.MainView = this.gridView1;
            this.grdPDV.Name = "grdPDV";
            this.grdPDV.Size = new System.Drawing.Size(951, 399);
            this.grdPDV.TabIndex = 0;
            this.grdPDV.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idAtor,
            this.Matriz,
            this.Filial,
            this.NumPDV});
            this.gridView1.GridControl = this.grdPDV;
            this.gridView1.Name = "gridView1";
            // 
            // idAtor
            // 
            this.idAtor.Caption = "idAtor";
            this.idAtor.FieldName = "id_ator";
            this.idAtor.Name = "idAtor";
            this.idAtor.Width = 231;
            // 
            // Matriz
            // 
            this.Matriz.Caption = "Matriz";
            this.Matriz.FieldName = "mt_nomeFant";
            this.Matriz.Name = "Matriz";
            this.Matriz.Visible = true;
            this.Matriz.VisibleIndex = 0;
            this.Matriz.Width = 470;
            // 
            // Filial
            // 
            this.Filial.Caption = "Filial";
            this.Filial.FieldName = "at_nomeFant";
            this.Filial.Name = "Filial";
            this.Filial.Visible = true;
            this.Filial.VisibleIndex = 1;
            this.Filial.Width = 588;
            // 
            // NumPDV
            // 
            this.NumPDV.Caption = "Núm. PDV";
            this.NumPDV.FieldName = "pdv_pdvNum";
            this.NumPDV.Name = "NumPDV";
            this.NumPDV.Visible = true;
            this.NumPDV.VisibleIndex = 2;
            this.NumPDV.Width = 127;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnCancelar.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnCancelar.Location = new System.Drawing.Point(146, 487);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(128, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfimar
            // 
            this.btnConfimar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.btnConfimar.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btnConfimar.Location = new System.Drawing.Point(12, 487);
            this.btnConfimar.Name = "btnConfimar";
            this.btnConfimar.Size = new System.Drawing.Size(128, 30);
            this.btnConfimar.TabIndex = 3;
            this.btnConfimar.Text = "Confirmar";
            this.btnConfimar.Click += new System.EventHandler(this.btnConfimar_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdPDV);
            this.layoutControl1.Location = new System.Drawing.Point(-3, 16);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(999, 468);
            this.layoutControl1.TabIndex = 6;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(999, 468);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(979, 448);
            this.layoutControlGroup1.Text = "Selecione o cadastro de PDV dessa estação";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdPDV;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(955, 403);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmSelecionarPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 529);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfimar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelecionarPDV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.grdPDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPDV;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnConfimar;
        private DevExpress.XtraGrid.Columns.GridColumn idAtor;
        private DevExpress.XtraGrid.Columns.GridColumn Filial;
        private DevExpress.XtraGrid.Columns.GridColumn Matriz;
        private DevExpress.XtraGrid.Columns.GridColumn NumPDV;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}