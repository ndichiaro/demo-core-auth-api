using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collecations
{
    public class UserCollection : MongoDbCollection<User>
    {
        protected UserCollection(string name, string connectionString) 
            : base(name, connectionString)
        {
        }
    }
}