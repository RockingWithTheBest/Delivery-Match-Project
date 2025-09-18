using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class PaymentRepository : IPayment
    {
        private ApplicationDatabaseContext databaseContext;
        public PaymentRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddPaymentRecord(Payment pay)
        {
            int textVariable = -1;
            if (pay.Id == 0)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Payments.Add(pay);
                databaseContext.SaveChanges();
                textVariable = pay.Id;
            }
            return textVariable;
        }

        public int DeletePaymentRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Payments.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Payments.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Payment> GetAllPayments()
        {
            return databaseContext.Payments.ToList();
        }

        public Payment GetSingleRecord(int Id)
        {
            return databaseContext.Payments.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdatePaymentRecord(int Id, Payment record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Payment updatedRecord = databaseContext.Payments.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Amount = record.Amount;
                updatedRecord.Status = record.Status;
                updatedRecord.Transaction_Identification = record.Transaction_Identification;
                updatedRecord.Processed_At = record.Processed_At;
                updatedRecord.Platform_Fee = record.Platform_Fee;
                updatedRecord.Driver_Earnings = record.Driver_Earnings;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}