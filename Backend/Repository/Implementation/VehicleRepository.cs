using Backend.DatabasContext;
using Backend.DTOs;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class VehicleRepository : IVehicle
    {
        private ApplicationDatabaseContext databaseContext;
        private readonly IHttpContextAccessor httpContextAccessor;
        public VehicleRepository(
            ApplicationDatabaseContext databaseContext, 
            IHttpContextAccessor httpContextAccessor)
        {
            this.databaseContext = databaseContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public int AddVehicleRecord(Vehicle vehicle)
        {
            int textVariable = -1;
            if (vehicle == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Vehicles.Add(vehicle);
                databaseContext.SaveChanges();
                textVariable = vehicle.Id;
            }
            return textVariable;
        }

        public int DeleteVehicleRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Vehicles.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Vehicles.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return databaseContext.Vehicles.ToList();
        }

        public Vehicle GetSingleRecord(int Id)
        {
            return databaseContext.Vehicles.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public Vehicle GetVehicleByDriverId(int DriverId)
        {
            return databaseContext.Vehicles.Where(temp => temp.DriverId == DriverId).FirstOrDefault();
        }

        public ImageResponseDto UploadImageInfo(ImageUploadDto uploadDto, int VehicleId)
        {

            // 4. Convert the uploaded file to byte array
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                uploadDto.Image.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }

            var vehicle = databaseContext.Vehicles.Where(i => i.Id == VehicleId).FirstOrDefault();
            vehicle.FileName = uploadDto.Image.FileName;
            vehicle.ContentType = uploadDto.Image.ContentType;
            vehicle.ImageData = imageData;
            vehicle.FileSize = uploadDto.Image.Length;
            vehicle.UploadedDate = DateTime.Now;
            vehicle.Description = uploadDto.Description;

            databaseContext.SaveChanges();

            // Get the current HTTP request context
            var request = httpContextAccessor.HttpContext?.Request;
            string baseUrl = $"{request?.Scheme}://{request?.Host}";
            // 7. Create response DTO
            var response = new ImageResponseDto
            {
                Id = vehicle.Id,
                FileName = vehicle.FileName,
                ContentType = vehicle.ContentType,
                FileSize = vehicle.FileSize,
                UploadedDate = vehicle.UploadedDate,
                Description = vehicle.Description,
                ImageBase64 = Convert.ToBase64String(vehicle.ImageData),
                ImageUrl = $"{request.Scheme}://{request.Host}/api/databaseimage/{vehicle.Id}"
            };

            return (response);
        }

        public string ClearImageData(int VehicleId)
        {
            try
            {
                var vehicle = databaseContext.Vehicles.Where(i => i.Id == VehicleId).FirstOrDefault();
                if (vehicle == null)
                    return "Image not found";

                // Delete old image if exists
                if (!string.IsNullOrEmpty(vehicle.FileSize.ToString()))
                {
                    vehicle.FileName = "";
                    vehicle.ContentType = "";
                    vehicle.ImageData = new Byte[0];
                    vehicle.FileSize = 0;
                    vehicle.UploadedDate = new DateTime();
                    vehicle.Description = "";
                    databaseContext.SaveChanges();
                }
                return "Image details successfully cleared";
            }
            catch (Exception ex)
            {
                return $"Internal server error, error message {ex.Message}";
            }
        }

        public ImageResponseDto GetImageData(int vehicleId)
        {
            var vehicle = databaseContext.Vehicles.Where(i => i.Id == vehicleId).FirstOrDefault();

            if (vehicle == null)
            {
                return null;
            }

            else
            {
                // Return image metadata (not the actual image data)
                var response = new ImageResponseDto
                {
                    Id = vehicle.Id,
                    FileName = vehicle.FileName,
                    ContentType = vehicle.ContentType,
                    FileSize = vehicle.FileSize,
                    UploadedDate = vehicle.UploadedDate,
                    Description = vehicle.Description,
                    ImageBase64 = Convert.ToBase64String(vehicle.ImageData),
                    ImageUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}/api/databaseimage/{vehicle.Id}"
                };
                return response;
            }
        }

        public ImageResponseDto GetImageDetail(int Id)
        {
            var vehicleImage = databaseContext.Vehicles.Where(i => i.Id == Id).FirstOrDefault();

            if (vehicleImage == null)
            {
                return null;
            }
            else
            {
                return new ImageResponseDto
                {
                    Id = vehicleImage.Id,
                    FileName = vehicleImage.FileName,
                    ContentType = vehicleImage.ContentType,
                    FileSize = vehicleImage.FileSize,
                    UploadedDate = vehicleImage.UploadedDate,
                    Description = vehicleImage.Description,
                    ImageBase64 = Convert.ToBase64String(vehicleImage.ImageData)
                };
            }
        }

        public int UpdateVehicleRecord(int Id, Vehicle record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Vehicle updatedRecord = databaseContext.Vehicles.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Brand = record.Brand;
                updatedRecord.MaxWeight = record.MaxWeight;
                updatedRecord.Model = record.Model;
                updatedRecord.MakeYear = record.MakeYear;
                updatedRecord.Color = record.Color;
                updatedRecord.LicensePlate = record.LicensePlate;
                updatedRecord.Length = record.Length;
                updatedRecord.Height = record.Height;
                updatedRecord.Width = record.Width;
                updatedRecord.FileName = record.FileName;
                updatedRecord.ContentType = record.ContentType;
                updatedRecord.ImageData = record.ImageData;
                updatedRecord.FileSize = record.FileSize;
                updatedRecord.UploadedDate = record.UploadedDate;
                updatedRecord.Description = record.Description;
                updatedRecord.DriverId = record.DriverId;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<ImageResponseDto> GetAllImageData()
        {
            var images = databaseContext.Vehicles
                    .OrderByDescending(i => i.UploadedDate)
                    .Select(i => new ImageResponseDto
                    {
                        Id = i.Id,
                        FileName = i.FileName,
                        ContentType = i.ContentType,
                        FileSize = i.FileSize,
                        UploadedDate = i.UploadedDate,
                        Description = i.Description,
                        ImageBase64 = Convert.ToBase64String(i.ImageData),
                        //ImageUrl = $"{Request.Scheme}://{Request.Host}/api/databaseimage/{i.Id}"
                    })
                    .ToList();

            return (images);
        }
    }
}