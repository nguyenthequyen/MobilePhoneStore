using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ColorService : BaseService<Color>, IColorService
    {
        public ColorService(IUnitOfWork unitOfWork, IColorRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
