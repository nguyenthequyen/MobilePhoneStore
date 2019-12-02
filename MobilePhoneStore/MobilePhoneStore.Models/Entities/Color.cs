using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Colors")]
    public class Color : BaseEntity
    {
        public string Name { get; set; }
    }
}
