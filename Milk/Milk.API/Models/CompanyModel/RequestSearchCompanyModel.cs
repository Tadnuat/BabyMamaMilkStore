namespace MilkStore.API.Models.CompanyModel
{
    public class RequestSearchCompanyModel
    {
        public string? CompanyName { get; set; }
        public int? CountryId { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string SortBy { get; set; }
        public SortCompanyTypeEnum SortCompanyType { get; set; }
    }

    public enum SortCompanyTypeEnum
    {
        Ascending,
        Descending
    }
}
