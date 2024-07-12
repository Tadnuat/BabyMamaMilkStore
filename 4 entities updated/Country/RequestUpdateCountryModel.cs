namespace MilkStore.API.Models.CountryModel
{
    public class RequestUpdateCountryModel
    {
        public string? CountryName { get; set; } = null!;
        public string? Image { get; set; } = null!;
        private int _delete;
        public int Delete
        {
            get => _delete;
            set => _delete = value == 0 || value == 1 ? value : 1;
        }
    }
}