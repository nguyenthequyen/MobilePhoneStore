using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Controllers.API
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected readonly ILogger<BaseController> _logger;
        protected ApplicationDbContext _dbContext;
        protected IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork, ApplicationDbContext dbContext, ILogger<BaseController> logger)
        {
            _logger = logger;
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
    }
}
