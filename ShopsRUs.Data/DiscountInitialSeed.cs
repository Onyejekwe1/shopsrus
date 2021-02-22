using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Enums_and_Constants;

namespace ShopsRUs.Data
{
    public class DiscountInitialSeed : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            var discount = new List<Discount>
            {
                new Discount
                {
                    Percentage = 10,
                    Name = "Discount For Affiliate",
                    DiscountType = DiscountTypeConstant.DiscountForAffiliate
                },
                new Discount
                {
                    Percentage = 30,
                    Name = "Discount For Employees",
                    DiscountType = DiscountTypeConstant.DiscountForEmployees
                },
                new Discount
                {
                    Percentage = 5,
                    Name = "Discount For Loyal Customers",
                    DiscountType = DiscountTypeConstant.DiscountForLoyalCustomers
                },
                new Discount
                {
                    Percentage = 5,
                    Name = "Every 100 Dollar Discount",
                    DiscountType = DiscountTypeConstant.Every100DollarDiscount
                }
            };

            builder.HasData(discount);
        }
    }
}
