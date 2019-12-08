using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Controllers
{
    public class ProductController : BaseMVCController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        public ProductController(
            IImageService imageService,
            ICategoryService categoryService,
            IProductService productService,
            IUnitOfWork unitOfWork,
            ApplicationDbContext dbContext,
            ILogger<ProductController> logger) : base(unitOfWork, dbContext, logger)
        {
            _imageService = imageService;
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            Product product = await _productService.FindFirstOrDefault(id);
            var category = await _categoryService.FindFirstOrDefault(product.CategoryId);
            var images = _dbContext.Images.Where(x => x.ProductId == product.Id).ToList();
            ViewData["Category"] = category;
            ViewData["Images"] = images;
            return View(product);
        }
    }
}
