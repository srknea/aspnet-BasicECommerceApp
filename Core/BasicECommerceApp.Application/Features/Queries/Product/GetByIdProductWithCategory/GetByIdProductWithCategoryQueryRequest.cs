using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetByIdProductWithCategoryQueryRequest : IRequest<GetByIdProductWithCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}