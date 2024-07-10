using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.AgeRangeModel
{
    public class RequestSearchAgeRangeModel
    {
        public string? Baby { get; set; }
        public string? Mama { get; set; }
        public int? ProductItemID { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        [Required(ErrorMessage = "sortAgeRangeBy is required")]
        public string sortAgeRangenBy { get; set; }
        public SortAgeRangeTypeEnum sortAgeRangeType { get; set; }
    }

    public enum SortAgeRangeTypeEnum
    {
        Ascending = 0,
        Descending = 1
    }
}