using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Commands.Product.CreateProduct
{
    public class CreateSubCategoryCommandRequest : IRequest<CreateSubCategoryCommandResponse>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}