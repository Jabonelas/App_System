using System;

namespace App_TelasCompartilhadas.Classes
{
    public static class LogErros
    {
        public static void GravarLog(string _mensagem)
        {
            try
            {
                string path = @"C:\Users\israe\source\repos\DXApplicationERP\DXApplicationERP\bin\Debug\LogErros.txt";
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