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
    public class FirmController : BaseAreaController
    {
        private readonly IFirmService _firmService;
        public FirmController(
            IFirmService firmService,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<FirmController> logger) : base(dbContext, unitOfWork, logger)
        {
            _firmService = firmService;
        }

        // GET: /<controller>/
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
        public async Task<IActionResult> Create(FirmViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _firmService.Insert(new Trademark
                    {
                        Name = model.Name
                    });
                    _unitOfWork.Commit();
                }
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi tạo hãng sản xuất: " + ex);
            }
            return View(model);
        }
    }
}
