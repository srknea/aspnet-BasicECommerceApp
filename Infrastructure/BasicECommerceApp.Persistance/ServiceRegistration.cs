using BasicECommerceApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddDbContext<BasicECommerceAppDbContext>(options => options.UseNpgsql("User ID = postgres; Password = mysecretpassword; Host = localhost; Port = 5432; Database = BasicECommerceAppDb;"));
        }
    }
}