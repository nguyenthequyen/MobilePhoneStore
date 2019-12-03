﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web.ViewModels
{
    public class LoginInputModel
    {
        [Required(ErrorMessage = "Tên tài khoản không được để trống")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
