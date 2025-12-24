using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class AddressData : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData
            (
                new Address { Id = 1, Label = "Home", AddressLine = "123 Main St", City = "Los Angeles", UserId = 1 },
                new Address { Id = 2, Label = "Work", AddressLine = "456 Business Rd", City = "Los Angeles", UserId = 2 },

                new Address { Id = 3, Label = "Home", AddressLine = "789 Oak St", City = "San Francisco", UserId = 3 },
                new Address { Id = 4, Label = "Vacation Home", AddressLine = "321 Pine Ave", City = "Lake Tahoe", UserId = 4 },

                new Address { Id = 5, Label = "Home", AddressLine = "654 Maple Dr", City = "Seattle", UserId = 5 },
                new Address { Id = 6, Label = "Office", AddressLine = "987 Birch Blvd", City = "Seattle", UserId = 6 },

                new Address { Id = 7, Label = "Home", AddressLine = "123 Elm St", City = "New York", UserId = 7 },
                new Address { Id = 8, Label = "Gym", AddressLine = "456 Fitness Ln", City = "New York", UserId = 8 },

                new Address { Id = 9, Label = "Home", AddressLine = "321 Cedar Ct", City = "Miami", UserId = 9 },
                new Address { Id = 10, Label = "School", AddressLine = "654 Academy Blvd", City = "Miami", UserId = 10 },

                new Address { Id = 11, Label = "Home", AddressLine = "234 Palm St", City = "Austin", UserId = 11 },
                new Address { Id = 12, Label = "Market", AddressLine = "567 Market St", City = "Austin", UserId = 12 }
            );
        }
    }
}
