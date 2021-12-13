using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public enum PrintingStatus
    {
        NOT_STARTED, IN_PROGRESS, SUCCEEDED, FAILED, WAITING_TO_PRINT, PRINTED, PRINTING_ERROR
    }
    public class Invoice
    {
        public int InvoiceID{ get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public PrintingStatus? PrintingStatus  { get; set; }

    }
}