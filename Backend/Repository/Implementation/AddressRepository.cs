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

        public IEnumerable<Address> GetAllAddresses()
        {
            return databaseContext.Addresses.ToList();
        }

        public Address GetSingleRecord(int Id)
        {
            return databaseContext.Addresses.Where(temp => temp.Id == Id).FirstOrDefault();
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
                Address updatedRecord = databaseContext.Addresses.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Label = record.Label;
                updatedRecord.Address_Line = record.Address_Line;
                updatedRecord.City = record.City;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}
