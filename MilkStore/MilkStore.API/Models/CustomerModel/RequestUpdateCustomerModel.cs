namespace MilkStore.API.Models.CustomerModel
{
    public class RequestUpdateCustomerModel
    {
        public string CustomerName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}
