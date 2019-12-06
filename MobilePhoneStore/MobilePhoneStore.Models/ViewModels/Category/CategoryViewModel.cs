using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        public string Name { get; set; }
        //public string ParentId { get; set; }
    }
}
