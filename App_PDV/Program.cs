using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Xpo.DB;
using App_TelasCompartilhadas.bancoSQLite;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using App_TelasCompartilhadas.Classes;

namespace App_PDV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ConnectionHelper.Connect(AutoCreateOption.DatabaseAndSchema);

            #region Aplicacao/selecao dos temas

            // Habilita skins de formulário e skins de usuário se necessário
            SkinManager.EnableFormSkins();
            BonusSkins.Register();

            // Define o tema padrão"
            //UserLookAndFeel.Default.SetSkinStyle("The Asphalt World");
            UserLookAndFeel.Default.SetSkinStyle("Sharp Plus");

            // Registrar apenas os temas permitidos
            var allowedSkins = new string[]
            {
                "Basic",
                //"High Contrast",
                "McSkin",
                "The Asphalt World",
                "Office 2019 Colorful",
                "Seven Classic",
                "Sharp Plus"
            };

            var skinContainerList = SkinManager.Default.Skins;
            for (int i = skinContainerList.Count - 1; i >= 0; i--)
            {
                var skinName = skinContainerList[i].SkinName;
                if (Array.IndexOf(allowedSkins, skinName) < 0)
                {
                    skinContainerList.RemoveAt(i);
                }
            }

            #endregion Aplicacao/selecao dos temas

            #region Definicao de fonte

            //// Defina a fonte padrão para todos os controles DevExpress
            Font minhaFonte = new Font("Exo 2", 8);
            DevExpress.Utils.AppearanceObject.DefaultFont = minhaFonte;

            #endregion Definicao de fonte

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmTelaInicial());

            //Main1();

            App_TelasCompartilhadas.frmLogin frmTelaInicial = new App_TelasCompartilhadas.frmLogin("PDV");
            frmTelaInicial.ShowDialog();

            if (App_TelasCompartilhadas.Classes.VariaveisGlobais.isInicializarSistema)
            {
                Application.Run(new frmTelaInicialPDV());
            }
        }

        private static async Task Main1()
        {
            try
            {
                string caminhoArquivo = @"C:\Users\israe\Desktop\Nova pasta (2)\PDV-1.0.0\App_PDV\bin\Debug\version.txt";

                // Lê todas as linhas do arquivo
                string[] linhas = File.ReadAllLines(caminhoArquivo);

                string versaoAtual = "";

                // Exibe cada linha no console
                foreach (string linha in linhas)
                {
                    versaoAtual = linha;
                }

                //string versaoAtual = "1.0.2"; // Versão atual da sua aplicação
                string versaoAtualUrl = "https://raw.githubusercontent.com/Jabonelas/PDV/refs/heads/main/version.txt?token=GHSAT0AAAAAACSVGVGU2CHRFEENSLZVQPXQZYQLITA"; // URL do arquivo version.txt no GitHub

                // Verifica se há uma versão mais recente disponível
                string versaoMaisRecente = await ObterVersaoMaisRecente(versaoAtualUrl);

                if (versaoMaisRecente == null)
                {
                    MensagensDoSistema.MensagemErroOk("Não foi possível obter a versão mais recente.");
                    return; // Finaliza a execução se não conseguir obter a versão
                }

                if (versaoAtual != versaoMaisRecente)
                {
                    MensagensDoSistema.MensagemAtencaoOk("Nova versão disponível! Iniciando atualizador externo...");

                    // Chama o atualizador externo (local onde você colocou o atualizador)
                    Process.Start(@"C:\Users\israe\source\repos\Atualizacao-Automatica\Atualizacao-Automatica\bin\Debug\net8.0-windows\Atualizacao-Automatica.exe");

                    // Feche a aplicação principal para permitir a atualização
                    Environment.Exit(0);
                }
                else
                {
                    MensagensDoSistema.MensagemAtencaoOk("Sua aplicação está atualizada!");
                }
            }
            catch (Exception e)
            {
                MensagensDoSistema.MensagemErroOk($"Erro na verificação de atualização: {e.Message}");
            }
        }

        private static async Task<string> ObterVersaoMaisRecente(string urlVersionTxt)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Definir um timeout de 10 segundos para evitar que a aplicação trave indefinidamente
                    client.Timeout = TimeSpan.FromSeconds(10);

                    // Tentar obter o conteúdo do arquivo version.txt
                    string versao = await client.GetStringAsync(urlVersionTxt);

                    // Verificar se o conteúdo retornado é vazio ou nulo
                    if (string.IsNullOrEmpty(versao))
                    {
                        MensagensDoSistema.MensagemErroOk("Erro: Arquivo de versão está vazio.");
                        return null;
                    }

                    return versao.Trim(); // Remove espaços extras ou quebras de linha
                }
            }
            catch (HttpRequestException e)
            {
                // Erros de requisição HTTP serão capturados aqui
                MensagensDoSistema.MensagemErroOk($"Erro ao obter versão mais recente: {e.Message}");
                return null;
            }
            catch (TaskCanceledException e)
            {
                // Se o timeout ocorrer, capturamos o erro
                MensagensDoSistema.MensagemErroOk($"Erro: Timeout ao tentar obter a versão. {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                // Qualquer outro tipo de exceção será capturado aqui
                MensagensDoSistema.MensagemErroOk($"Erro inesperado: {e.Message}");
                return null;
            }
        }
    }
}