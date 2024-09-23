using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;
using DXApplicationPDV.Classes;
using static DXApplicationPDV.Classes.DadosGeralNfe;

namespace DXApplicationPDV.AberturaCaixa
{
    public partial class uc_AberturaCaixa : DevExpress.XtraEditors.XtraUserControl
    {
        private tb_movimentacao caixaAberto;

        private tb_jornada jornada;

        private frmTelaInicial _frmTelaInicial;

        public uc_AberturaCaixa(frmTelaInicial _form)
        {
            InitializeComponent();

            _frmTelaInicial = _form;

            txtValorPagamento.Text = "R$ 0,00";

            IsCaixaAberto();

            if (caixaAberto != null)
            {
                txtValorPagamento.Text = caixaAberto.mv_nfeVlrTotNF.ToString("C");
            }
        }

        private void uc_AberturaCaixa_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

                    _caixaAberto.mv_nfeVlrTotNF = Convert.ToDecimal(txtValorPagamento.Text.Replace("R$", ""));
                    _caixaAberto.mv_dtAlt = DateTime.Now;

                    uow.Save(_caixaAberto);

                    tb_movimentacao_pagamento _movimentacaoPagamento = uow.Query<tb_movimentacao_pagamento>().FirstOrDefault(x => x.fk_tb_movimentacao.id_movimentacao == _caixaAberto.id_movimentacao);
                    _movimentacaoPagamento.mpg_nfeVlrPag = Convert.ToDecimal(txtValorPagamento.Text.Replace("R$", ""));
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

                    tb_movimentacao _caixaAberto = new tb_movimentacao(uow)
                    {
                        mv_movTipo = (int)SEnMovTipo.AbertCx1, //mv_movTipo = 1 é abertura de caixa
                        mv_cxAberto = 1, //mv_cxAberto = 1 é caixa aberto
                        mv_nfeVlrTotNF = Convert.ToDecimal(txtValorPagamento.Text.Replace("R$", "")),
                        mv_dtCri = DateTime.Now,
                        mv_dtAlt = DateTime.Now,
                        fk_tb_jornada = _jornada
                    };

                    tb_movimentacao_pagamento _movimentacaoPagamento = new tb_movimentacao_pagamento(uow)
                    {
                        mpg_nfeVlrPag = Convert.ToDecimal(txtValorPagamento.Text.Replace("R$", "")),
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
                MensagensDoSistema.MensagemErroOk($"Erro ao abrir caixa: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (caixaAberto == null)
            {
                AberturaJornada();

                AberturaCaixa();

                MensagensDoSistema.MensagemInformacaoOk("Caixa aberto com sucesso!");
            }
            else
            {
                var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza que deseja alterar o valor de abertura do caixa?");

                if (dialog == DialogResult.Yes)
                {
                    AlterarCaixaAberto();

                    MensagensDoSistema.MensagemInformacaoOk("A alteração foi realizada com sucesso!");
                }
            }

            this.Dispose();
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
    }
}