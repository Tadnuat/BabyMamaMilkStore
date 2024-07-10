namespace MilkStore.API.Models.OrderModel
{
    public class ResponseSearchOrderModel
    {
        public List<ResponseOrderModel> Orders { get; set; }
        public decimal? TotalSum { get; set; }
        public int OrderCount { get; set; } // Add OrderCount property
    }
}
