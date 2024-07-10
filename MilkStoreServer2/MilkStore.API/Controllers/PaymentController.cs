using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.PaymentModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;
using Microsoft.AspNetCore.Cors;


namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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
            var payments = _unitOfWork.PaymentRepository.Get()
                                    .Select(payment => new ResponsePaymentModel
                                    {
                                        PaymentId = payment.PaymentId,
                                        Amount = payment.Amount,
                                        PaymentMethod = payment.PaymentMethod,
                                        OrderId = payment.OrderId
                                    })
                                    .ToList();

            return Ok(payments);
        }
        [HttpGet("{id}")]
        public IActionResult GetPaymentById(int id)
        {
            var payment = _unitOfWork.PaymentRepository.GetByID(id);

            if (payment == null)
            {
                return NotFound(); // Handle the not found case appropriately
            }

            var responsePayment = new ResponsePaymentModel
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                OrderId = payment.OrderId
            };

            return Ok(responsePayment);
        }
        [HttpPost]
        public IActionResult CreatePayment(RequestCreatePaymentlModel requestCreatePaymentlModel)
        {
            var payment = new Payment
            {
                PaymentId = requestCreatePaymentlModel.PaymentId,
                Amount = requestCreatePaymentlModel.Amount,
                PaymentMethod = requestCreatePaymentlModel.PaymentMethod,
                OrderId = requestCreatePaymentlModel.OrderId
            };
            _unitOfWork.PaymentRepository.Insert(payment);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayment(int id, RequestUpdatePaymentlModel requestUpdatePaymentlModel)
        {
            var existedPayment = _unitOfWork.PaymentRepository.GetByID(id);
            if (existedPayment != null)
            {
                existedPayment.Amount = requestUpdatePaymentlModel.Amount;
                existedPayment.PaymentMethod = requestUpdatePaymentlModel.PaymentMethod;
                existedPayment.OrderId = requestUpdatePaymentlModel.OrderId;
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
