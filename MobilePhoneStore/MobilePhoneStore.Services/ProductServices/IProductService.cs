using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public interface IProductService : IBaseService<Product>
    {
        IEnumerable<ProductQuery> GetProducts();
    }
}
