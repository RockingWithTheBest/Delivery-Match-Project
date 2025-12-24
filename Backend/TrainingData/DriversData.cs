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
                     DriversLicense = "DL123456789",
                     LicenseExpiry = new DateOnly(2025, 12, 31),
                     IsVerified = true,
                     IsAvailable = true,
                     Rating = "4.8",
                     CompletionRate = "95%",
                     TotalEarnings = 1500.00m,
                     UserId = 7
                 },
                new Driver
                {
                    Id = 2,
                    DriversLicense = "DL987654321",
                    LicenseExpiry = new DateOnly(2025, 11, 15),
                    IsVerified = true,
                    IsAvailable = true,
                    Rating = "4.5",
                    CompletionRate = "90%",
                    TotalEarnings = 1200.00m,
                    UserId = 8 
                },
                new Driver
                {
                    Id = 3,
                    DriversLicense = "DL456123789",
                    LicenseExpiry = new DateOnly(2026, 05, 01),
                    IsVerified = true,
                    IsAvailable = true,
                    Rating = "4.6",
                    CompletionRate = "92%",
                    TotalEarnings = 1800.00m,
                    UserId = 9 
                },
                new Driver
                {
                    Id = 4,
                    DriversLicense = "DL321654987",
                    LicenseExpiry = new DateOnly(2025, 10, 30),
                    IsVerified = true,
                    IsAvailable = true,
                    Rating = "4.7",
                    CompletionRate = "93%",
                    TotalEarnings = 1600.00m,
                    UserId = 10 
                },
                new Driver
                {
                    Id = 5,
                    DriversLicense = "DL159753468",
                    LicenseExpiry = new DateOnly(2026, 01, 14),
                    IsVerified = true,
                    IsAvailable = true,
                    Rating = "4.9",
                    CompletionRate = "97%",
                    TotalEarnings = 2000.00m,
                    UserId = 11
                },
                new Driver
                {
                    Id = 6,
                    DriversLicense = "DL753159864",
                    LicenseExpiry = new DateOnly(2025, 08, 20),
                    IsVerified = true,
                    IsAvailable = true,
                    Rating = "4.4",
                    CompletionRate = "89%",
                    TotalEarnings = 1400.00m,
                    UserId = 12 
                }
            );
        }
    }
}
