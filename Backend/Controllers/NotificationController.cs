using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController:ControllerBase
    {
        private readonly INotifications notifications;
        public NotificationController(INotifications notifications)
        {
            this.notifications = notifications;
        }

        [HttpGet]
        [Route("Get-All-Notification")]
        public IActionResult GetAll()
        {
            if ((notifications.GetAllNotifications()) == null)
            {
                return NotFound();
            }
            return Ok(notifications.GetAllNotifications());
        }

        [HttpGet]
        [Route("Get-Notification-By-Id")]
        public IActionResult GetById(int id)
        {
            var result = notifications.GetSingleRecord(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("Add-Notification")]
        public IActionResult AddNotification(Notification notificationRecord)
        {
            if (notificationRecord == null)
            {
                return BadRequest("The notification record your provided is NULL");
            }
            else
            {
                notifications.AddNotificationRecord(notificationRecord);
                return Ok("Successfully added notification record");
            }
        }

        [HttpPut]
        [Route("Editing-Notification")]
        public IActionResult UpdateNotification(int Id, Notification notificationRecord)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id your provided is LESS THAN OR EQUAL to Zero!");
            }
            else if (notificationRecord == null)
            {
                return BadRequest("Some of the new record values you provided are of an invalid format.");
            }
            else
            {
                notifications.UpdateNotificationRecord(Id, notificationRecord);
                return Ok("Successfully Updated the record");
            }
        }

        [HttpDelete]
        [Route("Delete-An-Notification-Record")]
        public IActionResult DeleteNotification(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest("The Id you provided is LESS THAN OR EQUAL to Zero");
            }
            else
            {
                notifications.DeleteNotificationRecord(Id);
                return Ok($"Record with ID = {Id} has been successfully deleted");
            }
        }

    }
}
