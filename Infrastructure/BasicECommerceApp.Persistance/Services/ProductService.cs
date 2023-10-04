using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Application.UnitOfWork;
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
        private readonly IProductReadRepository _productReadRepository;

        public ProductService(IGenericReadRepository<Product> readRepository, IGenericWriteRepository<Product> writeRepository, IUnitOfWork unitOfWork, IProductReadRepository productReadRepository) : base(readRepository, writeRepository, unitOfWork)
        {
            _productReadRepository = productReadRepository;
        }

        /*
        public async Task<Product> GetByIdProductWithCategory(string id)
        {
            return await _productReadRepository.GetByIdProductWithCategory(id);
        }
        */
    }
}
