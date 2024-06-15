namespace MilkStore.API.Models.OrderDetailModel
{
    public class RequestCreateOrderDetailModel
    {
        public int OrderDetailId { get; set; }

        public int? OrderId { get; set; }

        public int? ProductItemId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string ItemName { get; set; } = null!;

        public string? Image { get; set; }

    }
}
