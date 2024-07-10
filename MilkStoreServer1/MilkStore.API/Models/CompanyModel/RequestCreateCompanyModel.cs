namespace MilkStore.API.Models.CompanyModel
{
    public class RequestCreateCompanyModel
    {
        public string CompanyName { get; set; } = null!;
        public int? CountryID { get; set; }
    }
}
