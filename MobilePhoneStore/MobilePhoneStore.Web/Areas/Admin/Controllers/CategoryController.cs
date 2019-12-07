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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseAreaController
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(
            ICategoryService categoryService,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<CategoryController> logger) : base(dbContext, unitOfWork, logger)
        {
            _categoryService = categoryService;
        }

        // GET: /<controller>/
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var category = new Category
                    {
                        Name = model.Name
                    };
                    _categoryService.Insert(category);
                    _unitOfWork.Commit();
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tạo danh mục: " + ex);
            }
            return View(model);
        }
    }
}
