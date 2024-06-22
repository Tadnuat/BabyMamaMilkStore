namespace MilkStore.API.Models.OrderModel
{
    public class RequestSearchOrderModel
    {
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public SortOrderTypeEnum sortOrderType { get; set; }
    }

    public enum SortOrderTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}
