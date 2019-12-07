using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class ColorViewModel
    {
        [Required(ErrorMessage = "Màu sắc không được để trống")]
        [Display(Name = "Màu sắc")]
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
