using System;
using System.Linq;
using Business.Implementation;
using Business.Model;
using DataAccess.Abstract;
using DataAccess.Models;
using Moq;
using NUnit.Framework;

namespace BusinessTests
{
    public class CustomerInquiryManagerTests
    {
        private Mock<CustomerInquiryManager> _sut;
        [SetUp]
        public void Setup()
        {
            var repository = new Mock<ICustomerRepository>();
            repository.Setup(x => x.GetCustomerWithRecentTransactionsByFilter(It.IsAny<Func<Customer, bool>>(), It.IsAny<int>()))
                .Returns((Func<Customer, bool> predicate, int amount) => MockData.GetCustomers().Where(predicate).FirstOrDefault());

            _sut = new Mock<CustomerInquiryManager>(repository.Object);
        }

        [Test]
        public void GetCustomerProfile_CustomerIsNotFound_CustomerNotFoundExceptionIsThrown()
        {
            Assert.Throws<CustomerNotFoundException>(() => _sut.Object.GetCustomerProfile(25));
        }

        [TestCase(395, null)]
        [TestCase(0, "p@gmail.com")]
        public void GetCustomerProfile_CustomerIsFound_CustomerProfileWithNoTransactionsIsReturned(int customerId, string email)
        {
            var res = _sut.Object.GetCustomerProfile(customerId, email);

            Assert.NotNull(res);
            Assert.IsEmpty(res.RecentTransactions);
        }

        [Test]
        public void GetCustomerProfile_CustomerIdIsValid_EmailIsNotValid_CustomerIsNotFoundExceptionIsThrown()
        {
            const int customerId = 61995;
            const string email = "test@gmail.com";

            Assert.Throws<CustomerNotFoundException>(() => _sut.Object.GetCustomerProfile(customerId, email));
        }
    }
}