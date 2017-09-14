using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Demo.Data.Mongo.Models;

namespace Demo.Data.Mongo.Collections
{
    public class UserCollection : IUserCollection
    {
        MongoDbContext _context;

        public UserCollection(MongoDbContext context) 
        {
            _context = context;
        }

        public User Add(User user)
        {
            return _context.User.Add(user);
        }

        public IEnumerable<User> All()
        {
            return _context.User.All();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return _context.User.Find(expression);
        }
    }
}