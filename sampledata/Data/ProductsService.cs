using sampledata.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using sampledatamodel.Interfaces;
using sampledatamodel.Models;

namespace sampledata.Data
{
    public class ProductsService : IProductService
    {
        cmsContext _context;

        public ProductsService(string ConnectionString)
        {
            _context = new cmsContext(ConnectionString);
        }

        public ProductsService(cmsContext context)
        {
            _context = context;
        }

        public IEnumerable<iProduct> GetProducts()
        {
            
            var products = _context.Product.Select(p => new iProduct
            {
                ProductId = p.ProductId,
                ProductCode = p.ProductCode,
                ProductName = p.ProductName,
                ProductCost = p.ProductCost
            }).ToList();
            
            return products;

        }

        public iProduct GetProduct(int productID)
        {
            
            return _context.Product.Where(p => p.ProductId == productID)
                .Select(p=>
                 new iProduct
                {
                    ProductId = p.ProductId,
                    ProductCode = p.ProductCode,
                    ProductName = p.ProductName,
                    ProductCost = p.ProductCost
                }).FirstOrDefault();
            
        }

        public bool DeleteProduct(int productId)
        {

            var selectedProduct = _context.Product.Where(p => p.ProductId == productId).First();
            _context.Product.Remove(selectedProduct);
            _context.SaveChanges();

            return true;

        }
        

        
        public iProduct CreateProduct(iProduct product)
        {
            Product setproduct;
            
            setproduct = new Product { ProductCode = product.ProductCode, ProductName = product.ProductName, ProductCost = product.ProductCost };

            _context.Product.Add(setproduct);

            _context.SaveChanges();

            return new iProduct
            {
                ProductId = setproduct.ProductId,
                ProductCode = setproduct.ProductCode,
                ProductName = setproduct.ProductName,
                ProductCost = setproduct.ProductCost
            };

        }

        public iProduct SetProduct(int id, iProduct product)
        {

            Product setproduct;
            
            setproduct = _context.Product.Where(p => p.ProductId == id).First();
            setproduct.ProductCode = product.ProductCode;
            setproduct.ProductName = product.ProductName;
            setproduct.ProductCost = product.ProductCost;

            _context.SaveChanges();

            return new iProduct { ProductId = setproduct.ProductId,
                ProductCode = setproduct.ProductCode,
                ProductName = setproduct.ProductName,
                ProductCost = setproduct.ProductCost
            };

        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }
    }
}
