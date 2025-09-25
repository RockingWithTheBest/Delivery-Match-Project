using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController:ControllerBase
    {
        private readonly IDriver driver;
        public DriverController(IDriver driver)
        {
            this.driver = driver;
        }

        [HttpGet]
        [Route("Get-All-Drivers")]
        public IActionResult GetAll()
        {
            if ((driver.GetAllDrivers() == null))
            {
                return NotFound();
            }
            return Ok(driver.GetAllDrivers());
        }

        [HttpGet]
        [Route("Get-All-Orders-Placed-By-Driver-ID")]
        public IActionResult AllOrdersPlacedByDriverID(int id)
        {
            var result = driver.GetAllOrdersPlacedByDriverID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Driver")]
        public IActionResult AddDriver(Driver driverRecord)
        {
            if (driverRecord == null)
            {
                return BadRequest("The driver record your provided is NULL");
            }
            else
            {
                driver.CreateDriverRecord(driverRecord);
                return Ok("Successfully Driver record");
            }
        }

        [HttpPut]
        [Route("Editing-Driver")]
        public IActionResult UpdateDriver(int Id, Driver driverRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (driverRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                driver.UpdateDriverRecord(Id, driverRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-A-Driver-Record")]
        public IActionResult DeleteDriver(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                driver.DeleteDriverRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
