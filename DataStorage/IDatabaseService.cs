using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IDatabaseService
    {
        Task<List<T>> StoreMany<T>(List<T> items);
        Task<T> StoreOne<T>(T item);
        Task<T> FindOne<T>(Expression<Func<T, bool>> predicate);
        //Task<T> UpdateOne<T>(Expression<Func<T, bool>> predicate, T item);
        Task<string> DeleteOne<T>(Expression<Func<T, bool>> predicate);
        Task<List<T>> FindMany<T>(Expression<Func<T, bool>> predicate);
        //Task<List<T>> UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items);
        Task<long> DeleteMany<T>(Expression<Func<T, bool>> predicate);
    }
}
