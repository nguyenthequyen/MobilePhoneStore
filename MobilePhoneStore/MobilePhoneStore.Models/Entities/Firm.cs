using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Providers")]
    public class Firm : BaseEntity
    {
        public string Name { get; set; }
    }
}
