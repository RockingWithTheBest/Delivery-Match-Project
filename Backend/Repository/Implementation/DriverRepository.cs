using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class DriverRepository : IDriver
    {
        private ApplicationDatabaseContext databaseContext;
        public DriverRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
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
            return databaseContext.Drivers.ToList();
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
                var record = databaseContext.Drivers.Where(x=>x.Id==Id).FirstOrDefault();
                record.Drivers_License = driver.Drivers_License;
                record.License_Expiry = driver.License_Expiry;
                record.Is_Verified = driver.Is_Verified;
                record.Is_Available = driver.Is_Available;
                record.Rating = driver.Rating;
                record.Completion_Rate = driver.Completion_Rate;
                record.Total_Earnings = driver.Total_Earnings;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
        public IEnumerable<Order_Placement> GetAllOrdersPlacedByDriverID(int DriverId)
        {
            return databaseContext.OrderPlacements.Where(x=>x.Id == DriverId).ToList();
        }
    }
}
