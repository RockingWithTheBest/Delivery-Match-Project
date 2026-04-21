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

        [HttpGet]
        [Route("Get-Notification-Placed-ByCustomer")]
        public IActionResult GetNotificationByCustomer(int CustomerId)
        {
            var response = notifications.GetAllNotificationsPlacedByCustomer(CustomerId);
            if(response == null)
            {
                return NotFound("Not notifications where placed by this Customer");
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpGet]
        [Route("Get-Notification-Placed-ByDriver")]
        public IActionResult GetNotificationByDriver(int DriverId)
        {
            var response = notifications.GetAllNotificationsPlacedByDriver(DriverId);
            if (response == null)
            {
                return NotFound("Not notifications where placed by this Customer");
            }
            else
            {
                return Ok(response);
            }
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

        [HttpPost]
        [Route("Get-Customers-With-CustomerIds")]
        public IActionResult GetCustomersWithCustomerIds(List<int> CustomerIds)
        {
            if(CustomerIds.Count == 0)
            {
                return NotFound("Their no notifications");
            }
            else
            {
                return Ok(notifications.GetCustomersWithIds(CustomerIds));
            }
        }

        [HttpPost]
        [Route("Notification-Made-On-A-Particular-Order-ByCustomer")]
        public IActionResult NotificationMadeOnOrderByCustomer(int CustomerId,
            int OrderPlacedId, Notification notify)
        {
            if(CustomerId <= 0 || OrderPlacedId <= 0 || notify == null)
            {
                return BadRequest("The notification cannot be created");
            }

            else
            {
                return Ok(notifications.NotificationMadeOnAParticularOrderByCustomer(CustomerId,
                    OrderPlacedId, notify));
            }
        }


        [HttpGet]
        [Route("Get-Notifications-Of-Particular-OrderPlaced")]
        public IActionResult GetNotificationsOfOrderPlaced(int OrderPlacementId)
        {
            if(OrderPlacementId <= 0)
            {
                return NotFound("The Notifications where not found");
            }
            else
            {
                return Ok(notifications.GetNotificationsOfParticularOrderPlaced(OrderPlacementId));
            }
        }

        [HttpPost]
        [Route("Send-Client-Message")]
        public IActionResult SendClientMessageRoute([FromBody] SendMessageRequest request)
        {
            try
            {
                var notification = notifications.SendClientMessage(
                    request.Id,
                    request.OrderId,
                    request.Message
                    );

                return Ok(notification);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost]
        [Route("Send-Driver-Message")]
        public IActionResult SendDriverMessage([FromBody] SendMessageRequest request)
        {
            try
            {
                var notification = notifications.SendDriverMessage(
                    request.Id,
                    request.OrderId,
                    request.Message
                    );
                
                return Ok(notification);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new {message = ex.Message});
            }
        }


        [HttpPut]
        [Route("Mark-Notification-Read")]
        public IActionResult MarkNotificationRead(int notificationId)
        {
            try
            {
                notifications.MarkNotificationAsRead(notificationId);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Mark-All-Notifications-Read")]
        public IActionResult MarkAllNotificationsRead(int customerId)
        {
            try
            {
                notifications.MarkAllAsRead(customerId);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        //int GetUnreadNotificationCount(int CustomerId);      
    }
}

public class SendMessageRequest
{
    public int Id {  get; set; }
    public int OrderId {  get; set; }
    public string Message { get; set; }
}