using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class NotificationRepository : INotifications
    {
        private ApplicationDatabaseContext databaseContext;
        public NotificationRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
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
                updatedRecord.Title = notify.Title;
                updatedRecord.Message = notify.Message;
                updatedRecord.Is_Read = notify.Is_Read;
                databaseContext.SaveChanges();
                testValue = updatedRecord.Id;
            }
            return testValue;
        }
    }
}
