using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;
using App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito;

namespace App_ERP.Cadastro.PDV
{
    public partial class uc_PDV : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private int idPDV = 0;

        public uc_PDV(frmTelaInicialERP frm)
        {
            InitializeComponent();

            LayoutBotoes();

            _frmTelaInicial = frm;

            CarregarGridPDVAtivas();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovo);
            configBotoes.BotaoAlterar(btnAlterar);
            configBotoes.BotaoExcluir(btnExcluir);

            uc_TituloTelas1.lblTituloTela.Text = "Ponto de Vendas (PDV)";
        }

        private void CarregarGridPDVAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_pdv"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "at_nomeFant DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosPDVCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdPDV.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosPDVCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryMarcaCadastradosAtivos =
                    from pdv in session.Query<tb_pdv>()
                    join filial in session.Query<tb_ator>()
                        on pdv.fk_tb_ator.id_ator equals filial.id_ator
                    where pdv.pdv_desat == 0
                    orderby filial.at_nomeFant ascending
                    select new
                    {
                        pdv.id_pdv,
                        pdv.pdv_pdvNum,
                        filial.at_nomeFant,
                        filial.at_cnpj
                    };

                e.QueryableSource = queryMarcaCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com PDV: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }

        private void TelaCadastrarPDV(string _operacao, int _idPDV)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadPDV ucCadPdv = new uc_CadPDV(_frmTelaInicial, _operacao, _idPDV);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadPdv);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadPdv;
            ucCadPdv.Show();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastrarPDV("cadastrar", 0);
        }

        private void PegaIdPDVSelecionadaGrid()
        {
            GridView view = grdPDV.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idPDV = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_pdv"));
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdPDVSelecionadaGrid();

            TelaCadastrarPDV("Alterar", idPDV);
        }

        private bool IsPDVComFilial()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var isPDVComFilial = uow.Query<tb_pdv>()
                        .Any(x => x.fk_tb_ator != null && x.id_pdv == idPDV && x.pdv_desat == 0);

                    return isPDVComFilial;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar filial cadastrado com este PDV: {ex.Message}");

                return false;
            }
        }

        private void ExcluirPDV()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_pdv pdv = uow.GetObjectByKey<tb_pdv>(Convert.ToInt64(idPDV));

                    pdv.pdv_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridPDVAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir PDV: {ex.Message}");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdPDVSelecionadaGrid();

            if (IsPDVComFilial())
            {
                MensagensDoSistema.MensagemAtencaoOk("Não é possível excluir este PDV, pois ela está vinculada ao cadastro de alguma filial.");

                idPDV = 0;

                return;
            }

            if (idPDV > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir este PDV?");

                if (result == DialogResult.Yes)
                {
                    ExcluirPDV();

                    uc_MensagemExclusao mensagemExclusaoCantoInferiorDireito = new uc_MensagemExclusao(_frmTelaInicial.pnlTelaPrincipal);
                }
            }
        }

        private void uc_PDV_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }
    }
}