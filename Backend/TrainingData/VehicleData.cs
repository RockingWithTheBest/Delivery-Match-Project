using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class VehicleData : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData
            (
                new Vehicle
                {
                    Id = 1,
                    Brand = "Toyota",
                    Model = "Camry",
                    Make_Year = new DateOnly(2020, 1, 1),
                    Color = "Blue",
                    License_Plate = "ABC1234",
                    Max_Weight = 1500.00m,
                    Max_Volume = 3.50m,
                    DriverId = 1 
                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Honda",
                    Model = "Civic",
                    Make_Year = new DateOnly(2019, 1, 1),
                    Color = "Red",
                    License_Plate = "XYZ5678",
                    Max_Weight = 1400.00m,
                    Max_Volume = 3.20m,
                    DriverId = 2 
                },
                new Vehicle
                {
                    Id = 3,
                    Brand = "Ford",
                    Model = "F-150",
                    Make_Year = new DateOnly(2021, 1, 1),
                    Color = "Black",
                    License_Plate = "LMN9101",
                    Max_Weight = 2000.00m,
                    Max_Volume = 5.00m,
                    DriverId = 3 
                },
                new Vehicle
                {
                    Id = 4,
                    Brand = "Chevrolet",
                    Model = "Silverado",
                    Make_Year = new DateOnly(2022, 1, 1),
                    Color = "White",
                    License_Plate = "QRS2345",
                    Max_Weight = 2200.00m,
                    Max_Volume = 5.50m,
                    DriverId = 4 
                },
                new Vehicle
                {
                    Id = 5,
                    Brand = "Nissan",
                    Model = "Altima",
                    Make_Year = new DateOnly(2021, 1, 1),
                    Color = "Silver",
                    License_Plate = "TUV6789",
                    Max_Weight = 1600.00m,
                    Max_Volume = 3.80m,
                    DriverId = 5
                },
                new Vehicle
                {
                    Id = 6,
                    Brand = "Hyundai",
                    Model = "Elantra",
                    Make_Year = new DateOnly(2023, 1, 1),
                    Color = "Green",
                    License_Plate = "JKL3456",
                    Max_Weight = 1400.00m,
                    Max_Volume = 3.00m,
                    DriverId = 6
                }
            );
        }
    }
}
