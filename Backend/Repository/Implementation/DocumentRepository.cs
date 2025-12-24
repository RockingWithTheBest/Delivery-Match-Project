using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class DocumentRepository : IDocuments
    {
        private ApplicationDatabaseContext databaseContext;
        public DocumentRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public int AddDocumentRecord(Documents document)
        {
            int testValue = -1;
            if (document == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Documents.Add(document);
                databaseContext.SaveChanges();
                return testValue = document.Id;
            }
            return testValue;
        }
        public Documents GetSingleDocumentDetails(int DriverId)
        {
            return databaseContext.Documents.Where(d => d.DriverId == DriverId).FirstOrDefault();
        }
        public int DeleteDocumentRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Documents.Where(x=>x.Id == Id).FirstOrDefault();
            if (record != null)
            {
                databaseContext.Documents.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Documents> GetAllDocuments()
        {
            return databaseContext.Documents.ToList();
        }

        public int UpdateDocumentRecord(int Id, Documents document)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            else if(document != null && Id > 0)
            {
                var updateRecord = databaseContext.Documents.Where(x => x.Id == Id).FirstOrDefault();
                updateRecord.DocumentType = document.DocumentType;
                updateRecord.FileUrl = document.FileUrl;
                updateRecord.ExpiryDate = document.ExpiryDate;
                updateRecord.Status = document.Status;
                updateRecord.RejectionReason = document.RejectionReason;
                updateRecord.UploadedAt = document.UploadedAt;
                updateRecord.ReviewedBy = document.ReviewedBy;
                updateRecord.ReviewedAt = document.ReviewedAt;
                databaseContext.SaveChanges();
                testValue = document.Id;
            }
                return testValue;
        }
    }
}
