namespace MilkStore.API.Models.OrderDetailModel
{
    public class ResponseOrderDetailModel
    {
        public int OrderDetailID { get; set; }
        public int? OrderId { get; set; }

        public int? ProductItemId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }

        public string? OrderDetailStatus { get; set; }
    }
}
