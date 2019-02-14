using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sampleangularwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListController : ControllerBase
    {
        [HttpGet("[action]")]
        public IEnumerable<ProductItem> ProductList()
        {
            var rng = new Random();
            var productListItems = Enumerable.Range(1, 9).Select(index => new ProductItem
            {
                ProductID = index,
                ProductCode = "Code" + index.ToString(),
                ProductName = "Name" + index.ToString()
            });

            return productListItems;
        }

        public class ProductItem
        {
            public int ProductID { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            
        }
    }
}