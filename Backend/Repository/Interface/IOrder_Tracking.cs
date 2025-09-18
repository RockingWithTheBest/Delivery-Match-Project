using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IOrder_Tracking
    {
        IEnumerable<Order_Tracking> GetAllTrackings();
        Order_Tracking GetSingleRecord(int Id);
        int AddTrackingRecord(Order_Tracking tracking);
        int UpdateTrackingRecord(int Id, Order_Tracking tracking);
        int DeleteTrackingRecord(int Id);
    }
}
