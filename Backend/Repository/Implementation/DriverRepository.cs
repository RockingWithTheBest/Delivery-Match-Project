using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementation
{
    public class DriverRepository : IDriver
    {
        private ApplicationDatabaseContext databaseContext;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfiguration _configuration;
        public DriverRepository(ApplicationDatabaseContext databaseContext, IWebHostEnvironment environment, IConfiguration configuration)
        {
            this.databaseContext = databaseContext;
            _environment = environment;
            _configuration = configuration;
        }
        public int CreateDriverRecord(Driver driver)
        {
            int testValue = -1;
            if (driver == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Drivers.Add(driver);
                databaseContext.SaveChanges();
                testValue = driver.Id;
            }
                return testValue;
        }

        public int DeleteDriverRecord(int Id)
        {
            int testValue = -1;
            if(Id <= 0)
            {
                return testValue;
            }
            var driverRecord = databaseContext.Drivers.Where(x=>x.Id == Id).FirstOrDefault();
            if (driverRecord != null)
            {
                databaseContext.Drivers.Remove(driverRecord);
                databaseContext.SaveChanges();
                testValue = driverRecord.Id;
            }
            else if(driverRecord==null)
            {
                return testValue;
            }
                return testValue;
        }

        public IEnumerable<Driver> GetAllDrivers()
        {
            return databaseContext.Drivers.Include(d=>d.OrdersPlaced).ToList();
        }

        public Driver GetDriverDetails(int Id)
        {
            return databaseContext.
                Drivers.
                Where(x => x.Id == Id)
                .Include(i=>i.User)
                .Include(z=>z.NotificationsPlaced)
                .FirstOrDefault();
        }
        public int UpdateDriverRecord(int Id, Driver driver)
        {
            int testValue = -1;
            if (driver == null)
            {
                return -1;
            }
            if(Id < 0)
            {
                return -1;
            }
            if(driver != null && Id > 0)
            {
                var record = databaseContext.Drivers.Where(x=>x.UserId==Id).FirstOrDefault();
                record.DriversLicense = driver.DriversLicense;
                record.LicenseExpiry = driver.LicenseExpiry;
                record.IsVerified = driver.IsVerified;
                record.IsAvailable = driver.IsAvailable;
                record.Rating = driver.Rating;
                record.CompletionRate = driver.CompletionRate;
                record.TotalEarnings = driver.TotalEarnings;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
        public IEnumerable<OrderPlacement> GetAllOrdersClaimedByDriverID(int DriverId)
        {
            return databaseContext.OrderPlacements.Where(x=>x.DriverId == DriverId).ToList();
        }

        public IEnumerable<OrderPlacement> AddCollectionOfOrdersPlaced(IEnumerable<OrderPlacement> OrdersPlaced, int DriverId)
        {
            List<OrderPlacement> result = new List<OrderPlacement>();
            if(OrdersPlaced!=null && DriverId > 0)
            {
                foreach (var order in OrdersPlaced)
                {
                    order.DriverId = DriverId; // This is the crucial line!
                }
                databaseContext.OrderPlacements.AddRange(OrdersPlaced);
                databaseContext.SaveChanges();
                result = OrdersPlaced.ToList();
            }
            return result;
        }

        Driver IDriver.GetDriverByUserId(int UserId)
        {
            return databaseContext.Drivers
                .Where(i => i.UserId == UserId)
                .FirstOrDefault();
        }
    }
}
