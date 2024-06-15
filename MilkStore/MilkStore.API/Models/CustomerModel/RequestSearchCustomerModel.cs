

namespace MilkStore.API.Models.CustomerModel
{
    public class RequestSearchCustomerModel
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string sortCustomerBy { get; set; }
        public SortCustomerTypeEnum sortCustomerType { get; set; }
    }

    public enum SortCustomerTypeEnum
    {
        Ascending,
        Descending
    }
}
