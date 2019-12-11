using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Controllers
{
    public class TrademarkController : BaseMVCController
    {
        private readonly ICategoryService _categoryService;
        private readonly IFirmService _firmService;
        public TrademarkController(
            IFirmService firmService,
            ICategoryService categoryService,
            IUnitOfWork unitOfWork,
            ApplicationDbContext dbContext,
            ILogger<TrademarkController> logger) : base(unitOfWork, dbContext, logger)
        {
            _categoryService = categoryService;
            _firmService = firmService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Product(string id)
        {
            var product = _dbContext.Products.Where(x => x.TrademarkId == id).ToList();
            var category = _categoryService.ListAll();
            var firm = _firmService.ListAll();
            ViewData["Category"] = category;
            ViewData["Product"] = product;
            ViewData["Firm"] = firm;
            return View();
        }
    }
}
