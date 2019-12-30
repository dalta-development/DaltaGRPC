using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataStorage
{
    class MongoDataService : IDatabaseService
    {
        MongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase db = 

        public List<T> DeleteMany<T>(Expression<Func<T, bool>> predicate, List<T> items)
        {
            throw new NotImplementedException();
        }

        public T DeleteOne<T>(T item)
        {
            throw new NotImplementedException();
        }

        public List<T> FindMany<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T FindOne<T>(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<T> Store<T>(List<T> items)
        {
            throw new NotImplementedException();
        }

        public List<T> UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items)
        {
            throw new NotImplementedException();
        }

        public T UpdateOne<T>(Expression<Func<T, bool>> predicate, T item)
        {
            throw new NotImplementedException();
        }
    }
}
