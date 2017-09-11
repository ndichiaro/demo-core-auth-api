using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public class MongoDbContext : IMongoDbContext
    {
        private static IMongoClient _client;
        private readonly MongoUrl _url;

        public IMongoDatabase Db => _client.GetDatabase(_url.DatabaseName);

        public MongoDbContext(string connectionString)
        {
            _url = new MongoUrl(connectionString);
            _client = new MongoClient(_url.Url);
        }
    }
}