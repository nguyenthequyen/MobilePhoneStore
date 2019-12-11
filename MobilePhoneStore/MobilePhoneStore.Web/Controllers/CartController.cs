using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models.ViewModels;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;
using MobilePhoneStore.Web.Helpers;

namespace MobilePhoneStore.Web.Controllers
{
    public class CartController : BaseMVCController
    {
        private readonly ICategoryService _categoryService;
        public CartController(
            ICategoryService categoryService,
            IUnitOfWork unitOfWork,
            ApplicationDbContext dbContext,
            ILogger<CartController> logger) : base(unitOfWork, dbContext, logger)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ListCart()
        {
            var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cartAfter != null)
            {
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
            }
            var category = _categoryService.ListAll();
            ViewData["Category"] = category;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RemoveCart(string id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                int index = isExist(id);
                cart.RemoveAt(index);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            var cartAfter = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cartAfter != null)
            {
                ViewData["Total"] = cartAfter.Sum(item => item.Product.Price * item.Quantity);
                ViewData["Cart"] = cartAfter;
            }
            var category = _categoryService.ListAll();
            ViewData["Category"] = category;
            return RedirectToAction(nameof(ListCart));
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