using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collections
{
    public class UserCollection : MongoDbCollection<User>
    {
        public UserCollection(string connectionString) 
            : base("User", connectionString: connectionString)
        {
        }
    }
}