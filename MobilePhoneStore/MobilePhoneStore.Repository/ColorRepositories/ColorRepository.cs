using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ColorRepository : BaseRepository<Color>, IColorRepository
    {
        public ColorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Color> GetColorsByColorId(string id)
        {
            return _dbContext.Colors.Where(x => x.Id == id);
        }
    }
}
