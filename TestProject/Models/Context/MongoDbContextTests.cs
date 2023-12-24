using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using variacao_ativo.Models;
using variacao_ativo.Models.Context;

namespace TestProject.Models.Context
{
    [TestClass]
    public class MongoDbContextTests
    {
        private IMongoDatabase _database { get; set; }
        private MongoDbContext _dbContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = new MongoDbContext("mongodb://localhost:27017", "VariacaoAtivo",true);

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));

            var mongoClient = new MongoClient(settings);

            _database = mongoClient.GetDatabase("VariacaoAtivo");

        }

        [TestMethod]
        public void AdicionaOuSubstitui_NovoPregao()
        {

            long timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var pregao = new Pregao 
            { 
                Id = ObjectId.GenerateNewId(),
                Data = timestamp, 
                Ativo = "AAPL",
                Valor = 10.00
            };

            _dbContext.AdicionaOuSubstitui(pregao);
            var result = _dbContext.BuscarAtivo("AAPL", timestamp);

            Assert.IsNotNull(result);
            Assert.AreEqual(pregao.Data, result.Data);
            Assert.AreEqual(pregao.Ativo, result.Ativo);
        }

        [TestMethod]
        public void AdicionaOuSubstituiVarios_Ok()
        {
            List<Pregao> pregaoList = new();
            var pregao = new Pregao
            {
                Id = ObjectId.GenerateNewId(),
                Data = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(),
                Ativo = "AAPL",
                Valor = 15.00
            };
            pregaoList.Add(pregao);

            var pregao2 = new Pregao
            {
                Id = ObjectId.GenerateNewId(),
                Data = new DateTimeOffset(DateTime.UtcNow).AddDays(1).ToUnixTimeSeconds(),
                Ativo = "AAPL",
                Valor = 10.005
            };
            pregaoList.Add(pregao);


            _dbContext.AdicionaOuSubstituiVarios(pregaoList);

            var count = 0;
            pregaoList.ForEach(x =>
            {
                var res = _dbContext.BuscarAtivo(x.Ativo, x.Data);
                if (res != null) { count++; }
            });

            Assert.AreEqual(pregaoList.Count, count);
        }

        [TestMethod]
        public void BuscarUltimos30_Ok()
        {
            var result = _dbContext.BuscarUltimos30("PETR4.SA");

            Assert.AreEqual(30, result.Count);
        }


    }
}