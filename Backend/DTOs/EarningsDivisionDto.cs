namespace Backend.DTOs
{
    public class EarningsDivisionDto
    {
        public List<OrderStatusEarningsDto> deliveredOrders {  get; set; }
        public List<OrderStatusEarningsDto> intransitOrders { get; set; }
        public List<OrderStatusEarningsDto> pendingOrders { get; set; }
        public List<OrderStatusEarningsDto> cancelledOrders { get; set; }
        public List<OrderStatusEarningsDto> confirmedOrders { get; set; }
        public EarningsDivisionDto()
        {
            deliveredOrders = new List<OrderStatusEarningsDto>();
            intransitOrders = new List<OrderStatusEarningsDto>();
            pendingOrders = new List<OrderStatusEarningsDto>();
            cancelledOrders = new List<OrderStatusEarningsDto>();
            confirmedOrders = new List<OrderStatusEarningsDto>();
        }
    }
}
