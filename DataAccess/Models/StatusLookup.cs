using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StatusLookup
    {
        public StatusLookup()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int StatusId { get; set; }
        public string Text { get; set; }

        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
