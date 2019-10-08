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

        public Customer GetCustomerWithAllTransactionsByFilter(Func<Customer, bool> filter)
        {
            return dbContext.Customer.Include(x => x.Transaction).FirstOrDefault(filter);
        }

        public Customer GetCustomerWithRecentTransactionsByFilter(Func<Customer, bool> filter, int amountOfTransactionToTake)
        {
            return dbContext.Customer.Include(x => x.Transaction
                    .OrderByDescending(t => t.Date)
                    .Take(amountOfTransactionToTake))
                .FirstOrDefault(filter);
        }
    }
}
