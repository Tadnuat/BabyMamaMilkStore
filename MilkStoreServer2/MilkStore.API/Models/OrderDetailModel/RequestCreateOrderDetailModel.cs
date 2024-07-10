namespace MilkStore.API.Models.OrderDetailModel
{
    public class RequestCreateOrderDetailModel
    {
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int? CustomerId { get; set; } // Added CustomerId property

        public int? ProductItemId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Image { get; set; }

        public int? OrderStatus { get; set; }  // Added OrderStatus property

        public decimal? Discount { get; set; } // Added Discount property
    }
}
