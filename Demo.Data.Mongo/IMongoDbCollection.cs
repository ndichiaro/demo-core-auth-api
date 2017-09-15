using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.Data.Mongo
{
    public interface IMongoDbCollection<TEntityType> where TEntityType : class 
    {
        IEnumerable<TEntityType> All();
        TEntityType Add(TEntityType entity);
        IEnumerable<TEntityType> Find(Expression<Func<TEntityType, bool>> expression);
    }
}