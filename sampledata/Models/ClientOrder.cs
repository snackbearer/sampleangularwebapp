using System;
using System.Collections.Generic;

namespace sampledata.Models
{
    public partial class ClientOrder
    {
        public int ClientOrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal? OrderTotal { get; set; }
    }
}
