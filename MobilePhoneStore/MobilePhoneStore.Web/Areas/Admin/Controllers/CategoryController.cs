using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Models.ViewModels;
using MobilePhoneStore.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : BaseAreaController
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(
            ICategoryRepository categoryRepository,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<CategoryController> logger) : base(dbContext, unitOfWork, logger)
        {
            _categoryRepository = categoryRepository;
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
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name
                };
                _categoryRepository.Insert(category);
                _unitOfWork.Commit();
            }
            return View(model);
        }
    }
}
