using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collections
{
    public interface IUserCollection : IMongoDbCollection<User> 
    {

    }
}