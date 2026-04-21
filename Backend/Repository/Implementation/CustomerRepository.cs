using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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
                customer.TotalOrders = 0;
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
            return databaseContext.OrderPlacements.Where(x=>x.CustomerId==CustomerId).ToList();
        }

        public Customer GetCustomerDetails(int Id)
        {
            var customer = databaseContext.Customers
                .Where(x => x.Id == Id)
                .Include(i => i.User)
                .FirstOrDefault();

            customer.TotalOrders = databaseContext.OrderPlacements.Where(i => i.CustomerId == Id).Count();
            var collection = databaseContext.OrderPlacements.Where(i => i.CustomerId == Id).ToList();
            decimal price = 0;
            foreach (var item in collection)
            {
                price = price + item.Price;
            }

            customer.TotalSpent = price;
            databaseContext.SaveChanges();
            return customer; 
        }
        //public User GetSingleUserRecordByCustomerId(int UserId)
        //{
        //    return databaseContext.Users.Where(user => user.Id == UserId).FirstOrDefault();
        //}

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
                updateRecord.BusinessName = customer.BusinessName;
                updateRecord.BusinessType = customer.BusinessType;
                updateRecord.TaxIdentification = customer.TaxIdentification;
                updateRecord.Rating = customer.Rating;
                updateRecord.TotalOrders = customer.TotalOrders;
                updateRecord.TotalSpent = customer.TotalSpent;
                databaseContext.SaveChanges();
                testValue = updateRecord.Id;
            }
                return testValue;
        }
    }
}
