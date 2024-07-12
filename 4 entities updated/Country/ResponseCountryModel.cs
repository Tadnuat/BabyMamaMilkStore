namespace MilkStore.API.Models.CountryModel
{
    public class ResponseCountryModel
    {
        public int CountryId { get; set; }

        public string CountryName { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int Delete { get; set; }
    }
}
