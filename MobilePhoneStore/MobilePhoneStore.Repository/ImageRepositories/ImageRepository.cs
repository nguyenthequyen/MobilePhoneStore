using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
