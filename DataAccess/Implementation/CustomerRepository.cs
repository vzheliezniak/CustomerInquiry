using DataAccess.Abstract;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Implementation
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomersInquiryDbContext dbContext)
        : base(dbContext)
        {

        }

        public Customer GetCustomerWithTransactionsByFilter(Func<Customer, bool> filter)
        {
            return dbContext.Customer.Include(x => x.Transaction).FirstOrDefault(filter);
        }
    }
}
