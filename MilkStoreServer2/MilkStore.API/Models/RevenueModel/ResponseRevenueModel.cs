
namespace MilkStore.API.Models.RevenueModel
{
    public class ResponseRevenueModel
    {
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; } // Added order count
    }
}
