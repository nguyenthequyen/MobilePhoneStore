using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models.Constants
{
    public static class Constant
    {
        public const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PhoneNumberRegex = @"^(([0-9]|\\+)(\\d{9})|(\\d{11}))$";
    }
}
