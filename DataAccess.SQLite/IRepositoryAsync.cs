using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SQLite
{
    internal interface IRepositoryAsync<T> where T : class
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> SaveAsync(T entity);
        Task<bool> DeleteAsync(T entity);

        Task<T> GetAsync(int id);
        Task<T> GetWithChildrenAsync(int id, bool recursive = false);

        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindWithChildrenAsync(Expression<Func<T, bool>> predicate, bool recursive = false);

        Task<List<T>> CollectionAsync(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> CollectionWithChildrenAsync(Expression<Func<T, bool>> predicate = null, bool recursive = false);
    }
}