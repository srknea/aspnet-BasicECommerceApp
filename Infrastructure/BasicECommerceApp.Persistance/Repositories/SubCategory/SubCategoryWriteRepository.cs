﻿using BasicECommerceApp.Application.Repositories.SubCategory;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Repositories.SubCategory
{
    public class SubCategoryWriteRepository : GenericWriteRepository<Domain.Entities.SubCategory>, ISubCategoryWriteRepository
    {
        public SubCategoryWriteRepository(BasicECommerceAppDbContext context) : base(context)
        {
        }
    }
}
