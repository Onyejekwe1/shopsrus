using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enums;
using ShopsRUs.Service.MappingConfig;

namespace ShopsRUs.Service.Response
{
    public class DiscountDto : IMap<Discount>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DiscountType { get; set; }    
        public double Percentage { get; set; }
    }
}
