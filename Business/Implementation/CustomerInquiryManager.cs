using System;
using Business.Abstract;
using Business.Model;
using DataAccess.Abstract;
using System.Linq;
using DataAccess.Models;

namespace Business.Implementation
{
    public class CustomerInquiryManager : ICustomerInquiryManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerInquiryManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public CustomerProfile GetCustomerProfile(int customerId = 0, string email = null)
        {
            Func<Customer, bool> filter;
            if (customerId != 0 && !string.IsNullOrEmpty(email))
            {
                filter = x => x.CustomerId == customerId && x.Email == email;
            }
            else if(customerId != 0)
            {
                filter = x => x.CustomerId == customerId;
            }
            else
            {
                filter = x => x.Email == email;
            }

            const int amountOfRecentTransaction = 5;
            var customer = _customerRepository.GetCustomerWithRecentTransactionsByFilter(filter, amountOfRecentTransaction); 
            if(customer == null)
            {
                throw new CustomerNotFoundException($"Customer is not found");
            }
            
            return new CustomerProfile
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.MobilePhone ?? 000,
                RecentTransactions = customer.Transaction
                    .Select(x => new TransactionDetails
                    {
                        Id = x.TransactionId,
                        Amount = x.Amount,
                        Currency = x.CurrencyCode,
                        Status = x.Status,
                        Date = x.Date 
                    }).ToList()
            };
        }
    }
}
