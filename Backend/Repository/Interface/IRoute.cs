using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IRoute
    {
        IEnumerable<Models.Route> GetAllRoutes();
        Models.Route GetSingleRecord(int Id);
        int AddRoutesRecord(Models.Route route);
        int UpdateRoutesRecord(int Id, Models.Route record);
        int DeleteRoutesRecord(int Id);
    }
}
