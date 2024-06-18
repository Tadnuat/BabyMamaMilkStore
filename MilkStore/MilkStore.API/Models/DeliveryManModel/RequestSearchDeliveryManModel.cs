

namespace MilkStore.API.Models.DeliveryManModel
{
    public class RequestSearchDeliveryManModel
    {
        public int? DeliveryManId { get; set; }
        public string DeliveryName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string sortDeliveryManBy { get; set; }
        public SortDeliveryManTypeEnum sortDeliveryManType { get; set; }
    }

    public enum SortDeliveryManTypeEnum
    {
        Ascending,
        Descending
    }
}
