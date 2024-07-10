namespace MilkStore.API.Models.VnPayModel
{
    public interface IVnPayService
    {
        string CreatePayMentUrl(HttpContext context, VnPayMentRequestModel model);

        VnPaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
