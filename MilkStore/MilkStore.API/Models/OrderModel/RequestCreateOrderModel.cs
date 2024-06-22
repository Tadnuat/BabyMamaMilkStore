namespace MilkStore.API.Models.OrderModel
{
    public class RequestCreateOrderModel
    {

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public int? DeliveryManId { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string ShippingAddress { get; set; } = null!;

        public decimal? TotalAmount { get; set; }

        public int? StorageId { get; set; }
    }
}
