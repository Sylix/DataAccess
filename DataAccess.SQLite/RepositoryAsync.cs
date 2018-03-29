using SQLiteNetExtensionsAsync.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DataAccess.SQLite
{
    public class RepositoryAsync<T> : SQLiteRepositoryConnectionAsync, IRepositoryAsync<T> where T : class, IEntityObject, new()
    {
        public async Task<bool> InsertAsync(T entity)
        {
            var affectedItens = await Conn.InsertAsync(entity);

            return affectedItens == 1;
        }

        public async Task<bool> SaveAsync(T entity)
        {
            var affectedItens = entity.Id == 0 ? await Conn.InsertAsync(entity) : await Conn.UpdateAsync(entity);

            return affectedItens == 1;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            int affectedItens = await Conn.DeleteAsync(entity);

            return affectedItens == 1;
        }

        public async Task<T> GetAsync(int id)
        {
            return await Conn.GetAsync<T>(id);
        }

        public async Task<T> GetWithChildrenAsync(int id, bool recursive = false)
        {
            return await Conn.GetWithChildrenAsync<T>(id, recursive);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await Conn.FindAsync<T>(predicate);
        }

        public async Task<T> FindWithChildrenAsync(Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            var element = await Conn.FindAsync<T>(predicate);
            if (element == null)
                return null;

            await Conn.GetChildrenAsync(element, recursive);

            return element;
        }

        public async Task<List<T>> CollectionAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? await Conn.Table<T>().ToListAsync() : await Conn.Table<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> CollectionWithChildrenAsync(Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            return await Conn.GetAllWithChildrenAsync(predicate, recursive);
        }
    }
}