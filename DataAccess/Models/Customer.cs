using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Transaction = new HashSet<Transaction>();
        }

        public decimal CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal? MobilePhone { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
