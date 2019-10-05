using System;
using System.Linq;

namespace DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetByFilter(Func<T, bool> filter);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
