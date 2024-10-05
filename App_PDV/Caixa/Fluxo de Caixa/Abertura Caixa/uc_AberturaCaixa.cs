using System;
using System.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using static App_TelasCompartilhadas.Classes.DadosGeralNfe;
using System.Globalization;

using App_TelasCompartilhadas.bancoSQLite;

using App_PDV.FechamentoCaixa;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars.Alerter;
using System.Windows.Forms;

namespace App_PDV.AberturaCaixa
{
    public partial class uc_AberturaCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_movimentacao caixaAberto;

        private tb_jornada jornada;

        private frmTelaInicialPDV _frmTelaInicial;

        private long idCaixaAberto;

        public uc_AberturaCaixa(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            Layout();

            _frmTelaInicial = _form;

            IsCaixaAberto();

            if (caixaAberto != null)
            {
                txtValorPagamento.Text = caixaAberto.mv_nfeVlrTotNF.ToString("C");
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoSalvar(btnSalvar);

            configBotoes.BotaoVoltar(btnVoltar);

            txtValorPagamento.Text = "R$ 0,00";
            uc_TituloTelas1.lblTituloTela.Text = "Abertura de Caixa";
        }

        private void uc_AberturaCaixa_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ExibirTelaInicial(this);
        }

        private void IsCaixaAberto()
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto: {ex.Message}");
            }
        }

        private void AlterarCaixaAberto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_movimentacao _caixaAberto = uow.Query<tb_movimentacao>().FirstOrDefault(x => x.id_movimentacao == caixaAberto.id_movimentacao);

                    string valorPagamento = txtValorPagamento.Text.Replace("R$", "").Replace(".", ",");

                    _caixaAberto.mv_nfeVlrTotNF = Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR"));
                    _caixaAberto.mv_dtAlt = DateTime.Now;

                    uow.Save(_caixaAberto);

                    tb_movimentacao_pagamento _movimentacaoPagamento = uow.Query<tb_movimentacao_pagamento>().FirstOrDefault(x => x.fk_tb_movimentacao.id_movimentacao == _caixaAberto.id_movimentacao);
                    _movimentacaoPagamento.mpg_nfeVlrMov = Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR"));
                    _movimentacaoPagamento.mpg_dtAlt = DateTime.Now;

                    uow.Save(_movimentacaoPagamento);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar dados caixa aberto: {ex.Message}");
            }
        }

        private void AberturaCaixa()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //ID 5 é a forma de pagamento dinheiro
                    tb_sub_forma_pagamento subFormaPagamento = uow.GetObjectByKey<tb_sub_forma_pagamento>(Convert.ToInt64(5));

                    tb_jornada _jornada = uow.GetObjectByKey<tb_jornada>(Convert.ToInt64(jornada.id_jornada));

                    string valorPagamento = txtValorPagamento.Text.Replace("R$", "").Replace(".", ",");

                    tb_movimentacao _caixaAberto = new tb_movimentacao(uow)
                    {
                        mv_movTipo = (int)DadosGeralNfe.SEnMovTipo.AbertCx1, //mv_movTipo = 1 é abertura de caixa
                        mv_cxAberto = 1, //mv_cxAberto = 1 é caixa aberto
                        mv_nfeVlrTotNF = Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR")),
                        mv_dtCri = DateTime.Now,
                        mv_dtAlt = DateTime.Now,
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

                    idCaixaAberto = _caixaAberto.id_movimentacao;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao abrir caixa: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (caixaAberto == null)
            {
                AberturaJornada();

                AberturaCaixa();

                AlertaConfirmacaoCantoInferiorDireito();

                ImprimiRelatorioAberturaCaixa();
            }
            else
            {
                //var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza que deseja alterar o valor de abertura do caixa?");

                //if (dialog == DialogResult.Yes)
                //{
                //    AlterarCaixaAberto();

                //    MensagensDoSistema.MensagemInformacaoOk("A alteração foi realizada com sucesso!");
                //}

                MensagensDoSistema.MensagemAtencaoOk("A abertura do caixa já foi realizada!");
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

        private void ImprimiRelatorioAberturaCaixa()
        {
            rp_ImpressaoAberturaCaixa relatorio =
                new rp_ImpressaoAberturaCaixa(idCaixaAberto);
            relatorio.ShowPreview();
        }

        private void AberturaJornada()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_pdv pdv = uow.GetObjectByKey<tb_pdv>(Convert.ToInt64(VariaveisGlobais.PDVLogado.id_pdv));

                    tb_jornada _jornada = new tb_jornada(uow)
                    {
                        jo_aberta = 1, //jo_aberta = 1 é jornada aberta
                        jo_dtCri = DateTime.Now,
                        jo_dtAlt = DateTime.Now,
                        fk_tb_pdv = pdv
                    };

                    uow.Save(_jornada);
                    uow.CommitChanges();

                    jornada = _jornada;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao fechar jornada na abertura de caixa: {ex.Message}");
            }
        }

        private void alcConfirmacao_HtmlElementMouseClick(object sender, AlertHtmlElementMouseEventArgs e)
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