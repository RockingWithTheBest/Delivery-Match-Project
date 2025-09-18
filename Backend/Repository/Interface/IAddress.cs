using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IAddress
    {
        IEnumerable<Address> GetAllAddresses();
        Address GetSingleRecord(int Id);
        int AddAddressRecord(Address address);
        int UpdateAddressRecord(int Id, Address record);
        int DeleteAddressRecord(int Id);
    }
}
