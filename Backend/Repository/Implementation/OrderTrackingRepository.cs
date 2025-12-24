using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class OrderTrackingRepository : IOrderTracking
    {
        private ApplicationDatabaseContext databaseContext;
        public OrderTrackingRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddTrackingRecord(OrderTracking tracking)
        {
            int textVariable = -1;
            if (tracking == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.OrderTrackings.Add(tracking);
                databaseContext.SaveChanges();
                textVariable = tracking.Id;
            }
            return textVariable;
        }
        public int DeleteTrackingRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.OrderPlacements.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.OrderPlacements.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<OrderTracking> GetAllTrackings()
        {
            return databaseContext.OrderTrackings.ToList();
        }

        public OrderTracking GetSingleRecord(int Id)
        {
            return databaseContext.OrderTrackings.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateTrackingRecord(int Id, OrderTracking tracking)
        {
            int testValue = -1;
            if (Id <= 0 || tracking == null)
            {
                return testValue;
            }
            else
            {
                OrderTracking updatedRecord = databaseContext.OrderTrackings.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Longitude = tracking.Longitude;
                updatedRecord.Latitude = tracking.Latitude;
                updatedRecord.Status = tracking.Status;
                updatedRecord.Notes = tracking.Notes;
                updatedRecord.TimeStamps = tracking.TimeStamps;
                databaseContext.SaveChanges();
                testValue = updatedRecord.Id;
            }
            return testValue;
        }
    }
}