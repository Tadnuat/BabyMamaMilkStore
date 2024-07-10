namespace MilkStore.API.Models.StorageModel
{
    public class RequestSearchStorageModel
    {
        public string? StorageName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public SortContent? SortContent { get; set; }
    }

    public class SortContent
    {
        public SortStorageTypeEnum SortStorageType { get; set; } = SortStorageTypeEnum.Ascending;
    }

    public enum SortStorageTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}
