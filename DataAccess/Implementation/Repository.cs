using DataAccess.Abstract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T:class
    {
        protected readonly CustomersInquiryDbContext dbContext;

        public Repository(CustomersInquiryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Create(T entity)
        {
            var addedEntity = dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return dbContext.Set<T>().AsNoTracking();
        }

        public T GetByFilter(Func<T, bool> filter)
        {
            return dbContext.Set<T>().Where(filter).FirstOrDefault();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();
        }
    }
}
