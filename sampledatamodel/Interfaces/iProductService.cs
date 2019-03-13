using sampledatamodel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Interfaces
{
    public interface IProductService
    {
        
        IEnumerable<IProduct> GetProducts();

        IProduct GetProduct(int productId);

        bool DeleteProduct(int productId);

        IProduct SetProduct(int id, IProduct product);

        IProduct CreateProduct(IProduct product);

    }
}
