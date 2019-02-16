using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sampleangularwebapp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductCost { get; set; }
    }
}
