namespace MilkStore.API.Models.DeliveryManModel
{
    public class RequestCreateDeliveryManModel
    {

        public int DeliveryManId { get; set; }

        public string? DeliveryName { get; set; }
        public string? DeliveryStatus { get; set; }
        public string? PhoneNumber { get; set; }
        public int? StorageId { get; set; }
        public string StorageName { get; set; } = null!;
        

    }
}
