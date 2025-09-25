using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class CustomerRepository : ICustomer
    {
        private ApplicationDatabaseContext databaseContext;
        public CustomerRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddCustomerRecord(Customer customer)
        {
            int testValue = 0;
            if(customer == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Customers.Add(customer);
                databaseContext.SaveChanges();
                testValue = customer.Id;
            }
                return testValue;
        }

        public int DeleteCustomerRecord(int Id)
        {
            int testValue = -1;
            if(Id <= 0)
            {
                return testValue;
            }
            Customer tempRecord = databaseContext.Customers.Where(temp=>temp.Id == Id).FirstOrDefault();
            if(tempRecord == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Customers.Remove(tempRecord);
                databaseContext.SaveChanges();
                testValue = tempRecord.Id;
            }
                return testValue;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return databaseContext.Customers.ToList();
        }

        public IEnumerable<OrderPlacement> GetAllOrderPlacementsByCustomerId(int CustomerId)
        {
            return databaseContext.OrderPlacements.Where(x=>x.Id==CustomerId).ToList();
        }

        public int UpdateCustomerRecord(int Id, Customer customer)
        {
           int testValue = 0;
           if(Id < 0)
           {
                return testValue;
           }
            if(customer == null)
            {
                return testValue;
            }
            else
            {
                var updateRecord = databaseContext.Customers.Where(temp => temp.Id == Id).FirstOrDefault();
                updateRecord.Business_Name = customer.Business_Name;
                updateRecord.Business_Type = customer.Business_Type;
                updateRecord.Tax_Identification = customer.Tax_Identification;
                updateRecord.Rating = customer.Rating;
                updateRecord.Total_Orders = customer.Total_Orders;
                updateRecord.Total_Spent = customer.Total_Spent;
                databaseContext.SaveChanges();
                testValue = updateRecord.Id;
            }
                return testValue;
        }
    }
}
