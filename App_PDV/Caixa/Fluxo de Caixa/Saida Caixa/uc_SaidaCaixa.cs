﻿using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Globalization;
using System.Linq;
using static App_TelasCompartilhadas.Classes.DadosGeralNfe;
using App_TelasCompartilhadas;

namespace App_PDV.Fluxo_de_Caixa.Saida_Caixa
{
    public partial class uc_SaidaCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_jornada jornada;

        private tb_movimentacao caixaAberto;

        private frmTelaInicialPDV _frmTelaInicial;

        public uc_SaidaCaixa(frmTelaInicialPDV _form)
        {
            InitializeComponent();

            LayoutBotoes();

            _frmTelaInicial = _form;

            txtValorPagamento.Text = "R$ 0,00";

            PegarDadosCaixaAberto();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Vendas Realizadas";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaVisualizarSaidaCaixa();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            BuscarJornada();

            SaidaCaixa();

            _frmTelaInicial.TelaVisualizarSaidaCaixa();

            uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(_frmTelaInicial.pnlTelaPrincipal);
        }

        private void uc_SaidaCaixa_Load(object sender, EventArgs e)
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar caixa aberto na retirada no caixa: {ex.Message}");
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
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar jornada na retirada de caixa: {ex.Message}");
            }
        }

        private void SaidaCaixa()
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
                        mv_movTipo = (int)SEnMovTipo.Retirada12, //mv_movTipo = 12 é retirada de dinheiro no caixa
                        mv_nfeVlrTotNF = -Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR")),//valor esta dando entrada negativa, pois trata de uma retirada
                        mv_dtCri = DateTime.Now,
                        mv_dtAlt = DateTime.Now,
                        fk_tb_ator_atend = usuairoLogado,
                        fk_tb_jornada = _jornada
                    };

                    tb_movimentacao_pagamento _movimentacaoPagamento = new tb_movimentacao_pagamento(uow)
                    {
                        mpg_nfeVlrMov = -Convert.ToDecimal(valorPagamento, new CultureInfo("pt-BR")), //valor esta dando entrada negativa, pois trata de uma retirada
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
                MensagensDoSistema.MensagemErroOk($"Erro ao realizar retirada no caixa: {ex.Message}");
            }
        }
    }
}