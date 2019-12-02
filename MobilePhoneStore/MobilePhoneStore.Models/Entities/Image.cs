using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Images")]
    public class Image : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
