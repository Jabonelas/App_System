using System;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace App_TelasCompartilhadas.Classes
{
    public static class LogErros
    {
        public static void GravarLogErros(string _mensagem)
        {
            try
            {
                string path = @"C:\App_System\Logs\LogErros.txt";

                if (!File.Exists(path))
                {
                    XtraMessageBox.Show("Arquivo de log não encontrado.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    CriarLogs();

                    return;
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine($"Data: {DateTime.Now}\n" +
                                   $"Mensagem: {_mensagem}\n" +
                                   "-------------------------------------------\n");
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao gravar log de erro: " + ex.Message);
            }
        }

        private static void CriarLogs()
        {
            try
            {
                // Defina o caminho da pasta
                string folderPath = @"C:\App_System\App_System_Logs";

                // Crie a pasta (se ela não existir)
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Caminhos dos arquivos .txt
                string filePath1 = Path.Combine(folderPath, "LogErros.txt");
                string filePath2 = Path.Combine(folderPath, "LogVerificacao.txt");

                // Conteúdo dos arquivos
                string conteudoArquivo1 = "Inicializando os logs de erro.";
                string conteudoArquivo2 = "Inicializando os logs de verificacao.";

                // Crie e escreva o conteúdo nos arquivos
                System.IO.File.WriteAllText(filePath1, conteudoArquivo1);
                System.IO.File.WriteAllText(filePath2, conteudoArquivo2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a criação dos arquivos de Log: {ex.Message}");
            }
        }

        public static void GravarLogVerificao(string _mensagem)
        {
            try
            {
                string path = @"C:\App_System\Logs\LogVerificacao.txt";

                if (!File.Exists(path))
                {
                    XtraMessageBox.Show("Arquivo de log de verificação não encontrado.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    CriarLogs();

                    return;
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                {
                    file.WriteLine($"Data: {DateTime.Now}\n" +
                                   $"Mensagem: {_mensagem}\n" +
                                   "-------------------------------------------\n");
                }
            }
            catch (Exception ex)
            {
                MensagensDoSistema.MensagemErroOk("Erro ao gravar log de erro: " + ex.Message);
            }
        }
    }
}