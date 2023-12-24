using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Text.Json;
using variacao_ativo.Models;
using variacao_ativo.Models.Context;
using variacao_ativo.Services.Interface;
using variacao_ativo.Views;

namespace variacao_ativo.Services
{
    public class FinanceApiService : IFinanceApiService
    {
        private readonly IConfiguration _configuration;

        public FinanceApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<VariacaoDoAtivoViewModel>> ObterVariacaoAtivos(string NomeAtivo)
        {
            //Faz atualização no banco de dados
            await AtualizarBanco(NomeAtivo);

            //Calculo da variação
            List<VariacaoDoAtivoViewModel> ultimos30List = CalcularVariacao(NomeAtivo);

            return ultimos30List;
        }

        private async Task<List<Pregao>> AtualizarBanco(string NomeAtivo)
        {
            MongoDbContext dbContext = new();

            using HttpClient client = new HttpClient();
            string url = _configuration["Finance:chartUrl"] + NomeAtivo;
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
            List<Pregao> list = new();

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                root root = JsonConvert.DeserializeObject<root>(jsonString)!;

                result result = root.chart.result[0];
                for (int i = 0; i < result.timestamp.Count; i++)
                {
                    Pregao pregao = new Pregao();
                    pregao.Id = ObjectId.GenerateNewId();
                    pregao.Data = result.timestamp[i];
                    pregao.Valor = result.indicators.quote[0].open[i];
                    pregao.Ativo = NomeAtivo;

                    list.Add(pregao);
                }

                dbContext.AdicionaOuSubstituiVarios(list);
                return list;
            }
            else
            {
                Console.WriteLine($"Erro na chamada da API: {response.StatusCode}");
                return null;
            }
            return list;
        }
        private List<VariacaoDoAtivoViewModel> CalcularVariacao(string NomeAtivo)
        {
            MongoDbContext dbContext = new MongoDbContext();

            List<VariacaoDoAtivoViewModel> variacaoDoAtivoViewModels = new();

            List<Pregao> ultimos30List = dbContext.BuscarUltimos30(NomeAtivo);
            List<Pregao> ordemReversaList = ultimos30List.OrderBy(x => DateTimeOffset.FromUnixTimeSeconds(x.Data)).ToList();

            for (int i = 1; i < ordemReversaList.Count; i++)
            {
                var variacaoDiaAnterior = ((ordemReversaList[i].Valor - ordemReversaList[i - 1].Valor) / ordemReversaList[i - 1].Valor) * 100;
                var variacaoD1 = ((ordemReversaList[i].Valor - ordemReversaList[0].Valor) / ordemReversaList[0].Valor) * 100;

                VariacaoDoAtivoViewModel var = new VariacaoDoAtivoViewModel
                {
                    Ativo = ordemReversaList[i].Ativo,
                    Valor = "R$ " + ordemReversaList[i].Valor.ToString(),
                    Data = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(ordemReversaList[i].Data),
                    VariacaoDiaAnterior = variacaoDiaAnterior.ToString() + "%",
                    variacaoD1 = variacaoD1.ToString() + "%",

                };
                variacaoDoAtivoViewModels.Add(var);
            }

            return variacaoDoAtivoViewModels;
        }


    }
}

