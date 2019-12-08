using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ColorProductService : BaseService<ColorProduct>, IColorProductService
    {
        private readonly IColorProductRepository _repository;
        public ColorProductService(IUnitOfWork unitOfWork, IColorProductRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _repository = reponsitory;
        }

        public IEnumerable<ColorProduct> GetColorProductsByProductId(string productId)
        {
            return _repository.GetColorProductsByProductId(productId);
        }
    }
}
