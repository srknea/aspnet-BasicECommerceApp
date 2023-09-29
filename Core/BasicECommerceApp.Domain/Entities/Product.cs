using BasicECommerceApp.Domain.Entities.Common;

namespace BasicECommerceApp.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
