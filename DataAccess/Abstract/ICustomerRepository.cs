using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer GetCustomerWithTransactionsByFilter(Func<Customer, bool> filter);
    }
}
