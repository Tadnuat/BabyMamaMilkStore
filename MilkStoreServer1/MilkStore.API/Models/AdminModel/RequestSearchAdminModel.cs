

using System.ComponentModel.DataAnnotations;

namespace MilkStore.API.Models.AdminModel
{
    public class RequestSearchAdminModel
    {
        public int? AdminID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public SortContent SortContent { get; set; }
    }

    public class SortContent
    {
        [Required(ErrorMessage = "sortAdminBy is required")]
        public string sortAdminBy { get; set; }
        public SortAdminTypeEnum sortAdminType { get; set; }
    }

    public enum SortAdminTypeEnum
    {
        Ascending = 0,
        Descending = 1
    }
}
