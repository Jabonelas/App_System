using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;
using App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito;

namespace App_ERP.Cadastro.Matriz
{
    public partial class uc_Matriz : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idMatriz = 0;

        public uc_Matriz(frmTelaInicialERP frm)
        {
            InitializeComponent();

            LayoutBotoes();

            _frmTelaInicial = frm;

            CarregarGridMatrizAtivas();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovo);
            configBotoes.BotaoAlterar(btnAlterar);
            configBotoes.BotaoExcluir(btnExcluir);

            uc_TituloTelas1.lblTituloTela.Text = "Matriz";
        }

        private void TelaCadastrarMatriz(string _operacao, long _idMatriz)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadMatriz ucCadMarca = new uc_CadMatriz(_frmTelaInicial, _operacao, _idMatriz);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadMarca);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadMarca;
            this.Invoke(new Action(() => TelaCarregamento.EsconderCarregamento()));
            ucCadMarca.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarMatriz("cadastrar", 0);
        }

        private void Matriz_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }

        private void PegaIdMatrizSelecionadaGrid()
        {
            GridView view = grdMatriz.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idMatriz = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_matriz"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdMatrizSelecionadaGrid();

            TelaCadastrarMatriz("Alterar", idMatriz);
        }

        private bool IsMatrizComAtorCadastro()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isMatrizComAtorCadastro = uow.Query<tb_ator>()
                        .Any(x => x.fk_tb_matriz.id_matriz == idMatriz && x.at_desat == 0);

                    return isMatrizComAtorCadastro;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar matriz cadastrada com ator cadastro: {ex.Message}");

                return false;
            }
        }

        private void ExcluirMatriz()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_matriz matriz = uow.GetObjectByKey<tb_matriz>(Convert.ToInt64(idMatriz));

                    matriz.mt_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridMatrizAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir matriz: {ex.Message}");
            }
        }

        private void CarregarGridMatrizAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_matriz"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "re_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosMatrizCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdMatriz.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMatrizCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryMarcaCadastradosAtivos =
                    from matriz in session.Query<tb_matriz>()
                    join rede in session.Query<tb_rede>()
                        on matriz.fk_tb_rede.id_rede equals rede.id_rede
                    where matriz.mt_desat == 0
                    orderby matriz.mt_nomeFant ascending
                    select new
                    {
                        matriz.id_matriz,
                        matriz.mt_nomeFant,
                        matriz.mt_razSoc,
                        matriz.mt_cnpj,
                        rede.re_desc,
                    };

                e.QueryableSource = queryMarcaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com matriz: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdMatrizSelecionadaGrid();

            if (IsMatrizComAtorCadastro())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta matriz, pois ela está vinculada a algum cadastro.");

                idMatriz = 0;

                return;
            }

            if (idMatriz > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta matriz?");

                if (result == DialogResult.Yes)
                {
                    ExcluirMatriz();

                    uc_MensagemExclusao mensagemExclusaoCantoInferiorDireito = new uc_MensagemExclusao(_frmTelaInicial.pnlTelaPrincipal);
                }
            }
        }
    }
}