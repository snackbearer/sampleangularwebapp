using sampledatamodel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Interfaces
{
    public interface IProductService
    {
        
        IEnumerable<iProduct> GetProducts();

        iProduct GetProduct(int productID);

        bool DeleteProduct(int productId);

        iProduct SetProduct(int id, iProduct product);

        iProduct CreateProduct(iProduct product);

    }
}
