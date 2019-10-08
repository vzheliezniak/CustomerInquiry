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
            repository.Setup(x => x.GetCustomerWithTransactionsByFilter(It.IsAny<Func<Customer, bool>>()))
                .Returns((Func<Customer, bool> predicate) => MockData.GetCustomers().Where(predicate).FirstOrDefault());
            _sut = new Mock<CustomerInquiryManager>(repository.Object);
        }

        [Test]
        public void GetCustomerProfile_CustomerIsNotFound_CustomerNotFoundExceptionIsThrown()
        {
            Assert.Throws<CustomerNotFoundException>(() => _sut.Object.GetCustomerProfile(25));
        }

        [TestCase(395, null)]
        [TestCase(0, "p@gmail.com")]
        public void GetCustomerProfile_CustomerIsFound_CustomerProfileWithNoTransactionsIsReturned(decimal customerId, string email)
        {
            var res = _sut.Object.GetCustomerProfile(customerId, email);

            Assert.NotNull(res);
            Assert.IsEmpty(res.RecentTransactions);
        }

        [Test]
        public void GetCustomerProfile_CustomerIsFound_CustomerIsFound_CustomerProfileWithListOfRecentTransactionsIsReturned()
        {
            const decimal customerId = 61995;
            const int expectedAmountOfTransactions = 5;

            var res = _sut.Object.GetCustomerProfile(customerId);

            Assert.IsNotEmpty(res.RecentTransactions);
            Assert.AreEqual(expectedAmountOfTransactions, res.RecentTransactions.Count);
        }

        [Test]
        public void GetCustomerProfile_CustomerIdIsValid_EmailIsNotValid_CustomerIsNotFoundExceptionIsThrown()
        {
            const decimal customerId = 61995;
            const string email = "test@gmail.com";

            Assert.Throws<CustomerNotFoundException>(() => _sut.Object.GetCustomerProfile(customerId, email));
        }
    }
}