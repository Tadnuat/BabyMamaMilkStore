using MilkStore.API.Models.AdminModel;
using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.CompanyModel
{
    public class RequestSearchCompanyModel
    {
        public string? CompanyName { get; set; }
        public int? CountryID { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageSize { get; set; } = 10;
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        [Required(ErrorMessage = "sortCompanyBy is required")]
        public string sortCompanyBy { get; set; }
        public SortAdminTypeEnum sortCompanyType { get; set; }
    }

    public enum SortCompanyTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}
