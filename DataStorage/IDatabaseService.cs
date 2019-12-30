﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface IDatabaseService
    {
        Task<List<T>> Store<T>(List<T> items);
        Task<T> FindOne<T>(Expression<Func<T, bool>> predicate);
        Task<T> UpdateOne<T>(Expression<Func<T, bool>> predicate, T item);
        Task<T> DeleteOne<T>(T item);
        Task<List<T>> FindMany<T>(Expression<Func<T, bool>> predicate);
        Task<List<T>> UpdateMany<T>(Expression<Func<T, bool>> predicate, List<T> items);
        Task<List<T>> DeleteMany<T>(Expression<Func<T, bool>> predicate, List<T> items);
    }
}