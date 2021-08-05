using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;

namespace OCM2.Repositories
{
    public interface IDeliveryExecutiveRepository
    {
        List<OcmConsignment> GetOcmConsignments(int delExId);

        void ChangeStatus(int consignmentId, string status);
    }
}
