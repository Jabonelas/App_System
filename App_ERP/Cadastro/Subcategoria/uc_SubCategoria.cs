using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Subcategoria
{
    public partial class uc_SubCategoria : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private int idSubategoria = 0;

        public uc_SubCategoria(frmTelaInicialERP frmtelaInical)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = frmtelaInical;

            CarregarGridSubcategoriasAtivas();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovo);
            configBotoes.BotaoAlterar(btnAlterar);
            configBotoes.BotaoExcluir(btnExcluir);

            uc_TituloTelas1.lblTituloTela.Text = "Subcategoria";
        }

        private void uc_SubCategoria_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void TelaCadastrarSubcategoria(string _operacao, long _idSubCategoria)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadSubcategoria ucCadSubCategoria = new uc_CadSubcategoria(_frmTelaInicial, _operacao, _idSubCategoria);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadSubCategoria);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadSubCategoria;
            this.Invoke(new Action(() => TelaCarregamento.EsconderCarregamento()));
            ucCadSubCategoria.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarSubcategoria("cadastrar", 0);
        }

        private void CarregarGridSubcategoriasAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_subcategoria_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "sp_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosSubcategoriasCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdSubcategorias.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosSubcategoriasCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var querySubCategoriaCadastradosAtivos =
                    from categoria in session.Query<tb_categoria_produto>()
                    join secao in session.Query<tb_secao_produto>()
                        on categoria.fk_tb_secao_produto.id_secao_produto equals secao.id_secao_produto
                    join subcategoria in session.Query<tb_subcategoria_produto>()
                        on categoria.id_categoria_produto equals subcategoria.fk_tb_categoria_produto.id_categoria_produto
                    where subcategoria.scp_desat == 0
                    orderby categoria.cp_desc ascending
                    select new
                    {
                        subcategoria.id_subcategoria_produto,
                        subcategoria.scp_desc,
                        secao.sp_desc,
                        categoria.cp_desc,
                    };

                e.QueryableSource = querySubCategoriaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com subcategorias: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void PegaIdSubCategoriaSelecionadaGrid()
        {
            GridView view = grdSubcategorias.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idSubategoria = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_subcategoria_produto"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdSubCategoriaSelecionadaGrid();

            TelaCadastrarSubcategoria("Alterar", idSubategoria);
        }

        private bool IsProdutoComCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isProdutoComCategoria = uow.Query<tb_produto>()
                        .Any(x => x.fk_tb_subcategoria_produto.id_subcategoria_produto == idSubategoria && x.pd_desat == 0);

                    return isProdutoComCategoria;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar produto cadastrado com esta subcategoria: {ex.Message}");

                return false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdSubCategoriaSelecionadaGrid();

            if (IsProdutoComCategoria())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta subcategoria, pois ela está vinculada ao cadastro de algum produto.");

                idSubategoria = 0;

                return;
            }

            if (idSubategoria > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta subcategoria?");

                if (result == DialogResult.Yes)
                {
                    ExcluirSubcategoria();
                }
            }
        }

        private void ExcluirSubcategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_subcategoria_produto subcategoria = uow.GetObjectByKey<tb_subcategoria_produto>(Convert.ToInt64(idSubategoria));

                    subcategoria.scp_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridSubcategoriasAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir subcategoria: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }
    }
}