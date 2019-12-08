using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Constants;
using MobilePhoneStore.Models.ViewModels;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;

namespace MobilePhoneStore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseAreaController
    {
        private readonly IProductService _productService;
        private readonly IImageService _imageService;
        private readonly IStorageService _storageService;
        private readonly IColorService _colorService;
        private readonly IFirmService _firmService;
        private readonly ICategoryService _categoryService;
        private readonly IColorProductService _colorProductService;
        private readonly IHostingEnvironment _env;

        public ProductController(
            IColorProductService colorProductService,
            IHostingEnvironment env,
            ICategoryService categoryService,
            IFirmService firmService,
            IColorService colorService,
            IStorageService storageService,
            IImageService imageService,
            IProductService productService,
            ApplicationDbContext dbContext,
            IUnitOfWork unitOfWork,
            ILogger<BaseAreaController> logger) : base(dbContext, unitOfWork, logger)
        {
            _env = env;
            _firmService = firmService;
            _storageService = storageService;
            _imageService = imageService;
            _productService = productService;
            _colorService = colorService;
            _categoryService = categoryService;
            _colorProductService = colorProductService;
        }

        public async Task<IActionResult> List()
        {
            var product = _productService.ListAll();
            ViewData["Product"] = product;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var category = _categoryService.ListAll();
            var color = _colorService.ListAll();
            var firm = _firmService.ListAll();
            ViewData["Color"] = color;
            ViewData["TrademarkId"] = firm;
            ViewData["Category"] = category;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            var category = _categoryService.ListAll();
            var color = _colorService.ListAll();
            var firm = _firmService.ListAll();
            ViewData["Color"] = color;
            ViewData["TrademarkId"] = firm;
            ViewData["Category"] = category;
            try
            {
                //MapUploadedFile(model);
                if (ModelState.IsValid)
                {
                    await ReplaceImageAsync(model);
                    var thumbnailUrl = await SaveThumbnail(model);
                    var product = new Product
                    {
                        Description = model.Description,
                        CategoryId = model.CategoryId,
                        Model = model.ModelName,
                        Name = model.Name,
                        Shortescription = model.ShortDescription,
                        TrademarkId = model.TrademarkId,
                        SKU = model.SKU,
                        Specification = model.Specification,
                        ImageThumbnail = thumbnailUrl,
                        OldPrice = model.OldPrice,
                        Quantity = model.Quantity,
                        Price = model.Price,
                        Gtin = model.Gtin
                    };
                    _productService.Insert(product);
                    await SaveProductMedias(model, product, Constant.IMGPRODUCTROOT);
                    _colorProductService.Insert(new ColorProduct { ColorId = model.ColorId, ProductId = product.Id });
                    _unitOfWork.Commit();
                    return View();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm sản phẩm: " + ex);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var category = _categoryService.ListAll();
            var color = _colorService.ListAll();
            var firm = _firmService.ListAll();
            ViewData["Color"] = color;
            ViewData["TrademarkId"] = firm;
            ViewData["Category"] = category;
            var product = await _productService.FindFirstOrDefault(id);
            var productViewModel = new ProductViewModel
            {
                CategoryId = product.CategoryId,
                Gtin = product.Gtin,
                Description = product.Description,
                ModelName = product.Model,
                Name = product.Name,
                OldPrice = product.OldPrice,
                Price = product.Price,
                Quantity = product.Quantity,
                ShortDescription = product.Shortescription,
                Specification = product.Specification,
                SKU = product.SKU,
                TrademarkId = product.TrademarkId,
            };
            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model, string id)
        {
            var category = _categoryService.ListAll();
            var color = _colorService.ListAll();
            var firm = _firmService.ListAll();
            ViewData["Color"] = color;
            ViewData["TrademarkId"] = firm;
            ViewData["Category"] = category;
            try
            {
                var product = await _productService.FindFirstOrDefault(id);
                //MapUploadedFile(model);
                if (ModelState.IsValid)
                {
                    await ReplaceImageAsync(model);
                    var thumbnailUrl = await SaveThumbnail(model);
                    var newProduct = new Product
                    {
                        Description = model.Description,
                        CategoryId = model.CategoryId,
                        Model = model.ModelName,
                        Name = model.Name,
                        Shortescription = model.ShortDescription,
                        TrademarkId = model.TrademarkId,
                        SKU = model.SKU,
                        Specification = model.Specification,
                        ImageThumbnail = thumbnailUrl,
                        OldPrice = model.OldPrice,
                        Quantity = model.Quantity,
                        Price = model.Price,
                        Gtin = model.Gtin,
                        Id = product.Id
                    };
                    _productService.Update(newProduct);
                    await SaveProductMedias(model, product, Constant.IMGPRODUCTROOT);
                    _colorProductService.Update(new ColorProduct { ColorId = model.ColorId, ProductId = product.Id });
                    _unitOfWork.Commit();
                    return View();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError("Lỗi thêm sản phẩm: " + ex);
            }
            return View(model);
        }

        private void MapUploadedFile(ProductViewModel model)
        {
            foreach (var file in Request.Form.Files)
            {
                if (file.Name.Contains("ProductImages"))
                {
                    model.ProductImages.Add(file);
                }
            }
        }
        private async Task SaveProductMedias(ProductViewModel productVM, Product product, string mediaFolder)
        {
            foreach (var item in productVM.ProductImages)
            {
                var fileName = await SaveFile(item, mediaFolder);
                var image = new Image
                {
                    Name = fileName,
                    ProductId = product.Id,
                    Url = Constant.IMGPRODUCT + fileName
                };
                _imageService.Insert(image);
            }
        }

        private async Task<string> SaveThumbnail(ProductViewModel productVM)
        {
            var productThumbnail = await SaveFile(productVM.ImageThumbnail, Constant.PRODUCTTHUMBNAILROOT);
            return Constant.IMAGETHUMBNAIL + productThumbnail;
        }

        private async Task<string> SaveFile(IFormFile file, string mediaFolder)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}".Trim('"');
            string reversed = new String(fileName.ToCharArray().Reverse().ToArray());
            var extension = reversed.Split(".");
            char[] fileNameArray = extension[0].ToCharArray();
            Array.Reverse(fileNameArray);
            var name = Guid.NewGuid();
            fileName = name + "." + String.Join("", fileNameArray);
            await _storageService.SaveMediaAsync(file.OpenReadStream(), fileName, mediaFolder, file.ContentType);
            return fileName;
        }

        public async Task ReplaceImageAsync(ProductViewModel model)
        {
            var imgRegex = new Regex("<img[^>]+ />", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            var base64Regex = new Regex("data:[^/]+/(?<ext>[a-z]+);base64,(?<base64>.+)", RegexOptions.IgnoreCase);
            string[] allowedExtensions = new[] {
              ".jpg",
              ".jpeg",
              ".gif",
              ".png",
              ".webp"
            };
            foreach (Match match in imgRegex.Matches(model.Description))
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<root>" + match.Value + "</root>");

                var img = doc.FirstChild.FirstChild;
                var srcNode = img.Attributes["src"];
                var fileNameNode = img.Attributes["alt"];

                // The HTML editor creates base64 DataURIs which we'll have to convert to image files on disk
                if (srcNode != null && fileNameNode != null)
                {
                    string extension = System.IO.Path.GetExtension(fileNameNode.Value);

                    // Only accept image files
                    if (!allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var base64Match = base64Regex.Match(srcNode.Value);
                    if (base64Match.Success)
                    {
                        byte[] bytes = Convert.FromBase64String(base64Match.Groups["base64"].Value);
                        srcNode.Value = await SaveFile(bytes, fileNameNode.Value).ConfigureAwait(false);

                        img.Attributes.Remove(fileNameNode);
                        model.Description = model.Description.Replace(match.Value, img.OuterXml);
                    }
                }
            }
        }
        public async Task<string> SaveFile(byte[] bytes, string fileName, string suffix = null)
        {
            suffix = CleanFromInvalidChars(suffix ?? DateTime.UtcNow.Ticks.ToString());

            string ext = Path.GetExtension(fileName);
            string name = CleanFromInvalidChars(Path.GetFileNameWithoutExtension(fileName));
            name = name.Replace(name, Guid.NewGuid().ToString());
            string fileNameWithSuffix = $"{name}_{suffix}{ext}";

            string absolute = Path.Combine(Path.Combine(_env.WebRootPath, Constant.POSTS), Constant.FILES, fileNameWithSuffix);
            string dir = Path.GetDirectoryName(absolute);

            Directory.CreateDirectory(dir);
            using (var writer = new FileStream(absolute, FileMode.CreateNew))
            {
                await writer.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            }

            return $"/{Constant.POSTS}/{Constant.FILES}/{fileNameWithSuffix}";
        }
        private static string CleanFromInvalidChars(string input)
        {
            var regexSearch = Regex.Escape(new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars()));
            var r = new Regex($"[{regexSearch}]");
            return r.Replace(input, "");
        }
    }
}