using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ColorProductService : BaseService<ColorProduct>, IColorProductService
    {
        public ColorProductService(IUnitOfWork unitOfWork, IColorProductRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
