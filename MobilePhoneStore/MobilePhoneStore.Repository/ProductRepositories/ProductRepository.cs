using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Dtos;
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

        public IEnumerable<ProductQuery> GetProducts()
        {
            var query = _dbContext.Products.Join(_dbContext.Images, p => p.Id, i => i.ProductId, (p, i) => new { p, i })
                .Join(_dbContext.Categories, p1 => p1.p.CategoryId, c => c.Id, (p1, c) => new { p1, c })
                .Join(_dbContext.Firms, p3 => p3.p1.p.TrademarkId, f => f.Id, (p3, f) => new { p3, f })
                .Join(_dbContext.ColorProducts.Join(_dbContext.Colors, cp => cp.ColorId, cl => cl.Id,
                (cp, cl) => new { cp, cl }), cpls => cpls.p3.p1.p.Id, cl => cl.cl.Id, (cpls, cl) => new { cpls, cl })
                .Select(x => new ProductQuery
                {
                    ImageThumbnail = x.cpls.p3.p1.p.ImageThumbnail,
                    Name = x.cpls.p3.p1.p.Name,
                    Model = x.cpls.p3.p1.p.Model,
                    OldPrice = x.cpls.p3.p1.p.OldPrice,
                    Price = x.cpls.p3.p1.p.Price,
                    Quantity = x.cpls.p3.p1.p.Quantity,
                    SKU = x.cpls.p3.p1.p.SKU,
                    Specification = x.cpls.p3.p1.p.Specification,
                    Shortescription = x.cpls.p3.p1.p.Specification,
                    Category = x.cpls.p3.c,
                    Trademark = x.cpls.f
                });
            return query;
        }
    }
}
