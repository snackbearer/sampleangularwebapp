using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Models
{
    public partial class iProduct
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductCost { get; set; }
    }
}
