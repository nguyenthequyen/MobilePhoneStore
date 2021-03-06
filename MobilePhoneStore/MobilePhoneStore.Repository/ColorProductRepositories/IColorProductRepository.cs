﻿using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public interface IColorProductRepository : IBaseRepository<ColorProduct>
    {
        IEnumerable<ColorProduct> GetColorProductsByProductId(string productId);
    }
}
