using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ImageService : BaseService<Image>, IImageService
    {
        private readonly IImageRepository _reponsitory;
        public ImageService(IUnitOfWork unitOfWork, IImageRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _reponsitory = reponsitory;
        }

        public IEnumerable<Image> GetImages(string productId)
        {
            return _reponsitory.GetImages(productId);
        }
    }
}
