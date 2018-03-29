using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace DataAccess.SQLite
{
    public class Repository<T> : SQLiteRepositoryConnection, IRepository<T> where T : class, IEntityObject, new()
    {
        public bool Insert(T entity)
        {
            var affectedItens = Conn.Insert(entity);

            return affectedItens == 1;
        }

        public bool Save(T entity)
        {
            var affectedItens = entity.Id == 0 ? Conn.Insert(entity) : Conn.Update(entity);

            return affectedItens == 1;
        }

        public bool Delete(T entity)
        {
            int affectedItens = Conn.Delete(entity);

            return affectedItens == 1;
        }

        public T Get(int id)
        {
            return Conn.Get<T>(id);
        }

        public T GetWithChildren(int id, bool recursive = false)
        {
            return Conn.GetWithChildren<T>(id, recursive);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return Conn.Find<T>(predicate);
        }

        public T FindWithChildren(Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            var element = Conn.Find<T>(predicate);
            if (element == null)
                return null;

            Conn.GetChildren(element, recursive);

            return element;
        }

        public List<T> Collection(Func<T, bool> predicate = null)
        {
            return predicate == null ? Conn.Table<T>().ToList() : Conn.Table<T>().Where(predicate).ToList();
        }

        public List<T> CollectionWithChildren(Expression<Func<T, bool>> predicate, bool recursive = false)
        {
            return Conn.GetAllWithChildren(predicate, recursive);
        }
    }
}