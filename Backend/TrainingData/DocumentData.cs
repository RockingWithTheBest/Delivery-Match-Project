using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class DocumentData : IEntityTypeConfiguration<Documents>
    {
        public void Configure(EntityTypeBuilder<Documents> builder)
        {
            builder.HasData
            (
                  new Documents
                  {
                      Id = 2,
                      DocumentType = "Insurance",
                      FileUrl = "http://example.com/documents/insurance1.pdf",
                      ExpiryDate = new DateOnly(2025, 05, 15),
                      Status = "Pending",
                      RejectionReason = "Awaiting verification",
                      UploadedAt = new DateTime(2023,09,02),
                      ReviewedBy = "Bob Smith",
                      ReviewedAt = new DateTime(2023, 09, 02, 10, 0, 0), // Static value
                      DriverId = 1 // Ensure this corresponds to an existing Driver
                  },
                new Documents
                {
                    Id = 3,
                    DocumentType = "Registration",
                    FileUrl = "http://example.com/documents/registration1.pdf",
                    ExpiryDate = new DateOnly(2026, 03, 01),
                    Status = "Rejected",
                    RejectionReason = "Expired document",
                    UploadedAt = new DateTime(2023,09,03),
                    ReviewedBy = "Charlie Brown",
                    ReviewedAt = new DateTime(2023, 09, 03, 11, 0, 0), // Static value
                    DriverId = 2 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 4,
                    DocumentType = "Vehicle Inspection",
                    FileUrl = "http://example.com/documents/inspection1.pdf",
                    ExpiryDate = new DateOnly(2025, 11, 30),
                    Status = "Approved",
                    RejectionReason = "None",
                    UploadedAt = new DateTime(2023,09,04),
                    ReviewedBy = "Diana Prince",
                    ReviewedAt = new DateTime(2023, 09, 04, 12, 0, 0), // Static value
                    DriverId = 3 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 5,
                    DocumentType = "Driving History",
                    FileUrl = "http://example.com/documents/history1.pdf",
                    ExpiryDate = new DateOnly(2025, 08, 20),
                    Status = "Pending",
                    RejectionReason = "Awaiting submission",
                    UploadedAt = new DateTime(2023,09,05),
                    ReviewedBy = "Ethan Hunt",
                    ReviewedAt = new DateTime(2023, 09, 05, 13, 0, 0), // Static value
                    DriverId = 4 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 6,
                    DocumentType = "Medical Certificate",
                    FileUrl = "http://example.com/documents/medical1.pdf",
                    ExpiryDate = new DateOnly(2025, 01, 14),
                    Status = "Approved",
                    RejectionReason = "None",
                    UploadedAt = new DateTime(2023,09,06),
                    ReviewedBy = "Fiona Gallagher",
                    ReviewedAt = new DateTime(2023, 09, 06, 14, 0, 0), // Static value
                    DriverId = 6 // Ensure this corresponds to an existing Driver
                }
            );
        }
    }
}
