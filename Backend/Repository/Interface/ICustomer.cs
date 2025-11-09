using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerDetails(int Id);
        int AddCustomerRecord(Customer customer);
        int UpdateCustomerRecord(int Id,Customer customer);
        int DeleteCustomerRecord(int Id);
        //User GetSingleCustomerRecord(int Id);
        IEnumerable<OrderPlacement> GetAllOrderPlacementsByCustomerId(int CustomerId);
    }
}
