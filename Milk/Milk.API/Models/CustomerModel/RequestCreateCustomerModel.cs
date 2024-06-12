namespace MilkStore.API.Models.CustomerModel
{
    public class RequestCreateCustomerModel
    {

        //public int CustomerId { get; set; }

        public string? CustomerName { get; set; }
        public string? Email { get; set;}
        public string? Password { get; set; }

    }
}
