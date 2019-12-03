using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MobilePhoneStore.Web.Areas.Admin.Controllers.API
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IColorProductService _colorProductService;
        public ProductController(
            IProductService productService,
            IColorProductService colorProductService,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
        ILogger<ProductController> logger) : base(unitOfWork, dbContext, logger)
        {
            _productService = productService;
            _colorProductService = colorProductService;
        }

        [HttpPost]
        [Route("products")]
        [ValidateModel]
        public async Task<IActionResult> InsertProduct([FromBody] ProductDto productDto)
        {

            try
            {
                var product = new Product
                {
                    CategoryId = productDto.CategoryId,
                    FirmId = productDto.FirmId,
                    Model = productDto.Model,
                    Name = productDto.Name,
                    SKU = productDto.SKU,
                    Trademark = productDto.Trademark,
                    Id = new Guid().ToString()
                };
                var colorProduct = new ColorProduct
                {
                    ColorId = productDto.ColorId,
                    ProductId = product.Id
                };
                _productService.Insert(product);
                _colorProductService.Insert(colorProduct);
                _unitOfWork.Commit();
                return Ok(new ResultService
                {
                    ErrorCode = (int)HttpStatusCode.OK,
                    Status = new Status
                    {
                        Code = 200,
                        Error = true,
                        Message = "success",
                        Type = "success"
                    },
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return Ok(new ResultService
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    Status = new Status
                    {
                        Code = 500,
                        Error = true,
                        Message = ex.Message,
                        Type = "Error"
                    },
                    Data = null
                });
            }
        }
    }
}
