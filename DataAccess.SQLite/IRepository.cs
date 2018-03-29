using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.SQLite
{
    internal interface IRepository<T> where T : class
    {
        bool Insert(T entity);
        bool Save(T entity);
        bool Delete(T entity);

        T Get(int id);
        T GetWithChildren(int id, bool recursive = false);

        T Find(Expression<Func<T, bool>> predicate);
        T FindWithChildren(Expression<Func<T, bool>> predicate, bool recursive = false);

        List<T> Collection(Func<T, bool> predicate = null);
        List<T> CollectionWithChildren(Expression<Func<T, bool>> predicate = null, bool recursive = false);
    }
}