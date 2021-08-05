using System;
using System.Collections.Generic;

#nullable disable

namespace OCM2.Models
{
    public partial class OcmDeliveryExecutive
    {
        public OcmDeliveryExecutive()
        {
            OcmConsignments = new HashSet<OcmConsignment>();
        }

        public int DelId { get; set; }
        public string DelName { get; set; }
        public int? DelNumber { get; set; }

        public virtual ICollection<OcmConsignment> OcmConsignments { get; set; }
    }
}
