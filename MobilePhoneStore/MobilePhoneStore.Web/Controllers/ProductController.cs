using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Models.ViewModels;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;
using MobilePhoneStore.Web.Helpers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Controllers
{
    public class ProductController : BaseMVCController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        private readonly IFirmService _firmService;
        public ProductController(
            IFirmService firmService,
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
            _firmService = firmService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cartAfter != null)
            {
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
            }
            Product product = await _productService.FindFirstOrDefault(id);
            var categoryById = await _categoryService.FindFirstOrDefault(product.CategoryId);
            var images = _dbContext.Images.Where(x => x.ProductId == product.Id).ToList();
            ViewData["CategoryById"] = categoryById;
            ViewData["Images"] = images;
            var category = _categoryService.ListAll();
            ViewData["Category"] = category;
            var firm = _firmService.ListAll();
            ViewData["Firm"] = firm;
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddCard(CartViewModel model)
        {
            Product product = await _productService.FindFirstOrDefault(model.ProductId);
            var categoryById = await _categoryService.FindFirstOrDefault(product.CategoryId);
            var images = _dbContext.Images.Where(x => x.ProductId == product.Id).ToList();
            ViewData["CategoryById"] = categoryById;
            ViewData["Images"] = images;
            var category = _categoryService.ListAll();
            ViewData["Category"] = category;
            var firm = _firmService.ListAll();
            ViewData["Firm"] = firm;
            if (product.Quantity < model.Quantity)
            {
                var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
                return RedirectToAction(nameof(Detail), new { id = product.Id });
            }
            if (SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart") == null)
            {
                List<Cart> cart = new List<Cart>();
                cart.Add(new Cart { Product = product, Quantity = model.Quantity });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
            }
            else
            {
                List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                int index = isExist(model.ProductId);
                if (index != -1)
                {
                    cart[index].Quantity = model.Quantity;
                }
                else
                {
                    cart.Add(new Cart { Product = product, Quantity = model.Quantity });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
            }
            return RedirectToAction(nameof(Detail), new { id = product.Id });
        }

        [Route("remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
