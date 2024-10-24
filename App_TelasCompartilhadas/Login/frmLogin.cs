using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;

using App_TelasCompartilhadas.Classes;
using App_TelasCompartilhadas.bancoSQLite;
using System.Net.NetworkInformation;
using App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito;

namespace App_TelasCompartilhadas
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private const string PlaceholderText = "Digite o usuário...";

        private string telaAcesso;

        public frmLogin(string _telaAcesso)
        {
            InitializeComponent();

            telaAcesso = _telaAcesso;

            // Desabilitar a opção de maximizar a tela
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            txtUsuario.EditValue = PlaceholderText;
            txtUsuario.ForeColor = Color.Gray;
            txtUsuario.Text = "geral";
            //txtUsuario.Text = "admin";
            txtSenha.Text = "123456789";

            if (Atualizacao.IsExisteConexaoInternet())
            {
                Atualizacao.VerificarAtualizacaoDisponivel(this, telaAcesso);
            }
        }

        private static bool IsSenhaUsuarioValido(string _senha, string _usuario)
        {
            // Gerar o hash da senha digitada
            byte[] senhaDigitadaHashCode = ComputeSHA256Hash(_senha);

            using (UnitOfWork uow = new UnitOfWork())
            {
                // Buscar o usuário no banco de dados
                var dadosUsuario = uow.Query<tb_ator>().FirstOrDefault(x => x.at_nomeUsuario == _usuario);

                if (dadosUsuario != null)
                {
                    // Converter a senha armazenada de Base64 para byte array
                    var senhaByteArray = Convert.FromBase64String(dadosUsuario.at_senhaUsuarioHashCode);

                    // Comparar os hashes de maneira segura
                    var isSenhaIgual = CompareHashes(senhaDigitadaHashCode, senhaByteArray);

                    VariaveisGlobais.UsuarioLogado = dadosUsuario;

                    VariaveisGlobais.MatrizLogada = dadosUsuario.fk_tb_matriz;

                    if (dadosUsuario.fk_tb_matriz != null)
                    {
                        tb_matriz dadosMatriz = uow.GetObjectByKey<tb_matriz>(Convert.ToInt64(dadosUsuario.fk_tb_matriz.id_matriz));

                        VariaveisGlobais.RedeLogada = dadosMatriz.fk_tb_rede;
                    }

                    return isSenhaIgual;
                }
            }

            return false;
        }

        // Função para gerar o hash SHA-256
        private static byte[] ComputeSHA256Hash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(senha);
                return sha256.ComputeHash(inputBytes);
            }
        }

        // Função para comparação segura de hashes
        private static bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) return false;

            bool areSame = true;
            for (int i = 0; i < hash1.Length; i++)
            {
                areSame &= (hash1[i] == hash2[i]);
            }

            return areSame;
        }

        //Niveis de acesso
        //"100 Funcionario"
        //"101 Vendedor"
        //"102 Gerente"

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if (IsSenhaUsuarioValido(txtSenha.Text, txtUsuario.Text.ToLower()))
            {
                //Acesso ao ERP apenas para usuario com nivel de acesso 102 - Gerente
                if (telaAcesso == "ERP" && VariaveisGlobais.UsuarioLogado.at_atorTipo != 102)
                {
                    MensagensDoSistema.MensagemAtencaoOk("Usuário sem permissão de acesso.");

                    return;
                }

                TelaCarregamento.ExibirCarregamentoForm(this);

                VerificandoMaquina();
            }
            else
            {
                MensagensDoSistema.MensagemInformacaoOk("Usuário ou senha incorretos.");
            }
        }

        private tb_pdv DadosMaquina()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    //string macAddress = new VerificarComponentesPC().GetMacAddress();
                    string diskSerialNumber = new VerificarComponentesPC().GetDiskSerialNumber();
                    string motherboardSerialNumber = new VerificarComponentesPC().GetMotherboardSerialNumber();

                    //var cadastroMaquina = uow.Query<tb_pdv>().FirstOrDefault(x => x.pdv_nicMacAddress == macAddress && x.pdv_dskSerialNumber == diskSerialNumber && x.pdv_boardSerialNumber == motherboardSerialNumber);
                    var cadastroMaquina = uow.Query<tb_pdv>().FirstOrDefault(x => x.pdv_dskSerialNumber == diskSerialNumber && x.pdv_boardSerialNumber == motherboardSerialNumber);

                    return cadastroMaquina;
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk($"Não foi possível verificar a identificação da máquina: {ex.Message}");

                return null;
            }
        }

        private void VerificandoMaquina()
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    ////string macAddress = new VerificarComponentesPC().GetMacAddress();
                    //string diskSerialNumber = new VerificarComponentesPC().GetDiskSerialNumber();
                    //string motherboardSerialNumber = new VerificarComponentesPC().GetMotherboardSerialNumber();

                    ////var cadastroMaquina = uow.Query<tb_pdv>().FirstOrDefault(x => x.pdv_nicMacAddress == macAddress && x.pdv_dskSerialNumber == diskSerialNumber && x.pdv_boardSerialNumber == motherboardSerialNumber);
                    //var cadastroMaquina = uow.Query<tb_pdv>().FirstOrDefault(x => x.pdv_dskSerialNumber == diskSerialNumber && x.pdv_boardSerialNumber == motherboardSerialNumber);

                    var cadastroMaquina = DadosMaquina();

                    if (VariaveisGlobais.UsuarioLogado.at_nomeUsuario == "admin")
                    {
                        TelaCarregamento.EsconderCarregamento();

                        this.Hide();

                        VariaveisGlobais.isInicializarSistema = true;

                        return;
                    }

                    if (cadastroMaquina == null)
                    {
                        TelaCarregamento.EsconderCarregamento();

                        this.Hide();

                        frmSelecionarFilial selecionarPdv = new frmSelecionarFilial();
                        selecionarPdv.ShowDialog();

                        if (VariaveisGlobais.isInicializarSistema == false)
                        {
                            return;
                        }

                        cadastroMaquina = DadosMaquina();

                        VariaveisGlobais.PDVLogado = cadastroMaquina;

                        VariaveisGlobais.FilialLogada = cadastroMaquina.fk_tb_ator;

                        VariaveisGlobais.isInicializarSistema = true;
                    }
                    else
                    {
                        VariaveisGlobais.PDVLogado = cadastroMaquina;

                        VariaveisGlobais.FilialLogada = cadastroMaquina.fk_tb_ator;

                        TelaCarregamento.EsconderCarregamento();

                        this.Hide();

                        VariaveisGlobais.isInicializarSistema = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Não foi possível verificar a identificação da máquina.");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.EditValue.ToString() == PlaceholderText)
            {
                txtUsuario.EditValue = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.EditValue.ToString()))
            {
                txtUsuario.EditValue = PlaceholderText;
                txtUsuario.ForeColor = Color.Gray;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Tem serteza que deseja finalizar a aplicação?");

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}