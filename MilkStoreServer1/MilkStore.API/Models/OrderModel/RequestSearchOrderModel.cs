namespace MilkStore.API.Models.OrderModel
{
    public class RequestSearchOrderModel
    {
        public int? CustomerId { get; set; } // Thêm CustomerId để tìm kiếm theo CustomerId
        public int? PageIndex { get; set; }
        public int? PageSize { get; set; }
        public string? Status { get; set; } // Thêm trường status để tìm kiếm theo status
        public SortContent? sortContent { get; set; } = new SortContent { SortOrderType = SortOrderTypeEnum.Ascending }; // Sắp xếp mặc định tăng dần

        // Thêm thuộc tính để search theo ngày tháng năm
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }

        public class SortContent
        {
            public SortOrderTypeEnum SortOrderType { get; set; }
        }
    }

    public enum SortOrderTypeEnum
    {
        Ascending = 1,
        Descending = 2
    }
}
