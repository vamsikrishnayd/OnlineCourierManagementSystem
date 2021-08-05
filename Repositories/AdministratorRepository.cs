using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;
using OCM2.Models;

namespace OCM2.Repositories
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private ProjectContext context = null;

        public AdministratorRepository()
        {
            context = new ProjectContext();
        }

        public void AssignDeliveryExecutive(int consignmentId, int dExecId)
        {
            var getExecutive = context.OcmConsignments.SingleOrDefault(s => s.ConsignmentId == consignmentId);
            getExecutive.DelId = dExecId;
            context.OcmConsignments.Update(getExecutive);
            context.SaveChanges();
            
          
            
        }

        public void CreateDeliveryExecutive(OcmDeliveryExecutive deliveryExecutive)
        {
            context.OcmDeliveryExecutives.Add(deliveryExecutive);
            context.SaveChanges();
        }

        public void CreateUser(OcmUser user)
        {
            context.OcmUsers.Add(user);
            context.SaveChanges();
        }

        public void DeleteDeliveryExecutive(int delExecId)
        {
            var getExecutive = context.OcmDeliveryExecutives.SingleOrDefault(s => s.DelId == delExecId);
            context.OcmDeliveryExecutives.Remove(getExecutive);
            context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var getUser = context.OcmUsers.SingleOrDefault(s => s.UserId == userId);
            context.OcmUsers.Remove(getUser);
            context.SaveChanges();
        }

        public object GetConsignment(int consignmentId)
        {

            var data = from con in context.OcmConsignments
                       join tracking in context.OcmTrackings
                       on con.ConsignmentId equals tracking.ConsignmentId
                       where con.ConsignmentId == consignmentId
                       select new { con.ConsignmentId,
                                    con.ConsignmentType,
                                    con.ConsigneName,
                                    con.ConsignerName,
                                    con.DateOfBooking,
                                    con.DelId ,
                                    con.SourceCity,
                                    con.DestinationCity,
                                    tracking.Status
                                  };

            
            if (data.Count() == 0)
            {
                var conId = from con in context.OcmConsignments
                         where con.ConsignmentId == consignmentId
                         select con;

                if(conId.Count() == 0)
                {
                    return "ConsignmentId is Invalid";
                }
            }
            return data;
            
        }

        public void UpdateDeliveryExecutive(OcmDeliveryExecutive deliveryExecutive)
        {
            context.OcmDeliveryExecutives.Update(deliveryExecutive);
            context.SaveChanges();
        }

        public void UpdateUser(OcmUser user)
        {
            context.OcmUsers.Update(user);
            context.SaveChanges();
        }
    }
}
