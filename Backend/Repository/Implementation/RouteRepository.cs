using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Implementation;
using Backend.Repository.Interface;
using System.Net;

namespace Backend.Repository.Implementation
{
    public class RouteRepository : IRoute
    {
        private ApplicationDatabaseContext databaseContext;
        public RouteRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddRoutesRecord(Models.Route route)
        {
            int textVariable = -1;
            if (route == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.Routes.Add(route);
                databaseContext.SaveChanges();
                textVariable = route.Id;
            }
            return textVariable;
        }

        public int DeleteRoutesRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.Routes.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.Routes.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<Models.Route> GetAllRoutes()
        {
            return databaseContext.Routes.ToList();
        }

        public Models.Route GetSingleRecord(int Id)
        {
            return databaseContext.Routes.Where(temp => temp.Id == Id).FirstOrDefault();
        }

        public int UpdateRoutesRecord(int Id, Models.Route record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                Models.Route updatedRecord = databaseContext.Routes.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Route_Data = record.Route_Data;
                updatedRecord.Total_Distance = record.Total_Distance;
                updatedRecord.Estimated_Duration = record.Estimated_Duration;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }
    }
}