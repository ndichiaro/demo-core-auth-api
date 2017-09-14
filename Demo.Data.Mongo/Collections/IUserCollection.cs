using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collections
{
    public interface IUserCollection
    {
        IEnumerable<User> All();
        User Add(User user);
        IEnumerable<User> Find(Expression<Func<User, bool>> expression);
    }
}