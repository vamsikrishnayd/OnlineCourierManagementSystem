using System;
using System.Collections.Generic;

#nullable disable

namespace OCM2.Models
{
    public partial class OcmUser
    {
        public OcmUser()
        {
            OcmConsignments = new HashSet<OcmConsignment>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }

        public virtual ICollection<OcmConsignment> OcmConsignments { get; set; }
    }
}
