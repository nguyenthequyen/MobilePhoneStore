using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Controllers
{
    public class CategoryController : BaseMVCController
    {
        public CategoryController(IUnitOfWork unitOfWork, ApplicationDbContext dbContext, ILogger<BaseMVCController> logger) : base(unitOfWork, dbContext, logger)
        {
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Product(string id)
        {
            var product = _dbContext.Categories.Where(x => x.Id == id).Join(_dbContext.Products, x => x.Id, y => y.CategoryId, (x, y) => new { x, y }).Select(x => new
            {
                Product = x.y
            }).ToList();

            ViewData["Product"] = product;
            return View();
        }
    }
}
