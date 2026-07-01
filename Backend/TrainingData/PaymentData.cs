using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class PaymentData : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasData
            (
                new Payment { Id = 1, Amount = 300.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN001", ProcessedAt = new DateTime(2023,09,15,10,00,00),  DriverEarnings = 290.00m, OrderPlacementId = 1 },
                new Payment { Id = 2, Amount = 500.00m, PaymentMethod = "PayPal", Status = "Completed", TransactionIdentification = "TXN002", ProcessedAt = new DateTime(2023,09,15,12,00,00), DriverEarnings = 485.00m, OrderPlacementId = 2 },
                new Payment { Id = 3, Amount = 150.00m, PaymentMethod = "Debit Card", Status = "Pending", TransactionIdentification = "TXN003", ProcessedAt = null, DriverEarnings = 145.00m, OrderPlacementId = 3 },
                new Payment { Id = 4, Amount = 600.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN004", ProcessedAt = new DateTime(2023,09,15,14,00,00), DriverEarnings = 580.00m, OrderPlacementId = 4 },
                new Payment { Id = 5, Amount = 200.00m, PaymentMethod = "Bank Transfer", Status = "Completed", TransactionIdentification = "TXN005", ProcessedAt = new DateTime(2023,09,15,15,00,00), DriverEarnings = 192.00m, OrderPlacementId = 5 },
                new Payment { Id = 6, Amount = 80.00m, PaymentMethod = "Cash", Status = "Completed", TransactionIdentification = "TXN006", ProcessedAt = new DateTime(2023,12,16,13,00,00), DriverEarnings = 80.00m, OrderPlacementId = 6 },
                new Payment { Id = 7, Amount = 300.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN007", ProcessedAt = new DateTime(2023,09,15,17,00,00), DriverEarnings = 290.00m, OrderPlacementId = 7 },
                new Payment { Id = 8, Amount = 450.00m, PaymentMethod = "PayPal", Status = "Completed", TransactionIdentification = "TXN008", ProcessedAt = new DateTime(2023,09,15,18,00,00), DriverEarnings = 435.00m, OrderPlacementId = 8 },
                new Payment { Id = 9, Amount = 150.00m, PaymentMethod = "Debit Card", Status = "Pending", TransactionIdentification = "TXN009", ProcessedAt = null, DriverEarnings = 145.00m, OrderPlacementId = 9 },
                new Payment { Id = 10, Amount = 700.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN010", ProcessedAt = new DateTime(2023,9,15,19,00,00), DriverEarnings = 675.00m, OrderPlacementId = 10 },
                new Payment { Id = 11, Amount = 250.00m, PaymentMethod = "Bank Transfer", Status = "Completed", TransactionIdentification = "TXN011", ProcessedAt = new DateTime(2023,09,15,20,00,00), DriverEarnings = 240.00m, OrderPlacementId = 11 },
                new Payment { Id = 12, Amount = 90.00m, PaymentMethod = "Cash", Status = "Completed", TransactionIdentification = "TXN012", ProcessedAt = new DateTime(2023,09,15,21,00,00), DriverEarnings = 90.00m, OrderPlacementId = 12 },
                new Payment { Id = 13, Amount = 350.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN013", ProcessedAt = new DateTime(2023,09,15,22,00,00), DriverEarnings = 338.00m, OrderPlacementId = 13 },
                new Payment { Id = 14, Amount = 500.00m, PaymentMethod = "PayPal", Status = "Completed", TransactionIdentification = "TXN014", ProcessedAt = new DateTime(2023,09,15,23,00,00), DriverEarnings = 485.00m, OrderPlacementId = 14 },
                new Payment { Id = 15, Amount = 180.00m, PaymentMethod = "Debit Card", Status = "Pending", TransactionIdentification = "TXN015", ProcessedAt = null, DriverEarnings = 174.00m, OrderPlacementId = 15 },
                new Payment { Id = 16, Amount = 650.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN016", ProcessedAt = new DateTime(2023,09,16,10,00,00), DriverEarnings = 628.00m, OrderPlacementId = 16 },
                new Payment { Id = 17, Amount = 220.00m, PaymentMethod = "Bank Transfer", Status = "Completed", TransactionIdentification = "TXN017", ProcessedAt = new DateTime(2023,09,16,11,00,00), DriverEarnings = 212.00m, OrderPlacementId = 17 },
                new Payment { Id = 18, Amount = 75.00m, PaymentMethod = "Cash", Status = "Completed", TransactionIdentification = "TXN018", ProcessedAt = new DateTime(2023,09,16,12,00,00), DriverEarnings = 75.00m, OrderPlacementId = 18 },
                new Payment { Id = 19, Amount = 400.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN019", ProcessedAt = new DateTime(2023,09,16,13,00,00), DriverEarnings = 386.00m, OrderPlacementId = 19 },
                new Payment { Id = 20, Amount = 600.00m, PaymentMethod = "PayPal", Status = "Completed", TransactionIdentification = "TXN020", ProcessedAt = new DateTime(2023,09,16,14,00,00), DriverEarnings = 580.00m, OrderPlacementId = 20 },
                new Payment { Id = 21, Amount = 150.00m, PaymentMethod = "Debit Card", Status = "Pending", TransactionIdentification = "TXN021", ProcessedAt = null, DriverEarnings = 145.00m, OrderPlacementId = 21 },
                new Payment { Id = 22, Amount = 300.00m, PaymentMethod = "Credit Card", Status = "Completed", TransactionIdentification = "TXN022", ProcessedAt = new DateTime(2023,09,16,15,00,00), DriverEarnings = 290.00m, OrderPlacementId = 22 },
                new Payment { Id = 23, Amount = 200.00m, PaymentMethod = "Bank Transfer", Status = "Completed", TransactionIdentification = "TXN023", ProcessedAt = new DateTime(2023,09,16,16,00,00), DriverEarnings = 192.00m, OrderPlacementId = 23 },
                new Payment { Id = 24, Amount = 80.00m, PaymentMethod = "Cash", Status = "Completed", TransactionIdentification = "TXN024", ProcessedAt = new DateTime(2023,09,16,17,00,00), DriverEarnings = 80.00m, OrderPlacementId = 24 }
            );
        }
    }
}
