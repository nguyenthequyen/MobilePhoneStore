using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Rates")]
    public class Rate : BaseEntity
    {
        public int Star { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }

    }
}
