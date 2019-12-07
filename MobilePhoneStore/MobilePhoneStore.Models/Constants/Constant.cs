using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Models.Constants
{
    public static class Constant
    {
        public const string EMAILREGEX = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const string PHONENUMBERREGEX = @"^(([0-9]|\\+)(\\d{9})|(\\d{11}))$";
        public const string POSTS = "product";
        public const string FILES = "img_description";
        public const string IMGPRODUCTROOT = "wwwroot/product/img_product/";
        public const string IMGPRODUCT = "product/img_product/";
        public const string PRODUCTTHUMBNAILROOT = "wwwroot/product/product_thumbnail/";
        public const string IMAGETHUMBNAIL = "/product/product_thumbnail/";
    }
}
