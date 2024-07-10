namespace MilkStore.API.Models.AdminModel
{
    public class RequestCreateAdminModel
    {

        public int AdminID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
