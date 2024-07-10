namespace MilkStore.API.Models.RevenueModel
{
    public class ResponseDailyRevenueModel
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; } // Added order count
    }
}
