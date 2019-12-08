using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ColorProductRepository : BaseRepository<ColorProduct>, IColorProductRepository
    {
        public ColorProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ColorProduct> GetColorProductsByProductId(string productId)
        {
            return _dbContext.ColorProducts.Where(x => x.ProductId == productId);
        }
    }
}
