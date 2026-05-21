using Backend.DatabasContext;
using Backend.DTOs;
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

        public IEnumerable<Earnings> GetAllEarnings()
        {
            return databaseContext.Earnings.ToList();
        }
        
        public IEnumerable<Earnings> GetAListOfEarningsByDriverId(int DriverId)
        {
            return databaseContext.Earnings
                .Where(e=>e.DriverId == DriverId)
                .ToList();
        }

        public void PopularEarnings()
        {
            var orders = databaseContext.OrderPlacements
                .ToList();

            foreach (var order in orders)
            {
                if(order.DriverId> 0)
                {                
                    databaseContext.Earnings.Add(
                        new Earnings()
                        {
                            GrossAmount = order.Price,
                            EarnedAt = new DateOnly(),
                            Status = order.Status,
                            DriverId = order.DriverId,
                            OrderPlacementId = order.Id
                        }
                    );
                }
            }
            databaseContext.SaveChanges();
        }
        public EarningsDivisionDto EarningDivionsByStatus(int DriverId)
        {
            var orders = databaseContext.OrderPlacements
                .Where(o=>o.DriverId == DriverId)
                .ToList();

            var deliveredOrders = new List<OrderStatusEarningsDto>();
            var intransitOrders = new List<OrderStatusEarningsDto>();
            var pendingOrders = new List<OrderStatusEarningsDto>();
            var cancelledOrders = new List<OrderStatusEarningsDto>();
            var confirmedOrders = new List<OrderStatusEarningsDto>();


            foreach (var orderItem in orders)
            {
                if (orderItem.Status == "Delivered")
                {
                    deliveredOrders.Add(
                        new OrderStatusEarningsDto()
                        {
                            Status = orderItem.Status, 
                            Amount = orderItem.Price, 
                            StatusEarningId = orderItem.Id
                        }
                    );
                }
                else if(orderItem.Status =="In Transit")
                {
                    intransitOrders.Add(
                        new OrderStatusEarningsDto()
                        {
                            Status = orderItem.Status,
                            Amount = orderItem.Price,
                            StatusEarningId = orderItem.Id
                        }
                    );
                }
                else if(orderItem.Status == "Pending")
                {
                    pendingOrders.Add(
                        new OrderStatusEarningsDto()
                        {
                            Status = orderItem.Status,
                            Amount = orderItem.Price,
                            StatusEarningId = orderItem.Id
                        }
                    );
                }
                else if(orderItem.Status == "Cancelled")
                {
                    cancelledOrders.Add(
                        new OrderStatusEarningsDto()
                        {
                            Status = orderItem.Status,
                            Amount = orderItem.Price,
                            StatusEarningId = orderItem.Id
                        }
                    );
                }
                else if(orderItem.Status == "Confirmed")
                {
                    confirmedOrders.Add(
                        new OrderStatusEarningsDto()
                        {
                            Status = orderItem.Status,
                            Amount = orderItem.Price,
                            StatusEarningId = orderItem.Id
                        }
                    );
                }
            }

            return new EarningsDivisionDto()
            {
                deliveredOrders = deliveredOrders,
                intransitOrders = intransitOrders,
                pendingOrders = pendingOrders,
                cancelledOrders = cancelledOrders,
                confirmedOrders = confirmedOrders
            };
        }
    }
}