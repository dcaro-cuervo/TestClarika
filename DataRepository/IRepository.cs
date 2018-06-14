using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataRepository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);
        T FindById(int id);
        T Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);

        void Save();
    }
}
