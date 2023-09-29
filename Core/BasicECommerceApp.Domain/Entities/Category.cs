﻿using BasicECommerceApp.Domain.Entities.Common;
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

        public List<SubCategory> SubCategories { get; set; }
    }
}
