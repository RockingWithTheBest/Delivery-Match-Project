using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;

namespace Backend.Repository.Implementation
{
    public class EarningRepository : IEarnings
    {
        private ApplicationDatabaseContext databaseContext;
        public EarningRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddEarningsRecord(Earnings earns)
        {
            int textVariable = -1;
            if (earns == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Earnings.Add(earns);
                databaseContext.SaveChanges();
                textVariable = earns.Id;
            }
            return textVariable;
        }

        public int DeleteEarningsRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Earnings.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Earnings.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Earnings> GetAllEarnings()
        {
            return databaseContext.Earnings.ToList();
        }

        public Earnings GetSingleRecord(int Id)
        {
            return databaseContext.Earnings.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateEarningsRecord(int Id, Earnings record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Earnings updatedRecord = databaseContext.Earnings.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.GrossAmount = record.GrossAmount;
                updatedRecord.PlatformFee = record.PlatformFee;
                updatedRecord.NetEarnings = record.NetEarnings;
                updatedRecord.IsPaidOut = record.IsPaidOut;
                updatedRecord.EarnedAt = record.EarnedAt;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}