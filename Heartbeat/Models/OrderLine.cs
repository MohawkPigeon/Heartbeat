using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public int unitPrice { get; set; }
        public double orderedQuantity { get; set; }
        public string priceId { get; set; }
        public string priceUoM { get; set; }
        public string quantityUoM { get; set; }
        public string itemGroup { get; set; }
        public double vatPercentage { get; set; }
        public int OrderLinePriceExclVat { get; set; }
        public int OrderLinePriceInclVat { get; set; }
        public int discountPercentage1 { get; set; }
        public int discountPercentage2 { get; set; }
    }
}