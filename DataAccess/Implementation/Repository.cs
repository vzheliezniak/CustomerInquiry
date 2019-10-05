using DataAccess.Abstract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private readonly CustomersInquiryDBContext _dbContext;

        public Repository(CustomersInquiryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Create(T entity)
        {
            var addedEntity = _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public T GetByFilter(Func<T, bool> filter)
        {
            return _dbContext.Set<T>().Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
