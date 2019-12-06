using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ImageService : BaseService<Image>, IImageService
    {
        public ImageService(IUnitOfWork unitOfWork, IImageRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
