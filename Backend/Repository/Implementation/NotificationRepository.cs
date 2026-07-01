using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class NotificationRepository : INotifications
    {
        private ApplicationDatabaseContext databaseContext;
        private ILogger<Notification> logger;
        public NotificationRepository(ApplicationDatabaseContext databaseContext, ILogger<Notification> logger)
        {
            this.databaseContext = databaseContext;
            this.logger = logger;
        }
        public int AddNotificationRecord(Notification notify)
        {
            int textVariable = -1;
            if (notify == null)
            {
                return textVariable;
            }
            else
            {
                Driver driver = databaseContext.Drivers.Where(i => i.UserId == notify.DriverId).FirstOrDefault();
                notify.DriverId = driver.Id;
                databaseContext.Notifications.Add(notify);
                databaseContext.SaveChanges();
                textVariable = notify.Id;
            }
            return textVariable;
        }

        public int DeleteNotificationRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Notifications.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Notifications.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Notification> GetAllNotifications()
        {
            return databaseContext.Notifications.ToList();
        }

        public IEnumerable<Notification> GetAllNotificationsPlacedByDriver(int DriverId)
        {
            var driverRecord = databaseContext
                .Drivers
                .Where(d=>d.Id == DriverId)
                .Include(i=>i.NotificationsPlaced)
                .FirstOrDefault();
            if (driverRecord == null)
            {
                return Enumerable.Empty<Notification>();
            }
            else
            {
                return driverRecord.NotificationsPlaced
                    .OrderByDescending(i => i.CreatedAt)
                    .ToList();
            }
        }

        private void AddedNotificationsByCustomer(int CustomerId)
        {
            var ordersPlacedByCustomer = databaseContext.OrderPlacements
                .Where(i => i.CustomerId == CustomerId)
                .ToList();

            foreach ( var o in ordersPlacedByCustomer)
            { 
                var driver = databaseContext.Drivers
                     .Include(i=>i.User)
                     .Where(i => i.Id == o.DriverId).FirstOrDefault();

                if (driver != null)
                {
                    var notification = new Notification
                    {
                        Type = "Order Message",
                        Message = o.Status,
                        DriverCommentry = driver.User.FirstName + " " + driver.User.LastName + " updated the order status",
                        CreatedAt = DateTime.Now,
                        IsRead = false,
                        CustomerId = o.CustomerId,
                        DriverId = driver.Id,
                        OrderPlacementId = o.Id
                    };

                    //Add to notifications table
                    databaseContext.Notifications.Add(notification);
                    databaseContext.SaveChanges();
                }
            }
        }
        public IEnumerable<Notification> GetAllNotificationsPlacedByCustomer(int CustomerId)
        {
            try
            {
               // AddedNotificationsByCustomer(CustomerId);
                var customerRecord = databaseContext
                    .Customers
                    .Where(d => d.Id == CustomerId)
                    .Include(i=>i.NotificationsPlaced)
                    .ThenInclude(n=>n.OrderPlacement)
                    .FirstOrDefault();
          
                if (customerRecord == null)
                {
                    return Enumerable.Empty<Notification>();
                }
                else
                {
                    return customerRecord.NotificationsPlaced
                        .OrderByDescending(i => i.CreatedAt)
                        .ToList();
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error getting notifications for customer {CustomerId}", CustomerId);
                return Enumerable.Empty<Notification>();
            }
        }

        public Notification NotificationMadeOnAParticularOrderByCustomer(int CustomerId, 
            int OrderPlacedId, Notification notify)
        {
            try
            {
                var order = databaseContext.OrderPlacements
                    .FirstOrDefault(o => o.Id == OrderPlacedId && o.CustomerId == CustomerId);
                var customer = databaseContext.Customers
                    .Where(i => i.Id == CustomerId)
                    .Include(i=>i.User)
                    .FirstOrDefault();

                if(order == null)
                {
                    throw new ArgumentException("Order not found or doesnt belong to this customer");
                }
            
                notify.CustomerId = CustomerId;
                notify.OrderPlacementId = OrderPlacedId;
                notify.CreatedAt = DateTime.Now;
                notify.IsRead = false;
                notify.Type = customer.User.FirstName+" "+customer.User.LastName;


                databaseContext.Notifications.Add(notify);
                databaseContext.SaveChanges();
                return notify;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error creating notification for customer {CustomerId}, order {OrderId}",
                    CustomerId, OrderPlacedId);
                throw;
            }
        }

        public OrderPlacement GetNotificationsOfParticularOrderPlaced(int OrderPlacementId)
        {
            var ordersPlaced = databaseContext.OrderPlacements
                .Where(i => i.Id == OrderPlacementId)
                .Include(o => o.NotificationsPlaced)
                .FirstOrDefault();

            if (ordersPlaced != null)
            {
                return ordersPlaced;
            }
            else 
                return new OrderPlacement();
            
        }

        public Notification SendDriverMessage(int CustomerId, int OrderId, string message)
        {
            try
            {            
                var order = databaseContext.OrderPlacements
                    .FirstOrDefault(o=>o.Id == OrderId && o.CustomerId == CustomerId);

                
                if (order == null)
                {
                    throw new ArgumentException("Order not found");
         
                }
                else
                {
                    var customer = databaseContext.Customers
                        .Where(i => i.Id == CustomerId)
                        .Include(i => i.User)
                        .FirstOrDefault();

                    var notification = new Notification
                    {
                        Type = "customer message",
                        Message = message,
                        IsRead = false,
                        CustomerId = CustomerId,
                        DriverId = (int)order.DriverId,
                        OrderPlacementId = OrderId,
                        CreatedAt = DateTime.Now,
                        DriverCommentry = "You sent a message to the driver regarding this order"
                    };
                    databaseContext.Notifications.Add(notification);
                    databaseContext.SaveChanges();

                    return notification;
                } 
            }
            catch (Exception ex){
                var messageError = new
                {
                    Error = ex.Message,
                    Message = "Debug the method to find the error"
                };
                Console.WriteLine(messageError);    
            }
            return new Notification();
        }

        public Notification SendClientMessage(int DriverId, int OrderId, string message)
        {
            try
            {
                var order = databaseContext.OrderPlacements
                    .FirstOrDefault(o => o.Id == OrderId && o.DriverId == DriverId);


                if (order == null)
                {
                    throw new ArgumentException("Order not found");

                }
                else
                {
                    var notification = new Notification
                    {
                        Type = "driver message",
                        Message = message,
                        IsRead = false,
                        CustomerId = order.CustomerId,
                        DriverId = (int)order.DriverId,
                        OrderPlacementId = OrderId,
                        CreatedAt = DateTime.Now,
                        DriverCommentry = "You sent a message regarding this order"
                    };
                    databaseContext.Notifications.Add(notification);
                    databaseContext.SaveChanges();

                    return notification;
                }
            }
            catch (Exception ex)
            {
                var messageError = new
                {
                    Error = ex.Message,
                    Message = "Debug the method to find the error"
                };
                Console.WriteLine(messageError);
            }
            return new Notification();
        }

        public int GetUnreadNotificationCount(int CustomerId)
        {
            return databaseContext.Notifications
                .Where(n => n.CustomerId == CustomerId && n.IsRead == false)
                .ToList()
                .Count();
        }

        public void MarkAllAsRead(int CustomerId)
        {
            var unreadNotifications = databaseContext.Notifications
                .Where(n => n.CustomerId == CustomerId && n.IsRead == false)
                .ToList();

            foreach(var notification in unreadNotifications)
            {
                notification.IsRead = true;
            }

            databaseContext.SaveChanges();
        }

        public void MarkNotificationAsRead(int notificationId)
        {
            try
            {
                var notify = databaseContext.Notifications.Where(i => i.Id == notificationId).FirstOrDefault();
                notify.IsRead = true;
                databaseContext.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogError($"Unable to mark all notifications as read {ex.Message}");
            }
        }

        public IEnumerable<Customer> GetCustomersWithIds(List<int> CustomersList)
        {
            return databaseContext
                .Customers
                .Where(i => CustomersList.Contains(i.Id)).ToList();
        }
        public Notification GetSingleRecord(int Id)
        {
            return databaseContext.Notifications.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateNotificationRecord(int Id, Notification notify)
        {
            int testValue = -1;
            if (Id <= 0 || notify == null)
            {
                return testValue;
            }
            else
            {
                Notification updatedRecord = databaseContext.Notifications.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Type = notify.Type;
                //updatedRecord.Title = notify.Title;
                updatedRecord.Message = notify.Message;
                updatedRecord.IsRead = notify.IsRead;
                updatedRecord.DriverCommentry = notify.DriverCommentry;
                updatedRecord.CreatedAt = notify.CreatedAt;
                updatedRecord.IsRead = notify.IsRead;
                updatedRecord.CustomerId = notify.CustomerId;
                updatedRecord.DriverId = notify.DriverId;
                updatedRecord.OrderPlacementId = notify.OrderPlacementId;
                databaseContext.SaveChanges();
                testValue = updatedRecord.Id;
            }
            return testValue;
        }
    }
}
