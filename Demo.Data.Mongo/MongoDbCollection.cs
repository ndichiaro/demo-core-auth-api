using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public abstract class MongoDbCollection<TEntityType> where TEntityType : class 
    {
        private readonly IMongoDbContext _context;

        protected string CollectionName { get; }
        protected IMongoCollection<TEntityType> Collection => _context.Db.GetCollection<TEntityType>(CollectionName);

        protected MongoDbCollection(string name, string connectionString)
        {
            CollectionName = name;
            _context = new MongoDbContext(connectionString);
        }

        public IEnumerable<TEntityType> All()
        {
            return Collection.AsQueryable();
        }

        public virtual TEntityType Add(TEntityType entity)
        {
            Collection.InsertOne(entity);
            return entity;    
        }

        public virtual IEnumerable<TEntityType> Find(Expression<Func<TEntityType, bool>> expression)
        {
            return Collection.Find(expression).ToEnumerable();
        }
    }
}