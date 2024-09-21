﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DXApplicationPDV.Classes;
using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DXApplicationPDV.bancoSQLite;
using Unimake.Business.DFe.Servicos;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using DevExpress.XtraGrid.Views.Grid;

namespace DXApplicationPDV
{
    public partial class uc_VendasPDV : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicial _frmTelaInicial;

        public uc_VendasPDV(frmTelaInicial _form)
        {
            InitializeComponent();

            _frmTelaInicial = _form;

            CarregarGridMovimentacaoAtivas();
        }

        private void uc_VendasPDV_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void CarregarGridMovimentacaoAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_movimentacao"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "mv_dtCri DESC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosMovimentacaoCadastradosAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdListaVendas.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosMovimentacaoCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                tb_ator filialLogado = session.GetObjectByKey<tb_ator>(VariaveisGlobais.FilialLogada.id_ator);

                DateTime dataLimite = DateTime.Now.AddDays(-30);

                var queryMovimentacoesAtivas =
                    from movimentacao in session.Query<tb_movimentacao>()
                    join nfe in session.Query<tb_nfe>()
                        on movimentacao.id_movimentacao equals nfe.fk_tb_movimentacao.id_movimentacao
                    where movimentacao.mv_dtCri >= dataLimite && movimentacao.fk_tb_ator_emit == filialLogado
                    orderby movimentacao.mv_dtCri descending
                    select new
                    {
                        movimentacao.id_movimentacao,
                        movimentacao.mv_dtCri,
                        movimentacao.fk_tb_ator_atend.at_nomeFant,
                        nfe.nf_nfe1ResProtNFeInfProt0ChNFe,
                        movimentacao.mv_qtdItens,
                        movimentacao.mv_nfeVlrTotNF,
                        movimentacao.mv_nfeVlrTotDesc,
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

        public void TelaPDV()
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_PDV ucProdutos = new uc_PDV(_frmTelaInicial);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucProdutos);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucProdutos;
            ucProdutos.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            TelaPDV();
        }

        public void TelaVisualizarVenda()
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_VisualizarVenda ucVisualizarVenda = new uc_VisualizarVenda(_frmTelaInicial, idMovimentacaoSelecionada);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucVisualizarVenda);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucVisualizarVenda;
            ucVisualizarVenda.Show();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            TelaVisualizarVenda();
        }

        private int idMovimentacaoSelecionada = 0;

        private void PegaIdCategoriaSelecionadaGrid()
        {
            GridView view = grdListaVendas.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idMovimentacaoSelecionada = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_movimentacao"));
                }
            }
        }
    }
}