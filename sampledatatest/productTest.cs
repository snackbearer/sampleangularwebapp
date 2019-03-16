using Microsoft.EntityFrameworkCore;
using sampledata.Models;
using System;
using Xunit;
using System.Linq;
using sampledatamodel.Models;

namespace sampledatatest
{
    
    public class productTest : IDisposable
    {
        
        cmsContext _context;
        
        public productTest()
        {
            DbContextOptions<cmsContext> options;
            var builder = new DbContextOptionsBuilder<cmsContext>();
            //builder.UseSqlServer(connectionstr);
            builder.UseInMemoryDatabase(databaseName: "kevsDatabase");
            options = builder.Options;
            
            _context = new cmsContext(options);

            InitialiseData();

        }


        [Fact]
        public void HasProducts()
        {
            var data = new sampledata.Data.ProductsService(_context);

            var products = data.GetProducts();

            Assert.NotEmpty(products);

        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void HasProduct(int id)
        {
            var data = new sampledata.Data.ProductsService(_context);

            var product = data.GetProduct(id);

            Assert.NotNull(product);

        }
        [Theory]
        [InlineData(1,"REDHAT","Red Hat",34) ]
        [InlineData(2,"BLUEHAT", "Blue Hat", 55)]
        [InlineData(3, "GREENSHOES", "Green Shoes", 100)]
        public void AddProduct(int id, string Code, string Name, decimal Cost)
        {
            var ExpiryDate = DateTime.Now.AddMonths(5);
                
            var data = new sampledata.Data.ProductsService(_context);

            var newProduct = data.CreateProduct(new IProduct { ProductId = id, ProductCode = Code, ProductName = Name, ProductCost = Cost, ProductExpiryDate = ExpiryDate });

            Assert.NotNull(newProduct);

        }

        private void InitialiseData()
        {

            if (_context.Product.Count() > 0)
                return;
            
            _context.Product.Add(new Product { ProductId = 7, ProductCode = "PRODUCT1", ProductName = "Product Name1", ProductCost = 1 });
            _context.Product.Add(new Product { ProductId = 8, ProductCode = "PRODUCT2", ProductName = "Product Name2", ProductCost = 1 });
            _context.Product.Add(new Product { ProductId = 9, ProductCode = "PRODUCT3", ProductName = "Product Name3", ProductCost = 1 });
            _context.SaveChanges();
            var productList = _context.Product.ToList();
            
        }

        public void Dispose()
        {
            _context = null;
        }
    }
}
