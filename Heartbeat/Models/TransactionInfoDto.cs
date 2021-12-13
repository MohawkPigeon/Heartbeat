using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class TransactionInfoDto
    {
        public int TransactionInfoDtoID { get; set; }
        public virtual Order Order { get; set; }
        public int vat { get; set; }
        public string feeType { get; set; }
        public int feeAmount { get; set; }
        public int cashBack { get; set; }
        public int recievedAmount { get; set; }
        public int amount { get; set; }
    }
}