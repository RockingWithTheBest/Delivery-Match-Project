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
                new Payment { Id = 1, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN001", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 1 },
                new Payment { Id = 2, Amount = 500.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN002", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 485.00m, Order_Placement_Id = 2 },

                new Payment { Id = 3, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN003", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 3 },
                new Payment { Id = 4, Amount = 600.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN004", Processed_At = DateTime.Now.ToString(), Platform_Fee = 20.00m, Driver_Earnings = 580.00m, Order_Placement_Id = 4 },

                new Payment { Id = 5, Amount = 200.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN005", Processed_At = DateTime.Now.ToString(), Platform_Fee = 8.00m, Driver_Earnings = 192.00m, Order_Placement_Id = 5 },
                new Payment { Id = 6, Amount = 80.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN006", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 80.00m, Order_Placement_Id = 6 },

                new Payment { Id = 7, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN007", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 7 },
                new Payment { Id = 8, Amount = 450.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN008", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 435.00m, Order_Placement_Id = 8 },

                new Payment { Id = 9, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN009", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 9 },
                new Payment { Id = 10, Amount = 700.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN010", Processed_At = DateTime.Now.ToString(), Platform_Fee = 25.00m, Driver_Earnings = 675.00m, Order_Placement_Id = 10 },

                new Payment { Id = 11, Amount = 250.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN011", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 240.00m, Order_Placement_Id = 11 },
                new Payment { Id = 12, Amount = 90.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN012", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 90.00m, Order_Placement_Id = 12 },

                new Payment { Id = 13, Amount = 350.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN013", Processed_At = DateTime.Now.ToString(), Platform_Fee = 12.00m, Driver_Earnings = 338.00m, Order_Placement_Id = 13 },
                new Payment { Id = 14, Amount = 500.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN014", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 485.00m, Order_Placement_Id = 14 },

                new Payment { Id = 15, Amount = 180.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN015", Processed_At = null, Platform_Fee = 6.00m, Driver_Earnings = 174.00m, Order_Placement_Id = 15 },
                new Payment { Id = 16, Amount = 650.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN016", Processed_At = DateTime.Now.ToString(), Platform_Fee = 22.00m, Driver_Earnings = 628.00m, Order_Placement_Id = 16 },

                new Payment { Id = 17, Amount = 220.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN017", Processed_At = DateTime.Now.ToString(), Platform_Fee = 8.00m, Driver_Earnings = 212.00m, Order_Placement_Id = 17 },
                new Payment { Id = 18, Amount = 75.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN018", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 75.00m, Order_Placement_Id = 18 },

                new Payment { Id = 19, Amount = 400.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN019", Processed_At = DateTime.Now.ToString(), Platform_Fee = 14.00m, Driver_Earnings = 386.00m, Order_Placement_Id = 19 },
                new Payment { Id = 20, Amount = 600.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN020", Processed_At = DateTime.Now.ToString(), Platform_Fee = 20.00m, Driver_Earnings = 580.00m, Order_Placement_Id = 20 },

                new Payment { Id = 21, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN021", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 21 },
                new Payment { Id = 22, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN022", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 22 },

                new Payment { Id = 23, Amount = 200.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN023", Processed_At = DateTime.Now.ToString(), Platform_Fee = 8.00m, Driver_Earnings = 192.00m, Order_Placement_Id = 23 },
                new Payment { Id = 24, Amount = 80.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN024", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 80.00m, Order_Placement_Id = 24 },

                new Payment { Id = 25, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN025", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 25 },
                new Payment { Id = 26, Amount = 450.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN026", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 435.00m, Order_Placement_Id = 26 },

                new Payment { Id = 27, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN027", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 27 },
                new Payment { Id = 28, Amount = 700.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN028", Processed_At = DateTime.Now.ToString(), Platform_Fee = 25.00m, Driver_Earnings = 675.00m, Order_Placement_Id = 28 },

                new Payment { Id = 29, Amount = 250.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN029", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 240.00m, Order_Placement_Id = 29 },
                new Payment { Id = 30, Amount = 90.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN030", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 90.00m, Order_Placement_Id = 30 },

                new Payment { Id = 31, Amount = 350.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN031", Processed_At = DateTime.Now.ToString(), Platform_Fee = 12.00m, Driver_Earnings = 338.00m, Order_Placement_Id = 31 },
                new Payment { Id = 32, Amount = 500.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN032", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 485.00m, Order_Placement_Id = 32 },

                new Payment { Id = 33, Amount = 180.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN033", Processed_At = null, Platform_Fee = 6.00m, Driver_Earnings = 174.00m, Order_Placement_Id = 33 },
                new Payment { Id = 34, Amount = 650.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN034", Processed_At = DateTime.Now.ToString(), Platform_Fee = 22.00m, Driver_Earnings = 628.00m, Order_Placement_Id = 34 },

                new Payment { Id = 35, Amount = 220.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN035", Processed_At = DateTime.Now.ToString(), Platform_Fee = 8.00m, Driver_Earnings = 212.00m, Order_Placement_Id = 35 },
                new Payment { Id = 36, Amount = 75.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN036", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 75.00m, Order_Placement_Id = 36 },

                new Payment { Id = 37, Amount = 400.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN037", Processed_At = DateTime.Now.ToString(), Platform_Fee = 14.00m, Driver_Earnings = 386.00m, Order_Placement_Id = 37 },
                new Payment { Id = 38, Amount = 600.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN038", Processed_At = DateTime.Now.ToString(), Platform_Fee = 20.00m, Driver_Earnings = 580.00m, Order_Placement_Id = 38 },

                new Payment { Id = 39, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN039", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 39 },
                new Payment { Id = 40, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN040", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 40 },

                new Payment { Id = 41, Amount = 200.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN041", Processed_At = DateTime.Now.ToString(), Platform_Fee = 8.00m, Driver_Earnings = 192.00m, Order_Placement_Id = 41 },
                new Payment { Id = 42, Amount = 80.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN042", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 80.00m, Order_Placement_Id = 42 },

                new Payment { Id = 43, Amount = 300.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN043", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 290.00m, Order_Placement_Id = 43 },
                new Payment { Id = 44, Amount = 450.00m, Payment_Method = "PayPal", Status = "Completed", Transaction_Identification = "TXN044", Processed_At = DateTime.Now.ToString(), Platform_Fee = 15.00m, Driver_Earnings = 435.00m, Order_Placement_Id = 44 },

                new Payment { Id = 45, Amount = 150.00m, Payment_Method = "Debit Card", Status = "Pending", Transaction_Identification = "TXN045", Processed_At = null, Platform_Fee = 5.00m, Driver_Earnings = 145.00m, Order_Placement_Id = 45 },
                new Payment { Id = 46, Amount = 700.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN046", Processed_At = DateTime.Now.ToString(), Platform_Fee = 25.00m, Driver_Earnings = 675.00m, Order_Placement_Id = 46 },

                new Payment { Id = 47, Amount = 250.00m, Payment_Method = "Bank Transfer", Status = "Completed", Transaction_Identification = "TXN047", Processed_At = DateTime.Now.ToString(), Platform_Fee = 10.00m, Driver_Earnings = 240.00m, Order_Placement_Id = 47 },
                new Payment { Id = 48, Amount = 90.00m, Payment_Method = "Cash", Status = "Completed", Transaction_Identification = "TXN048", Processed_At = DateTime.Now.ToString(), Platform_Fee = 0.00m, Driver_Earnings = 90.00m, Order_Placement_Id = 48 },
                new Payment { Id = 49, Amount = 350.00m, Payment_Method = "Credit Card", Status = "Completed", Transaction_Identification = "TXN049", Processed_At = DateTime.Now.ToString(), Platform_Fee = 12.00m, Driver_Earnings = 90.00m, Order_Placement_Id = 49 }
            );
        }
    }
}
