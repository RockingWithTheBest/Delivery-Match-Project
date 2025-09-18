using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class OrderItemRepository : IOrder_Items
    {
        private ApplicationDatabaseContext databaseContext;
        public OrderItemRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddOrderItemsRecord(Order_Items item)
        {
            int textVariable = -1;
            if (item.Id == 0)
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

        public IEnumerable<Order_Items> GetAllOrderItems()
        {
            return databaseContext.OrderItems.ToList();
        }

        public Order_Items GetSingleRecord(int Id)
        {
            return databaseContext.OrderItems.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateOrderItemsRecord(int Id, Order_Items record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Order_Items updatedRecord = databaseContext.OrderItems.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Item_Name = record.Item_Name;
                updatedRecord.Quantity = record.Quantity;
                updatedRecord.Weight_Per_Item = record.Weight_Per_Item;
                updatedRecord.Special_Instructions = record.Special_Instructions;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}