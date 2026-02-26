using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

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
        ImageResponseDto UploadImageInfo(ImageUploadDto uploadDto, int VehicleId);
        string ClearImageData(int VehicleId);
        ImageResponseDto GetImageData(int vehicleId);
        ImageResponseDto GetImageDetail(int Id);
        IEnumerable<ImageResponseDto> GetAllImageData();
    }
}
