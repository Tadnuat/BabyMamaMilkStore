namespace MilkStore.API.Models.CountryModel
{
    public class RequestCreateCountryModel
    {

        public int CountryId { get; set; }

        public string? CountryName { get; set; }
        public string Image { get; set; } = null!;
        

    }
}