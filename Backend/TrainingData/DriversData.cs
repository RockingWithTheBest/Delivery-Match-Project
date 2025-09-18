using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class DriversData : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasData
            (
                 new Driver
                 {
                     Id = 1,
                     Drivers_License = "DL123456789",
                     License_Expiry = new DateOnly(2025, 12, 31),
                     Is_Verified = true,
                     Is_Available = true,
                     Rating = "4.8",
                     Completion_Rate = "95%",
                     Total_Earnings = 1500.00m,
                     UserId = 7
                 },
                new Driver
                {
                    Id = 2,
                    Drivers_License = "DL987654321",
                    License_Expiry = new DateOnly(2025, 11, 15),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.5",
                    Completion_Rate = "90%",
                    Total_Earnings = 1200.00m,
                    UserId = 8 
                },
                new Driver
                {
                    Id = 3,
                    Drivers_License = "DL456123789",
                    License_Expiry = new DateOnly(2026, 05, 01),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.6",
                    Completion_Rate = "92%",
                    Total_Earnings = 1800.00m,
                    UserId = 9 
                },
                new Driver
                {
                    Id = 4,
                    Drivers_License = "DL321654987",
                    License_Expiry = new DateOnly(2025, 10, 30),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.7",
                    Completion_Rate = "93%",
                    Total_Earnings = 1600.00m,
                    UserId = 10 
                },
                new Driver
                {
                    Id = 5,
                    Drivers_License = "DL159753468",
                    License_Expiry = new DateOnly(2026, 01, 14),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.9",
                    Completion_Rate = "97%",
                    Total_Earnings = 2000.00m,
                    UserId = 11
                },
                new Driver
                {
                    Id = 6,
                    Drivers_License = "DL753159864",
                    License_Expiry = new DateOnly(2025, 08, 20),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.4",
                    Completion_Rate = "89%",
                    Total_Earnings = 1400.00m,
                    UserId = 12 
                }
            );
        }
    }
}
