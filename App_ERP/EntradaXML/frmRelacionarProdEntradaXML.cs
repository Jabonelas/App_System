using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP
{
    public partial class frmRelacionarProdEntradaXML : DevExpress.XtraEditors.XtraForm
    {
        public static bool isProdutoSelecionado = false;

        public frmRelacionarProdEntradaXML(string _cnpjFornecedor, string _nomeFornecedor, string _codProd, string _descProd)
        {
            InitializeComponent();

            txtCNPJFornecedor.Text = _cnpjFornecedor;
            txtFornecedor.Text = _nomeFornecedor;
            txtCodProduto.Text = _codProd;
            txtDesProduto.Text = _descProd;

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            PreencherProduto();
        }

        private void PreencherProduto()
        {
            try
            {
                using (Session session = new Session())
                {
                    var produto = session.Query<tb_produto>()
                        .Where(x => x.pd_desat == 0)
                        .Select(x => new
                        {
                            x.id_produto,
                            x.pd_desc
                        })
                        .ToList();

                    cmbProduto.Properties.DataSource = produto;
                    cmbProduto.Properties.DisplayMember = "pd_desc";
                    cmbProduto.Properties.ValueMember = "id_produto";
                    cmbProduto.Properties.NullText = "Selecione o Produto";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher produto na relação com a XML: {ex.Message}");
            }
        }

        private void btnConfimar_Click(object sender, EventArgs e)
        {
            if (cmbProduto.EditValue == null)
            {
                MensagensDoSistema.MensagemAtencaoOk("Selecione um produto para relacionar com a XML.");

                return;
            }

            frmEntradaXML.idProd = Convert.ToInt64(cmbProduto.EditValue);

            isProdutoSelecionado = true;

            frmEntradaXML.confirmarEntradaXML = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmEntradaXML.confirmarEntradaXML = false;
            this.Close();
        }
    }
}