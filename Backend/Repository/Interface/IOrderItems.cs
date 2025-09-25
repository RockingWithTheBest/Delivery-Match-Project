using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrderItems
    {
        IEnumerable<Order_Items> GetAllOrderItems();
        Order_Items GetSingleRecord(int Id);
        int AddOrderItemsRecord(Order_Items items);
        int UpdateOrderItemsRecord(int Id, Order_Items items);
        int DeleteOrderItemRecord(int Id);
    }
}
