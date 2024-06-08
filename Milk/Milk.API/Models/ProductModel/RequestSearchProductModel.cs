namespace MilkStore.API.Models.ProductModel
{
    public class RequestSearchProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int? BrandMilkId { get; set; }

        public int? AdminId { get; set; }
        public SortContent? SortContent { get; set; }
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 10;

    }
    public class SortContent
    {
        public SortProductByEnum sortProductBy { get; set; }
        public SortProductTypeEnum sortProductType { get; set; }
    }

    public enum SortProductByEnum
    {
        ProductId = 1,
        ProductName = 2,
        BrandMilkId = 3,
        AdminId = 4,
    }
    public enum SortProductTypeEnum
    {
        Ascending = 1,
        Descending = 2,
    }
}

