

namespace MilkStore.API.Models.ProductItemModel
{
    public class RequestSearchProductItemModel
    {
        public int ProductItemId { get; set; }

        public string? Benefit { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string ItemName { get; set; }

        public double? Weight { get; set; }

        public int? ProductId { get; set; }

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
        ProductItemId = 1,
        ItemName = 2,
        Weight = 3,
        ProductId = 4,
        Price = 5,
    }
    public enum SortProductItemTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }
}
