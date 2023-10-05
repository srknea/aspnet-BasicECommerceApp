using BasicECommerceApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int Quantity { get; set; } // Ürünün sepette kaç adet olduğu

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
