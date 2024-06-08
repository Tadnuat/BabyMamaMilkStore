namespace MilkStore.API.Models.PaymentModel
{
    public class RequestPaymentlModel
    {
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = null!;

        public int? OrderId { get; set; }
    }
}
