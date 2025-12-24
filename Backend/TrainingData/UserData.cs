using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class UserData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User { Id = 1, Email = "johndoe@example.com", Phone = "1234567890", FirstName = "John", LastName = "Doe", Password = "P@ss0rd1" },
                new User { Id = 2, Email = "janesmith@example.com", Phone = "2345678901", FirstName = "Jane", LastName = "Smith", Password = "S3cr3P@s" },
                new User { Id = 3, Email = "alciejohnson@example.com", Phone = "3456789012", FirstName = "Alice", LastName = "Johnson", Password = "A1i3#Pas" },
                new User { Id = 4, Email = "bobbrown@example.com", Phone = "4567890123", FirstName = "Bob", LastName = "Brown", Password = "B0b$T0ub" },
                new User { Id = 5, Email = "charliedavis@example.com", Phone = "5678901234", FirstName = "Charlie", LastName = "Davis", Password = "Ch@rie1$" },
                new User { Id = 6, Email = "dianamiller@example.com", Phone = "6789012345", FirstName = "Diana", LastName = "Miller", Password = "D1na!Cmp" },
                new User { Id = 7, Email = "ethanwilson@example.com", Phone = "7890123456", FirstName = "Ethan", LastName = "Wilson", Password = "Ethn1234" },
                new User { Id = 8, Email = "fionamoore@example.com", Phone = "8901234567", FirstName = "Foina", LastName = "Moore", Password = "F!0nC0d3" },
                new User { Id = 9, Email = "georgetaylor@example.com", Phone = "9012345678", FirstName = "George", LastName = "Taylor", Password = "G3rge@20" },
                new User { Id = 10, Email = "hannahanderson@example.com", Phone = "0123456789", FirstName = "Hannah", LastName = "Anderson", Password = "H@nah202" },
                new User { Id = 11, Email = "brunofernandes@example.com", Phone = "0129756789", FirstName = "Bruno", LastName = "Fernandes", Password = "F@brno20" },
                new User { Id = 12, Email = "cristianojuan@example.com", Phone = "4208656789", FirstName = "Cristiano", LastName = "Juan", Password = "C@juan02" }
            );
        }
    }
}
