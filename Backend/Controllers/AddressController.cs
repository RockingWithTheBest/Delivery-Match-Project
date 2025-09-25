using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private  IAddress address;
        public AddressController(IAddress address)
        {
            this.address = address;
        }

        [HttpGet]
        [Route("Get-All-Addresses")]
        public IActionResult GetAll()
        {
            if((address.GetAllAddresses()) == null)
            {
                return NotFound();
            }
            return Ok(address.GetAllAddresses());
        }

        [HttpGet]
        [Route("Get-Addresses-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = address.GetSingleRecord(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Addresses")]
        public IActionResult AddAddress(Address addressRecord)
        {
            if(addressRecord == null)
            {
                return BadRequest("The address record your provided is NULL");
            }
            else
            {
                address.AddAddressRecord(addressRecord);
                return Ok("Successfully Address record");
            }
        }

        [HttpPut]
        [Route("Editing_Addresses")]
        public IActionResult UpdateAddress(int Id, Address addressRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if(addressRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                address.UpdateAddressRecord(Id, addressRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Address-Record")]
        public IActionResult DeleteAddress(int Id)
        {
            if(Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                address.DeleteAddressRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
