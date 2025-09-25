using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    public class RouteController:ControllerBase
    {
        private readonly Repository.Interface.IRoute route;
        public RouteController(IRoute route)
        {
            this.route = route;
        }

        [HttpGet]
        [Route("Get-All-Route")]
        public IActionResult GetAll()
        {
            if ((route.GetAllRoutes()) == null)
            {
                return NotFound();
            }
            return Ok(route.GetAllRoutes());
        }

        [HttpGet]
        [Route("Get-Route-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = route.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Route")]
        public IActionResult AddRoute(Models.Route routeRecord)
        {
            if (routeRecord == null)
            {
                return BadRequest("The route record your provided is NULL");
            }
            else
            {
                route.AddRoutesRecord(routeRecord);
                return Ok("Successfully added router record");
            }
        }

        [HttpPut]
        [Route("Editing_Route")]
        public IActionResult UpdateRoute(int Id, Models.Route routeRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (routeRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid formatyour provided");
            }
            else
            {
                route.UpdateRoutesRecord(Id, routeRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-A-Route-Record")]
        public IActionResult DeleteRoute(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                route.DeleteRoutesRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }
    }
}
