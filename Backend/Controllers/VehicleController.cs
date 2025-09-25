using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController:ControllerBase
    {
        private readonly IVehicle vehicle;
        public VehicleController(IVehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        [HttpGet]
        [Route("Get-All-Vehcile")]
        public IActionResult GetAll()
        {
            if ((vehicle.GetAllVehicles()) == null)
            {
                return NotFound();
            }
            return Ok(vehicle.GetAllVehicles());
        }

        [HttpGet]
        [Route("Get-Vehcile-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = vehicle.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Vehcile")]
        public IActionResult AddVehicle(Vehicle vehicleRecord)
        {
            if (vehicleRecord == null)
            {
                return BadRequest("The Vehcile record your provided is NULL");
            }
            else
            {
                vehicle.AddVehicleRecord(vehicleRecord);
                return Ok("Successfully add Vehicle record");
            }
        }

        [HttpPut]
        [Route("Edit-Vehcile")]
        public IActionResult UpdateVehicle(int Id, Vehicle vehicleRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (vehicleRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                vehicle.UpdateVehicleRecord(Id, vehicleRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-A-Vehcile-Record")]
        public IActionResult DeleteVehicle(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                vehicle.DeleteVehicleRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
