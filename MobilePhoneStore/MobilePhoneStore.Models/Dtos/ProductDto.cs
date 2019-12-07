using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobilePhoneStore.Models
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string TrademarkId { get; set; }
        public string ColorId { get; set; }
    }
}
