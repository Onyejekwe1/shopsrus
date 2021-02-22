using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;
using ShopsRUs.Service.MappingConfig;

namespace ShopsRUs.Service.Response
{
    public class CustomerDto : IMap<Customer>
    {
        
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public bool IsEmployee { get; set; }
        public bool IsAffiliate { get; set; }
    }
}
