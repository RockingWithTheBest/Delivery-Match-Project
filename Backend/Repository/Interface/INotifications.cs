using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface INotifications
    {
        IEnumerable<Notification> GetAllNotifications();
        Notification GetSingleRecord(int Id);
        int AddNotificationRecord(Notification notify);
        int UpdateNotificationRecord(int Id, Notification notify);
        int DeleteNotificationRecord(int Id);
        IEnumerable<Notification> GetAllNotificationsPlacedByDriver(int DriverId);
        IEnumerable<Notification> GetAllNotificationsPlacedByCustomer(int CustomerId);
        IEnumerable<Customer> GetCustomersWithIds(List<int> CustomersList);
    }
}
