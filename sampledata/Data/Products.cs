using sampledata.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace sampledata.Data
{
    public class Products
    {
        cmsContext context;

        public Products()
        {
            context = new cmsContext();
        }

        public IEnumerable<Product> GetProducts()
        {
            
            var products = context.Product.ToList();

            return products;

        }

        public Product GetProduct(int productID)
        {
            
            return context.Product.Where(p => p.ProductId == productID).FirstOrDefault();
            
        }

        public Product SetProduct(Product product)
        {

            Product selectedProduct;

            if (product.ProductId == 0)
            {
                selectedProduct = new Product { ProductCode = product.ProductCode, ProductName = product.ProductName, ProductCost = product.ProductCost };

                context.Product.Add(selectedProduct);

            }
            else
            {
                selectedProduct = context.Product.Where(p => p.ProductId == product.ProductId).First();
            }
            
            context.SaveChanges();

            return selectedProduct;

        }

    }
}
