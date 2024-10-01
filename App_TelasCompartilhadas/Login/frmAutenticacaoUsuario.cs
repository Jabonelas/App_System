using DevExpress.Xpo;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using App_TelasCompartilhadas.bancoSQLite;
using App_TelasCompartilhadas.Classes;

namespace App_TelasCompartilhadas.Login
{
    public partial class frmAutenticacaoUsuario : DevExpress.XtraEditors.XtraForm
    {
        public frmAutenticacaoUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            var dialog = MensagensDoSistema.MensagemAtencaoYesNo("Tem serteza que deseja finalizar a aplicação?");

            if (dialog == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (IsSenhaUsuarioValido(txtSenha.Text, txtUsuario.Text.ToLower()))
            {
                //this.Dispose();
            }
            else
            {
                MensagensDoSistema.MensagemInformacaoOk("Usuário ou senha incorretos.");
            }
        }

        private bool IsSenhaUsuarioValido(string _senha, string _usuario)
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

                    //se for usuário com permissão de administrador
                    if (dadosUsuario.at_atorTipo == 102)
                    {
                        VariaveisGlobais.isUsuarioComPermissao = true;

                        this.Dispose();
                    }
                    else
                    {
                        MensagensDoSistema.MensagemAtencaoOk("Usuário sem permissão de acesso.");
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

        private void frmAutenticacaoUsuario_Load(object sender, EventArgs e)
        {
            TelaCarregamento.EsconderCarregamento();
        }
    }
}