

namespace MilkStore.API.Models.OrderModel
{
    public class RequestSearchOrderModel
    {
        public int? OrderId { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string sortOrderBy { get; set; }
        public SortOrderTypeEnum sortOrderType { get; set; }
    }

    public enum SortOrderTypeEnum
    {
        Ascending,
        Descending
    }
}
