using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class EarningsData : IEntityTypeConfiguration<Earnings>
    {
        public void Configure(EntityTypeBuilder<Earnings> builder)
        {
            builder.HasData
            (
                // Driver 1 - Aggregated earnings from multiple payments
                new Earnings
                {
                    Id = 1,
                    Gross_Amount = 1350.00m,
                    Platform_Fee = 46.00m,
                    Net_Earnings = 1304.00m,
                    Is_Paid_Out = "Yes",
                    Earned_At = "2023-09-15 22:00:00",
                    DriverId = 1,
                    Order_PlacementId = 13
                },

                // Driver 2 - Aggregated earnings from multiple payments
                new Earnings
                {
                    Id = 2,
                    Gross_Amount = 1650.00m,
                    Platform_Fee = 53.00m,
                    Net_Earnings = 1597.00m,
                    Is_Paid_Out = "Yes",
                    Earned_At = "2023-09-15 23:00:00",
                    DriverId = 2,
                    Order_PlacementId = 14
                },

                // Driver 3 - Aggregated earnings from multiple payments (some pending)
                new Earnings
                {
                    Id = 3,
                    Gross_Amount = 630.00m,
                    Platform_Fee = 21.00m,
                    Net_Earnings = 609.00m,
                    Is_Paid_Out = "Partial",
                    Earned_At = "2023-09-15",
                    DriverId = 3,
                    Order_PlacementId = 15
                },

                // Driver 4 - Aggregated earnings from multiple payments
                new Earnings
                {
                    Id = 4,
                    Gross_Amount = 1300.00m,
                    Platform_Fee = 47.00m,
                    Net_Earnings = 1253.00m,
                    Is_Paid_Out = "Yes",
                    Earned_At = "2023-09-15 19:00:00",
                    DriverId = 4,
                    Order_PlacementId = 10
                },

                // Driver 5 - Aggregated earnings from multiple payments
                new Earnings
                {
                    Id = 5,
                    Gross_Amount = 970.00m,
                    Platform_Fee = 36.00m,
                    Net_Earnings = 934.00m,
                    Is_Paid_Out = "Yes",
                    Earned_At = "2023-09-15 20:00:00",
                    DriverId = 5,
                    Order_PlacementId = 11
                },

                // Driver 6 - Aggregated earnings from multiple payments
                new Earnings
                {
                    Id = 6,
                    Gross_Amount = 245.00m,
                    Platform_Fee = 0.00m,
                    Net_Earnings = 245.00m,
                    Is_Paid_Out = "Yes",
                    Earned_At = "2023-09-15 21:00:00",
                    DriverId = 6,
                    Order_PlacementId = 12
                }
            );
        }
    }
}