using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class VehicleRepository : IVehicle
    {
        private ApplicationDatabaseContext databaseContext;
        public VehicleRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddAddressRecord(Vehicle vehicle)
        {
            int textVariable = -1;
            if (vehicle.Id == 0)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Vehicles.Add(vehicle);
                databaseContext.SaveChanges();
                textVariable = vehicle.Id;
            }
            return textVariable;
        }

        public int DeleteVehicleRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Vehicles.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Vehicles.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return databaseContext.Vehicles.ToList();
        }

        public Vehicle GetSingleRecord(int Id)
        {
            return databaseContext.Vehicles.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateVehicleRecord(int Id, Vehicle record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Vehicle updatedRecord = databaseContext.Vehicles.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Brand = record.Brand;
                updatedRecord.Max_Weight = record.Max_Weight;
                updatedRecord.Model = record.Model;
                updatedRecord.Make_Year = record.Make_Year;
                updatedRecord.Color = record.Color;
                updatedRecord.License_Plate = record.License_Plate;
                updatedRecord.Max_Volume = record.Max_Volume;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}