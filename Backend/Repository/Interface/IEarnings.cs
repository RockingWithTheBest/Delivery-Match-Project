using Backend.DTOs;
using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IEarnings
    {
        IEnumerable<Earnings> GetAllEarnings();
        EarningsDivisionDto EarningDivionsByStatus(int DriverId);
        IEnumerable<Earnings> GetAListOfEarningsByDriverId(int DriverId);
        void PopularEarnings();
    }
}
