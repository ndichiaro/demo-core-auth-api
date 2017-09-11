using Demo.Data.Mongo.Models;
using Demo.Model;

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