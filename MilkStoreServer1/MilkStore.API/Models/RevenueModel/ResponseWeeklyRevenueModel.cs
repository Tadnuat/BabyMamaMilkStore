namespace MilkStore.API.Models.RevenueModel
{
    public class ResponseWeeklyRevenueModel
    {
        public int WeekNumber { get; set; }
        public int Year { get; set; }
        public decimal TotalRevenue { get; set; }
        public int OrderCount { get; set; } // Added order count
    }
}
