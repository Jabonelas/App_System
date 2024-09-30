using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Secao
{
    public partial class uc_Secao : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private int idSecao = 0;

        public uc_Secao(frmTelaInicialERP _frm)
        {
            InitializeComponent();

            CarregarGridSecaoAtivas();

            _frmTelaInicial = _frm;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TelaCadastrarSecao(string _operacao, long _idSecao)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadSecao ucCadSecao = new uc_CadSecao(_frmTelaInicial, _operacao, _idSecao);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadSecao);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadSecao;
            this.Invoke(new Action(() => TelaDeCarregamento.EsconderCarregamento()));
            ucCadSecao.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarSecao("cadastrar", 0);
        }

        private void CarregarGridSecaoAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_secao_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "sp_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosSecoesCadastradasAtivas; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdSecao.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosSecoesCadastradasAtivas(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var querySecaoCadastradosAtivos =
                    from secao in session.Query<tb_secao_produto>()
                    where secao.sp_desat == 0
                    orderby secao.sp_desc ascending
                    select new
                    {
                        secao.id_secao_produto,
                        secao.sp_desc,
                    };

                e.QueryableSource = querySecaoCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com seções: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void uc_Secao_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void PegaIdSecaoSelecionadaGrid()
        {
            GridView view = grdSecao.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idSecao = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_secao_produto"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdSecaoSelecionadaGrid();

            TelaCadastrarSecao("Alterar", idSecao);
        }

        private bool IsCategoriaComSecao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isCategoriaComSecao = uow.Query<tb_categoria_produto>()
                        .Any(x => x.fk_tb_secao_produto.id_secao_produto == idSecao && x.cp_desat == 0);

                    return isCategoriaComSecao;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar categoria cadastrada com esta seção: {ex.Message}");

                return false;
            }
        }

        private void ExcluirSecao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = uow.GetObjectByKey<tb_secao_produto>(Convert.ToInt64(idSecao));

                    secao.sp_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridSecaoAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir subcategoria: {ex.Message}");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdSecaoSelecionadaGrid();

            if (IsCategoriaComSecao())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta seção, pois ela está vinculada ao cadastro de alguma categoria.");

                idSecao = 0;

                return;
            }

            if (idSecao > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta seção?");

                if (result == DialogResult.Yes)
                {
                    ExcluirSecao();
                }
            }
        }
    }
}