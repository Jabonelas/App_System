﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using App_TelasCompartilhadas.Mensagens_Canto_Inferior_Direito;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;

namespace App_TelasCompartilhadas.Classes
{
    public class Atualizacao
    {
        private static string versaoAtualUrl = "https://raw.githubusercontent.com/Jabonelas/PDV/refs/heads/main/App_PDV/bin/Debug/version.txt?token=GHSAT0AAAAAACSVGVGUBVQ7TOPLOQ77A3XUZYRSECQ"; // URL do arquivo version.txt no GitHub
        private static string token = "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";
        private static string caminhoArquivo = @"C:\Users\israe\Desktop\Nova pasta (2)\PDV-1.0.0\App_PDV\bin\Debug\version.txt";
        private static string versaoAtual = "";

        public static async Task VerificarAtualizacaoDisponivel(Form _forms)
        {
            try
            {
                // Lê todas as linhas do arquivo
                string[] linhas = File.ReadAllLines(caminhoArquivo);

                // Exibe cada linha no console
                foreach (string linha in linhas)
                {
                    versaoAtual = linha;
                }

                // Verifica se há uma versão mais recente disponível
                string versaoMaisRecente = await ObterVersaoMaisRecente(versaoAtualUrl, token);

                if (versaoMaisRecente == null)
                {
                    MensagensDoSistema.MensagemErroOk("Não foi possível obter a versão mais recente.");
                    return; // Finaliza a execução se não conseguir obter a versão
                }

                if (versaoAtual != versaoMaisRecente)
                {
                    if (_forms.Name == "frmLogin")
                    {
                        uc_MensagemAtualizacao mensagemAtualizacao = new uc_MensagemAtualizacao(_forms);
                        mensagemAtualizacao.Show();
                    }
                    else
                    {
                        ExecutarAtualizacao(_forms);
                    }
                }
                else if (_forms.Name == "frmTelaInicialERP" || _forms.Name == "frmTelaInicialPDV")
                {
                    MensagensDoSistema.MensagemInformacaoOk("A aplicação está atualizada.");
                }
            }
            catch (Exception e)
            {
                MensagensDoSistema.MensagemErroOk($"Erro na verificação de atualização: {e.Message}");
            }
        }

        public static void ExecutarAtualizacao(Form _forms)
        {
            try
            {
                var dialog = MensagensDoSistema.MensagemAtencaoYesNo("A aplicação será finalizada. Deseja continuar?");

                if (dialog == DialogResult.Yes)
                {
                    // Chama o atualizador externo e passa um parâmetro
                    Process.Start(@"C:\PDV\Atualizacao\Release\net8.0-windows\Atualizacao-Automatica.exe", $"{_forms.Name}");

                    // Feche a aplicação principal para permitir a atualização
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                MensagensDoSistema.MensagemErroOk($"Erro ao executar arquivo de atualização: {e.Message}");
            }
        }

        private static async Task<string> ObterVersaoMaisRecente(string urlVersionTxt, string token)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Adicione o token no cabeçalho da requisição
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Definir um timeout de 10 segundos para evitar que a aplicação trave indefinidamente
                    client.Timeout = TimeSpan.FromSeconds(10);

                    // Tentar obter o conteúdo do arquivo version.txt
                    string versao = await client.GetStringAsync(urlVersionTxt);

                    // Verificar se o conteúdo retornado é vazio ou nulo
                    if (string.IsNullOrEmpty(versao))
                    {
                        System.Windows.Forms.MessageBox.Show("Erro: Arquivo de versão está vazio.");
                        return null;
                    }

                    return versao.Trim(); // Remove espaços extras ou quebras de linha
                }
            }
            catch (HttpRequestException e)
            {
                // Erros de requisição HTTP serão capturados aqui
                System.Windows.Forms.MessageBox.Show($"Erro ao obter versão mais recente: {e.Message}");
                return null;
            }
            catch (TaskCanceledException e)
            {
                // Se o timeout ocorrer, capturamos o erro
                System.Windows.Forms.MessageBox.Show($"Erro: Timeout ao tentar obter a versão. {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                // Qualquer outro tipo de exceção será capturado aqui
                System.Windows.Forms.MessageBox.Show($"Erro inesperado: {e.Message}");
                return null;
            }
        }

        public static bool IsExisteConexaoInternet()
        {
            try
            {
                Ping ping = new Ping();
                PingReply resposta = ping.Send("www.google.com");

                // Verifica se o status do Ping foi "Success"
                if (resposta.Status == IPStatus.Success)
                {
                    return true; // Conectado à internet
                }
                else
                {
                    return false; // Sem conexão
                }
            }
            catch
            {
                return false; // Qualquer exceção indica que não há conexão
            }
        }
    }
}