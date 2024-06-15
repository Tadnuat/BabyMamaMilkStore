using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.BrandMilkModel
{
    public class RequestCreateBrandMilkModel
    {
        [Required(ErrorMessage = "BrandName is required")]
        public string BrandName { get; set; }

        public int? CompanyId { get; set; }
    }
}

