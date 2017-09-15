using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;

namespace Demo.Data.Mongo
{
    public abstract class MongoDbCollection<TEntityType> where TEntityType : class 
    {
        private IMongoDatabase _db;
        protected string CollectionName { get; }
        protected IMongoCollection<TEntityType> Collection => _db.GetCollection<TEntityType>(CollectionName);

        protected MongoDbCollection(string name, MongoDbContext context)
        {
            CollectionName = name;
            _db = context.Db;
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