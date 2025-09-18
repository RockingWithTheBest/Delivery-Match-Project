using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class UserRepository : IUser
    {
        private ApplicationDatabaseContext databaseContext;
        public UserRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddUserRecord(User user)
        {
            int textVariable = -1;
            if (user.Id == 0)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Users.Add(user);
                databaseContext.SaveChanges();
                textVariable = user.Id;
            }
            return textVariable;
        }

        public int DeleteUserRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Users.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Users.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return databaseContext.Users.ToList();
        }

        public User GetSingleRecord(int Id)
        {
            return databaseContext.Users.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateUserRecord(int Id, User record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                User updatedRecord = databaseContext.Users.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Email = record.Email;
                updatedRecord.Phone = record.Phone;
                updatedRecord.First_Name = record.First_Name;
                updatedRecord.Last_Name = record.Last_Name;
                updatedRecord.Password = record.Password;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}