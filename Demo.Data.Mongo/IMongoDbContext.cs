using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public interface IMongoDbContext
    {
        IMongoDatabase Db { get; }
    }
}
