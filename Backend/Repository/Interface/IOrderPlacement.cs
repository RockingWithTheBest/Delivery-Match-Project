using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrderPlacement
    {
        IEnumerable<OrderPlacement> GetAllOrderPlacement();
        IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByDriverId(int DriverId);
        IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByCustomerId(int CustomerId);
        OrderPlacement GetSingleRecord(int Id);
        int AddOrderPlacementRecord(OrderPlacement order_Placement);
        int UpdateOrderPlacementRecord(int Id, OrderPlacement record);
        int DeleteOrderPlacementRecord(int Id);

    }
}
