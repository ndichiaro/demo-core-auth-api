using Demo.Data.Mongo.Models;
using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public interface IMongoDbContext
    {
        IMongoDatabase Db { get; }
        MongoDbCollection<User> User { get; set; }
    }
}
