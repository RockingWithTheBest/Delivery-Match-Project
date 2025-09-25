using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningController:ControllerBase
    {
        private readonly IEarnings earnings;
        public EarningController(IEarnings earnings)
        {
            this.earnings = earnings;
        }
        [HttpGet]
        [Route("Get-All-Earnings")]
        public IActionResult GetAll()
        {
            if ((earnings.GetAllEarnings()) == null)
            {
                return NotFound();
            }
            return Ok(earnings.GetAllEarnings());
        }

        [HttpGet]
        [Route("Get-Earnings-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = earnings.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Earnings")]
        public IActionResult AddEarnings(Earnings earningsRecord)
        {
            if (earningsRecord == null)
            {
                return BadRequest("The earnings record your provided is NULL");
            }
            else
            {
                earnings.AddEarningsRecord(earningsRecord);
                return Ok("Successfully Earnings record");
            }
        }

        [HttpPut]
        [Route("Editing-Earnings")]
        public IActionResult UpdateEarnings(int Id, Earnings earningsRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (earningsRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                earnings.UpdateEarningsRecord(Id, earningsRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Address-Record")]
        public IActionResult DeleteAddress(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                earnings.DeleteEarningsRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
