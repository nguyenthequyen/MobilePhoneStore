using Microsoft.AspNetCore.Http;
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
        public string Model { get; set; }
        public string SKU { get; set; }
        public string CategoryId { get; set; }
        public string TrademarkId { get; set; }
        public string Shortescription { get; set; }
        public string Specification { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string ImageThumbnail { get; set; }
        public int Quantity { get; set; }
        public string Gtin { get; set; }
        public Category Category { get; set; }
        public Trademark Trademark { get; set; }
    }
}
