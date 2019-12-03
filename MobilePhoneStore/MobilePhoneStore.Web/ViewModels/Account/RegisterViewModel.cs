using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Họ đệm không được để trống")]
        [Display(Name = "Họ đệm")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [Display(Name = "Tên")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        [Display(Name ="Số điện thoại/Email")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Display(Name = "Mật khẩu")]
        [StringLength(100, ErrorMessage = "{0} Mật khẩu phải chứa ít nhất {2} và tối đa {1} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Xác nhận mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu phải trùng nhau")]
        public string ConfirmPassword { get; set; }
    }
}
