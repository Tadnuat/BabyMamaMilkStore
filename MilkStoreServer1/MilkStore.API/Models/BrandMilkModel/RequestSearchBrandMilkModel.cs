using MilkStore.API.Models.AdminModel;
using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.BrandMilkModel
{
    public class RequestSearchBrandMilkModel
    {
        public string BrandName { get; set; }

        public int? CompanyID { get; set; }

        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public SortContentModel SortContent { get; set; }
    }

    public class SortContentModel
    {
        [Required(ErrorMessage = "sortBrandMilkBy is required")]
        public string sortBrandMilkBy { get; set; }
        public SortAdminTypeEnum sortBrandMilkType { get; set; }
    }

    public enum SortBrandMilkTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}