using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;

namespace OCM2.Repositories
{
    public class DeliveryExecutiveRepository : IDeliveryExecutiveRepository
    {
        private ProjectContext context = null;

        public DeliveryExecutiveRepository()
        {
            context = new ProjectContext();
        }

        public void ChangeStatus(int consignmentId,string status)
        {
            OcmTracking tracking = context.OcmTrackings.SingleOrDefault(s => s.ConsignmentId == consignmentId);
            tracking.Status = status;
            context.OcmTrackings.Update(tracking);
            context.SaveChanges();
        }

        public List<OcmConsignment> GetOcmConsignments(int delExId)
        {
            var consignments = (from con in context.OcmConsignments
                                where con.DelId == delExId
                                select con).ToList();
            return consignments;
        }
    }
}
