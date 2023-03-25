using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Note.DataLayer.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid Id);

        IQueryable<T> GetAll();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);

        void Update(T entity);
    }
}
