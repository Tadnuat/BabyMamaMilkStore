namespace MilkStore.API.Models.ProductItemModel
{
    public class RequestUpdateProductItemModel
    {
        public string? Benefit { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public string ItemName { get; set; } = null!;

        public decimal? Price { get; set; }

        public double? Weight { get; set; }

        public int? BrandMilkId { get; set; }

        public string? Baby { get; set; }

        public string? Mama { get; set; }

        public string BrandName { get; set; } = null!;

        public string CountryName { get; set; } = null!;

        public string CompanyName { get; set; } = null!;
    }
}
