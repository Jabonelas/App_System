using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraEditors;
using DXApplicationPDV.bancoSQLite;
using DXApplicationPDV.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DXApplicationPDV.Consultas.Clientes.Consumidores_Empresas;
using Unimake.Business.DFe.Servicos;

namespace DXApplicationPDV.Consultas.Itens.Consumidores
{
    public partial class uc_Ator : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicial _frmTelaInicial;

        private int tipoAtor = 0;

        private int idAtor = 0;

        public uc_Ator(frmTelaInicial _form, int _tipoAtor)
        {
            InitializeComponent();

            Layout();

            FormatarTelaTipoAtor(_tipoAtor);

            _frmTelaInicial = _form;

            tipoAtor = _tipoAtor;

            CarregarGridAtorAtivas();
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovoRegistro);
            configBotoes.BotaoVisualizar(btnVisualizar);
            configBotoes.BotaoExcluir(btnExcluir);
        }

        //Tipos Ator

        //(1, 'Consumidor'),
        //(10, 'Empresa'),
        //(11, 'Filial'),
        //(20, 'Fornecedor'),
        //(30, 'Transporte'),
        //(40, 'Intermediador'),
        //(100, 'Funcionário'),
        //(101, 'Vendedor'),
        //(102, 'Gerente');

        private void FormatarTelaTipoAtor(int _tipoAtor)
        {
            switch (_tipoAtor)
            {
                case 1:

                    uc_TituloTelas1.lblTituloTela.Text = "Consumidor";
                    uc_SubTituloTelas1.lblSubTituloTela.Text = "Aqui você pode visualizar todos os consumidores cadastrados";
                    break;

                case 10:

                    uc_TituloTelas1.lblTituloTela.Text = "Empresa";
                    uc_SubTituloTelas1.lblSubTituloTela.Text = "Aqui você pode visualizar todas as empresas cadastradas";
                    break;
            }
        }

        private void uc_Consumidor_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.ribbonControl1.Minimized = false;

            this.Dispose();
        }

        private void CarregarGridAtorAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_ator"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "at_nomeFant ASC"; //Coluna de ordenação padrão na ordem escolhida

            if (tipoAtor == 100)
            {
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosFuncionariosCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            }
            else
            {
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosAtorCadastradosAtivos; //Buscar os dados que vao preencher o grid.
            }

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.
            grdAtor.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosFuncionariosCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryAtorCadastradosAtivos =
                    from ator in session.Query<tb_ator>()
                    where ator.at_desat == 0 && (ator.at_atorTipo == 100 || ator.at_atorTipo == 101 || ator.at_atorTipo == 102)
                    orderby ator.at_nomeFant ascending
                    select new
                    {
                        ator.id_ator,
                        ator.at_cnpj,
                        ator.at_razSoc,
                        ator.at_cpf,
                        ator.at_nomeFant,
                    };

                e.QueryableSource = queryAtorCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com ator: {exception}");
            }
        }

        private void linqBuscarDadosAtorCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryAtorCadastradosAtivos =
                    from ator in session.Query<tb_ator>()
                    where ator.at_desat == 0 && ator.at_atorTipo == tipoAtor
                    orderby ator.at_nomeFant ascending
                    select new
                    {
                        ator.id_ator,
                        ator.at_cnpj,
                        ator.at_razSoc,
                        ator.at_cpf,
                        ator.at_nomeFant,
                    };

                e.QueryableSource = queryAtorCadastradosAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com ator: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void TelaCadastrarAtor(string _operacao, long _idAtor)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadAtor ucCadAtor = new uc_CadAtor(_frmTelaInicial, _operacao, _idAtor, tipoAtor);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadAtor);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadAtor;
            this.Invoke(new Action(() => TelaDeCarregamento.EsconderCarregamento()));
            ucCadAtor.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
        {
            TelaCadastrarAtor("cadastrar", 0);
        }

        private void PegaIdCategoriaSelecionadaGrid()
        {
            GridView view = grdAtor.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    idAtor = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_ator"));
                }
            }
        }

        //Niveis de acesso
        //"100 Funcionario"
        //"101 Vendedor"
        //"102 Gerente"

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (VariaveisGlobais.UsuarioLogado.at_atorTipo == 102)
            {
                PegaIdCategoriaSelecionadaGrid();

                TelaCadastrarAtor("Alterar", idAtor);
            }
            else
            {
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            if (idAtor > 0)
            {
                var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir este cadastro?");

                if (result == DialogResult.Yes)
                {
                    ExcluirCategoria();
                }
            }
        }

        private void ExcluirCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_ator ator = uow.GetObjectByKey<tb_ator>(Convert.ToInt64(idAtor));

                    ator.at_desat = 1;

                    uow.CommitChanges();
                }

                CarregarGridAtorAtivas();
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao excluir ator: {ex.Message}");
            }
        }
    }
}