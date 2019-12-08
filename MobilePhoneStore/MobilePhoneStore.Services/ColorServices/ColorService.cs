using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ColorService : BaseService<Color>, IColorService
    {
        private readonly IColorRepository _repository;
        public ColorService(IUnitOfWork unitOfWork, IColorRepository reponsitory) : base(unitOfWork, reponsitory)
        {
            _repository = reponsitory;
        }

        public IEnumerable<Color> GetColorsByColorId(string id)
        {
            return _repository.GetColorsByColorId(id);
        }
    }
}
