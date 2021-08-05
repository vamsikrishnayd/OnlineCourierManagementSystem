using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;

namespace OCM2.Repositories
{
    public interface IAdministratorRepository
    {
        void CreateUser(OcmUser user);
        void UpdateUser(OcmUser user);
        void DeleteUser(int userId);
        void CreateDeliveryExecutive(OcmDeliveryExecutive deliveryExecutive);
        void UpdateDeliveryExecutive(OcmDeliveryExecutive deliveryExecutive);
        void DeleteDeliveryExecutive(int delExecId);
        object GetConsignment(int consignmentId);
        void AssignDeliveryExecutive(int consignmentId, int dExecId);

    }
}
