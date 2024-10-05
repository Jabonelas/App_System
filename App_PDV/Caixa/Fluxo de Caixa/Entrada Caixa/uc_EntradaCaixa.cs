using System;
using System.Linq;
using App_TelasCompartilhadas.Classes;
using App_TelasCompartilhadas.bancoSQLite;
using DevExpress.Xpo;
using static App_TelasCompartilhadas.Classes.DadosGeralNfe;
using System.Globalization;
using DevExpress.XtraBars.Alerter;
using System.Windows.Forms;

namespace App_PDV.Fluxo_de_Caixa.Entrada_Caixa
{
    public partial class uc_EntradaCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_jornada jornada;

        private tb_movimentacao caixaAberto;

        private frmTelaInicialPDV _frmTelaInicial;

        public uc_EntradaCaixa(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            PegarDadosCaixaAberto();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            txtValorPagamento.Text = "R$ 0,00";
            uc_TituloTelas1.lblTituloTela.Text = "Entrada de Caixa";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            BuscarJornada();

            EntradaCaixa();

            AlertaConfirmacaoCantoInferiorDireito();

            _frmTelaInicial.TelaVisualizarEntradaCaixa();
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

        private void uc_EntradaCaixa_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaVisualizarEntradaCaixa();
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto na entrada no caixa: {ex.Message}");
            }
        }

        private void BuscarJornada()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    jornada = uow.GetObjectByKey<tb_jornada>(Convert.ToInt64(caixaAberto.fk_tb_jornada.id_jornada));
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar jornada na entrada de caixa: {ex.Message}");
            }
        }

        private void EntradaCaixa()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //ID 5 é a forma de pagamento dinheiro
                    tb_sub_forma_pagamento subFormaPagamento = uow.GetObjectByKey<tb_sub_forma_pagamento>(Convert.ToInt64(5));

                    tb_jornada _jornada = uow.GetObjectByKey<tb_jornada>(Convert.ToInt64(jornada.id_jornada));

                    tb_ator usuairoLogado = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(VariaveisGlobais.UsuarioLogado.id_ator));

                    string valorPagamento = txtValorPagamento.Text.Replace("R$", "").Replace(".", ",");

                    tb_movimentacao _caixaAberto = new tb_movimentacao(uow)
                    {
                        mv_movTipo = (int)SEnMovTipo.Reforco11, //mv_movTipo = 11 é entrada de dinheiro no caixa
                        mv_nfeVlrTotNF = Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR")),
                        mv_dtCri = DateTime.Now,
                        mv_dtAlt = DateTime.Now,
                        fk_tb_ator_atend = usuairoLogado,
                        fk_tb_jornada = _jornada
                    };

                    tb_movimentacao_pagamento _movimentacaoPagamento = new tb_movimentacao_pagamento(uow)
                    {
                        mpg_nfeVlrMov = Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR")),
                        mpg_dtCri = DateTime.Now,
                        mpg_dtAlt = DateTime.Now,
                        fk_tb_movimentacao = _caixaAberto,
                        fk_tb_sub_forma_pagamento = subFormaPagamento,
                    };

                    uow.Save(_caixaAberto);
                    uow.Save(_movimentacaoPagamento);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao realizar entrada no caixa: {ex.Message}");
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