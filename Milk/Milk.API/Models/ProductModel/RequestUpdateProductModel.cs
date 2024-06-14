namespace MilkStore.API.Models.ProductModel
{
    public class RequestUpdateProductModel
    {

        public string ProductName { get; set; } = null!;

        public int? BrandMilkId { get; set; }

        public int? AdminId { get; set; }
    }
}
