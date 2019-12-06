using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class FirmViewModel
    {
        [Required(ErrorMessage = "Tên hãng không được để trống")]
        [Display(Name = "Hãng điện thoại")]
        public string Name { get; set; }
    }
}
