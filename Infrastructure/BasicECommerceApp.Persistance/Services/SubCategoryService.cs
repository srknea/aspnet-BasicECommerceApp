using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Repositories.SubCategory;
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
    public class SubCategoryService : GenericService<SubCategory>, ISubCategoryService
    {
        private readonly ISubCategoryReadRepository _subCategoryReadRepository;

        public SubCategoryService(IGenericReadRepository<SubCategory> readRepository, IGenericWriteRepository<SubCategory> writeRepository, IUnitOfWork unitOfWork, ISubCategoryReadRepository subCategoryReadRepository) : base(readRepository, writeRepository, unitOfWork)
        {
            _subCategoryReadRepository = subCategoryReadRepository;
        }

        public async Task<SubCategory> GetProductsBySubCategoryNameWithCategories(string categoryName)
        {
            return await _subCategoryReadRepository.GetSubCategoryByNameWithCategoryAndProducts(categoryName);
        }
    }
}
