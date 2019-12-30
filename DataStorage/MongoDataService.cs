using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class MongoDataService : IDatabaseService
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;

        public MongoDataService()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("DaltaDB");
        }

        Task<List<T>> IDatabaseService.DeleteMany<T>(Expression<Func<T, bool>> predicate, List<T> items)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<T> IDatabaseService.DeleteOne<T>(T item)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<List<T>> IDatabaseService.FindMany<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<T> IDatabaseService.FindOne<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<List<T>> IDatabaseService.Store<T>(List<T> items)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<List<T>> IDatabaseService.UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }

        Task<T> IDatabaseService.UpdateOne<T>(Expression<Func<T, bool>> predicate, T item)
        {
            var collection = _db.GetCollection<T>(nameof(T));
            throw new NotImplementedException();
        }
    }
}
