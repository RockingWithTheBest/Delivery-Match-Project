using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IVehicle
    {
        IEnumerable<Vehicle> GetAllVehicles();
        Vehicle GetSingleRecord(int Id);
        int AddAddressRecord(Vehicle vehicle);
        int UpdateVehicleRecord(int Id, Vehicle record);
        int DeleteVehicleRecord(int Id);
    }
}
