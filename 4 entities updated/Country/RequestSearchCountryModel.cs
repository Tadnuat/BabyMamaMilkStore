

namespace MilkStore.API.Models.CountryModel
{
    public class RequestSearchCountryModel
    {
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string sortCountryBy { get; set; }
        public SortCountryTypeEnum sortCountryType { get; set; }
    }

    public enum SortCountryTypeEnum
    {
        Ascending,
        Descending
    }
}
