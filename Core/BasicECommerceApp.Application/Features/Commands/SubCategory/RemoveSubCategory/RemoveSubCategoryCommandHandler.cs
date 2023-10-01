using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasicECommerceApp.Application.Features.Commands.Product.RemoveCategory
{
    public class RemoveSubCategoryCommandHandler : IRequestHandler<RemoveSubCategoryCommandRequest, RemoveSubCategoryCommandResponse>
    {
        readonly ISubCategoryService _categoryService;

        public RemoveSubCategoryCommandHandler(ISubCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<RemoveSubCategoryCommandResponse> Handle(RemoveSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var subCategory = await _categoryService.GetByIdAsync(request.Id);

            await _categoryService.RemoveAsync(subCategory);

            return new RemoveSubCategoryCommandResponse();
        }
    }
}