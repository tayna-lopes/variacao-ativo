using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace variacao_ativo.Models.Context
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        private IMongoDatabase _database { get; }

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível se conectar com o servidor.", ex);
            }
        }

        public void AdicionaOuSubstitui(Pregao pregao)
        {
            var collection = _database.GetCollection<Pregao>("PregaoCollection");

            var filter = Builders<Pregao>.Filter.And(
            Builders<Pregao>.Filter.Eq(x => x.Data, pregao.Data),
            Builders<Pregao>.Filter.Eq(x => x.Ativo, pregao.Ativo));

            var options = new FindOneAndReplaceOptions<BsonDocument>
            {
                ReturnDocument = ReturnDocument.Before
            };

            var encontrado = collection.Find(filter);
            if (encontrado == null)
            {
                collection.InsertOne(pregao);
            }
            else
            {
                collection.DeleteOne(filter);
                collection.InsertOne(pregao);
            }
        }
        public void AdicionaOuSubstituiVarios(List<Pregao> pregaoList)
        {
            pregaoList.ForEach(x =>
            {
                AdicionaOuSubstitui(x);
            } );
        }

        public List<Pregao> BuscarUltimos30(string NomeAtivo)
        {
            var collection = _database.GetCollection<Pregao>("PregaoCollection");

            var filtro = Builders<Pregao>.Filter.Eq(x => x.Ativo, NomeAtivo);
            var ordenacao = Builders<Pregao>.Sort.Descending(x => x.Data);
            var limit = 30;

            return collection.Find(filtro).Sort(ordenacao).Limit(limit).ToList();
        }
    }
}

