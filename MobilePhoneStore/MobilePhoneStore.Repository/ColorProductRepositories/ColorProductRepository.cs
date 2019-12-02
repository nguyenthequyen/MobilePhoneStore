using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ColorProductRepository : BaseRepository<ColorProduct>, IColorProductRepository
    {
        public ColorProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
