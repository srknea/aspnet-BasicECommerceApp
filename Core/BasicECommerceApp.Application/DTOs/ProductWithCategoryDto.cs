using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.DTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryWithChildrenDto CategoryDto { get; set; }
    }
}
