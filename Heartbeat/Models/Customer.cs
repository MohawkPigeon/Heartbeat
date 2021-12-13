using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string CustomerType { get; set; }
        public string Requisition { get; set; }
    }
}