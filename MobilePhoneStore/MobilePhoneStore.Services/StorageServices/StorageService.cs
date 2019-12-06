using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MobilePhoneStore.Services
{
    public class StorageService : IStorageService
    {
        private const string MediaRootFoler = "user-content";
        public async Task DeleteMediaAsync(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), MediaRootFoler, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetMediaUrl(string fileName)
        {
            return $"/{MediaRootFoler}/{fileName}";
        }

        public async Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mimeType = null)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), MediaRootFoler, fileName);
            using (var output = new FileStream(filePath, FileMode.Create))
            {
                await mediaBinaryStream.CopyToAsync(output);
            }
        }
    }
}
