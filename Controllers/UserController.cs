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
    public class UserController : ControllerBase
    {
        private IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // User booking the Consignment
         
         [HttpPost]
        [Route("Adding Consignment")]

         public string AddConsignment(OcmConsignment consignment)
         {
             repository.AddConsignment(consignment);
             return $" Consigner : {consignment.ConsignerName}, Consignee : {consignment.ConsigneName}, Source City : {consignment.SourceCity}, Destination City : {consignment.DestinationCity}, Total Charges : ₹{(consignment.Weight) * 15}";
         }

        // User is searching the Consignment by the consignmentId

        [HttpGet]
        [Route("Get Consignment/{consignmentId}")]
        public object GetConsignment(int consignmentId)
        {
            return repository.GetConsignment(consignmentId);   
        }

        // To know the Tracking Status

        [HttpGet]
        [Route("Tracking Status/{consignmentId}")]
        public string GetTrackingStatus(int consignmentId)
        { 
            return repository.GetTrackingStatus(consignmentId);
        }
    }
}
