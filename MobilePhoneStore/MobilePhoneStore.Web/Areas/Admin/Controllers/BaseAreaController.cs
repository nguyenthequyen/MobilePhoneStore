using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Web.Areas.Admin.Controllers
{
    public class BaseAreaController : Controller
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseAreaController> _logger;
        public BaseAreaController(
            ApplicationDbContext dbContext, 
            IUnitOfWork unitOfWork,
            ILogger<BaseAreaController> logger)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}