namespace MilkStore.API.Models.AdminModel
{
    public class RequestCreateAdminModel
    {

       
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Delete { get; set; } = null!;
    }
}
