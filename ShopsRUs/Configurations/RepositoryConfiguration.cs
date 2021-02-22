using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShopsRUs.Core;
using ShopsRUs.Core.Repositories;
using ShopsRUs.Persistence;
using ShopsRUs.Persistence.Repositories;

namespace ShopsRUs.Web.Configurations
{
    public static class RepositoryConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();

        }
    }
}
