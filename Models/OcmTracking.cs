using System;
using System.Collections.Generic;

#nullable disable

namespace OCM2.Models
{
    public partial class OcmTracking
    {
        public int TrackingId { get; set; }
        public string Status { get; set; }
        public int? ConsignmentId { get; set; }

        public virtual OcmConsignment Consignment { get; set; }
    }
}
