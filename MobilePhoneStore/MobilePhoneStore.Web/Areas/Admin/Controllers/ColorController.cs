﻿using System;
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
    public class ColorController : BaseAreaController
    {
        private readonly IColorRepository _colorRepository;
        public ColorController(
            IColorRepository colorRepository,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<ColorController> logger) : base(dbContext, unitOfWork, logger)
        {
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
        public async Task<IActionResult> Create(ColorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var color = new Color
                {
                    Name = model.Name
                };
                _colorRepository.Insert(color);
                _unitOfWork.Commit();
            }
            return View(model);
        }
    }
}