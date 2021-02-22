using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsRUs.Core.Entities;

namespace ShopsRUs.Data
{
    public class CustomerInitialSeed : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            var customer = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    IsAffiliate = true,
                    FirstName = "Jane",
                    LastName = "Doe"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    IsEmployee = true,
                    FirstName = "Bash",
                    LastName = "Ali"

                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Shina",
                    LastName = "Peters",
                    DateCreated = DateTime.Now.AddYears(-5)
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Victor",
                    LastName = "Ifeanyi"
                }
            };

            builder.HasData(customer);
        }
    }
}
