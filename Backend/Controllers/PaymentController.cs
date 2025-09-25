using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController:ControllerBase
    {
        private readonly IPayment payment;
        public PaymentController(IPayment payment)
        {
            this.payment = payment;
        }

        [HttpGet]
        [Route("Get-All-Payment")]
        public IActionResult GetAll()
        {
            if ((payment.GetAllPayments()) == null)
            {
                return NotFound();
            }
            return Ok(payment.GetAllPayments());
        }

        [HttpGet]
        [Route("Get-Payment-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = payment.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Payments")]
        public IActionResult AddPayment(Payment payRecord)
        {
            if (payRecord == null)
            {
                return BadRequest("The payRecord record your provided is NULL");
            }
            else
            {
                payment.AddPaymentRecord(payRecord);
                return Ok("Successfully add payRecord record");
            }
        }

        [HttpPut]
        [Route("Payment")]
        public IActionResult UpdatePayment(int Id, Payment payRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (payRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                payment.UpdatePaymentRecord(Id, payRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Payment-Record")]
        public IActionResult DeleteAddress(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                payment.DeletePaymentRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
