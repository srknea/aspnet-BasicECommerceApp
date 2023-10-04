using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Services;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasicECommerceApp.Application.Features.Commands.Product.CreateProduct
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {

        readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService productService, ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.AddAsync(new()
            {
                Name = request.Name,
                ParentId = request.ParentId
            });

            return new CreateCategoryCommandResponse()
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId
            };
        }
    }
}