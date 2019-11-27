using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Order : IBaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
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
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public virtual User User { get; set; }
    }
}
