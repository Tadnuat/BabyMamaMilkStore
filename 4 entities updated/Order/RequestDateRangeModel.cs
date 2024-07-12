using System;

namespace MilkStore.API.Models.OrderModel
{
    public class RequestDateRangeModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
