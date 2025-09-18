using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrder_Placement
    {
        IEnumerable<Order_Placement> GetAllOrderPlacement();
        IEnumerable<Order_Placement> GetAllOrderPlacementRecordsByDriverId(int DriverId);
        IEnumerable<Order_Placement> GetAllOrderPlacementRecordsByCustomerId(int CustomerId);
        Order_Placement GetSingleRecord(int Id);
        int AddOrderPlacementRecord(Order_Placement order_Placement);
        int UpdateOrderPlacementRecord(int Id, Order_Placement record);
        int DeleteOrderPlacementRecord(int Id);

    }
}
