using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class FirmService : BaseService<Trademark>, IFirmService
    {
        public FirmService(IUnitOfWork unitOfWork, IFirmRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
