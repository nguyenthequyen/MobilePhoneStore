using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MobilePhoneStore.Services
{
    public class StorageService : IStorageService
    {
        private readonly IHostingEnvironment _env;
        public StorageService(IHostingEnvironment env)
        {
            _env = env;
        }
        public async Task DeleteMediaAsync(string fileName, string mediaFolder)
        {
            var filePath = Path.Combine(_env.ContentRootPath, mediaFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetMediaUrl(string fileName, string mediaFolder)
        {
            return $"/{mediaFolder}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mediaFolder, string mimeType = null)
        {
            var filePath = Path.Combine(_env.ContentRootPath, mediaFolder, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }
    }
}
