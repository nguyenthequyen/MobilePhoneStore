using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Models.ViewModels;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

namespace MobilePhoneStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseAreaController
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IStorageService _storageService;
        public ProductController(
            IStorageService storageService,
            IImageService imageService,
            IProductService productService,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<BaseAreaController> logger) : base(dbContext, unitOfWork, logger)
        {
            _storageService = storageService;
            _imageService = imageService;
            _productService = productService;
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            try
            {
                MapUploadedFile(model);
                if (ModelState.IsValid)
                {
                    var product = new Product
                    {

                    };
                    _productService.Insert(product);
                    foreach (var item in model.ProductImages)
                    {
                        var image = new Image
                        {
                            Name = item.FileName,
                            ProductId = product.Id,
                            Url = item.ContentType
                        };
                        _imageService.Insert(image);
                    }
                    await SaveProductMedias(model, product);
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm sản phẩm: " + ex);
            }
            return View(model);
        }

        private void MapUploadedFile(ProductViewModel model)
        {
            foreach (var file in Request.Form.Files)
            {
                if (file.Name.Contains("ProductImages"))
                {
                    model.ProductImages.Add(file);
                }
            }
        }
        private async Task SaveProductMedias(ProductViewModel productVM, Product product)
        {
            foreach (var item in productVM.ProductImages)
            {
                var fileName = await SaveFile(item);
            }
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}