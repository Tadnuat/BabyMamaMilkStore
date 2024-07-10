using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.RevenueModel;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/revenue")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class RevenueController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public RevenueController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthlyRevenue(int year)
        {
            if (year == 0)
            {
                return BadRequest("Year is required.");
            }

            var monthlyRevenues = new List<ResponseMonthlyRevenueModel>();

            for (int month = 1; month <= 12; month++)
            {
                var startDate = new DateOnly(year, month, 1);
                var endDate = startDate.AddMonths(1);

                var monthlyRevenue = _unitOfWork.OrderRepository.Get(o => o.OrderDate.HasValue && o.OrderDate.Value.Year == year && o.OrderDate.Value.Month == month)
                                     .GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month })
                                     .Select(g => new ResponseRevenueModel
                                     {
                                         Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                                         TotalRevenue = g.Sum(o => o.TotalAmount) ?? 0
                                     })
                                     .FirstOrDefault();

                var orderCount = _unitOfWork.OrderRepository.Count(o => o.OrderDate.HasValue && o.OrderDate.Value.Year == year && o.OrderDate.Value.Month == month);

                if (monthlyRevenue != null)
                {
                    monthlyRevenues.Add(new ResponseMonthlyRevenueModel
                    {
                        Month = startDate.Month,
                        Year = startDate.Year,
                        TotalRevenue = monthlyRevenue.TotalRevenue,
                        OrderCount = orderCount
                    });
                }
                else
                {
                    monthlyRevenues.Add(new ResponseMonthlyRevenueModel
                    {
                        Month = startDate.Month,
                        Year = startDate.Year,
                        TotalRevenue = 0,
                        OrderCount = 0
                    });
                }
            }

            var totalYearlyRevenue = monthlyRevenues.Sum(m => m.TotalRevenue);

            return Ok(new { MonthlyRevenues = monthlyRevenues, TotalYearlyRevenue = totalYearlyRevenue });
        }

        [HttpGet("daily")]
        public IActionResult GetDailyRevenue(int year, int month, int day)
        {
            var selectedDate = new DateOnly(year, month, day);

            var dailyRevenue = _unitOfWork.OrderRepository.Get(o => o.OrderDate.HasValue && o.OrderDate.Value.Year == year && o.OrderDate.Value.Month == month && o.OrderDate.Value.Day == day)
                                   .GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month, o.OrderDate.Value.Day })
                                   .Select(g => new ResponseDailyRevenueModel
                                   {
                                       Day = g.Key.Day,
                                       Month = g.Key.Month,
                                       Year = g.Key.Year,
                                       TotalRevenue = g.Sum(o => o.TotalAmount) ?? 0,
                                       OrderCount = g.Count() // Count of orders for the day
                                   })
                                   .FirstOrDefault();

            if (dailyRevenue == null)
            {
                return NotFound("No revenue data found for the specified date.");
            }

            var response = new ResponseDailyRevenueModel
            {
                Day = dailyRevenue.Day,
                Month = dailyRevenue.Month,
                Year = dailyRevenue.Year,
                TotalRevenue = dailyRevenue.TotalRevenue,
                OrderCount = dailyRevenue.OrderCount
            };

            return Ok(response);
        }

        [HttpGet("weekly")]
        public IActionResult GetWeeklyRevenue(int year = 0, int weekNumber = 0)
        {
            if (year == 0 && weekNumber == 0)
            {
                // Use current week if no specific week is requested
                var currentDate = DateTime.Now;
                year = currentDate.Year;
                weekNumber = GetIso8601WeekOfYear(currentDate);
            }

            var firstDayOfWeek = GetFirstDayOfWeek(year, weekNumber);
            var lastDayOfWeek = firstDayOfWeek.AddDays(7);

            var weeklyRevenue = _unitOfWork.OrderRepository.Get(o =>
                o.OrderDate.HasValue &&
                o.OrderDate.Value.Date >= firstDayOfWeek &&
                o.OrderDate.Value.Date < lastDayOfWeek)
                .GroupBy(o => new { Year = o.OrderDate.Value.Year, WeekNumber = GetIso8601WeekOfYear(o.OrderDate.Value) })
                .Select(g => new ResponseWeeklyRevenueModel
                {
                    Year = g.Key.Year,
                    WeekNumber = g.Key.WeekNumber,
                    TotalRevenue = g.Sum(o => o.TotalAmount) ?? 0,
                    OrderCount = g.Count() // Count of orders for the week
                })
                .FirstOrDefault();

            if (weeklyRevenue == null)
            {
                weeklyRevenue = new ResponseWeeklyRevenueModel
                {
                    Year = year,
                    WeekNumber = weekNumber,
                    TotalRevenue = 0,
                    OrderCount = 0 // No orders for the week
                };
            }

            return Ok(weeklyRevenue);
        }

        [HttpGet("range")]
        public IActionResult GetRevenueInRange(DateTime startDate, DateTime endDate)
        {
            // Ensure start date is less than or equal to end date
            if (startDate > endDate)
            {
                return BadRequest("Start date must be less than or equal to end date.");
            }

            var revenueInRange = _unitOfWork.OrderRepository.Get(o =>
                o.OrderDate.HasValue &&
                o.OrderDate.Value.Date >= startDate &&
                o.OrderDate.Value.Date <= endDate)
                .GroupBy(o => new { o.OrderDate.Value.Date })
                .Select(g => new ResponseDailyRevenueModel
                {
                    Day = g.Key.Date.Day,
                    Month = g.Key.Date.Month,
                    Year = g.Key.Date.Year,
                    TotalRevenue = g.Sum(o => o.TotalAmount) ?? 0,
                    OrderCount = g.Count() // Count of orders for each day in range
                })
                .ToList();

            if (revenueInRange.Count == 0)
            {
                return NotFound("No revenue data found for the specified date range.");
            }

            return Ok(revenueInRange);
        }

        // Helper method to get the first day of a week based on ISO 8601
        private DateTime GetFirstDayOfWeek(int year, int weekNumber)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = System.Globalization.CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekNumber;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        // Helper method to get ISO 8601 week number
        private int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = System.Globalization.CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return System.Globalization.CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, System.Globalization.CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
}
