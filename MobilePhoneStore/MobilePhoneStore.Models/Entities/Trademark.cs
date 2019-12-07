using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Firms")]
    public class Trademark : BaseEntity
    {
        public string Name { get; set; }
    }
}
