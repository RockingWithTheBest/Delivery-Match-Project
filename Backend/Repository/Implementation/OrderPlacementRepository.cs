using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class OrderPLacementRepository : IOrder_Placement
    {
        private ApplicationDatabaseContext databaseContext;
        public OrderPLacementRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddOrderPlacementRecord(Order_Placement order_Placement)
        {
            int textVariable = -1;
            if (order_Placement.Id == 0)
            {
                return textVariable;
            }
            else
            {
                databaseContext.OrderPlacements.Add(order_Placement);
                databaseContext.SaveChanges();
                textVariable = order_Placement.Id;
            }
            return textVariable;
        }

        public int DeleteOrderPlacementRecord(int Id)
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

        public IEnumerable<Order_Placement> GetAllOrderPlacement()
        {
            return databaseContext.OrderPlacements.ToList();
        }
        public IEnumerable<Order_Placement> GetAllOrderPlacementRecordsByCustomerId(int CustomerId)
        {
            return databaseContext.OrderPlacements.Where(x=>x.Id==CustomerId).ToList();
        }

        public IEnumerable<Order_Placement> GetAllOrderPlacementRecordsByDriverId(int DriverId)
        {
            return databaseContext.OrderPlacements.Where(x => x.Id == DriverId).ToList();
        }
        public Order_Placement GetSingleRecord(int Id)
        {
            return databaseContext.OrderPlacements.Where(temp => temp.Id == Id).FirstOrDefault();
        }
        public int UpdateOrderPlacementRecord(int Id, Order_Placement record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Order_Placement updatedRecord = databaseContext.OrderPlacements.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Pick_Up_Contact = record.Pick_Up_Contact;
                updatedRecord.Delivery_Contact = record.Delivery_Contact;
                updatedRecord.Delivery_Up_Address = record.Delivery_Up_Address;
                updatedRecord.Weight = record.Weight;
                updatedRecord.Volume = record.Volume;
                updatedRecord.Price = record.Price;
                updatedRecord.Description = record.Description;
                updatedRecord.Distance = record.Distance;
                updatedRecord.Created_At = record.Created_At;
                updatedRecord.Scheduled_At = record.Scheduled_At;
                updatedRecord.Completed_On = record.Completed_On;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}
