using Backend.Models;

namespace Backend.DTOs
{
    public class BulkOrderDto
    {
        public List<OrderPlacement> OrdersPlacmentsDto { get; set; }
        public List<Order_Items> OrderItemsDto { get; set; }
        public int ClientId { get; set; }
    }
}
