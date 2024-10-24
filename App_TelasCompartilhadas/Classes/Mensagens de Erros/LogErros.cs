using System;

namespace App_TelasCompartilhadas.Classes
{
    public static class LogErros
    {
        public static void GravarLogErros(string _mensagem)
        {
            try
            {
                string path = @"C:\App_System\Logs\LogErros.txt";
                //string path = @"C:\LogErros.txt";

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

        public static void GravarLogVerificao(string _mensagem)
        {
            try
            {
                string path = @"C:\App_System\Logs\LogVerificacao.txt";
                //string path = @"C:\LogErros.txt";

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