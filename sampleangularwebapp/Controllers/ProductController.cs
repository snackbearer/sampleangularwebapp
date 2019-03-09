using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sampledata.Models;
using sampledatamodel.Models;

namespace sampleangularwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly cmsContext _context;
        

        public ProductController(cmsContext context)
        {
            _context = context;
            //this.configuration = Configuration;
            //this.connectionString = this.configuration.GetConnectionString("kevinangularcms");
        }

        // GET: api/Product
        [Authorize(Policy = "CanAccessProducts")]
        [HttpGet]
        public IEnumerable<iProduct> Get()
        {
            
            var data = new sampledata.Data.ProductsService(_context);

            return data.GetProducts();
            
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public iProduct Get(int id)
        {
            
            var data = new sampledata.Data.ProductsService(_context);

            var p = data.GetProduct(id);
            //var lst = new List<Product>();

            //lst.Add(new Product { ProductId = p.ProductId, ProductCode = p.ProductCode, ProductName = p.ProductName, ProductCost = p.ProductCost });
            return p; // lst.First();
            
        }

        

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] iProduct value)
        {
            
            var data = new sampledata.Data.ProductsService(_context);

            data.CreateProduct(new iProduct { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost });
            
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put([FromBody] Product value, int id)
        {
            var data = new sampledata.Data.ProductsService(_context);

            data.SetProduct(id, new iProduct { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost });

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var data = new sampledata.Data.ProductsService(_context);

            data.DeleteProduct(id);
        }
    }
}
