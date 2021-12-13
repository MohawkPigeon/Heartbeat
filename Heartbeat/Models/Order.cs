using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string orderNumber { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Delivery> Deliveries { get; set; }
        public string orderDate { get; set; }
        public float totalPriceSumInclVat { get; set; }
        public int? storeCode { get; set; }
        public string currency { get; set; }
        public float? deductionPercentage { get; set; }
        public int? companyId { get; set; }

    }
}