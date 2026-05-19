using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using Backend.Services.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementation
{
    public class UserRepository : IUser
    {
        private ApplicationDatabaseContext databaseContext;
        private readonly IPasswordHasher<User> passwordHasher;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(ApplicationDatabaseContext databaseContext, IPasswordHasher<User> passwordHasher, ILogger<UserRepository>logger)
        {
            this.databaseContext = databaseContext;
            this.passwordHasher = passwordHasher;
            _logger = logger;
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
                FirstName = "",
                LastName = "",
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
                client.Customer.TotalOrders = 0;
                client.Customer.TotalSpent = 0;
                databaseContext.Users.Add(client);
                databaseContext.SaveChanges();
                return client;
            }
        }

        public User AddUserWithDriver(User driver)
        {
            User record = new User
            {
                FirstName = "",
                LastName = "",
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

        public User RegisterUser(User user)
        {
            var existingUser = databaseContext.Users.Where(i=>i.Email == user.Email).FirstOrDefault();
            if(existingUser != null)
            {
                throw new Exception("User with this email already exists");
            }

            //Create new user
            var userRecord = new User
            {
                Email = user.Email,
                Phone = user.Phone,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Driver = user.Driver,
                Customer = user.Customer,
            };

            userRecord.Password = passwordHasher.HashPassword(userRecord, user.Password);
            databaseContext.Users.Add(userRecord);
            databaseContext.SaveChanges();

            return userRecord;
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
                updatedRecord.FirstName = record.FirstName;
                updatedRecord.LastName = record.LastName;
                //updatedRecord.Password = record.Password;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public bool UserPasswordChanger(int UserId, string password)
        {
            try
            {   
                var LastId = databaseContext.Users
                    .Select(o=>o.Id)
                    .OrderBy(Id=> Id).LastOrDefault();
                
                if (UserId <= 0 || UserId >= LastId+1)
                {
                    _logger.LogWarning("The Id you provided isnt Valid", UserId);
                    return false;
                }
                
               
                
                var user = databaseContext.Users.Where(i=>i.Id == UserId).FirstOrDefault();
                if (user != null)
                {
                    user.Password = passwordHasher.HashPassword(user, password);
                    databaseContext.SaveChanges();
                    return true;
                }
               return false;
            }
            catch(Exception ex)
            {
                _logger.LogWarning("The Id you provided isnt Valid", UserId);
                return false;
            }
        }
    }
}