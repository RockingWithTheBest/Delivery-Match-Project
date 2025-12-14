using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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

            if (user == null)
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

        public User AddUserWithClient(User client)
        {
            User record = new User
            {
                First_Name = "",
                Last_Name = "",
                Password = "",
                Phone = "",
                Driver = null,
                Customer = null
            };

            if (record == null)
            {
                return record;
            }
            else
            {
                databaseContext.Users.Add(client);
                databaseContext.SaveChanges();
                return client;
            }
        }

        public User AddUserWithDriver(User driver)
        {
            User record = new User
            {
                First_Name = "",
                Last_Name = "",
                Password = "",
                Phone = "",
                Driver = null,
                Customer = null
            };

            if (record == null)
            {
                return record;
            }
            else
            {
                databaseContext.Users.Add(driver);
                databaseContext.SaveChanges();
                return driver;
            }
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
            return databaseContext.Users
                .Include(u=>u.Customer)
                .Include(x=>x.Driver)
                .ToList();
        }

        

        public User GetSingleRecord(int Id)
        {
            return databaseContext.Users
                .Include(u => u.Customer)
                .Include(x => x.Driver)
                .Where(temp => temp.Id == Id).FirstOrDefault();
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