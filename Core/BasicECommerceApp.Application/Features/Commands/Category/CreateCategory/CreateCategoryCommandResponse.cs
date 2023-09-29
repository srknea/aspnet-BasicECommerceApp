using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Commands.Product.CreateProduct
{
    public class CreateCategoryCommandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}