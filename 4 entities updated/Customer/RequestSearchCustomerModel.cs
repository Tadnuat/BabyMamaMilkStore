namespace MilkStore.API.Models.CustomerModel
{
    public class RequestSearchCustomerModel
    {

        public string CustomerName { get; set; }
        public int pageIndex { get; set; } = 1; // Default page index
        public int pageSize { get; set; } = 10; // Default page size
        public SortType SortType { get; set; } = SortType.Ascending; // Default sort type
    }

    public enum SortType
    {
        Ascending = 1,
        Descending = 2,
    }
}