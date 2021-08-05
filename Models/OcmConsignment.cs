using System;
using System.Collections.Generic;

#nullable disable

namespace OCM2.Models
{
    public partial class OcmConsignment
    {
        public OcmConsignment()
        {
            OcmTrackings = new HashSet<OcmTracking>();
        }

        public int ConsignmentId { get; set; }
        public string ConsignmentType { get; set; }
        public string SourceCity { get; set; }
        public string DestinationCity { get; set; }
        public DateTime? DateOfBooking { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string ConsignerName { get; set; }
        public string ConsigneName { get; set; }
        public int? UserId { get; set; }
        public int? DelId { get; set; }
        public double? Weight { get; set; }

        public virtual OcmDeliveryExecutive Del { get; set; }
        public virtual OcmUser User { get; set; }
        public virtual ICollection<OcmTracking> OcmTrackings { get; set; }
    }
}
