using System.Globalization;

namespace MilkStore.API.Models.RevenueModel
{
    public class RequestWeeklyRevenueModel
    {
        public int Year { get; set; } = DateTime.UtcNow.Year;
        public int WeekNumber { get; set; } = GetCurrentIso8601Week();

        private static int GetCurrentIso8601Week()
        {
            DateTime currentDate = DateTime.UtcNow;
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(currentDate);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                currentDate = currentDate.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
