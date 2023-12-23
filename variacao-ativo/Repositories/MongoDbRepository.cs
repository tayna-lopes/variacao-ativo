using Microsoft.Extensions.Configuration;
using variacao_ativo.Models.Context;
using variacao_ativo.Repositories.Interface;

namespace variacao_ativo.Repositories
{
    public class MongoDbRepository : IMongoDbRepository
    {
        private readonly MongoDbContext _context;

        public MongoDbRepository(MongoDbContext context)
        {
            _context = context;
        }
        //
    }
}
