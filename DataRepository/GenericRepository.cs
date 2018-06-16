using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataRepository
{
    public class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private readonly DbContext _context;

        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            if (_context.Entry<T>(entity).State != System.Data.Entity.EntityState.Detached)
                _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Added;
            else
                _context.Set<T>().Add(entity);
        }

        public IQueryable<T> AsQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public void Delete(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            if (_context.Entry<T>(entity).State == System.Data.Entity.EntityState.Detached)
                _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Dispose()
        {
            return;
        }
    }
}
