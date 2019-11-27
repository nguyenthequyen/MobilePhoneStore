﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Rate : IBaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int Star { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

    }
}