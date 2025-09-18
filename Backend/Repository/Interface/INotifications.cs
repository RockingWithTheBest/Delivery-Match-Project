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
    }
}
