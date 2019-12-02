using MobilePhoneStore.Models;
using MobilePhoneStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneStore.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _repository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
    }
}
