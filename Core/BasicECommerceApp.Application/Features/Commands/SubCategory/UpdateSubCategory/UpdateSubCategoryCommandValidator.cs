﻿using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommandRequest>
    {
        public UpdateSubCategoryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} cannot be empty");
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("{PropertyName} cannot be empty");
        }
    }
}
