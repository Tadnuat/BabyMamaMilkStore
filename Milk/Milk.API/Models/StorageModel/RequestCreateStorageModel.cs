namespace MilkStore.API.Models.StorageModel
{
    public class RequestCreateStorageModel
    {
        public int StorageId { get; set; }

        public string StorageName { get; set; } = null!;
    }
}
