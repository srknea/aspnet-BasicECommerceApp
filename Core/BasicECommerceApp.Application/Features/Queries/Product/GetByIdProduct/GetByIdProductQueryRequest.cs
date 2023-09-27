using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    // GetByIdProductQueryRequest sınıfının request sınıfı olduğunu IRequest arayüzünü implemente etmiş olmasından anlıyoruz.
    // Request sonucunda hangi response sınıfının döneceğini belirtlmek için de IRequest<TResponse> kullanarak GetByIdProductQueryResponse sınıfını veriyoruz.
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public string Id { get; set; }
    }
}