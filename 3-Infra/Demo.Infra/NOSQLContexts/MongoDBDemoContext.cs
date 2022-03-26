using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Demo.Infra.NOSQLContexts
{
    public class MongoDBDemoContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public MongoDBDemoContext(IOptions<ConfigDB> options)
        {
            MongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            if (mongoClient != null)
            {
                _mongoDatabase = mongoClient.GetDatabase(options.Value.DataBase);
            }
        }
    }
}
