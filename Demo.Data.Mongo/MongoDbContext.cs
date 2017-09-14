using Demo.Data.Mongo.Models;
using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public class MongoDbContext
    {
        private static IMongoClient _client;
        private readonly MongoUrl _url;

        public IMongoDatabase Db => _client.GetDatabase(_url.DatabaseName);

        public MongoDbContext(string connectionString)
        {
            _url = new MongoUrl(connectionString);
            _client = new MongoClient(_url.Url);
        }

        public MongoDbCollection<User> User { get; set; }
    }
}