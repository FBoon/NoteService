using Note.DataLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Note.DataLayer.Repositories
{
    /// <summary>
    /// Basic functions all Repositories will have
    /// 
    /// https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NoteContext _context;

        public GenericRepository(NoteContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
       
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid Id)
        {
            return _context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            _context.Update<T>(entity);
        }
    }
}
