using DevExpress.Data.Linq;
using DevExpress.Xpo;
using DevExpress.XtraGrid.Views.Grid;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Linq;
using System.Windows.Forms;

namespace App_TelasCompartilhadas
{
    public partial class frmSelecionarFilial : DevExpress.XtraEditors.XtraForm
    {
        private int _idAtor = 0;

        public frmSelecionarFilial()
        {
            InitializeComponent();

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            CarregarGridPDVAtivos();
        }

        private void CarregarGridPDVAtivos()
        {
            LinqInstantFeedbackSource linqInstantFeedbackSource = new LinqInstantFeedbackSource();

            linqInstantFeedbackSource.KeyExpression = "id_ator"; //Coluna Primary Key
            linqInstantFeedbackSource.DefaultSorting = "at_nomeFant ASC"; //Coluna de ordenação padrão na ordem escolhida

            linqInstantFeedbackSource.GetQueryable += linqBuscarDadosFuncionariosCadastradosAtivos; //Buscar os dados que vao preencher o grid.

            linqInstantFeedbackSource.DismissQueryable += linq_DismissQueryable; //Basta deixar vazio dentro do metodo.

            grdPDV.DataSource = linqInstantFeedbackSource;
        }

        private void linqBuscarDadosFuncionariosCadastradosAtivos(object sender, GetQueryableEventArgs e)
        {
            try
            {
                Session session = new Session();

                var queryProdutoPDVAtivos = from ator in session.Query<tb_ator>()
                                            join matriz in session.Query<tb_matriz>()
                                                on ator.fk_tb_matriz.id_matriz equals matriz.id_matriz
                                            join pdv in session.Query<tb_pdv>()
                                                on ator.id_ator equals pdv.fk_tb_ator.id_ator
                                            where ator.at_atorTipo == 11 && ator.at_desat == 0 && pdv.pdv_dskSerialNumber == null && pdv.pdv_boardSerialNumber == null
                                            orderby ator.at_razSoc
                                            select new
                                            {
                                                ator.id_ator,
                                                ator.at_nomeFant,
                                                matriz.mt_nomeFant,
                                                pdv.pdv_pdvNum,
                                            };

                e.QueryableSource = queryProdutoPDVAtivos;
            }
            catch (Exception exception)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher tabela com PDV's: {exception}");
            }
        }

        private void linq_DismissQueryable(object sender, GetQueryableEventArgs e)
        {
            //Vazio mesmo
        }

        private void PegaIdCategoriaSelecionadaGrid()
        {
            GridView view = grdPDV.FocusedView as GridView;

            if (view != null)
            {
                int rowHandle = view.FocusedRowHandle;

                if (rowHandle >= 0)
                {
                    _idAtor = Convert.ToInt16(view.GetRowCellValue(rowHandle, "id_ator"));
                }
            }
        }

        private void btnConfimar_Click(object sender, EventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Deseja realmente selecionar este PDV?");

            if (dialog == DialogResult.Yes)
            {
                PegaIdCategoriaSelecionadaGrid();

                PreencherPDVSelecionado();
            }
        }

        private void PreencherPDVSelecionado()
        {
            string macAddress = new VerificarComponentesPC().GetMacAddress();
            string diskSerialNumber = new VerificarComponentesPC().GetDiskSerialNumber();
            string motherboardSerialNumber = new VerificarComponentesPC().GetMotherboardSerialNumber();

            if (_idAtor > 0)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var pdvSelecionado = uow.Query<tb_pdv>().FirstOrDefault(x => x.fk_tb_ator.id_ator == _idAtor);

                    if (pdvSelecionado != null)
                    {
                        pdvSelecionado.pdv_nicMacAddress = macAddress;
                        pdvSelecionado.pdv_dskSerialNumber = diskSerialNumber;
                        pdvSelecionado.pdv_boardSerialNumber = motherboardSerialNumber;

                        VariaveisGlobais.PDVLogado = pdvSelecionado;

                        uow.Save(pdvSelecionado);
                        uow.CommitChanges();

                        this.Close();

                        VariaveisGlobais.isInicializarSistema = true;
                    }
                    else
                    {
                        MensagensDoSistema.MensagemErroOk("Erro ao selecionar o PDV.");
                    }
                }
            }
            else
            {
                MensagensDoSistema.MensagemErroOk("Selecione um PDV.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Deseja realmente cancelar a seleção do PDV?");

            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}