using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Image> GetImages(string productId)
        {
            return _dbContext.Images.Where(x => x.ProductId == productId);
        }
    }
}
