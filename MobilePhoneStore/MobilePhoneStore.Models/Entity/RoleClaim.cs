using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }
        public DateTime CreatedDate { get ; set; }
        public DateTime ModifyDate { get ; set ; }
    }
}
