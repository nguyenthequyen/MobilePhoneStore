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
    public class HomeController : Controller
    {

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            ApplicationDbContext dbContext,
            ICategoryService categoryService,
            IProductService productService,
            ILogger<HomeController> logger)
        {
            _categoryService = categoryService;
            _productService = productService;
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var product = _productService.ListAll();
            ViewData["Product"] = product;
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
