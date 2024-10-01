using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Marca
{
    public partial class uc_Marca : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;
        private long idMarca = 0;

        public uc_Marca(frmTelaInicialERP frm)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = frm;

            CarregarGridMarcasAtivas();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovo);
            configBotoes.BotaoAlterar(btnAlterar);
            configBotoes.BotaoExcluir(btnExcluir);

            uc_TituloTelas1.lblTituloTela.Text = "Marca";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void TelaCadastrarMarca(string _operacao, long _idMarca)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadMarca ucCadMarca = new uc_CadMarca(_frmTelaInicial, _operacao, _idMarca);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadMarca);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadMarca;
            this.Invoke(new Action(() => TelaCarregamento.EsconderCarregamento()));
            ucCadMarca.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarMarca("cadastrar", 0);
        }

        private void uc_Marca_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void PegaIdMarcaSelecionadaGrid()
        {
            GridView view = grdMarca.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idMarca = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_marca_produto"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdMarcaSelecionadaGrid();

            TelaCadastrarMarca("Alterar", idMarca);
        }

        private bool IsProdutoComMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isProdutoComCategoria = uow.Query<tb_produto>()
                        .Any(x => x.fk_tb_marca_produto.id_marca_produto == idMarca && x.pd_desat == 0);

                    return isProdutoComCategoria;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar produto cadastrado com esta marca: {ex.Message}");

                return false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdMarcaSelecionadaGrid();

            if (IsProdutoComMarca())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta marca, pois ela está vinculada ao cadastro de algum produto.");

                idMarca = 0;

                return;
            }

            if (idMarca > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta marca?");

                if (result == DialogResult.Yes)
                {
                    ExcluirMarca();
                }
            }
        }

        private void CarregarGridMarcasAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_marca_produto"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mp_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosMarcasCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdMarca.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMarcasCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryMarcaCadastradosAtivos =
                    from marca in session.Query<tb_marca_produto>()
                    where marca.mp_desat == 0
                    orderby marca.mp_desc ascending
                    select new
                    {
                        marca.id_marca_produto,
                        marca.mp_desc,
                    };

                e.QueryableSource = queryMarcaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com marca: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void ExcluirMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_marca_produto marca = uow.GetObjectByKey<tb_marca_produto>(Convert.ToInt64(idMarca));

                    marca.mp_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridMarcasAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir marca: {ex.Message}");
            }
        }
    }
}