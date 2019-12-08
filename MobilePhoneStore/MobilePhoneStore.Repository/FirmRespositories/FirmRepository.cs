using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class FirmRepository : BaseRepository<Trademark>, IFirmRepository
    {
        public FirmRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
