using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllCategoryQueryResponse
    {
        public List<CategoryDto> Categories { get; set; }
    }
}