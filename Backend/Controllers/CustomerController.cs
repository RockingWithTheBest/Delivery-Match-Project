using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomer customer;
        public CustomerController(ICustomer customer)
        {
            this.customer = customer;
        }

        [HttpGet]
        [Route("Get-All-Customers")]
        public IActionResult GetAll()
        {
            if ((customer.GetAllCustomers() == null))
            {
                return NotFound();
            }
            return Ok(customer.GetAllCustomers());
        }

        [HttpGet]
        [Route("Get-AllOrderPlacedByCustomer-By-Id")]
        public IActionResult AllOrderPlacementsByCustomerId(int id)
        {
            var result = customer.GetAllOrderPlacementsByCustomerId(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Customer")]
        public IActionResult AddCustomer(Customer customerRecord)
        {
            if (customerRecord == null)
            {
                return BadRequest("The customer data record you provided is NULL");
            }
            else
            {
                customer.AddCustomerRecord(customerRecord);
                return Ok("Successfully Add Customer record");
            }
        }

        [HttpPut]
        [Route("Edit-Customer")]
        public IActionResult UpdateCustomer(int Id, Customer customerRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (customerRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid format your provided");
            }
            else
            {
                customer.UpdateCustomerRecord(Id, customerRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Customer-Record")]
        public IActionResult DeleteCustomer(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                customer.DeleteCustomerRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
