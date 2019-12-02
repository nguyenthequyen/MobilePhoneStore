using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("OrderDetails")]
    public class OrderDetail : BaseEntity
    {
        public int Quantity { get; set; }
        public float SalePice { get; set; }
        public string OrderId { get; set; }
        public string ProductId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
