using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OCM2.Repositories;
using OCM2.Models;

namespace OCM2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private IAdministratorRepository repository;

        public AdministratorController(IAdministratorRepository repository)
        {
            this.repository = repository;
        }

        // Action Methods

        // Getting the Consignment using consignmentId

        [HttpGet]
        [Route("Get Consignment/{consignmentId}")]
        public object GetConsignment(int consignmentId)
        {
            return repository.GetConsignment(consignmentId);
        }

        // Assigning the Delivery Executive to Consignment

        [HttpPut]
        [Route("Assign DeliveryExcutive/{consignmentId}/{dExecId}")]
        public string AssignDeliveryExecutive(int consignmentId, int dExecId)
        {
            try
            {
                repository.AssignDeliveryExecutive(consignmentId, dExecId);
                return "DeliveryExcutive successfully assigned";
            }
            catch
            {
                return "Enter valid Details";
            }
            
        }

        // Creating the New User

        [HttpPost]
        [Route("Creating User")]
        public string CreateUser(OcmUser user)
        {
            try
            {
                repository.CreateUser(user);
                return "User Added";
            }
            catch
            {
                return "User Already Existed";
            }
            
        }

        // Modifying the User

        [HttpPut]
        [Route("Updating User")]
        public string UpdateUser(OcmUser user)
        {
            
            try
            {
                repository.UpdateUser(user);
                return "User Updated";
            }
            catch
            {
                return "UserId is Invaild";
            }
        }

        // Deleting the User

        [HttpDelete]
        [Route("Deleting User/{userId}")]
        public string DeleteUser(int userId)
        {
            try
            {
                repository.DeleteUser(userId);
                return "User Deleted";
            }
            catch
            {
                return "UserId is Invaild";
            }
        }

        // Creating the Delivery Executive

        [HttpPost]
        [Route("Creating DeliveryExecutive")]
        public string CreateDeliveryExecutive(OcmDeliveryExecutive DeliveryExecutive)
        {
            
            try
            {
                repository.CreateDeliveryExecutive(DeliveryExecutive);
                return "DeliveryExecutive Added";
            }
            catch
            {
                return "DeliveryExecutive Already Existed";
            }
        }

        // Modifying the Delivery Executive

        [HttpPut]
        [Route("Updating DeliveryExecutive")]
        public string UpdateDeliveryExecutive(OcmDeliveryExecutive DeliveryExecutive)
        {
            
            try
            {
                repository.UpdateDeliveryExecutive(DeliveryExecutive);
                return "DeliveryExecutive Updated";
            }
            catch
            {
                return "DeliveryExecutiveId is Invalid";
            }
        }

        // Deleting the Delivery Executive

        [HttpDelete]
        [Route("Deleting DeliveryExecutive/{dExecId}")]
        public string DeleteDeliveryExecutive(int dExecId)
        {
            
            try
            {
                repository.DeleteDeliveryExecutive(dExecId);
                return "DeliveryExecutive Deleted";
            }
            catch
            {
                return "DeliveryExecutiveId is Invalid";
            }
        }
    }
}