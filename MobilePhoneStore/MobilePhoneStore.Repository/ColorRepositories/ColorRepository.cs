using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
