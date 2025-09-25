using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  readonly IUser user;
        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpGet]
        [Route("Get-All-Users")]
        public IActionResult GetAll()
        {
            if((user.GetAllUsers()) == null)
            {
                return NotFound();
            }
            return Ok(user.GetAllUsers());
        }

        [HttpGet]
        [Route("Get-Users-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = user.GetSingleRecord(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Users")]
        public IActionResult AddAddress(User userRecord)
        {
            if(userRecord == null)
            {
                return BadRequest("The user record your provided is NULL");
            }
            var i = user.AddUserRecord(userRecord);
            if(i==-1)
            {
                return BadRequest($"Not Successfully Added {i}");
            }
            return Ok("Added"+userRecord);
        }

        [HttpPut]
        [Route("Editing-User")]
        public IActionResult UpdateUser(int Id, User userRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if(userRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid format your provided");
            }
            else
            {
                user.UpdateUserRecord(Id, userRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-User-Record")]
        public IActionResult DeleteAddress(int Id)
        {
            if(Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                user.DeleteUserRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
