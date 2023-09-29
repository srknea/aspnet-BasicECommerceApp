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
    public class CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommandRequest, CreateSubCategoryCommandResponse>
    {
        readonly ISubCategoryService _subCategoryService;

        public CreateSubCategoryCommandHandler(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        public async Task<CreateSubCategoryCommandResponse> Handle(CreateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {

            var product = await _subCategoryService.AddAsync(new()
            {
                Name = request.Name,
                CategoryId = request.CategoryId
            });

            return new CreateSubCategoryCommandResponse()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId
            };
        }
    }
}