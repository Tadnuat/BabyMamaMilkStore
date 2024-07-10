using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.AgeRangeModel
{
    public class ResponseCompanyModel
    {
        public string CompanyName { get; set; } = null!;
        public int? CountryID { get; set; }
    }
}
