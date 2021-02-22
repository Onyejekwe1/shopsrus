using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Data;

namespace ShopsRUs.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ShopsRUsDbContext context) : base(context)
        {
        }
    }
}
