using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IVehicle
    {
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetSingleRecord(int Id);
        Vehicle GetVehicleByDriverId(int DriverId);
        int AddVehicleRecord(Vehicle vehicle);
        int UpdateVehicleRecord(int Id, Vehicle record);
        int DeleteVehicleRecord(int Id);
    }
}
