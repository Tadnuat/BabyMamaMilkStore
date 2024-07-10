using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.BrandMilkModel
{
    public class RequestUpdateCompanyModel

    {

        public string CompanyName { get; set; } = null!;
        public int? CountryID { get; set; }
    }
}

