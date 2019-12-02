using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, ICategoryRepository reponsitory) : base(unitOfWork, reponsitory)
        {
        }
    }
}
