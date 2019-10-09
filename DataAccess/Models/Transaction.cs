using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
    }
}
