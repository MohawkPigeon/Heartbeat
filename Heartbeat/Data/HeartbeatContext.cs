using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Heartbeat.Data
{
    public class HeartbeatContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public HeartbeatContext() : base("name=HeartbeatContext")
        {
        }

        public System.Data.Entity.DbSet<Heartbeat.Models.Address> Addresses { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.Delivery> Deliveries { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.TransactionInfoDto> TransactionInfoDtoes { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.OrderLine> OrderLines { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Heartbeat.Models.Key> Keys { get; set; }
    }
}
