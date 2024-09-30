using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Rede
{
    public partial class uc_Rede : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idRede = 0;

        public uc_Rede(frmTelaInicialERP frm)
        {
            InitializeComponent();

            _frmTelaInicial = frm;

            CarregarGridRedeAtivas();
        }

        private void uc_Rede_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void TelaCadastrarRede(string _operacao, long _idRede)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadRede ucCadRede = new uc_CadRede(_frmTelaInicial, _operacao, _idRede);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadRede);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadRede;
            this.Invoke(new Action(() => TelaDeCarregamento.EsconderCarregamento()));
            ucCadRede.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarRede("cadastrar", 0);
        }

        private void PegaIdRedeSelecionadaGrid()
        {
            GridView view = grdRede.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idRede = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_rede"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdRedeSelecionadaGrid();

            TelaCadastrarRede("Alterar", idRede);
        }

        private void ExcluirRede()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_rede rede = uow.GetObjectByKey<tb_rede>(Convert.ToInt64(idRede));

                    rede.re_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridRedeAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir rede: {ex.Message}");
            }
        }

        private void CarregarGridRedeAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_rede"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "re_desc DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosMatrizCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdRede.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMatrizCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryMarcaCadastradosAtivos =
                    from rede in session.Query<tb_rede>()
                    where rede.re_desat == 0
                    orderby rede.re_desc ascending
                    select new
                    {
                        rede.id_rede,
                        rede.re_desc,
                    };

                e.QueryableSource = queryMarcaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com rede: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private bool IsRedeComAtorCadastro()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isRedeComMatriz = uow.Query<tb_matriz>()
                        .Any(x => x.fk_tb_rede.id_rede == idRede && x.mt_desat == 0);

                    return isRedeComMatriz;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar rede cadastrada com matriz: {ex.Message}");

                return false;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdRedeSelecionadaGrid();

            if (IsRedeComAtorCadastro())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir esta rede, pois ela está vinculada a algum cadastro.");

                idRede = 0;

                return;
            }

            if (idRede > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir esta matriz?");

                if (result == DialogResult.Yes)
                {
                    ExcluirRede();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}