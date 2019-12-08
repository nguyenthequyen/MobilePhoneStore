using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Web.Controllers
{
    public class BaseMVCController : Controller
    {
        protected readonly ILogger<BaseMVCController> _logger;
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseMVCController(
            IUnitOfWork unitOfWork,
            ApplicationDbContext dbContext,
            ILogger<BaseMVCController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
    }
}