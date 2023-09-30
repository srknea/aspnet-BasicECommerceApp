using BasicECommerceApp.Domain.Entities.Common;

namespace BasicECommerceApp.Domain.Entities
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}
