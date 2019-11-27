using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class Category : IBaseEntity
    {
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string Id { get; set; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifyDate { get; set; }
    }
}
