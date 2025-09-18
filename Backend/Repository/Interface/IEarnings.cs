using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IEarnings
    {
        IEnumerable<Earnings> GetAllEarnings();
        Earnings GetSingleRecord(int Id);
        int AddEarningsRecord(Earnings address);
        int UpdateEarningsRecord(int Id, Earnings record);
        int DeleteEarningsRecord(int Id);
    }
}
