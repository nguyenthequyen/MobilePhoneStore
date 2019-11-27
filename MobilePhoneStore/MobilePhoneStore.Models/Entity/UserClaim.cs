﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
