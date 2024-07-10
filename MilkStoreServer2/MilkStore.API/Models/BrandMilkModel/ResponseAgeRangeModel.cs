using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.AgeRangeModel
{
    public class ResponseBrandMilkModel
    {
        //public int BrandMilkID { get; set; }

        [Required(ErrorMessage = "BrandName is required")]
        public string BrandName { get; set; }

        public int? CompanyID { get; set; }
    }
}
