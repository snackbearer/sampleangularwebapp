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
        public IEnumerable<IProduct> Get()
        {

            using (var data = new sampledata.Data.ProductsService(_context)) { 

                return data.GetProducts();

            }

        }

        // GET: api/Product/5
        [Authorize(Policy = "CanAccessProducts")]
        [HttpGet("{id}", Name = "Get")]
        public IProduct Get(int id)
        {

            using (var data = new sampledata.Data.ProductsService(_context)) { 
                return data.GetProduct(id);
            }
            
        }
        
        // POST: api/Product
        [Authorize(Policy = "CanAccessProducts")]
        [HttpPost]
        public void Post([FromBody] IProduct value)
        {

            using (var data = new sampledata.Data.ProductsService(_context)) {

                data.CreateProduct(new IProduct { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost, ProductExpiryDate = value.ProductExpiryDate });

            }
        }

        // PUT: api/Product/5
        [Authorize(Policy = "CanAccessProducts")]
        [HttpPut("{id}")]
        public void Put([FromBody] Product value, int id)
        {
            using (var data = new sampledata.Data.ProductsService(_context)) { 

                data.SetProduct(id, new IProduct { ProductId = value.ProductId, ProductCode = value.ProductCode, ProductName = value.ProductName, ProductCost = value.ProductCost, ProductExpiryDate = value.ProductExpiryDate });

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "CanAccessProducts")]
        public void Delete(int id)
        {
            using (var data = new sampledata.Data.ProductsService(_context)) { 
                data.DeleteProduct(id);
            }
        }
    }
}
