using BasicECommerceApp.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public Guid? ParentId { get; set; }
        public Category Parent { get; set; }

        public List<Category> Children { get; set; }

        public List<Product> Products { get; set; }
    }
}
