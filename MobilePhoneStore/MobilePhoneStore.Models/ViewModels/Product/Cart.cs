using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class Cart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string ColorId { get; set; }
    }
}
