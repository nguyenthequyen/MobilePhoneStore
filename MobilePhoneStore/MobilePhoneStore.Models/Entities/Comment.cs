using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MobilePhoneStore.Models
{
    [Table("Comments")]
    public class Comment : BaseEntity
    {
        public string Value { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
