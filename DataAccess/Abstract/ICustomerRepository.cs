using DataAccess.Models;
using System;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        Customer GetCustomerWithAllTransactionsByFilter(Func<Customer, bool> filter);
        Customer GetCustomerWithRecentTransactionsByFilter(Func<Customer, bool> filter, int amountOfTransactionToTake);
    }
}
