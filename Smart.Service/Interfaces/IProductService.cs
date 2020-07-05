
using Smart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Service.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();

        void Add(Product obj);

        void Update(Product obj);

        void Delete(string id);

        Product GetById(string id);

        void Save();

    }
}
