

namespace MilkStore.API.Models.AdminModel
{
    public class RequestSearchAdminModel
    {
        public int? AdminId { get; set; }
        public string Username { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        public string sortAdminBy { get; set; }
        public SortAdminTypeEnum sortAdminType { get; set; }
    }

    public enum SortAdminTypeEnum
    {
        Ascending,
        Descending
    }
}
