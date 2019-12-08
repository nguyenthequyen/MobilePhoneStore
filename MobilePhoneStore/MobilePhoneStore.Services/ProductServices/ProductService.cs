using MobilePhoneStore.Models;
using MobilePhoneStore.Models.Dtos;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private IProductRepository _repository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public IEnumerable<ProductQuery> GetProducts()
        {
            return _repository.GetProducts();
        }
    }
}
