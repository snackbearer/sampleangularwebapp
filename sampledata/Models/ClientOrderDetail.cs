using System;
using System.Collections.Generic;

namespace sampledata.Models
{
    public partial class ClientOrderDetail
    {
        public int ClientOrderDetailId { get; set; }
        public int ClientOrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal DetailTotal { get; set; }
    }
}
