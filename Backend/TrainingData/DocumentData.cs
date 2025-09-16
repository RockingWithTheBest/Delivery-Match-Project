using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class DocumentData : IEntityTypeConfiguration<DocumentData>
    {
        public void Configure(EntityTypeBuilder<DocumentData> builder)
        {
            builder.HasData
            (
                new Documents
                {
                    Id = 2,
                    Document_Type = "Insurance",
                    File_Url = "http://example.com/documents/insurance1.pdf",
                    Expiry_Date = new DateOnly(2025, 05, 15),
                    Status = "Pending",
                    Rejection_Reason = "Awaiting verification",
                    Uploaded_At = "2023-09-02",
                    Reviewed_By = "Bob Smith",
                    Reviewed_At = DateTime.Now,
                    Driver_Id = 1 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 3,
                    Document_Type = "Registration",
                    File_Url = "http://example.com/documents/registration1.pdf",
                    Expiry_Date = new DateOnly(2026, 03, 01),
                    Status = "Rejected",
                    Rejection_Reason = "Expired document",
                    Uploaded_At = "2023-09-03",
                    Reviewed_By = "Charlie Brown",
                    Reviewed_At = DateTime.Now,
                    Driver_Id = 2 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 4,
                    Document_Type = "Vehicle Inspection",
                    File_Url = "http://example.com/documents/inspection1.pdf",
                    Expiry_Date = new DateOnly(2025, 11, 30),
                    Status = "Approved",
                    Rejection_Reason = "None",
                    Uploaded_At = "2023-09-04",
                    Reviewed_By = "Diana Prince",
                    Reviewed_At = DateTime.Now,
                    Driver_Id = 3 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 5,
                    Document_Type = "Driving History",
                    File_Url = "http://example.com/documents/history1.pdf",
                    Expiry_Date = new DateOnly(2025, 08, 20),
                    Status = "Pending",
                    Rejection_Reason = "Awaiting submission",
                    Uploaded_At = "2023-09-05",
                    Reviewed_By = "Ethan Hunt",
                    Reviewed_At = DateTime.Now,
                    Driver_Id = 4 // Ensure this corresponds to an existing Driver
                },
                new Documents
                {
                    Id = 6,
                    Document_Type = "Medical Certificate",
                    File_Url = "http://example.com/documents/medical1.pdf",
                    Expiry_Date = new DateOnly(2025, 01, 14),
                    Status = "Approved",
                    Rejection_Reason = "None",
                    Uploaded_At = "2023-09-06",
                    Reviewed_By = "Fiona Gallagher",
                    Reviewed_At = DateTime.Now,
                    Driver_Id = 6 // Ensure this corresponds to an existing Driver
                }
            );
        }
    }
}
