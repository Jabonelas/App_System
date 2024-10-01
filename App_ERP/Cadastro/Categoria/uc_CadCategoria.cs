using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Xpo;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;

namespace App_ERP
{
    public partial class uc_CadCategoria : DevExpress.XtraEditors.XtraUserControl
    {
        private frmTelaInicialERP _frmTelaInicial;

        private long idSecao = 0;
        private long idCategoria = 0;

        private string operacao = string.Empty;

        private Dictionary<long, string> dicSecao = new Dictionary<long, string>();

        public uc_CadCategoria(frmTelaInicialERP _form, string _operacao, int _idCategoria)
        {
            InitializeComponent();

            Layout();

            PreencherSecoes();

            _frmTelaInicial = _form;

            idCategoria = _idCategoria;

            operacao = _operacao;

            if (idCategoria != 0)
            {
                PreencherCampos();
            }
        }

        private void Layout()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = " Cadastro de Categorias";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            _frmTelaInicial.TelaCategoria();
        }

        private void uc_CadCategoria_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }

        private void PreencherCampos()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var query = (from categoria in uow.Query<tb_categoria_produto>()
                                 join secao in uow.Query<tb_secao_produto>()
                                 on categoria.fk_tb_secao_produto.id_secao_produto equals secao.id_secao_produto
                                 where categoria.id_categoria_produto == idCategoria
                                 select new
                                 {
                                     categoria.cp_desc,
                                     secao.sp_desc
                                 }).FirstOrDefault();

                    txtDescrcricaoCategoria.Text = query.cp_desc;
                    cmbSecao.Text = query.sp_desc;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preenhcer campos da tela de cadastro de categoria: {ex.Message}");
            }
        }

        private void PreencherSecoes()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var secao = uow.Query<tb_secao_produto>().Where(x => x.sp_desat == 0).Select(x => new { x.sp_desc, x.id_secao_produto }).ToList();

                    foreach (var item in secao)
                    {
                        dicSecao.Add(item.id_secao_produto, item.sp_desc);
                    }

                    cmbSecao.Properties.Items.AddRange(dicSecao.Values);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar secao: {ex.Message}");
            }
        }

        private bool IsSecaoExiste()
        {
            try
            {
                var descricaoSecao = cmbSecao.Text;

                idSecao = dicSecao.FirstOrDefault(x => x.Value == descricaoSecao).Key;

                var isSecaoExiste = idSecao == 0 ? false : true;

                return isSecaoExiste;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar secao: {ex.Message}");

                return false;
            }
        }

        private void CadastrarSecao()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = new tb_secao_produto(uow);

                    secao.sp_desc = cmbSecao.Text;
                    secao.sp_dtCri = DateTime.Now;
                    secao.sp_dtAlt = DateTime.Now;
                    secao.sp_desat = 0;

                    uow.CommitChanges();

                    idSecao = secao.id_secao_produto;

                    dicSecao.Add(secao.id_secao_produto, secao.sp_desc);

                    //cmbSecao.Properties.Items.AddRange(dicSecao.Values);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar secao: {ex.Message}");
            }
        }

        private void CadastrarCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_secao_produto secao = uow.GetObjectByKey<tb_secao_produto>(Convert.ToInt64(idSecao));

                    tb_categoria_produto categoria = new tb_categoria_produto(uow);

                    categoria.cp_desc = txtDescrcricaoCategoria.Text;
                    categoria.cp_dtCri = DateTime.Now;
                    categoria.cp_dtAlt = DateTime.Now;
                    categoria.cp_desat = 0;
                    categoria.fk_tb_secao_produto = secao;

                    uow.Save(categoria);
                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar categoria: {ex.Message}");
            }
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(cmbSecao.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Seção.");
                cmbSecao.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescrcricaoCategoria.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Descrição Categoria.");
                txtDescrcricaoCategoria.Focus();
                return false;
            }

            return true;
        }

        private void AlterarCategoria()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(idCategoria);

                    long idSecao = dicSecao.FirstOrDefault(x => x.Value == cmbSecao.Text).Key;

                    tb_secao_produto secaoProduto = uow.GetObjectByKey<tb_secao_produto>(idSecao);

                    categoria.cp_desc = txtDescrcricaoCategoria.Text;
                    categoria.cp_dtAlt = DateTime.Now;
                    categoria.fk_tb_secao_produto = secaoProduto;

                    uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar categoria: {ex.Message}");
            }
        }

        private bool IsCategoriaExiste()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    string descricaoCategoria = txtDescrcricaoCategoria.Text;

                    var isCateSecaoExist = uow.Query<tb_categoria_produto>()
                        .Any(x => x.cp_desc == descricaoCategoria && x.cp_desat == 0);

                    return isCateSecaoExist;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar categoria: {ex.Message}");

                return false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar" && IsCategoriaExiste())
            {
                MensagensDoSistema.MensagemAtencaoOk("Uma categoria com essa descrição já está cadastrada.");

                return;
            }

            if (operacao == "cadastrar")
            {
                if (IsSecaoExiste())
                {
                    CadastrarCategoria();
                }
                else
                {
                    CadastrarSecao();

                    CadastrarCategoria();
                }
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    if (!IsSecaoExiste())
                    {
                        CadastrarSecao();
                    }

                    AlterarCategoria();
                }
            }

            _frmTelaInicial.TelaCategoria();
        }
    }
}