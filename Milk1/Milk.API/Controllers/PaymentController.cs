using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.PaymentModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;


namespace MilkStore.API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public PaymentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var responePayments = _unitOfWork.PaymentRepository.Get();
            return Ok(responePayments);
        }
        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var responePayments = _unitOfWork.PaymentRepository.GetByID(id);
            return Ok(responePayments);
        }
        [HttpPost]
        public IActionResult CreatePayment(RequestPaymentlModel requestPaymentlModel)
        {
            var payment = new Payment
            {
                
                Amount = requestPaymentlModel.Amount,
                PaymentMethod = requestPaymentlModel.PaymentMethod,
                OrderId = requestPaymentlModel.OrderId
            };
            _unitOfWork.PaymentRepository.Insert(payment);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, RequestPaymentlModel requestPaymentlModel)
        {
            var existedPayment = _unitOfWork.PaymentRepository.GetByID(id);
            if (existedPayment != null)
            {
                existedPayment.Amount = requestPaymentlModel.Amount;
                existedPayment.PaymentMethod = requestPaymentlModel.PaymentMethod;
                existedPayment.OrderId = requestPaymentlModel.OrderId;
            }
            _unitOfWork.PaymentRepository.Update(existedPayment);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            var existedPayment = _unitOfWork.PaymentRepository.GetByID(id);
            _unitOfWork.PaymentRepository.Delete(existedPayment);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
