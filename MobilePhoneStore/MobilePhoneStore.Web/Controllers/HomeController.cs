using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;
using MobilePhoneStore.Web.Models;

namespace MobilePhoneStore.Web.Controllers
{
    public class HomeController : BaseMVCController
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IFirmService _firmService;

        public HomeController(
            ICategoryService categoryService,
            IProductService productService,
            IUnitOfWork unitOfWork,
            IFirmService firmService,
            ApplicationDbContext dbContext,
            ILogger<BaseMVCController> logger) : base(unitOfWork, dbContext, logger)
        {
            _categoryService = categoryService;
            _productService = productService;
            _firmService = firmService;
        }

        public IActionResult Index()
        {
            var firm = _firmService.ListAll();
            var category = _categoryService.ListAll();
            var product = _productService.ListAll();
            ViewData["Product"] = product;
            ViewData["Category"] = category;
            ViewData["Firm"] = firm;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
