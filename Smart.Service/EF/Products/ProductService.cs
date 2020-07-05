using Smart.Core.Domain;
using Smart.Core.Domain.Common;
using Smart.Data.Infrastructor;
using Smart.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smart.Service.EF.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, string> _productRepository;
        private readonly IRepository<Info, string> _infoRepository;

        public ProductService(IRepository<Product, string> productRepository,
            IRepository<Info, string> _infoRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product obj)
        {
            _productRepository.Add(obj);
        }

        public void Delete(string id)
        {
            _productRepository.Remove(id);
        }

        public List<Product> GetAll()
        {
            return _productRepository.FindAll().ToList();
        }

        public Product GetById(string id)
        {
            return _productRepository.FindById(id);
        }

        public void Save()
        {
            _productRepository.SaveChange();
        }

        public void Update(Product obj)
        {
            _productRepository.Update(obj);
        }
    }
}
