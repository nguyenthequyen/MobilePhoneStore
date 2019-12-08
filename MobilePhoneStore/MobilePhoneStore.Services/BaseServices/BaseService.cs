using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobilePhoneStore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> _reponsitory;
        protected readonly IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<TEntity> reponsitory)
        {
            _reponsitory = reponsitory;
            _unitOfWork = unitOfWork;
        }
        public void Insert(TEntity entity)
        {
            //entity.Id = new Guid().ToString();
            entity.CreatedDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;
            entity.Status = 1;
            _reponsitory.Insert(entity);
        }

        public void Delete(TEntity entity)
        {
            _reponsitory.Delete(entity);
        }

        public IEnumerable<TEntity> ListAll()
        {
            return _reponsitory.ListAll();
        }

        public async Task<TEntity> FindFirstOrDefault(string id)
        {
            return await _reponsitory.FindFirstOrDefault(id);
        }

        public void Save()
        {
            _reponsitory.Save();
        }

        public void Update(TEntity entity)
        {
            _reponsitory.Update(entity);
        }

        public IEnumerable<TEntity> ListEntityById(string id)
        {
            return _reponsitory.ListEntityById(id);
        }
    }
}
