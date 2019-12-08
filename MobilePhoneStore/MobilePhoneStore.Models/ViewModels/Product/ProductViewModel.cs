using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MobilePhoneStore.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SKU không được để trống")]
        [Display(Name = "SKU")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Mô tả ngắn không được để trống")]
        [Display(Name = "Mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Giá cũ")]
        public decimal? OldPrice { get; set; }

        [Required(ErrorMessage = "Gtin không được để trống")]
        [Display(Name = "Gtin")]
        public string Gtin { get; set; }

        [Display(Name = "Hình ảnh")]
        public IList<IFormFile> ProductImages { get; set; } = new List<IFormFile>();

        public string ColorId { get; set; }
        public string TrademarkId { get; set; }

        public string CategoryId { get; set; }

        [Display(Name = "ModelName")]
        public string ModelName { get; set; }

        [Display(Name = "Thông số kỹ thuật")]
        public string Specification { get; set; }

        [Display(Name = "Hình nhỏ")]
        public IFormFile ImageThumbnail { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
    }
}
