namespace MilkStore.API.Models.CustomerModel
{
    public class ResponseCustomerModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Phone { get; set; } = null!;
        public int Delete { get; set; }
    }
}