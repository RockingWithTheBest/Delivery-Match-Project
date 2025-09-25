using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController:ControllerBase
    {
        private readonly IOrderItems orderItems;
        public OrderItemsController(IOrderItems orderItems)
        {
            this.orderItems = orderItems;
        }

        [HttpGet]
        [Route("Get-All-OrderItems")]
        public IActionResult GetAll()
        {
            if ((orderItems.GetAllOrderItems()) == null)
            {
                return NotFound();
            }
            return Ok(orderItems.GetAllOrderItems());
        }

        [HttpGet]
        [Route("Get-OrderItems-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = orderItems.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-OrderItems")]
        public IActionResult AddOrderItems(Order_Items orderItemRecord)
        {
            if (orderItemRecord == null)
            {
                return BadRequest("The item record your provided is NULL");
            }
            else
            {
                orderItems.AddOrderItemsRecord(orderItemRecord);
                return Ok("Successfully added item record");
            }
        }

        [HttpPut]
        [Route("Editing-OrderItems")]
        public IActionResult UpdateOrderItems(int Id, Order_Items orderItemRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (orderItemRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                orderItems.UpdateOrderItemsRecord(Id, orderItemRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-OrderItems-Record")]
        public IActionResult DeleteOrderItems(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                orderItems.DeleteOrderItemRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
