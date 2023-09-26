using BasicECommerceApp.Domain.Entities.Common;

namespace BasicECommerceApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
