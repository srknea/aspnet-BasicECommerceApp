﻿using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories.Product
{
    public interface IProductWriteRepository : IGenericWriteRepository<Domain.Entities.Product>
    {
    }
}
