using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Linq;
using System.Windows.Forms;
using App_ERP.Cadastro.Ator;
using DevExpress.XtraGrid.Views.Grid;
using App_ERP.Cadastro.Funcionario;
using App_TelasCompartilhadas.Classes;

namespace App_ERP.Cadastro.Consumidor
{
    public partial class uc_Ator : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private int tipoAtor = 0;

        private int idAtor = 0;

        public uc_Ator(frmTelaInicialERP _form, int _tipoAtor)
        {
            InitializeComponent();

            _frmTelaInicial = _form;

            tipoAtor = _tipoAtor;

            FormatarTelaTipoAtor(_tipoAtor);

            CarregarGridAtorAtivas();
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

                    lblTitulo.Text = "Consumidor";
                    lblSubTitulo.Text = "Consumidores cadastrados";
                    break;

                case 10:

                    lblTitulo.Text = "Empresa";
                    lblSubTitulo.Text = "Empresas cadastradas";
                    break;

                case 11:

                    lblTitulo.Text = "Filial";
                    lblSubTitulo.Text = "Filiais cadastradas";
                    break;

                case 20:

                    lblTitulo.Text = "Fornecedor";
                    lblSubTitulo.Text = "Fornecedores cadastrados";
                    break;

                case 30:

                    lblTitulo.Text = "Transportadora";
                    lblSubTitulo.Text = "Transportadoras cadastradas";
                    break;

                case 40:

                    lblTitulo.Text = "Intermediador";
                    lblSubTitulo.Text = "Intermediadores cadastrados ";
                    break;

                case 100:

                    lblTitulo.Text = "Funcionário";
                    lblSubTitulo.Text = "Funcionários cadastrados";
                    break;
            }
        }

        private void uc_CadastroAtor_Load(object sender, EventArgs e)
        {
            TelaDeCarregamento.EsconderCarregamento();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
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

        private void TelaCadastrarFuncionario(string _operacao, long _idAtorFuncionario)
        {
            TelaDeCarregamento.ExibirCarregamentoUserControl(this);

            _frmTelaInicial.pnlTelaPrincipal.Controls.Clear();
            uc_CadFuncionario ucCadFuncionario = new uc_CadFuncionario(_frmTelaInicial, _operacao, _idAtorFuncionario);
            _frmTelaInicial.pnlTelaPrincipal.Controls.Add(ucCadFuncionario);
            _frmTelaInicial.pnlTelaPrincipal.Tag = ucCadFuncionario;
            this.Invoke(new Action(() => TelaDeCarregamento.EsconderCarregamento()));
            ucCadFuncionario.Show();
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

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //entra caso for cadastro de funcionário
            if (tipoAtor == 100)
            {
                TelaCadastrarFuncionario("cadastrar", 0);
            }
            else
            {
                TelaCadastrarAtor("cadastrar", 0);
            }
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            PegaIdCategoriaSelecionadaGrid();

            //entra caso for cadastro de funcionário
            if (tipoAtor == 100)
            {
                TelaCadastrarFuncionario("Alterar", idAtor);
            }
            else
            {
                TelaCadastrarAtor("Alterar", idAtor);
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