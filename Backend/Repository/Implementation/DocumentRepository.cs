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
                updateRecord.Document_Type = document.Document_Type;
                updateRecord.File_Url = document.File_Url;
                updateRecord.Expiry_Date = document.Expiry_Date;
                updateRecord.Status = document.Status;
                updateRecord.Rejection_Reason = document.Rejection_Reason;
                updateRecord.Uploaded_At = document.Uploaded_At;
                updateRecord.Reviewed_By = document.Reviewed_By;
                updateRecord.Reviewed_At = document.Reviewed_At;
                databaseContext.SaveChanges();
                testValue = document.Id;
            }
                return testValue;
        }
    }
}
