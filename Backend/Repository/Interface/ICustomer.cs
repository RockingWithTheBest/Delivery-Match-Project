using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface ICustomer
    {
        IEnumerable<Customer> GetAllCustomers();
        int AddCustomerRecord(Customer customer);
        int UpdateCustomerRecord(int Id,Customer customer);
        int DeleteCustomerRecord(int Id);
        IEnumerable<OrderPlacement> GetAllOrderPlacementsByCustomerId(int CustomerId);
    }
}
