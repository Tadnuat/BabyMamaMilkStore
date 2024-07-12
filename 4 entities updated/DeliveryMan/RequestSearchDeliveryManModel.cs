namespace MilkStore.API.Models.DeliveryManModel
{
    public class RequestSearchDeliveryManModel
    {
        public string? DeliveryName { get; set; }
        public string? DeliveryStatus { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent? SortContent { get; set; }
    }

    public class SortContent
    {
        public SortDeliveryManTypeEnum sortDeliveryManType { get; set; } = SortDeliveryManTypeEnum.Ascending;
    }

    public enum SortDeliveryManTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}
