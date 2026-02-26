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
                new Address { Id = 1, Label = "Home", AddressLine = "123 Main St", City = "Los Angeles", UserId = 1  },
                new Address { Id = 2, Label = "Work", AddressLine = "456 Business Rd", City = "Los Angeles", UserId = 2 },

                new Address { Id = 3, Label = "Home", AddressLine = "789 Oak St", City = "San Francisco", UserId = 3 },
                new Address { Id = 4, Label = "Vacation Home", AddressLine = "321 Pine Ave", City = "Lake Tahoe", UserId = 4 },

                new Address { Id = 5, Label = "Home", AddressLine = "654 Maple Dr", City = "Seattle", UserId = 5 },
                new Address { Id = 6, Label = "Office", AddressLine = "987 Birch Blvd", City = "Seattle", UserId = 6 },

                new Address { Id = 7, Label = "Home", AddressLine = "123 Elm St", City = "New York", UserId = 7,  Latitude = "55.75100000000001", Longitude = "37.61760000000001",Location= "Kremlin, Moscow" },
                new Address { Id = 8, Label = "Gym", AddressLine = "456 Fitness Ln", City = "New York", UserId = 8, Latitude = "59.88520000000001", Longitude="29.90910000000001", Location= "Samson Fountain, Saint Petersburg" },

                new Address { Id = 9, Label = "Home", AddressLine = "321 Cedar Ct", City = "Miami", UserId = 9 , Latitude = "55.80060000000001",Longitude="48.97470000000001", Location= "Temple of all Religions, Kazan" },
                new Address { Id = 10, Label = "School", AddressLine = "654 Academy Blvd", City = "Miami", UserId = 10 , Latitude = "55.76670000000001",Longitude="37.43520000000001", Location = "Ice Palace, Moscow" },

                new Address { Id = 11, Label = "Home", AddressLine = "234 Palm St", City = "Austin", UserId = 11 },
                new Address { Id = 12, Label = "Market", AddressLine = "567 Market St", City = "Austin", UserId = 12 }
            );
        }
    }
}
