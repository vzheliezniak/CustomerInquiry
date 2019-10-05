using Business.Abstract;
using Business.Model;
using DataAccess.Abstract;
using System.Linq;

namespace Business.Implementation
{
    public class CustomerInquiryManager : ICustomerInquiryManager
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerInquiryManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public CustomerProfile GetCustomerProfile(decimal customerId = 0, string email = null)
        {
            var customer = customerId != 0 ? _customerRepository.GetCustomerWithTransactionsByFilter(x => x.CustomerId == customerId) : _customerRepository.GetCustomerWithTransactionsByFilter(x => x.Email == email);
            if(customer == null)
            {
                throw new CustomerNotFoundException($"Customer is not found");
            }

            const int amountOfRecentTransaction = 5;
            
            return new CustomerProfile
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.MobilePhone ?? 000,
                RecentTransactions = customer.Transaction.OrderByDescending(x => x.Date)
                    .Take(amountOfRecentTransaction)
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
