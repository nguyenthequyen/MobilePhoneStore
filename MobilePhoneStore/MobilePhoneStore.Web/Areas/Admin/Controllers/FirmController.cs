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
        }

        public IActionResult List()
        {
            return View();
        }
        public  async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(FirmViewModel model)
        {
            if (ModelState.IsValid)
            {
                var firm = new Firm
                {
                    Name = model.Name
                };
                _firmService.Insert(firm);
                _unitOfWork.Commit();
            }
            return View(model);
        }
    }
}