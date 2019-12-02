using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("UserInfos")]
    public class UserInfo : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
