using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class OrderTrackingController:ControllerBase
    {
        private readonly IOrderTracking orderTracking;
        public OrderTrackingController(IOrderTracking orderTracking)
        {
            this.orderTracking = orderTracking;
        }

        [HttpGet]
        [Route("Get-All-Order-Tracking")]
        public IActionResult GetAll()
        {
            if ((orderTracking.GetAllTrackings()) == null)
            {
                return NotFound();
            }
            return Ok(orderTracking.GetAllTrackings());
        }

        [HttpGet]
        [Route("Get-Order-Tracking-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = orderTracking.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Order-Tracking")]
        public IActionResult AddOrderTracking(Order_Tracking trackinRecord)
        {
            if (trackinRecord == null)
            {
                return BadRequest("The order tracking record your provided is NULL");
            }
            else
            {
                orderTracking.AddTrackingRecord(trackinRecord);
                return Ok("Successfully added order tracking record");
            }
        }

        [HttpPut]
        [Route("Editing-Order-Tracking")]
        public IActionResult UpdateOrderTracking(int Id, Order_Tracking trackinRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (trackinRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                orderTracking.UpdateTrackingRecord(Id, trackinRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Order-Tracking-Record")]
        public IActionResult DeleteOrderTracking(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                orderTracking.DeleteTrackingRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
