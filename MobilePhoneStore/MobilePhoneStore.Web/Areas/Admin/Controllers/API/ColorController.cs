using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    public class ColorController : BaseController
    {
        //private readonly Ico
        public ColorController(
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<BaseController> logger) : base(unitOfWork, dbContext, logger)
        {
        }

        [HttpPost]
        [Route("color-product")]
        public async Task<IActionResult> ColorProduct([FromBody] ColorDto colorProductDto)
        {
            try
            {
                var colorProduct = new Color
                {
                    Id = new Guid().ToString(),
                    Name = colorProductDto.Name
                };
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm màu sản phẩm: " + ex);
                return Ok();
            }
        }
    }
}
