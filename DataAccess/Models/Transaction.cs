using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime? Date { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int? StatusId { get; set; }
        public decimal? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual StatusLookup Status { get; set; }
    }
}
