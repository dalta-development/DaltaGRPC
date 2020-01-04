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
        private IMongoDatabase _db;

        public MongoDataService()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db = _client.GetDatabase("DaltaDB");
        }

        Task<bool> SchoolExists(string schoolUUID)
        {
            bool guidParsed = Guid.TryParse(schoolUUID, out var output);
            if(guidParsed == true)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        Task<long> IDatabaseService.DeleteMany<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.DeleteMany<T>(predicate).DeletedCount;
            return Task.FromResult(result);
        }

        Task<string> IDatabaseService.DeleteOne<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = collection.DeleteOneAsync<T>(predicate);
            return Task.FromResult(result.Result.ToString());
        }

        async Task<List<T>> IDatabaseService.FindMany<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = await collection.Find<T>(predicate).ToListAsync();
            return result;
        }

        async Task<T> IDatabaseService.FindOne<T>(Expression<Func<T, bool>> predicate)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            var result = await collection.Find<T>(predicate).SingleAsync();
            return result;
        }

        async Task<List<T>> IDatabaseService.StoreMany<T>(List<T> items)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            await collection.InsertManyAsync(items);
            return items;
        }

        async Task<T> IDatabaseService.StoreOne<T>(T item)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            await collection.InsertOneAsync(item);
            return item;
        }

        async Task<List<T>> IDatabaseService.UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            items.ForEach(x =>
            {
                collection.ReplaceOne(predicate, x);
            });
            return items;
        }

        async Task<T> IDatabaseService.UpdateOne<T>(Expression<Func<T, bool>> predicate, T item)
        {
            var collection = _db.GetCollection<T>(typeof(T).Name);
            await collection.ReplaceOneAsync(predicate, item);
            return item;
        }
    }
}
