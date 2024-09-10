using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplicationPDV.Classes
{
    public static class LogErros
    {
        public static void GravarLog(string _mensagem)
        {
            try
            {
                string path = @"C:\Users\israe\source\repos\DXApplicationPDV\DXApplicationPDV\bin\Debug\LogErros.txt";
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