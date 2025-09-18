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
                new User { Id = 1, Email = "johndoe@example.com", Phone = "1234567890", First_Name = "John", Last_Name = "Doe", Password = "P@ss0rd1" },
                new User { Id = 2, Email = "janesmith@example.com", Phone = "2345678901", First_Name = "Jane", Last_Name = "Smith", Password = "S3cr3P@s" },
                new User { Id = 3, Email = "alciejohnson@example.com", Phone = "3456789012", First_Name = "Alice", Last_Name = "Johnson", Password = "A1i3#Pas" },
                new User { Id = 4, Email = "bobbrown@example.com", Phone = "4567890123", First_Name = "Bob", Last_Name = "Brown", Password = "B0b$T0ub" },
                new User { Id = 5, Email = "charliedavis@example.com", Phone = "5678901234", First_Name = "Charlie", Last_Name = "Davis", Password = "Ch@rie1$" },
                new User { Id = 6, Email = "dianamiller@example.com", Phone = "6789012345", First_Name = "Diana", Last_Name = "Miller", Password = "D1na!Cmp" },
                new User { Id = 7, Email = "ethanwilson@example.com", Phone = "7890123456", First_Name = "Ethan", Last_Name = "Wilson", Password = "Ethn1234" },
                new User { Id = 8, Email = "fionamoore@example.com", Phone = "8901234567", First_Name = "Foina", Last_Name = "Moore", Password = "F!0nC0d3" },
                new User { Id = 9, Email = "georgetaylor@example.com", Phone = "9012345678", First_Name = "George", Last_Name = "Taylor", Password = "G3rge@20" },
                new User { Id = 10, Email = "hannahanderson@example.com", Phone = "0123456789", First_Name = "Hannah", Last_Name = "Anderson", Password = "H@nah202" },
                new User { Id = 11, Email = "brunofernandes@example.com", Phone = "0129756789", First_Name = "Bruno", Last_Name = "Fernandes", Password = "F@brno20" },
                new User { Id = 12, Email = "cristianojuan@example.com", Phone = "4208656789", First_Name = "Cristiano", Last_Name = "Juan", Password = "C@juan02" }
            );
        }
    }
}
