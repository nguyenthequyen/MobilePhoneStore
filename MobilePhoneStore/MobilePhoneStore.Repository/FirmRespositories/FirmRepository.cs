﻿using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class FirmRepository : BaseRepository<Firm>, IFirmRepository
    {
        public FirmRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}