using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DXApplicationPDV.bancoSQLite;
using DXApplicationPDV.Classes;
using DXApplicationPDV.Fluxo_de_Caixa.Entrada_Caixa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplicationPDV.Fluxo_de_Caixa.Saida_Caixa
{
    public partial class uc_VisualizarSaidaCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicial _frmTelaInicial;

        private tb_movimentacao caixaAberto;

        public uc_VisualizarSaidaCaixa(frmTelaInicial _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            PegarDadosCaixaAberto();

            CarregarGridEntradasCaixaAtivas();

            RodaPeGridValorTotal();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovoRegistro);

            uc_TituloTelas1.lblTituloTela.Text = "Retiradas de Caixa";
            uc_SubTituloTelas1.lblSubTituloTela.Text = "Aqui você pode visualizar todas as retiradas de caixa realizadas na jornada atual.";
        }

        private void CarregarGridEntradasCaixaAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_movimentacao"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mv_dtCri DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosVendasAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdListaRetiradasCaixa.DataSource = linqInstantFeedbackSource;
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
                    where movimentacao.fk_tb_jornada == _jornada && movimentacao.mv_movTipo == 12 //11 é entrada de caixa
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
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com retiradas realizadas: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ribbonControl1.Minimized = false;
            this.Dispose();
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto retirada de caixa: {ex.Message}");
            }
        }

        private void RodaPeGridValorTotal()
        {
            // Acessando o GridView do GridControl
            GridView view = grdListaRetiradasCaixa.MainView as GridView;

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

        public void TelaSaidaCaixa()
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_SaidaCaixa ucSaidaCaixa = new uc_SaidaCaixa(_frmTelaInicial);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucSaidaCaixa);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucSaidaCaixa;
            ucSaidaCaixa.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            TelaSaidaCaixa();
        }

        private void uc_VisualizarSaidaCaixa_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }
    }
}