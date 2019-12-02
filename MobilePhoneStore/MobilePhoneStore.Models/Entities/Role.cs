using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Roles")]
    public class Role : IdentityRole<string>
    {
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<RoleClaim> RoleClaims { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
