using sampledatamodel.Interfaces;
using sampledatamodel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampledataservice.services
{
    public class ProductService : IProductService
    {
        public ProductService(string ConnectionString)
        {

        }

        public bool DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Product SetProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
