namespace MilkStore.API.Models.ProductItemModel
{
    public class RequestSearchProductItemModel
    {
        public string? ItemName { get; set; }
        public decimal? FromPrice { get; set; } = decimal.Zero;
        public decimal? ToPrice { get; set; } = null;
        public string? Mama { get; set; }
        public string? Baby { get; set; }
        public string? Benefit { get; set; }
        public string? BrandName { get; set; }
        public string? CountryName { get; set; }
        public string? CompanyName { get; set; }
        public SortContent? SortContent { get; set; }
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class SortContent
    {
        public SortProductItemTypeEnum? SortProductItemType { get; set; }
        public SortByPropertyEnum? SortByProperty { get; set; } = SortByPropertyEnum.Price;
    }

    public enum SortProductItemTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }

    public enum SortByPropertyEnum
    {
        Price = 1,
        Mama = 2,
        Baby = 3
    }
}
