using DevExpress.Data.Linq;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Linq;
using System.Windows.Forms;
using App_TelasCompartilhadas.Cadastro.Funcionario;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.Login;
using App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito;

namespace App_TelasCompartilhadas.Ator
{
    public partial class uc_Ator : DevExpress.XtraEditors.XtraUserControl
    {
        private int tipoAtor = 0;

        private int idAtor = 0;

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_Ator(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, int _tipoAtor)
        {
            InitializeComponent();

            LayoutBotoes();

            painelTelaInicial = _painelTelaInicial;

            FormatarTelaTipoAtor(_tipoAtor);

            tipoAtor = _tipoAtor;

            CarregarGridAtorAtivas();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoNovoRegistro(btnNovoRegistro);
            configBotoes.BotaoAlterar(btnAlterar);
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
                    layoutControlGroup1.Text = "Aqui você pode visualizar todos os consumidores cadastrados";
                    break;

                case 10:

                    uc_TituloTelas1.lblTituloTela.Text = "Empresa";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todas as empresas cadastradas";
                    break;

                case 11:

                    uc_TituloTelas1.lblTituloTela.Text = "Filial";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todas as filiais cadastradas";
                    break;

                case 20:

                    uc_TituloTelas1.lblTituloTela.Text = "Fornecedor";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todos os fornecedores cadastrados";
                    break;

                case 30:

                    uc_TituloTelas1.lblTituloTela.Text = "Transportadora";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todas as transportadoras cadastradas";

                    break;

                case 40:

                    uc_TituloTelas1.lblTituloTela.Text = "Intermediador";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todos os intermediadores cadastrados";

                    break;

                case 100:

                    uc_TituloTelas1.lblTituloTela.Text = "Funcionário";
                    layoutControlGroup1.Text = "Aqui você pode visualizar todos os funcionários cadastrados";

                    break;
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            painelTelaInicial.Controls.Clear();
            uc_TelaInicial ucCadAtor = new uc_TelaInicial();
            painelTelaInicial.Controls.Add(ucCadAtor);
            painelTelaInicial.Tag = ucCadAtor;

            ucCadAtor.Show();
        }

        private void CarregarGridAtorAtivas()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_ator"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "at_nomeFant ASC"; //Coluna de ordenação padrão na ordem escolhida

            if (tipoAtor == 100)
            {
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosFuncionariosCadastradosAtivos; //Buscar os dados que vao preencher o grid. Exibindo apenas os cadastros de funcionarios ativos.
            }
            else
            {
                linqInstantFeedbackSource.GetQueryable += linqBuscarDadosAtorCadastradosAtivos; //Buscar os dados que vao preencher o grid. Exibindo todos os outros tipos de cadastros.
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
            painelTelaInicial.Controls.Clear();
            uc_CadAtor ucCadAtor = new uc_CadAtor(painelTelaInicial, _operacao, _idAtor, tipoAtor);
            painelTelaInicial.Controls.Add(ucCadAtor);
            painelTelaInicial.Tag = ucCadAtor;

            ucCadAtor.Show();
        }

        private void btnNovoRegistro_Click(object sender, EventArgs e)
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

        private void TelaCadastrarFuncionario(string _operacao, long _idAtorFuncionario)
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            painelTelaInicial.Controls.Clear();
            uc_CadFuncionario ucCadFuncionario = new uc_CadFuncionario(painelTelaInicial, _operacao, _idAtorFuncionario);
            painelTelaInicial.Controls.Add(ucCadFuncionario);
            painelTelaInicial.Tag = ucCadFuncionario;
            ucCadFuncionario.Show();
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

        private void TelaAutenticacaoUsuario()
        {
            TelaCarregamento.ExibirCarregamentoUserControl(this);

            frmAutenticacaoUsuario frmAutenticacaoUsuario = new frmAutenticacaoUsuario();
            frmAutenticacaoUsuario.ShowDialog();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

                PegaIdCategoriaSelecionadaGrid();

                if (idAtor > 0)
                {
                    var result = MensagensDoSistema.MensagemAtencaoYesNo("Você tem certeza de que deseja excluir este cadastro?");

                    if (result == DialogResult.Yes)
                    {
                        ExcluirCadastroAtor();

                        uc_MensagemExclusao mensagemExclusaoCantoInferiorDireito = new uc_MensagemExclusao(painelTelaInicial);
                    }
                }
            }
        }

        private void ExcluirCadastroAtor()
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //Gerente 102
            bool podeAlterarAtor = VariaveisGlobais.UsuarioLogado.at_atorTipo == 102 || VariaveisGlobais.isUsuarioComPermissao;

            if (!podeAlterarAtor)
            {
                TelaAutenticacaoUsuario();

                podeAlterarAtor = VariaveisGlobais.isUsuarioComPermissao;
            }

            if (podeAlterarAtor)
            {
                VariaveisGlobais.isUsuarioComPermissao = false;

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
        }

        private void uc_Ator_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }
    }
}