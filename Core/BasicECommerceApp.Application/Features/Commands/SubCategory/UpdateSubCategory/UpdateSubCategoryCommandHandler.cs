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

namespace BasicECommerceApp.Application.Features.Commands.Product.RemoveProduct
{
    public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, UpdateSubCategoryCommandResponse>
    {
        readonly ISubCategoryService _subCategoryService;

        public UpdateSubCategoryCommandHandler(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        public async Task<UpdateSubCategoryCommandResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            await _subCategoryService.UpdateAsync(new Domain.Entities.SubCategory()
            {
                Id = Guid.Parse(request.Id),
                Name = request.Name,
                CategoryId = Guid.Parse(request.CategoryId),
            });

            return new UpdateSubCategoryCommandResponse();
        }
    }
}