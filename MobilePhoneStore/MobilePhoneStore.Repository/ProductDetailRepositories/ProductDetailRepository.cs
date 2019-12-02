using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ProductDetailRepository : BaseRepository<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
