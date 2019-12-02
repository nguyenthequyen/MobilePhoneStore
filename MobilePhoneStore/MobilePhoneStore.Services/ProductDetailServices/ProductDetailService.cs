using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ProductDetailService : BaseService<ProductDetail>, IProductDetailService
    {
        public ProductDetailService(IUnitOfWork unitOfWork, IProductDetailRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
