using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsRUs.Data;
using ShopsRUs.Service.Validators;

namespace ShopsRUs.Web.Configurations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopsRUsDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("dbContext")));

            services.AddRepositories();

            

            return services;
        }
    }
}
