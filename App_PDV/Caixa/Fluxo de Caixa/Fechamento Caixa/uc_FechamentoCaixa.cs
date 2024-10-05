using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Classes;
using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using static App_TelasCompartilhadas.Classes.DadosGeralNfe;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraEditors;
using Unimake.Business.DFe.Xml.SNCM;
using DevExpress.XtraBars.Alerter;

namespace App_PDV.FechamentoCaixa
{
    public partial class uc_FechamentoCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_movimentacao caixaAberto;

        private frmTelaInicialPDV _frmTelaInicial;

        public uc_FechamentoCaixa(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            PegarDadosCaixaAberto();

            if (caixaAberto != null)
            {
                CarregarGridVendasAtivas();

                RodaPeGridValorTotal();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);
            configBotoes.BotaoImprimir(btnImprimir);
            configBotoes.BotaoExcel(btnExcel);

            uc_TituloTelas1.lblTituloTela.Text = "Fechamento de Caixa";
        }

        private void RodaPeGridValorTotal()
        {
            // Acessando o GridView do GridControl
            GridView view = grdListaVendas.MainView as GridView;

            // Ativar o rodapé (footer) no GridView
            view.OptionsView.ShowFooter = true;

            // Definir a soma total para a coluna específica
            view.Columns["mpg_nfeVlrMov"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            view.Columns["mpg_nfeVlrMov"].SummaryItem.DisplayFormat = "Total: {0:C2}"; // Formato de exibição

            // Desabilita a edição para todas as colunas
            if (view != null)
            {
                view.OptionsBehavior.Editable = false;
            }
        }

        private void CarregarGridVendasAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_movimentacao"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mv_dtCri DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosVendasAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdListaVendas.DataSource = linqInstantFeedbackSource;
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
                        on movimentacaoPagamento.id_movimentacao_pagamento equals subFormaPagamento.fk_tb_forma_pagamento.id_forma_pagamento
                    where movimentacao.fk_tb_jornada == _jornada
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
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com vendas realizadas: {exception}");
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

        private void uc_FechamentoCaixa_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto fechamento de caixa: {ex.Message}");
            }
        }

        private void AlterarCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var _caixaAberto = uow.Query<tb_movimentacao>().FirstOrDefault(x => x.id_movimentacao == caixaAberto.id_movimentacao);

                    _caixaAberto.mv_cxAberto = 0; //mv_cxAberto = 0 é caixa fechado

                    uow.Save(_caixaAberto);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar dados caixa aberto fechamento caixa: {ex.Message}");
            }
        }

        private void FechamentoCaixa()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _caixaAberto = new tb_movimentacao(uow)
                    {
                        mv_movTipo = (int)SEnMovTipo.FechCx2, //mv_movTipo = 2 é fechamento de caixa
                        mv_dtCri = DateTime.Now,
                        mv_dtAlt = DateTime.Now
                    };

                    uow.Save(_caixaAberto);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao abrir caixa fechamento de caixa: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza que deseja realizar o fechamento do caixa?");

            if (dialog == DialogResult.Yes)
            {
                FechamentoCaixa();

                AlterarCaixaAberto();

                FecharJornada();

                AlertaConfirmacaoCantoInferiorDireito();

                ImprimiRelatorioFechamentoCaixa();
            }
        }

        private void AlertaConfirmacaoCantoInferiorDireito()
        {
            // Obtém o FluentDesignForm ao qual o FluentDesignFormContainer pertence
            Form parentForm = _frmTelaInicial.FindForm();

            // Verifica se o parentForm não é nulo
            if (parentForm != null)
            {
                // Cria a mensagem e exibe o AlertControl
                AlertInfo info = new AlertInfo("", "");
                alcConfirmacao.Show(parentForm, info);
            }
        }

        private void FecharJornada()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_jornada _jornada = uow.GetObjectByKey<tb_jornada>(Convert.ToInt64(caixaAberto.fk_tb_jornada.id_jornada));

                    _jornada.jo_aberta = 0; //jo_aberta = 0 é jornada fechada
                    _jornada.jo_dtAlt = DateTime.Now;

                    uow.Save(_jornada);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao fechar jornada no fechamento de caixa: {ex.Message}");
            }
        }

        private void ImprimiRelatorioFechamentoCaixa()
        {
            rp_ImpressaoFechamentoCaixa relatorio =
                new rp_ImpressaoFechamentoCaixa(caixaAberto.id_movimentacao);
            relatorio.ShowPreview();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ImprimiRelatorioFechamentoCaixa();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grdListaVendas.DataSource != null)
            {
                using (Session session = new Session())
                {
                    tb_jornada _jornada = session.GetObjectByKey<tb_jornada>(caixaAberto.fk_tb_jornada.id_jornada);

                    string dataAbertura = _jornada.jo_dtCri.ToString("dd/MM/yyyy HH:mm:ss");

                    string dataFechamento = _jornada.jo_dtAlt.ToString("dd/MM/yyyy HH:mm:ss");

                    if (dataFechamento == dataAbertura)
                    {
                        dataFechamento = DateTime.Now.ToString("dd/MM/yyyy");
                    }

                    XtraSaveFileDialog saveFileDialog = new XtraSaveFileDialog();

                    saveFileDialog.Filter = "Excel Files|*.xlsx";

                    string dataInicio = Convert.ToDateTime(dataAbertura).ToString("dd-MM-yyyy");
                    string dataFinal = Convert.ToDateTime(dataFechamento).ToString("dd-MM-yyyy");

                    saveFileDialog.FileName = $"FechamentoCaixa_{dataInicio}_a_{dataFinal}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        grdListaVendas.ExportToXlsx(saveFileDialog.FileName);
                    }
                }
            }
            else
            {
                MensagensDoSistema.MensagemAtencaoOk("Por favor, primeiro inicie a busca.");
            }
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, DevExpress.XtraBars.Alerter.AlertHtmlElementMouseEventArgs e)
        {
            // Verifica qual elemento foi clicado pelo 'id'
            if (e.ElementId == "dialogresult-ok")
            {
                alcConfirmacao.Dispose();
            }
            else if (e.ElementId == "close")
            {
                alcConfirmacao.Dispose();
            }
        }
    }
}