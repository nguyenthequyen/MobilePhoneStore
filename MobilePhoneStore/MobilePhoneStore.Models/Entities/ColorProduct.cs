using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("ColorProducts")]
    public class ColorProduct : BaseEntity
    {
        public string ColorId { get; set; }
        public string ProductId { get; set; }
        public Color Color { get; set; }
        public Product Product { get; set; }
    }
}
