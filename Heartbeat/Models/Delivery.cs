using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class Delivery
    {
        public int DeliveryID { get; set; }
        public virtual Address Address { get; set; }
        public virtual Order Order { get; set; }

    }
}