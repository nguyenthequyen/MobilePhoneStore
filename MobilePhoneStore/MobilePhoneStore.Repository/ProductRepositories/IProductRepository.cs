using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        IEnumerable<ProductQuery> GetProducts();
    }
}
