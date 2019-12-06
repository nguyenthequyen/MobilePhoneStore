using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Số điện thoại/Email không được để trống")]
        [Display(Name = "Số điện thoại/Email")]
        public string Username { get; set; }
    }
}
