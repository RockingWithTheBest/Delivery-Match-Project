using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IDriver
    {
        IEnumerable<Driver>GetAllDrivers();
        int CreateDriverRecord(Driver driver);
        int UpdateDriverRecord(int Id,Driver driver);
        int DeleteDriverRecord(int Id);
        IEnumerable<Order_Placement> GetAllOrdersPlacedByDriverID(int DriverId);
    }
}
