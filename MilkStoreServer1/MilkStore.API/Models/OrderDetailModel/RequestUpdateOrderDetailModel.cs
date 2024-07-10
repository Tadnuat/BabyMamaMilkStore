namespace MilkStore.API.Models.OrderDetailModel
{
    public class RequestUpdateOrderDetailModel
    {
        public int? OrderId { get; set; }
        public int? CustomerId { get; set; } // Added CustomerId property
        public int? ProductItemId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? ItemName { get; set; }
        public string? Image { get; set; }
        public int? OrderStatus { get; set; }
        public decimal? Discount { get; set; } // Added Discount property
    }
}
