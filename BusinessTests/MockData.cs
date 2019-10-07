using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace BusinessTests
{
    public static class MockData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    CustomerId = 395,
                    Name = "Petro Ivanenko",
                    Email = "p@gmail.com",
                    MobilePhone = 2849583535,
                    Transaction = new List<Transaction>()
                },
                new Customer
                {
                    CustomerId = 31995,
                    Name = "Semen Ivanenko",
                    Email = "semen@gmail.com",
                    MobilePhone = 2800583535,
                    Transaction = new List<Transaction>
                    {
                        new Transaction
                        {
                            TransactionId = 1,
                            Amount = 56,
                            CurrencyCode = "UAH",
                            CustomerId = 31995,
                            Date = new DateTime(2018, 12, 1),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 5,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 31995,
                            Date = new DateTime(2018, 12, 2),
                            Status = "Success"
                        }
                    }
                },
                new Customer
                {
                    CustomerId = 61995,
                    Name = "Adam Peters",
                    Email = "peters@gmail.com",
                    MobilePhone = 2800583535,
                    Transaction = new List<Transaction>
                    {
                        new Transaction
                        {
                            TransactionId = 7,
                            Amount = 56,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2018, 12, 1),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 9,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2018, 12, 15),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 11,
                            Amount = 516,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 4, 7),
                            Status = "Failure"
                        },
                        new Transaction{
                            TransactionId = 13,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 5, 3),
                            Status = "Canceled"
                        },
                        new Transaction{
                            TransactionId = 15,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 6, 1),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 17,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 6, 10),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 19,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 8, 15),
                            Status = "Success"
                        },
                        new Transaction{
                            TransactionId = 21,
                            Amount = 51,
                            CurrencyCode = "UAH",
                            CustomerId = 61995,
                            Date = new DateTime(2019, 9, 1),
                            Status = "Success"
                        }
                    }
                }
            };
        }
    }
}
