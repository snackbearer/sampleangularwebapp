using sampledatamodel.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sampledatamodel.Interfaces
{
    public interface IProductService
    {

        List<IProduct> GetProducts();
        Task<List<IProduct>> GetProductsAsync();
        
        IProduct GetProduct(int productId);

        bool DeleteProduct(int productId);

        IProduct SetProduct(int id, IProduct product);

        IProduct CreateProduct(IProduct product);

    }
}
