using Backend.AdditionalClasses;
using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementation
{
    public class OrderPLacementRepository : IOrderPlacement
    {
        private ApplicationDatabaseContext databaseContext;
        public OrderPLacementRepository(ApplicationDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public int AddOrderPlacementRecord(OrderPlacement order_Placement)
        {
            int textVariable = -1;
            if (order_Placement == null)
            {
                return textVariable;
            }
            else
            {
                databaseContext.OrderPlacements.Add(order_Placement);
                databaseContext.SaveChanges();
                textVariable = order_Placement.Id;
            }
            return textVariable;
        }
        public int AddBulkOrdersWithClientId(List<OrderPlacement> BulkOrders, int ClientId)
        {
            if (BulkOrders != null)
            {  
                databaseContext.OrderPlacements.AddRange(BulkOrders);
                databaseContext.SaveChanges(); // This only saves OrderPlacements
                return ClientId;
            }
            else
            {
                return -1;
            }
        }

        public int DeleteOrderPlacementRecord(int Id)
        {
            int testValue = -1;
            if (Id <= 0)
            {
                return testValue;
            }
            var record = databaseContext.OrderPlacements.Find(Id);
            if (record == null)
            {
                return testValue;
            }
            else
            {
                databaseContext.OrderPlacements.Remove(record);
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public IEnumerable<OrderPlacement> GetAllOrderPlacement()
        {
            return databaseContext.OrderPlacements
                .Include(d => d.Order_Items)
                    .ThenInclude(i => i.OrderDimension)
            .ToList();
        }
        public IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByCustomerId(int CustomerId)
        {
            return databaseContext.OrderPlacements.Where(x=>x.Id==CustomerId).ToList();
        }

        public IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByDriverId(int DriverId)
        {
            return databaseContext.OrderPlacements.Where(x => x.Id == DriverId).ToList();
        }
        public OrderPlacement GetSingleRecord(int Id)
        {
            return databaseContext.OrderPlacements.Where(temp => temp.Id == Id).FirstOrDefault();
        }
        public int UpdateOrderPlacementRecord(int Id, OrderPlacement record)
        {
            int testValue = -1;
            if (Id <= 0 || record == null)
            {
                return testValue;
            }
            else
            {
                OrderPlacement updatedRecord = databaseContext.OrderPlacements.Where(temp => temp.Id == Id).FirstOrDefault();
                updatedRecord.Pick_Up_Contact = record.Pick_Up_Contact;
                updatedRecord.Delivery_Contact = record.Delivery_Contact;
                updatedRecord.Delivery_Up_Address = record.Delivery_Up_Address;
                //updatedRecord.Weight = record.Weight;
                //updatedRecord.Volume = record.Volume;
                updatedRecord.Price = record.Price;
                updatedRecord.Description = record.Description;
                //updatedRecord.Distance = record.Distance;
                updatedRecord.Created_At = record.Created_At;
                updatedRecord.Scheduled_At = record.Scheduled_At;
                updatedRecord.Completed_On = record.Completed_On;
                updatedRecord.DriverId = record.DriverId;
                databaseContext.SaveChanges();
                testValue = record.Id;
            }
            return testValue;
        }

        public string AddBulkOrdersWithItems(List<OrderPlacement> orders, List<Order_Items> orderItems, int ClientId)
        {
            
            {
                try
                {
                    if (orders == null || !orders.Any())
                    {
                        return "No orders provided";
                    }

                    if (orderItems == null || !orderItems.Any())
                    {
                        return "No items provided";
                    }

                    if (orderItems.Count != orderItems.Count)
                    {
                        return "Number of orders and order items must match";
                    }

                    var createdOrders = new List<OrderPlacement>();

                    // Add all orders first
                    for(int i=0;i<orders.Count;i++)
                    {
                        var order = orders[i];
                        
                        var orderPlacement = new OrderPlacement
                        {
                            Pick_Up_Address = order.Pick_Up_Address,
                            Delivery_Up_Address = order.Delivery_Up_Address,
                            Pick_Up_Contact = order.Pick_Up_Contact,
                            Delivery_Contact = order.Delivery_Contact,
                            //Weight = order.Weight,
                            //Volume = order.Volume,
                            Description = order.Description,
                            Status = order.Status,
                            Price = order.Price,
                            Created_At = DateTime.Now,
                            Scheduled_At = order.Scheduled_At,
                            Completed_On = order.Completed_On,
                            CustomerId = ClientId
                        };
          

                        databaseContext.OrderPlacements.Add(orderPlacement);
                        databaseContext.SaveChanges();// Save to get the Id
                        createdOrders.Add(orderPlacement);
                        Console.WriteLine("ID", orderPlacement.Id);
                    }
                    
                    for (int i = 0; i < orderItems.Count; i++)
                    {
                        var order = orders[i];
                        var item = orderItems[i];
                        var orderitem = new Order_Items
                        {
                            Item_Name = item.Item_Name,
                            Quantity = item.Quantity,
                            Weight_Per_Item = item.Weight_Per_Item,
                            Special_Instructions = item.Special_Instructions,
                            //Dimension = new OrderDimension
                            //{
                            //    Length = item.Dimension.Length,
                            //    Height = item.Dimension.Height,
                            //    Width = item.Dimension.Width
                            //},
                            OrderDimension = item.OrderDimension,
                            OrderPlacementId = order.Id // Set the relationship
                        };

                        databaseContext.OrderItems.Add(item);
                        databaseContext.SaveChanges();
                    }

                    // Now add order items with the generated Order IDs



                    //commit transaction
          

                    return $"Successfully added {orders.Count} orders with their items";
                    //return createdOrders;
                }
                catch (Exception ex)
                {
                    //transaction.Rollback();
                    return $"Error: {ex.Message}";
                }
            }
            
        }
    }
}
