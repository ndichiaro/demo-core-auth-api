using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collections
{
    public class UserCollection : MongoDbCollection<User>, IUserCollection
    {
        public UserCollection(MongoDbContext context)
            : base("User", context) 
        {

        }
    }
}