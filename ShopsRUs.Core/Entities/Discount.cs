using System;
using System.Collections.Generic;
using System.Text;
using static ShopsRUs.Core.Enums.Enums;

namespace ShopsRUs.Core.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public string DiscountType { get; set; }
        public decimal Percentage { get; set; } 
    }
}
