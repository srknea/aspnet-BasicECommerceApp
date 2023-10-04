﻿using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public List<CategoryDto> Children { get; set; }
    }
}
