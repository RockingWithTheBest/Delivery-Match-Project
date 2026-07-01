using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class AddressRepository : IAddress
    {
        private ApplicationDatabaseContext databaseContext;
        public AddressRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddAddressRecord(Address address)
        {
            int textVariable = -1;
            
            if(address!=null)
            {
                var record = databaseContext.Addresses.Where(i => i.UserId == address.UserId).FirstOrDefault();
                databaseContext.Addresses.Remove(record);
                databaseContext.SaveChanges();

                databaseContext.Addresses.Add(address);
                databaseContext.SaveChanges();
                textVariable = address.Id;
            }
            else
            {
                return textVariable;
            }
            return textVariable;
        }

        public int DeleteAddressRecord(int Id)
        {
            int testValue = -1;
            if(Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Addresses.Find(Id);
            if(record == null) 
            {
                return testValue;
            }
            else
            {
                databaseContext.Addresses.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
        public IEnumerable<Address>GetAddressListByUserId(int UserId)
        {
            return databaseContext.Addresses.ToList().Where(u => u.UserId == UserId);
        }
        public IEnumerable<Address> GetAllAddresses()
        {
            return databaseContext.Addresses.ToList();
        }

        public Address GetSingleRecord(int Id)
        {
            return databaseContext.Addresses.Where(temp => temp.UserId == Id).FirstOrDefault();
        }

        public int UpdateAddressRecord(int Id, Address record)
        {
            int testValue = -1;
            if(Id <= 0 || record==null)
            {
                return testValue;
            }
            else
            {
                Address updatedRecord = databaseContext.Addresses.Where(temp => temp.UserId == Id).FirstOrDefault();
                updatedRecord.Label = record.Label;
                updatedRecord.Latitude = record.Latitude;
                updatedRecord.Longitude = record.Longitude;
                updatedRecord.Location = record.Location;
                databaseContext.SaveChanges();
                testValue = updatedRecord.Id;
            }
            return testValue;
        }
    }
}
