using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Backend.Repository.Implementation
{
    public class OrderPLacementRepository : IOrderPlacement
    {
        private ApplicationDatabaseContext databaseContext;
        private readonly HttpClient _httpClient;
        private readonly ILogger<OrderPlacement> logger;
        public OrderPLacementRepository(ApplicationDatabaseContext databaseContext, ILogger<OrderPlacement>log)
        {
            this.databaseContext = databaseContext;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "BackendApp/1.0");
            logger = log;
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
                .Include(d => d.OrderItems)
                    .ThenInclude(i => i.OrderDimension)
                .Include(i=>i.OrderTrackings)
            .ToList();
        }
        public IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByCustomerId(int CustomerId)
        {
            return databaseContext.OrderPlacements
                .Where(x=>x.CustomerId==CustomerId && x.DriverId != null)
                .Include(i => i.OrderItems)
                .ThenInclude(i => i.OrderDimension)
                .ToList();
        }

        public IEnumerable<OrderPlacement> GetAllOrderPlacementRecordsByDriverId(int DriverId)
        {
            return databaseContext.OrderPlacements
                .Where(x => x.DriverId == DriverId  && x.CustomerId != null)
                .ToList();
        }
        public OrderPlacement GetSingleRecord(int Id)
        {
            return databaseContext.OrderPlacements
                .Where(temp => temp.Id == Id)
                .Include(i=>i.OrderItems)
                .ThenInclude(i=>i.OrderDimension)
                .FirstOrDefault();
        }
        public int UpdateOrderPlacementRecord(int Id, OrderPlacement record)
        {
            try
            {
                int testValue = -1;
                if (Id <= 0 || record == null)
                {
                    return testValue;
                }
                else
                {
                    OrderPlacement updatedRecord = databaseContext.OrderPlacements
                        .Where(temp => temp.Id == Id)
                        .FirstOrDefault();

                    updatedRecord.PickUpContact = record.PickUpContact;
                    updatedRecord.DeliveryContact = record.DeliveryContact;
                    updatedRecord.DeliveryUpAddress = record.DeliveryUpAddress;
                    updatedRecord.Status = record.Status;
                    updatedRecord.Price = record.Price;
                    updatedRecord.Description = record.Description;
                    updatedRecord.CreatedAt = record.CreatedAt;
                    updatedRecord.ScheduledAt = record.ScheduledAt;
                    updatedRecord.CompletedOn = record.CompletedOn;
                    updatedRecord.DriverId = record.DriverId;
                    databaseContext.SaveChanges();

                    //var notification = new Notification()
                    //{
                    //    Type = "order update",
                    //    Message = record.Status,
                    //    CreatedAt = DateTime.Now,
                    //    IsRead = false,
                    //    CustomerId = record.CustomerId,
                    //    DriverId = (int)record.DriverId,
                    //    OrderPlacementId = Id,
                    //    DriverCommentry = "Driver updated the order status"
                    //};

                    //databaseContext.Notifications.Add(notification);
                    databaseContext.SaveChanges();
                    testValue = Id;              
                }
                return testValue;
            }
            catch(Exception ex)
            {
                logger.LogWarning($"Error Message {ex.Message} \n Error Stack {ex.StackTrace}");
                return -1;
            }
        }

        public string AddBulkOrdersWithItems(List<OrderPlacement> orders, List<OrderItems> orderItems, int ClientId)
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
                            PickUpAddress = order.PickUpAddress,
                            DeliveryUpAddress = order.DeliveryUpAddress,
                            PickUpContact = order.PickUpContact,
                            DeliveryContact = order.DeliveryContact,
                            //Weight = order.Weight,
                            //Volume = order.Volume,
                            Description = order.Description,
                            Status = order.Status,
                            Price = order.Price,
                            CreatedAt = DateTime.Now,
                            ScheduledAt = order.ScheduledAt,
                            CompletedOn = order.CompletedOn,
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
                        var orderitem = new OrderItems
                        {
                            ItemName = item.ItemName,
                            Quantity = item.Quantity,
                            //WeightPerItem = item.WeightPerItem,
                            SpecialInstructions = item.SpecialInstructions,
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

        public async Task<OrderPlacement> SettingDeliveryAddressName(int OrderPlacementId, OrderPlacement orderPlacement)
        {
            var OrderPlacement = databaseContext.OrderPlacements
                                    .Where(i=>i.Id == OrderPlacementId)
                                    .FirstOrDefault();

            var OrderTrackingDeliveryLocation = databaseContext.OrderTrackings
                                    .Where(i=>i.OrderPlacementId == OrderPlacementId)
                                    //.Select(o => o.DeliveryLocation)
                                    .FirstOrDefault();

            string[] addressParts = OrderTrackingDeliveryLocation.DeliveryLocation.Split(',', StringSplitOptions.RemoveEmptyEntries);
            if (addressParts.Length < 2)
            {
                throw new InvalidOperationException($"Invalid delivery location format: '{OrderTrackingDeliveryLocation.DeliveryLocation}'");
            }
            if (OrderPlacement == null)
            {
                return new OrderPlacement();
            }
            else
            {
                double lat = double.Parse(addressParts[0].Trim());
                double lon = double.Parse(addressParts[1].Trim());

                string url = $"https://nominatim.openstreetmap.org/reverse?lat={lat}&lon={lon}&format=json";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();


                using JsonDocument document = JsonDocument.Parse(jsonResponse);
                JsonElement root = document.RootElement;


                if (root.TryGetProperty("display_name", out JsonElement displayName))
                {
                    OrderPlacement.PickUpContact = orderPlacement.PickUpContact;
                    OrderPlacement.DeliveryContact = orderPlacement.DeliveryContact;
                    OrderPlacement.Status = orderPlacement.Status;
                    OrderPlacement.Price = orderPlacement.Price;
                    OrderPlacement.Description = orderPlacement.Description;
                    OrderPlacement.CreatedAt = orderPlacement.CreatedAt;
                    OrderPlacement.ScheduledAt = orderPlacement.ScheduledAt;
                    OrderPlacement.CompletedOn = orderPlacement.CompletedOn;
                    OrderPlacement.DriverId = orderPlacement.DriverId;

                    OrderPlacement.PickUpAddress = orderPlacement.PickUpAddress;
                    OrderPlacement.DeliveryUpAddress = displayName.GetString();
                    databaseContext.SaveChanges();
                }
                return OrderPlacement;
            }
        }
    }
}
