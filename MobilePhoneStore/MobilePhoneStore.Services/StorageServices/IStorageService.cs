using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneStore.Services
{
    public interface IStorageService
    {
        string GetMediaUrl(string fileName, string mediaFolder);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string mediaFolder, string mimeType = null);

        Task DeleteMediaAsync(string fileName, string mediaFolder);
    }
}
