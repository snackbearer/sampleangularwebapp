using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampleangularwebapp.Models;

namespace sampleangularwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return null;
            /*
            var data = new sampledata.Data.Products();

            return data.GetProducts().Select(p=>
                new Product { ProductId = p.ProductId , ProductCode = p.ProductCode , ProductName = p.ProductName , ProductCost = p.ProductCost  });
            */
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return null;
            /*
            var data = new sampledata.Data.Products();

            var p = data.GetProduct(id);

            return new Product { ProductId = p.ProductId, ProductCode = p.ProductCode , ProductName = p.ProductName , ProductCost = p.ProductCost  };
            */
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            /*
            var data = new sampledata.Data.Products();

            data.SetProduct(new sampledata.Models.Product { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost });
            */
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
