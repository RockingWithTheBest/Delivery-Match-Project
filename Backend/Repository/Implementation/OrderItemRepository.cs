using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementation
{
    public class OrderItemRepository : IOrderItems
    {
        private ApplicationDatabaseContext databaseContext;
        public OrderItemRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddOrderItemsRecord(OrderItems item)
        {
            int textVariable = -1;
            if (item == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.OrderItems.Add(item);
                databaseContext.SaveChanges();
                textVariable = item.Id;
            }
            return textVariable;
        }

        public int DeleteOrderItemRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.OrderItems.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.OrderItems.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<OrderItems> GetAllOrderItems()
        {
            return databaseContext.OrderItems.Include(d => d.OrderDimension).ToList();
        }

        public OrderItems GetSingleRecord(int Id)
        {
            return databaseContext.OrderItems.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateOrderItemsRecord(int Id, OrderItems record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                OrderItems updatedRecord = databaseContext.OrderItems.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.ItemName = record.ItemName;
                updatedRecord.Quantity = record.Quantity;
                //updatedRecord.WeightPerItem = record.WeightPerItem;
                updatedRecord.SpecialInstructions = record.SpecialInstructions;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}