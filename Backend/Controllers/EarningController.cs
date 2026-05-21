using Backend.DTOs;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarningController : ControllerBase
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
        [Route("get-list-of-earningsBy-driverId")]
        public IActionResult GetAllByDriverId(int DriverId)
        {
            if ((earnings.GetAListOfEarningsByDriverId(DriverId)) == null)
            {
                return BadRequest(
                    new
                    {
                        message = $"The Driver Id = {DriverId} you provided " +
                        $"does not have a list of orders."
                    });
            }
            return Ok(earnings.GetAListOfEarningsByDriverId(DriverId));
        }

        [HttpGet]
        [Route("popular-earnings-by-adding")]
        public void PopularEarningsByAdding()
        {
            earnings.PopularEarnings();
        }


        [HttpGet]
        [Route("getting-earning-divisions-by-driverId-orderplacements")]
        public IActionResult GetOrderEarningsDivisions(int DriverId)
        {
            var response = earnings.EarningDivionsByStatus(DriverId);
            if(response == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
