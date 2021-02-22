using System;
using System.Collections.Generic;
using System.Text;
using ShopsRUs.Core.Entities;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Data;

namespace ShopsRUs.Persistence.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ShopsRUsDbContext context) : base(context)
        {
        }
    }
}
