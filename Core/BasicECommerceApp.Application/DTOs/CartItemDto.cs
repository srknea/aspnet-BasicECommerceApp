using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.DTOs
{
    public class CartItemDto
    {
        public int Quantity { get; set; } // Ürünün sepette kaç adet olduğu
        public Guid ProductId { get; set; }
    }
}
