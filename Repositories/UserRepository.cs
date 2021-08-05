using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;


namespace OCM2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ProjectContext context = null;

        public UserRepository()
        {
            context = new ProjectContext();
        }

        public void AddConsignment(OcmConsignment consignment)
        {
            context.OcmConsignments.Add(consignment);
            context.SaveChanges();     
        }

        public object GetConsignment(int consignmentId)
        {
            OcmConsignment consignment = context.OcmConsignments.SingleOrDefault(s => s.ConsignmentId == consignmentId);
            if (consignment == null)
            {
                return "ConsignmentId is Invalid";
            }
            return consignment;
        }


        public string GetTrackingStatus(int consignmentId)
        {
            OcmTracking tracking = context.OcmTrackings.SingleOrDefault(s => s.ConsignmentId == consignmentId);

            if (tracking == null)
            {
                return "ConsignmentId is Invalid";
            }
            return $"ConsignmentId : {tracking.ConsignmentId}, Tracking Status : {tracking.Status}";
        }
    }
}
