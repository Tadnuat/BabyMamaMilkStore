namespace MilkStore.API.Models.ProductItemModel
{
    public class RequestSearchProductItemModel
    {
        public string? ItemName { get; set; }
        public decimal? FromPrice { get; set; } = decimal.Zero;
        public decimal? ToPrice { get; set; } = null;
        public SortContent? SortContent { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SortContent
    {
        public SortProductItemTypeEnum SortProductItemType { get; set; }
    }

    public enum SortProductItemTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }
}
