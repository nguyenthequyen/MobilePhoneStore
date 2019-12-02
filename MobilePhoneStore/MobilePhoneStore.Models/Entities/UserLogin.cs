using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{

    [Table("UserLogins")]
    public class UserLogin : IdentityUserLogin<string>
    {
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
