using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllSubCategory
{
    public class GetAllSubCategoryQueryResponse
    {
        public List<SubCategoryDto> SubCategories { get; set; }
    }
}