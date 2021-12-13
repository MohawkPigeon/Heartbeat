using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Heartbeat.Models
{
    public class Empty
    {
        public virtual ICollection<KeyDTO> KeyDTOs { get; set; }
    }
}