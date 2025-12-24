using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrderTracking
    {
        IEnumerable<OrderTracking> GetAllTrackings();
        OrderTracking GetSingleRecord(int Id);
        int AddTrackingRecord(OrderTracking tracking);
        int UpdateTrackingRecord(int Id, OrderTracking tracking);
        int DeleteTrackingRecord(int Id);
    }
}
