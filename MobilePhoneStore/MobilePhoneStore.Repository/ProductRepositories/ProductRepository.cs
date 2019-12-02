using MobilePhoneStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
