namespace MilkStore.API.Models.PaymentModel
{
    public class ResponsePaymentModel
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public int? OrderId { get; set; }
    }
}
