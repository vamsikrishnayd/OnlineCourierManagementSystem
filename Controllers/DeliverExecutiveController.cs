using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Models;
using OCM2.Repositories;

namespace OCM2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliverExecutiveController : ControllerBase
    {
        private IDeliveryExecutiveRepository repository;

        public DeliverExecutiveController(IDeliveryExecutiveRepository repository)
        {
            this.repository = repository;
        }

        // Delivery Executive is changing the tracking status of the Consignment

        [HttpPut]
        [Route("Changing Tracking Status/{consignmentId}/{status}")]
        public string ChangeStatus(int consignmentId, string status)
        {
            ProjectContext ctx = new ProjectContext();
            OcmTracking tracking = ctx.OcmTrackings.SingleOrDefault(s => s.ConsignmentId == consignmentId);
            if (tracking == null)
            {
                return "ConsignmentId is Invalid";
            }
            else
            {
                repository.ChangeStatus(consignmentId, status);
                return "Tracking Status is successfully updated";
            }
        }

        // View the Consignments assigned to Delivery Executive by the Admin

        [HttpGet]
        [Route("Consignment/{delId}")]
        public List<OcmConsignment> GetOcmConsignments(int delId)
        {
            return repository.GetOcmConsignments(delId);
        }
    }
}
