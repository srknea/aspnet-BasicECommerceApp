using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Persistance.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistence.Services
{
    public class ProductService : GenericService<Product>, IProductService
    {
        public ProductService(IGenericReadRepository<Product> readRepository, IGenericWriteRepository<Product> writeRepository) : base(readRepository, writeRepository)
        {
        }   
    }
}
