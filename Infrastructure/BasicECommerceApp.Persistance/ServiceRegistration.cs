using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.AppUser;
using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Repositories.Visitor;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistance.Repositories.Category;
using BasicECommerceApp.Persistance.Repositories.Product;
using BasicECommerceApp.Persistance.Repositories.Visitor;
using BasicECommerceApp.Persistance.Services;
using BasicECommerceApp.Persistence.Repositories;
using BasicECommerceApp.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
            services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));            
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<ICartReadRepository, CartReadRepository>();
            services.AddScoped<ICartWriteRepository, CartWriteRepository>();
            services.AddScoped<ICartService, CartService>();

            services.AddScoped<IVisitorReadRepository, VisitorReadRepository>();
            services.AddScoped<IVisitorWriteRepository, VisitorWriteRepository>();
            services.AddScoped<IVisitorService, VisitorService>();

            services.AddScoped<IAppUserReadRepository, AppUserReadRepository>();
            services.AddScoped<IAppUserWriteRepository, AppUserWriteRepository>();
        }
    }
}