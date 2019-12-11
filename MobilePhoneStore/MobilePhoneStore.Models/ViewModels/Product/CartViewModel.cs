using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class CartViewModel
    {
        public string ColorId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
