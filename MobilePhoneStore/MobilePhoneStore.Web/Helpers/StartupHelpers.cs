using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using MobilePhoneStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneStore.Web.Helpers
{
    public static class StartupHelpers
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IColorRepository, ColorRepository>();
            services.AddTransient<IColorProductRepository, ColorProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();
            services.AddTransient<IFirmRepository, FirmRepository>();
        }
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IColorService, ColorService>();
            services.AddTransient<IColorProductService, ColorProductService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IStorageService, StorageService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IFirmService, FirmService>();
        }
    }
}
