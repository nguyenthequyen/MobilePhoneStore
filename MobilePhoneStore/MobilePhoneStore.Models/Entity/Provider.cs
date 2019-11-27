using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Provider : IBaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
