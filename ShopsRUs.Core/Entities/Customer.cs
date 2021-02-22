using System;
using System.Collections.Generic;
using System.Text;

namespace ShopsRUs.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsAffiliate { get; set; }   
    }
}
