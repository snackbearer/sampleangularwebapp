using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampledata.Models;

namespace sampleangularwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        // GET: api/Product
        [Authorize(Policy = "CanAccessProducts")]
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            
            var data = new sampledata.Data.Products();

            return data.GetProducts();
            
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            
            var data = new sampledata.Data.Products();

            var p = data.GetProduct(id);
            //var lst = new List<Product>();

            //lst.Add(new Product { ProductId = p.ProductId, ProductCode = p.ProductCode, ProductName = p.ProductName, ProductCost = p.ProductCost });
            return p; // lst.First();
            
        }

        

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            
            var data = new sampledata.Data.Products();

            data.SetProduct(new sampledata.Models.Product { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost });
            
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
