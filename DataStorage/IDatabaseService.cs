using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IDatabaseService
    {
        Task<List<T>> StoreMany<T>(List<T> items, string schoolUUID);
        Task<T> StoreOne<T>(T item, string schoolUUID);
        Task<T> FindOne<T>(Expression<Func<T, bool>> predicate, string schoolUUID);
        Task<T> UpdateOne<T>(Expression<Func<T, bool>> predicate, T item, string schoolUUID);
        Task<string> DeleteOne<T>(Expression<Func<T, bool>> predicate, string schoolUUID);
        Task<List<T>> FindMany<T>(Expression<Func<T, bool>> predicate, string schoolUUID);
        Task<List<T>> UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items, string schoolUUID);
        Task<long> DeleteMany<T>(Expression<Func<T, bool>> predicate, string schoolUUID);
    }
}
