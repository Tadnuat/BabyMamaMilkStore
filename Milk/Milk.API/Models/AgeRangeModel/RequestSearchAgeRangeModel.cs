namespace MilkStore.API.Models.AgeRangeModel
{
    public class RequestSearchAgeRangeModel
    {
        public string? Baby { get; set; }
        public string? Mama { get; set; }
        public int? ProductId { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string SortBy { get; set; }
        public SortTypeEnum SortType { get; set; }
    }

    public enum SortTypeEnum
    {
        Ascending,
        Descending
    }
}
