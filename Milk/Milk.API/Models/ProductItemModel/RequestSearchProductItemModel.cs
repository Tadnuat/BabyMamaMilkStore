

namespace MilkStore.API.Models.ProductItemModel
{
    public class RequestSearchProductItemModel
    {
        public string? Benefit { get; set; }

        public string? Description { get; set; }

        public string ItemName { get; set; }

        public double? Weight { get; set; }

        public decimal? FromPrice { get; set; } = decimal.Zero;
        public decimal? ToPrice { get; set; } = null;
        public SortContent? SortContent { get; set; }
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;

    }
    public class SortContent
    {
        public SortProductItemByEnum sortProductItemBy { get; set; }
        public SortProductItemTypeEnum sortProductItemType { get; set; }
    }

    public enum SortProductItemByEnum
    {
        ItemName = 1,
        Weight = 2,
        Price = 3,
    }
    public enum SortProductItemTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }
}
