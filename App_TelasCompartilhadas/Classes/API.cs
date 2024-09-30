using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App_TelasCompartilhadas.Classes
{
    public class API
    {
        private DadosCep temperatures = new DadosCep();

        public async Task APICorreios(string _cep)
        {
            HttpClient cliente = new HttpClient { BaseAddress = new Uri($"https://viacep.com.br/ws/{_cep}/json/") };
            var response = await cliente.GetAsync(string.Empty);
            var content = await response.Content.ReadAsStringAsync();

            var users = JsonConvert.DeserializeObject<DadosCep>(content);

            temperatures = users;
        }

        public DadosCep RetornoApi()
        {
            return temperatures;
        }
    }
}