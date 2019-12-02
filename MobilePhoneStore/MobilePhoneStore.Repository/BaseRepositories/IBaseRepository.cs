using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneStore.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity, new()
    {
        IEnumerable<TEntity> ListAll();
        Task<TEntity> FindFirstOrDefault(string id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
