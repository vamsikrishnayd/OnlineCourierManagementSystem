using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;

namespace OCM2.Repositories
{
    public interface IUserRepository
    {
        void AddConsignment(OcmConsignment consignment);
        object GetConsignment(int consignmentId);
        string GetTrackingStatus(int consignmentId);
    }
}
