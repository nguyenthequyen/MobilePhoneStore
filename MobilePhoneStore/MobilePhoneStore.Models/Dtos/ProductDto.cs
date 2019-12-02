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
        /// <summary>
        /// Thương hiệu
        /// </summary>
        [Required]
        public string Trademark { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public string FirmId { get; set; }
        public string ColorId { get; set; }
    }
}
