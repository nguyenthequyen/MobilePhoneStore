using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// Thương hiệu
        /// </summary>
        public string Trademark { get; set; }
        public string Model { get; set; }
        public string SKU { get; set; }
        public string CategoryId { get; set; }
        public string FirmId { get; set; }
        public Category Category { get; set; }
        public Firm Firm { get; set; }
    }
}
