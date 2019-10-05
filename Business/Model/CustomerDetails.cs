﻿using System.Collections.Generic;

namespace Business.Model
{
    public class CustomerDetails
    {
        public CustomerDetails()
        {
            RecentTransactions = new List<TransactionDetails>();
        }

        public decimal CustomerId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public decimal Phone { get; set; }
        public List<TransactionDetails> RecentTransactions { get; set; }

    }
}