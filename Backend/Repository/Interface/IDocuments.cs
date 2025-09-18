using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IDocuments
    {
        IEnumerable<Documents> GetAllDocuments();
        int AddDocumentRecord(Documents document);
        int UpdateDocumentRecord(int Id,Documents document);
        int DeleteDocumentRecord(int Id);
    }
}
