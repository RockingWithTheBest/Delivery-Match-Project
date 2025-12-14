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
                    Brand = "Ford",
                    Model = "Transit Luton",
                    Make_Year = new DateOnly(2021, 1, 1),
                    Color = "White",
                    License_Plate = "LU1 VAN",
                    Max_Weight = 1500.00m,
                    //Max_Volume = 12.00m,
                    Length = 620,  // 6.2m in cm
                    Width = 230,   // 2.3m in cm
                    Height = 250,  // 2.5m in cm
                    DriverId = 1
                },
                new Vehicle
                {
                    Id = 2,
                    Brand = "Mercedes-Benz",
                    Model = "Sprinter Luton",
                    Make_Year = new DateOnly(2020, 1, 1),
                    Color = "Silver",
                    License_Plate = "LU2 VAN",
                    Max_Weight = 1700.00m,
                    //Max_Volume = 13.50m,
                    Length = 650,  // 6.5m in cm
                    Width = 240,   // 2.4m in cm
                    Height = 260,  // 2.6m in cm
                    DriverId = 2
                },
                new Vehicle
                {
                    Id = 3,
                    Brand = "Iveco",
                    Model = "Daily Luton",
                    Make_Year = new DateOnly(2022, 1, 1),
                    Color = "Blue",
                    License_Plate = "LU3 VAN",
                    Max_Weight = 2000.00m,
                    //Max_Volume = 15.00m,
                    Length = 680,  // 6.8m in cm
                    Width = 240,   // 2.4m in cm
                    Height = 270,  // 2.7m in cm
                    DriverId = 3
                },
                new Vehicle
                {
                    Id = 4,
                    Brand = "Volkswagen",
                    Model = "Crafter Luton",
                    Make_Year = new DateOnly(2021, 1, 1),
                    Color = "Red",
                    License_Plate = "LU4 VAN",
                    Max_Weight = 1800.00m,
                    //Max_Volume = 14.00m,
                    Length = 660,  // 6.6m in cm
                    Width = 235,   // 2.35m in cm
                    Height = 265,  // 2.65m in cm
                    DriverId = 4
                },
                new Vehicle
                {
                    Id = 5,
                    Brand = "Renault",
                    Model = "Master Luton",
                    Make_Year = new DateOnly(2023, 1, 1),
                    Color = "Yellow",
                    License_Plate = "LU5 VAN",
                    Max_Weight = 1600.00m,
                    //Max_Volume = 12.50m,
                    Length = 630,  // 6.3m in cm
                    Width = 230,   // 2.3m in cm
                    Height = 255,  // 2.55m in cm
                    DriverId = 5
                },
                new Vehicle
                {
                    Id = 6,
                    Brand = "Peugeot",
                    Model = "Boxer Luton",
                    Make_Year = new DateOnly(2022, 1, 1),
                    Color = "Green",
                    License_Plate = "LU6 VAN",
                    Max_Weight = 1900.00m,
                    //Max_Volume = 14.50m,
                    Length = 670,  // 6.7m in cm
                    Width = 240,   // 2.4m in cm
                    Height = 270,  // 2.7m in cm
                    DriverId = 6
                }
            );
        }
    }
}