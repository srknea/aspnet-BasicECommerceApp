using BasicECommerceApp.Domain.Entities.Auth;
using BasicECommerceApp.Domain.Entities.Common;

namespace BasicECommerceApp.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public bool IsActive { get; set; } // Sepet aktif mi?
        public bool IsCheckedOut { get; set; } // Sepet siparişe dönüştü mü?
        public List<CartItem> CartItems { get; set; } // Sepetteki ürünler

        public string? UserId { get; set; }
        public AppUser User { get; set; }

        public Guid? VisitorId { get; set; }
        public Visitor Visitor { get; set; }

    }
}
