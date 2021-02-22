using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enums;
using ShopsRUs.Core.Enums_and_Constants;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Data;

namespace ShopsRUs.Persistence.Repositories
{
    public class DiscountRepository: Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ShopsRUsDbContext context) : base(context)
        {
        }

        public decimal CalculateDiscount(decimal amount, Discount discount)
        {
            var result = 0.0m;
            if (discount.DiscountType != DiscountTypeConstant.Every100DollarDiscount)
            {
                result =  amount - (amount * (discount.Percentage / 100));
                return result;
            }

            var percentage = discount.Percentage * (amount / 100);
            result =  amount - (amount * (percentage / 100));
            return result;
        }
    }
}
