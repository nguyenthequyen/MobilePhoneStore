using MobilePhoneStore.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MobilePhoneStore.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
