namespace MilkStore.API.Models.DeliveryManModel
{
    public class RequestUpdateDeliveryManModel
    {
        public string DeliveryName { get; set; } = null!;

        public string? DeliveryStatus { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public int? StorageId { get; set; }
        public string StorageName { get; set; } = null!;
        private int _delete;
        public int Delete
        {
            get => _delete;
            set => _delete = value == 0 || value == 1 ? value : 1;
        }
    }
}