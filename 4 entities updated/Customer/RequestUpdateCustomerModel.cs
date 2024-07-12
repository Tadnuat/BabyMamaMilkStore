namespace MilkStore.API.Models.CustomerModel
{
    public class RequestUpdateCustomerModel
    {
        public string? CustomerName { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public string? Phone { get; set; } = null!;
        private int _delete;
        public int Delete
        {
            get => _delete;
            set => _delete = value == 0 || value == 1 ? value : 1;
        }
    }
}