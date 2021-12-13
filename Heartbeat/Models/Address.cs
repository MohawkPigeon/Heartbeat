using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int? streetNumber { get; set; }
        public string addressXCoordinate { get; set; }
        public string addressYCoordinate { get; set; }

    }
}