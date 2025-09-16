using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class AddressData : IEntityTypeConfiguration<AddressData>
    {
        public void Configure(EntityTypeBuilder<AddressData> builder)
        {
            builder.HasData
            (
                new Address { Id = 1, Label = "Home", Address_Line = "123 Main St", City = "Los Angeles", User_Id = 1 },
                new Address { Id = 2, Label = "Work", Address_Line = "456 Business Rd", City = "Los Angeles", User_Id = 2 },

                new Address { Id = 3, Label = "Home", Address_Line = "789 Oak St", City = "San Francisco", User_Id = 3 },
                new Address { Id = 4, Label = "Vacation Home", Address_Line = "321 Pine Ave", City = "Lake Tahoe", User_Id = 4 },

                new Address { Id = 5, Label = "Home", Address_Line = "654 Maple Dr", City = "Seattle", User_Id = 5 },
                new Address { Id = 6, Label = "Office", Address_Line = "987 Birch Blvd", City = "Seattle", User_Id = 6 },

                new Address { Id = 7, Label = "Home", Address_Line = "123 Elm St", City = "New York", User_Id = 7 },
                new Address { Id = 8, Label = "Gym", Address_Line = "456 Fitness Ln", City = "New York", User_Id = 8 },

                new Address { Id = 9, Label = "Home", Address_Line = "321 Cedar Ct", City = "Miami", User_Id = 9 },
                new Address { Id = 10, Label = "School", Address_Line = "654 Academy Blvd", City = "Miami", User_Id = 10 },

                new Address { Id = 11, Label = "Home", Address_Line = "234 Palm St", City = "Austin", User_Id = 11 },
                new Address { Id = 12, Label = "Market", Address_Line = "567 Market St", City = "Austin", User_Id = 12 }
            );
        }
    }
}
