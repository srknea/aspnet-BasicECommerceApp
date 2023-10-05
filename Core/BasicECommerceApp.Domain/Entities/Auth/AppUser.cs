using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Domain.Entities.Auth
{
    public class AppUser : IdentityUser
    {
        public List<Cart> Carts { get; set; }

        public bool HasActiveCart()
        {
            // Kullanıcının aktif bir sepeti var mı kontrolünü yapın
            return Carts != null && Carts.Any(cart => cart.IsActive);
        }
        public Cart GetActiveCart()
        {
            // Kullanıcının aktif bir sepeti varsa onu döndürün
            return Carts.FirstOrDefault(cart => cart.IsActive);
        }
    }
}
