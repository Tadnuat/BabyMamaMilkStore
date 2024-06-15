namespace MilkStore.API.Models.ProductModel
{
    public class ResponseProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public int? BrandMilkId { get; set; }

        public int? AdminId { get; set; }

    }
}
