using System;
using System.Linq;
using App_TelasCompartilhadas.Classes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;

namespace App_PDV.Fluxo_de_Caixa.Entrada_Caixa
{
    public partial class uc_VisualizarEntradasCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialPDV _frmTelaInicial;

        private tb_movimentacao caixaAberto;

        public uc_VisualizarEntradasCaixa(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            LayoutBotoes();

            _frmTelaInicial = _form;

            PegarDadosCaixaAberto();

            CarregarGridEntradasCaixaAtivas();

            RodaPeGridValorTotal();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovoRegistro);

            uc_TituloTelas1.lblTituloTela.Text = "Entradas de Caixa";
        }

        private void CarregarGridEntradasCaixaAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_movimentacao"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mv_dtCri DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosVendasAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdListaEntradasCaixa.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosVendasAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                var queryMovimentacoesAtivas =
                    from movimentacao in session.Query<tb_movimentacao>()
                    join movimentacaoPagamento in session.Query<tb_movimentacao_pagamento>()
                        on movimentacao.id_movimentacao equals movimentacaoPagamento.fk_tb_movimentacao.id_movimentacao
                    join subFormaPagamento in session.Query<tb_sub_forma_pagamento>()
                        on movimentacaoPagamento.id_movimentacao_pagamento equals subFormaPagamento
                            .fk_tb_forma_pagamento.id_forma_pagamento
                    where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 11 //11 é entrada de caixa
                    orderby movimentacao.mv_dtCri descending
                    select new
                    {
                        movimentacao.mv_dtCri,
                        movimentacaoPagamento.mpg_nfeVlrMov,
                        movimentacao.id_movimentacao,
                        movimentacaoPagamento.fk_tb_sub_forma_pagamento.sfp_desc,
                        subFormaPagamento.fk_tb_forma_pagamento,
                    };

                e.QueryableSource = queryMovimentacoesAtivas;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com entradas realizadas: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void PegarDadosCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //mv_movTipo = 1 é abertura de caixa e mv_cxAberto = 1 é caixa aberto

                    caixaAberto = uow.Query<tb_movimentacao>().FirstOrDefault(x => x.mv_movTipo == 1 && x.mv_cxAberto == 1);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto entrada de caixa: {ex.Message}");
            }
        }

        private void RodaPeGridValorTotal()
        {
            // Acessando o GridView do GridControl
            GridView view = grdListaEntradasCaixa.MainView as GridView;

            // Ativar o rodapé (footer) no GridView
            view.OptionsView.ShowFooter = true;

            // Definir a soma total para a coluna específica
            view.Columns["mpg_nfeVlrMov"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["mpg_nfeVlrMov"].SummaryItem.DisplayFormat = "Total: {0:n2}"; // Formato de exibição

            // Desabilita a edição para todas as colunas
            if (view != null)
            {
                view.OptionsBehavior.Editable = false;
            }
        }

        private void uc_VisualizarEntradasCaixa_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }

        public void TelaEntradaCaixa()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_EntradaCaixa ucEntradaCaixa = new uc_EntradaCaixa(_frmTelaInicial);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucEntradaCaixa);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucEntradaCaixa;
            ucEntradaCaixa.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            TelaEntradaCaixa();
        }
    }
}