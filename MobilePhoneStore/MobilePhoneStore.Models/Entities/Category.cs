using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        //public Guid ParentId { get; set; }
    }
}
