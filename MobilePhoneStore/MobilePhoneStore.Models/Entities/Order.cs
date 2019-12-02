using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{

    [Table("Orders")]
    public class Order : BaseEntity
    {
        /// <summary>
        /// Họ tên người nhận
        /// </summary>
        public string ReviceverName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Địa chỉ người nhận
        /// </summary>
        public string ReviceverAddress { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
