using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Entities
{
    public class Invoice : BaseEntity   
    {
        public decimal Amount { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }  
    }
}
