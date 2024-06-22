namespace MilkStore.API.Models.DeliveryManModel
{
    public class RequestUpdateDeliveryManModel
    {
        public string DeliveryName { get; set; } = null!;

        public string? DeliveryStatus { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public int? StorageId { get; set; }
    }
}
