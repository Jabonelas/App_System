using DevExpress.Xpo;
using DevExpress.XtraEditors;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace App_TelasCompartilhadas.Produtos
{
    public partial class uc_CadProduto : DevExpress.XtraEditors.XtraUserControl
    {
        private string formaOrdenarGrid = "";
        private string operacao = "";
        public static string vlrAjuste = "";
        private long idProduto = 0;
        private long idMarcaProduto = 0;
        private decimal vlrProdInicial = 0;

        private Dictionary<int, string> dicUnMed = new Dictionary<int, string>();
        private Dictionary<long, string> dicMarcaProd = new Dictionary<long, string>();

        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer painelTelaInicial;

        public uc_CadProduto(DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer _painelTelaInicial, string _operacao, long _idProduto, string _formaOrdenarGrid)
        {
            InitializeComponent();

            painelTelaInicial = _painelTelaInicial;

            operacao = _operacao;

            idProduto = _idProduto;

            formaOrdenarGrid = _formaOrdenarGrid;

            CarregaUnMed();

            PreencherCategoria();

            PreencherSubcategoria();

            PreencherMarca();

            LayoutBotoes();

            if (operacao == "cadastrar")
            {
                PreencherCodigoProduto();
            }
            else
            {
                PreencherCampoProdutoSelecionado();
            }

            cmbCFOP.Properties.AddEnum<DadosGeralNfe.SEnNfeCfop>();

            cmbCest.Properties.AddEnum<DadosGeralNfe.SEnNfeCst>();

            cmbModalidade_ICMSST.Properties.AddEnum<DadosGeralNfe.SEnNfeModBcSt>();

            cmbModalidade_ICMSEProprio.Properties.AddEnum<DadosGeralNfe.SEnNfeModBc>();
        }

        private void LayoutBotoes()
        {
            ConfigBotoes configBotoes = new ConfigBotoes();

            configBotoes.BotaoVoltar(btnVoltar);
            configBotoes.BotaoSalvar(btnSalvar);

            uc_TituloTelas1.lblTituloTela.Text = "Cadastro de Produtos";
        }

        private void CadastrarMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_marca_produto marcaProduto = new tb_marca_produto(uow);

                    marcaProduto.mp_desc = cmbMarca.Text;
                    marcaProduto.mp_dtCri = DateTime.Now;
                    marcaProduto.mp_dtAlt = DateTime.Now;
                    //secao.mp_desat = 0;

                    uow.CommitChanges();

                    idMarcaProduto = marcaProduto.id_marca_produto;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar marca: {ex.Message}");
            }
        }

        private bool IsMarcaExiste()
        {
            try
            {
                if (cmbMarca.Text == "")
                {
                    return true;
                }

                long idMarca = dicMarcaProd.FirstOrDefault(x => x.Value == cmbMarca.Text).Key;

                var isMarcaExiste = idMarca == 0 ? false : true;

                return isMarcaExiste;
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao verificar marca: {ex.Message}");

                return false;
            }
        }

        private void PreencherMarca()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var marca = uow.Query<tb_marca_produto>().Where(x => x.mp_desat == 0).Select(x => new { x.mp_desc, x.id_marca_produto }).ToList();

                    foreach (var item in marca)
                    {
                        dicMarcaProd.Add(item.id_marca_produto, item.mp_desc);
                    }

                    cmbMarca.Properties.Items.AddRange(dicMarcaProd.Values);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao buscar marca: {ex.Message}");
            }
        }

        private void PreencherCategoria()
        {
            try
            {
                using (Session session = new Session())
                {
                    var categoria = session.Query<tb_categoria_produto>()
                        .Where(x => x.cp_desat == 0)
                        .Select(x => new
                        {
                            x.id_categoria_produto,
                            x.cp_desc
                        })
                        .ToList();

                    cmbCategoria.Properties.DataSource = categoria;
                    cmbCategoria.Properties.DisplayMember = "cp_desc";
                    cmbCategoria.Properties.ValueMember = "id_categoria_produto";
                    cmbCategoria.Properties.NullText = "Selecione a Categoria";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher categoria: {ex.Message}");
            }
        }

        private void PreencherSubcategoria()
        {
            try
            {
                using (Session session = new Session())
                {
                    var subcategoria = session.Query<tb_subcategoria_produto>()
                        .Where(x => x.scp_desat == 0)
                    .Select(x => new
                    {
                        x.id_subcategoria_produto,
                        x.scp_desc
                    })
                    .ToList();

                    cmbSubcategoria.Properties.DataSource = subcategoria;
                    cmbSubcategoria.Properties.DisplayMember = "scp_desc";
                    cmbSubcategoria.Properties.ValueMember = "id_subcategoria_produto";
                    cmbSubcategoria.Properties.NullText = "Selecione a Subcategoria";
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher subcategoria: {ex.Message}");
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            painelTelaInicial.Controls.Clear();
            uc_Produto ucProduto = new uc_Produto(painelTelaInicial, formaOrdenarGrid);
            painelTelaInicial.Controls.Add(ucProduto);
            painelTelaInicial.Tag = ucProduto;

            ucProduto.Show();
        }

        public void CarregaUnMed()
        {
            dicUnMed.Add(0, "NAO DEFINIDO");
            dicUnMed.Add(1, "UN");
            dicUnMed.Add(2, "PC");
            dicUnMed.Add(3, "PT");
            dicUnMed.Add(4, "RL");
            dicUnMed.Add(5, "BN");
            dicUnMed.Add(6, "BL");
            dicUnMed.Add(7, "CO");
            dicUnMed.Add(10, "KG");
            dicUnMed.Add(11, "KT");
            dicUnMed.Add(20, "MT");
            dicUnMed.Add(21, "M2");
            dicUnMed.Add(22, "M3");
            dicUnMed.Add(30, "LT");
            dicUnMed.Add(31, "ML");
            dicUnMed.Add(32, "FL");
            dicUnMed.Add(42, "MW");
            dicUnMed.Add(50, "PR");
            dicUnMed.Add(51, "DZ");
            dicUnMed.Add(52, "CJ");
            dicUnMed.Add(53, "CX");
            dicUnMed.Add(54, "FD");
            dicUnMed.Add(55, "SD");
            dicUnMed.Add(56, "JG");
            dicUnMed.Add(57, "FR");
            dicUnMed.Add(58, "TB");
            dicUnMed.Add(59, "BD");
            dicUnMed.Add(60, "FC");
            dicUnMed.Add(61, "TU");
            dicUnMed.Add(62, "GL");
            dicUnMed.Add(63, "LA");
            dicUnMed.Add(64, "MI");

            cmbUn.Properties.Items.AddRange(dicUnMed.Values);
        }

        private bool IsCamposPreenchidos()
        {
            if (string.IsNullOrEmpty(txtCodProd.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Código do Produto.");
                txtCodProd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDescCurta.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Descrição Curta.");
                txtDescCurta.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Descrição.");
                txtDesc.Focus();
                return false;
            }

            if (cmbCategoria.Text == "Selecione a Categoria")
            {
                MensagensDoSistema.MensagemInformacaoOk("Selecione a Categoria.");
                cmbSubcategoria.Focus();
                return false;
            }

            if (cmbSubcategoria.Text == "Selecione a Subcategoria")
            {
                MensagensDoSistema.MensagemInformacaoOk("Selecione a SubCategoria.");
                cmbSubcategoria.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPrecoCusto.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Preço de Custo.");
                txtPrecoCusto.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbUn.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Selecione a Unidade de Medida.");
                cmbUn.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtPrecoUn.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Preço Unitário.");
                txtPrecoUn.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEstoqMaximo.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Estoque Maximo.");
                txtEstoqMaximo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtEstoqMinimo.Text))
            {
                MensagensDoSistema.MensagemInformacaoOk("Preencha o campo Estoque Mínimo.");
                txtEstoqMinimo.Focus();
                return false;
            }

            return true;
        }

        private void PreencherCodigoProduto()
        {
            try
            {
                using (Session session = new Session())
                {
                    var codigoProduto = session.Query<tb_produto>()
                    .OrderByDescending(x => x.pd_codRef)
                    .Select(x => x.pd_codRef)
                    .FirstOrDefault();

                    txtCodProd.Text = (++codigoProduto).ToString();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao gerar codigo do produto: {ex.Message}");
            }
        }

        private void CadastroProdutoFilial(long _idProduto)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    tb_produto _produto = uow.GetObjectByKey<tb_produto>(Convert.ToInt64(_idProduto));

                    var filial = uow.Query<tb_ator>()
                        .Where(x => x.at_desat == 0 && x.at_atorTipo == 11);

                    foreach (var item in filial)
                    {
                        tb_produto_filial produtoFilial = new tb_produto_filial(uow);

                        produtoFilial.pf_codRef = _produto.pd_codRef;
                        produtoFilial.pf_desc = _produto.pd_desc;
                        produtoFilial.pf_descCurta = _produto.pd_descCurta;
                        produtoFilial.pf_proTipo = _produto.pd_proTipo;
                        produtoFilial.pf_unMedCom = _produto.pd_unMedCom;
                        produtoFilial.pf_dtCri = DateTime.Now;
                        produtoFilial.pf_dtAlt = DateTime.Now;
                        produtoFilial.pf_vlrUnCom = _produto.pd_vlrUnComBase;
                        produtoFilial.pf_cstUnCom = _produto.pd_cstUnComBase;
                        produtoFilial.pf_estMin = _produto.pd_estMinBase;
                        produtoFilial.pf_estMax = _produto.pd_estMaxBase;
                        produtoFilial.pf_est = 0;
                        produtoFilial.pf_desat = 0;
                        produtoFilial.fk_tb_ator = item;
                        produtoFilial.fk_tb_produto = _produto;

                        uow.Save(produtoFilial);
                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar produto filial: {ex.Message}");
            }
        }

        private long CadastroProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    if (idMarcaProduto == 0)
                    {
                        idMarcaProduto = dicMarcaProd.FirstOrDefault(x => x.Value == cmbMarca.Text).Key;
                    }

                    tb_marca_produto marca = uow.Query<tb_marca_produto>().FirstOrDefault(x => x.id_marca_produto == idMarcaProduto);

                    tb_subcategoria_produto subcategoria = uow.GetObjectByKey<tb_subcategoria_produto>(Convert.ToInt64(cmbSubcategoria.EditValue));

                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(Convert.ToInt64(cmbCategoria.EditValue));

                    tb_ator usuarioCadastrador = uow.GetObjectByKey<tb_ator>(VariaveisGlobais.UsuarioLogado.id_ator);

                    tb_rede redeLogada = uow.GetObjectByKey<tb_rede>(VariaveisGlobais.RedeLogada.id_rede);

                    tb_produto produto = new tb_produto(uow);
                    produto.pd_dtCri = DateTime.Now;
                    produto.pd_dtAlt = DateTime.Now;
                    produto.pd_codRef = Convert.ToInt64(txtCodProd.Text);
                    produto.pd_codRefStr = txtCodProd.Text;
                    produto.pd_barras = txtBarras.Text;
                    produto.pd_proTipo = 1;
                    produto.pd_estTot = string.IsNullOrEmpty(txtEstoqInicial.Text) ? 0 : Convert.ToDecimal(txtEstoqInicial.Text);
                    produto.pd_descCurta = txtDescCurta.Text;
                    produto.pd_desc = txtDesc.Text;
                    produto.pd_cstUnComBase = Convert.ToDecimal(txtPrecoCusto.Text);
                    produto.pd_unMedCom = Convert.ToByte(dicUnMed.FirstOrDefault(x => x.Value == cmbUn.Text).Key);
                    produto.pd_vlrUnComBase = Convert.ToDecimal(txtPrecoUn.Text);
                    produto.pd_estMinBase = Convert.ToDecimal(txtEstoqMinimo.Text);
                    produto.pd_estMaxBase = Convert.ToInt64(txtEstoqMaximo.Text);
                    produto.fk_tb_ator = usuarioCadastrador;
                    produto.fk_tb_marca_produto = marca;
                    produto.fk_tb_subcategoria_produto = subcategoria;
                    produto.fk_tb_categoria_produto = categoria;
                    produto.fk_tb_rede = redeLogada;

                    uow.Save(produto);
                    uow.CommitChanges();

                    return produto.id_produto;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao cadastrar produto: {ex.Message}");

                return 0;
            }
        }

        private void AlterarDadosProduto()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var idMarca = dicMarcaProd.FirstOrDefault(x => x.Value == cmbMarca.Text).Key;
                    tb_marca_produto marca = uow.GetObjectByKey<tb_marca_produto>(Convert.ToInt64(idMarca));

                    long idSubcategoria = Convert.ToInt64(cmbSubcategoria.EditValue);

                    tb_subcategoria_produto subcategoria = uow.GetObjectByKey<tb_subcategoria_produto>(idSubcategoria);

                    long idCategoria = Convert.ToInt64(cmbCategoria.EditValue);

                    tb_categoria_produto categoria = uow.GetObjectByKey<tb_categoria_produto>(Convert.ToInt64(idCategoria));

                    tb_rede redeLogada = uow.GetObjectByKey<tb_rede>(VariaveisGlobais.RedeLogada.id_rede);

                    tb_produto produto = uow.GetObjectByKey<tb_produto>(idProduto);

                    if (produto != null)
                    {
                        produto.pd_dtAlt = DateTime.Now;
                        produto.pd_codRef = Convert.ToInt64(txtCodProd.Text);
                        produto.pd_codRefStr = txtCodProd.Text;
                        produto.pd_barras = txtBarras.Text;
                        produto.pd_proTipo = 1;
                        produto.pd_descCurta = txtDescCurta.Text;
                        produto.pd_desc = txtDesc.Text;
                        produto.pd_cstUnComBase = Convert.ToDecimal(txtPrecoCusto.Text);
                        produto.pd_unMedCom = Convert.ToByte(dicUnMed.FirstOrDefault(x => x.Value == cmbUn.Text).Key);
                        produto.pd_vlrUnComBase = Convert.ToDecimal(txtPrecoUn.Text);
                        produto.pd_estMinBase = Convert.ToDecimal(txtEstoqMinimo.Text);
                        produto.pd_estMaxBase = Convert.ToDecimal(txtEstoqMaximo.Text);
                        produto.pd_estTot = Convert.ToDecimal(txtEstoqInicial.Text);
                        produto.fk_tb_marca_produto = marca;
                        produto.fk_tb_subcategoria_produto = subcategoria;
                        produto.fk_tb_categoria_produto = categoria;
                        produto.fk_tb_rede = redeLogada;

                        uow.CommitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar cadastro produto: {ex.Message}");
            }
        }

        private void AlterarDadosProdutoFilial()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var produtosFilial = uow.Query<tb_produto_filial>().Where(x => x.fk_tb_produto.id_produto == idProduto);

                    foreach (var item in produtosFilial)
                    {
                        item.pf_codRef = Convert.ToInt64(txtCodProd.Text);
                        item.pf_desc = txtDesc.Text;
                        item.pf_descCurta = txtDescCurta.Text;
                        item.pf_proTipo = 1;
                        item.pf_unMedCom = Convert.ToByte(dicUnMed.FirstOrDefault(x => x.Value == cmbUn.Text).Key);
                        item.pf_dtCri = DateTime.Now;
                        item.pf_dtAlt = DateTime.Now;
                        item.pf_cstUnCom = Convert.ToInt32(txtPrecoCusto.Text);
                        item.pf_estMin = Convert.ToDecimal(txtEstoqMinimo.Text);
                        item.pf_estMax = Convert.ToDecimal(txtEstoqMaximo.Text);
                        item.pf_est = 0;
                        item.pf_desat = 0;

                        if (vlrProdInicial == item.pf_vlrUnCom)
                        {
                            item.pf_vlrUnCom = Convert.ToInt32(txtPrecoUn.Text);
                        }

                        uow.CommitChanges();
                    }

                    //tb_produto_filial produtoFilial = uow.GetObjectByKey<tb_produto_filial>(Convert.ToInt64(idProduto));

                    //produtoFilial.pf_codRef = Convert.ToInt64(txtCodProd.Text);
                    //produtoFilial.pf_desc = txtDesc.Text;
                    //produtoFilial.pf_descCurta = txtDescCurta.Text;
                    //produtoFilial.pf_proTipo = 1;
                    //produtoFilial.pf_unMedCom = Convert.ToByte(dicUnMed.FirstOrDefault(x => x.Value == cmbUn.Text).Key);
                    //produtoFilial.pf_dtCri = DateTime.Now;
                    //produtoFilial.pf_dtAlt = DateTime.Now;
                    //produtoFilial.pf_cstUnCom = Convert.ToInt32(txtPrecoCusto.Text);
                    //produtoFilial.pf_estMin = Convert.ToDecimal(txtEstoqMinimo.Text);
                    //produtoFilial.pf_estMax = Convert.ToDecimal(txtEstoqMaximo.Text);
                    //produtoFilial.pf_est = 0;
                    //produtoFilial.pf_desat = 0;

                    //if (vlrProdInicial == produtoFilial.pf_vlrUnCom)
                    //{
                    //    produtoFilial.pf_vlrUnCom = Convert.ToInt32(txtPrecoUn.Text);
                    //}

                    //uow.CommitChanges();
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao alterar cadastro produto filial: {ex.Message}");
            }
        }

        private void PreencherCampoProdutoSelecionado()
        {
            try
            {
                using (Session session = new Session())
                {
                    var produto = session.Query<tb_produto>()
                        .Where(x => x.id_produto == idProduto)
                        .Select(x => new
                        {
                            x.pd_codRef,
                            x.pd_descCurta,
                            x.pd_desc,
                            x.pd_vlrUnComBase,
                            x.pd_cstUnComBase,
                            x.pd_estMinBase,
                            x.pd_estMaxBase,
                            x.pd_estTot,
                            x.pd_unMedCom,
                            x.pd_barras,
                            x.fk_tb_subcategoria_produto,
                            x.fk_tb_categoria_produto,
                            x.fk_tb_marca_produto
                        })
                        .FirstOrDefault();

                    txtCodProd.Text = produto.pd_codRef.ToString();
                    txtDescCurta.Text = produto.pd_descCurta;
                    txtDesc.Text = produto.pd_desc;
                    txtPrecoCusto.Text = produto.pd_cstUnComBase.ToString();
                    txtPrecoUn.Text = produto.pd_vlrUnComBase.ToString();
                    txtEstoqMinimo.Text = produto.pd_estMinBase.ToString();
                    txtEstoqMaximo.Text = produto.pd_estMaxBase.ToString();
                    txtEstoqInicial.Text = produto.pd_estTot.ToString();
                    cmbUn.Text = dicUnMed[Convert.ToInt16(produto.pd_unMedCom)];
                    txtBarras.Text = produto.pd_barras;
                    cmbCategoria.EditValue = produto.fk_tb_categoria_produto == null ? (object)null : produto.fk_tb_categoria_produto.id_categoria_produto;
                    cmbSubcategoria.EditValue = produto.fk_tb_subcategoria_produto == null ? (object)null : produto.fk_tb_subcategoria_produto.id_subcategoria_produto;

                    cmbMarca.Text = produto.fk_tb_marca_produto == null ? "" : produto.fk_tb_marca_produto.mp_desc;

                    vlrProdInicial = Convert.ToDecimal(produto.pd_vlrUnComBase);
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao preencher campos com o produto selecionado: {ex.Message}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!IsCamposPreenchidos())
            {
                return;
            }

            if (operacao == "cadastrar")
            {
                if (cmbMarca.Text != "Informe / Selecione a Marca" && !IsMarcaExiste())
                {
                    CadastrarMarca();
                }

                long idProduto = CadastroProduto();

                CadastroProdutoFilial(idProduto);

                uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(painelTelaInicial);
            }
            else
            {
                var dialogResult = MensagensDoSistema.MensagemAtencaoYesNo("Tem certeza de que deseja salvar as alterações?");

                if (dialogResult == DialogResult.Yes)
                {
                    if (!IsMarcaExiste())
                    {
                        CadastrarMarca();
                    }

                    AlterarDadosProduto();

                    AlterarDadosProdutoFilial();

                    uc_MensagemConfirmacao mensagemConfirmacaoCantoInferiorDireito = new uc_MensagemConfirmacao(painelTelaInicial);
                }
            }

            painelTelaInicial.Controls.Clear();
            uc_Produto ucProduto = new uc_Produto(painelTelaInicial, "CodigoRef");
            painelTelaInicial.Controls.Add(ucProduto);
            painelTelaInicial.Tag = ucProduto;

            ucProduto.Show();
        }

        private void ValidarDigitos(object sender, KeyPressEventArgs e)
        {
            // Verificar se o sender é um TextBox
            TextEdit textBox = sender as TextEdit;

            if (textBox == null)
            {
                // Se o sender não for um TextBox, não faça nada
                return;
            }

            // Verificar se o caractere digitado é um número, o caractere '%', o sinal de menos ou a tecla "Backspace"
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '%' && e.KeyChar != '-' && e.KeyChar != '\b' && e.KeyChar != '.')
            {
                // Verificar se o caractere é '-' e se está sendo inserido na primeira posição
                if (e.KeyChar == '-' && textBox.SelectionStart == 0 && !textBox.Text.Contains("-"))
                {
                    // Permitir a entrada
                    e.Handled = false;
                }
                else
                {
                    // Cancelar a entrada
                    e.Handled = true;
                }
            }
        }

        public static decimal CalcularVlrProd(string vlrTransacao, decimal vlrProdInicial)
        {
            decimal vlrTransacaoTratado = decimal.Parse(Regex.Replace(vlrTransacao, "[%-]", ""), CultureInfo.InvariantCulture);

            decimal vlrDiferenca = 0;

            decimal vlrFinal = 0;

            if (vlrTransacao.Contains("%"))
            {
                vlrDiferenca = Math.Round(decimal.Divide(decimal.Multiply(vlrTransacaoTratado, vlrProdInicial), 100), 2);
            }
            else
            {
                vlrDiferenca = vlrTransacaoTratado;
            }

            if (vlrTransacao.Contains("-"))
            {
                vlrFinal = decimal.Subtract(vlrProdInicial, vlrDiferenca);

                return vlrFinal;
            }
            else
            {
                vlrFinal = decimal.Add(vlrProdInicial, vlrDiferenca);
            }

            return vlrFinal;
        }

        private void uc_CadProduto_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();

            txtDescCurta.Focus();
        }

        private void txtEstoqMaximo_Validating(object sender, CancelEventArgs e)
        {
            long estoqueMinimo = string.IsNullOrEmpty(txtEstoqMinimo.Text) ? 0 : Convert.ToInt64(txtEstoqMinimo.Text);
            long estoqueMaximo = string.IsNullOrEmpty(txtEstoqMaximo.Text) ? 0 : Convert.ToInt64(txtEstoqMaximo.Text);

            if (estoqueMaximo < estoqueMinimo)
            {
                txtEstoqMaximo.ErrorText = "Estoque Máximo não pode ser menor que Estoque Mínimo.";
                e.Cancel = true;

                txtEstoqMaximo.Text = string.Empty;
            }
            else
            {
                txtEstoqMaximo.ErrorText = string.Empty;
                e.Cancel = false;
            }
        }

        private void txtEstoqMinimo_Validating(object sender, CancelEventArgs e)
        {
            long estoqueMinimo = string.IsNullOrEmpty(txtEstoqMinimo.Text) ? 0 : Convert.ToInt64(txtEstoqMinimo.Text);
            long estoqueMaximo = string.IsNullOrEmpty(txtEstoqMaximo.Text) ? 0 : Convert.ToInt64(txtEstoqMaximo.Text);

            if (estoqueMinimo > estoqueMaximo)
            {
                txtEstoqMinimo.ErrorText = "Estoque Mínimo não pode ser maior que Estoque Máximo.";
                e.Cancel = true;

                txtEstoqMinimo.Text = string.Empty;
            }
            else
            {
                txtEstoqMinimo.ErrorText = string.Empty;
                e.Cancel = false;
            }
        }

        private void txtAjustGeralPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDigitos(sender, e);
        }

        private void txtAjustGeralPreco_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAjustGeralPreco.Text) && txtAjustGeralPreco.Text != "-" && txtAjustGeralPreco.Text != "%" && !string.IsNullOrEmpty(txtPrecoUn.Text))
            {
                vlrAjuste = txtAjustGeralPreco.Text;

                if (vlrProdInicial == 0)
                {
                    vlrProdInicial = Convert.ToDecimal(txtPrecoUn.Text);
                }

                decimal vlrFinal = CalcularVlrProd(vlrAjuste, vlrProdInicial);

                txtPrecoUn.Text = vlrFinal.ToString();
            }
            else
            {
                //txtPrecoUn.Text = vlrProdInicial.ToString();
            }
        }
    }
}