namespace MilkStore.API.Models.ProductModel
{
    public class RequestCreateProductModel
    {
        public string ProductName { get; set; } = null!;

        public int? BrandMilkId { get; set; }

        public int? AdminId { get; set; }
    }
}
