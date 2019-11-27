using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Comment : IBaseEntity
    {
        public string Value { get; set; }
        public string Title { get; set; }
        public string Id { get; set; }
        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
