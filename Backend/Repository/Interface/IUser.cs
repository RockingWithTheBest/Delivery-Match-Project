using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IUser
    {
        IEnumerable<User> GetAllUsers();
        User GetSingleRecord(int Id);
        int AddUserRecord(User address);
        int UpdateUserRecord(int Id, User record);
        int DeleteUserRecord(int Id);
    }
}
