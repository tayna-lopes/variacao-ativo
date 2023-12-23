using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.Json;
using variacao_ativo.Models;
using variacao_ativo.Services.Interface;

namespace variacao_ativo.Services
{
    public class FinanceApiService : IFinanceApiService
    {
        private readonly IConfiguration _configuration;

        public FinanceApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> ObterChart(string NomeAtivo)
        {
            using HttpClient client = new HttpClient();
            string url = _configuration["Finance:chartUrl"] + NomeAtivo;
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                return  await response.Content.ReadAsStringAsync();
            }
            else
            {
                Console.WriteLine($"Erro na chamada da API: {response.StatusCode}");
                return null;
            }
        }

        //public async Task<string> ObterValorAtivo(string NomeAtivo)
        //{
            //using HttpClient client = new HttpClient();
            //string url = _configuration["Finance:chartUrl"] + NomeAtivo;
            //client.BaseAddress = new Uri(url);

            //HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            //if (response.IsSuccessStatusCode)
            //{
            //    return await response.Content.ReadAsStringAsync();
            //}
            //else
            //{
            //    Console.WriteLine($"Erro na chamada da API: {response.StatusCode}");
            //    return null;
            //}
        }
    }
}
