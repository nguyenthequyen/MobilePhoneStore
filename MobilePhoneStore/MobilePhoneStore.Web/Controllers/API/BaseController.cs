using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Repository;

namespace MobilePhoneStore.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
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