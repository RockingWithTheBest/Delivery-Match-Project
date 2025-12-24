using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrderItems
    {
        IEnumerable<OrderItems> GetAllOrderItems();
        OrderItems GetSingleRecord(int Id);
        int AddOrderItemsRecord(OrderItems items);
        int UpdateOrderItemsRecord(int Id, OrderItems items);
        int DeleteOrderItemRecord(int Id);
    }
}
