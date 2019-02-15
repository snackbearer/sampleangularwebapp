using System;
using System.Collections.Generic;

namespace sampledata.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductCost { get; set; }
    }
}
