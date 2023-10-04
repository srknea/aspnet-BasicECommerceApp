using BasicECommerceApp.Application.DTOs;
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
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        readonly ICategoryReadRepository _categoryReadRepository;
        readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryService(IGenericReadRepository<Category> readRepository, IGenericWriteRepository<Category> writeRepository, IUnitOfWork unitOfWork, ICategoryReadRepository categoryReadRepository, ICategoryWriteRepository categoryWriteRepository) : base(readRepository, writeRepository, unitOfWork)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
        }
        
        
        public async Task<List<Category>> GetAllCategoriesWithSubCategories()
        {
            var categories = await _categoryReadRepository.GetAllCategoriesWithSubCategories();

            return categories;
        }
        
    }
}
