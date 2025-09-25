using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPlacementController:ControllerBase
    {
        private readonly IOrderPlacement orderPlacement;
        public OrderPlacementController(IOrderPlacement orderPlacement)
        {
            this.orderPlacement = orderPlacement;
        }

        [HttpGet]
        [Route("Get-All-OrderPlacements")]
        public IActionResult GetAll()
        {
            if ((orderPlacement.GetAllOrderPlacement()) == null)
            {
                return NotFound();
            }
            return Ok(orderPlacement.GetAllOrderPlacement());
        }

        [HttpGet]
        [Route("Get-Order-Single-Record-Placements-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = orderPlacement.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("Get-All-Order-Placement-Records-By-CustomerId")]
        public IActionResult AllOrderPlacementRecordsByCustomerId(int id)
        {
            var result = orderPlacement.GetAllOrderPlacementRecordsByCustomerId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("Get-All-Order-Placement-Records-By-DriverId")]
        public IActionResult AllOrderPlacementRecordsByDriverId(int id)
        {
            var result = orderPlacement.GetAllOrderPlacementRecordsByDriverId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-OrderPlacement")]
        public IActionResult AddOrderPlacement(OrderPlacement orderPlacementRecord)
        {
            if (orderPlacementRecord == null)
            {
                return BadRequest("The order record your provided is NULL");
            }
            else
            {
                orderPlacement.AddOrderPlacementRecord(orderPlacementRecord);
                return Ok("Successfully added order record");
            }
        }

        [HttpPut]
        [Route("Editing-Order-PlacementAddresses")]
        public IActionResult UpdateOrderPlacement(int Id, OrderPlacement orderPlacementRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (orderPlacementRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                orderPlacement.UpdateOrderPlacementRecord(Id, orderPlacementRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-OrderPlacment-Record")]
        public IActionResult DeleteOrderPlacement(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                orderPlacement.DeleteOrderPlacementRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
