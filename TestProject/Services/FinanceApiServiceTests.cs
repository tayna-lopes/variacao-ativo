using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using variacao_ativo.Models;
using variacao_ativo.Models.Context;
using variacao_ativo.Services;
using variacao_ativo.Services.Interface;
using variacao_ativo.Views;

namespace TestProject.Services
{
    [TestClass]
    public class FinanceApiServiceTests
    {
        private readonly IConfiguration _configuration;
        private FinanceApiService _financeApiService;

        public FinanceApiServiceTests(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }

        [TestMethod]
        public async Task ObterVariacaoAtivos_Ok()
        {
            _financeApiService = new FinanceApiService(_configuration);
            var result = await _financeApiService.ObterVariacaoAtivos("PETR4.SA");

            Assert.IsNotNull(result);
        }

    }
}
