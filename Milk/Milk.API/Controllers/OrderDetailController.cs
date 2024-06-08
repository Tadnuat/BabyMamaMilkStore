using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.OrderDetailModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;


namespace MilkStore.API.Controllers
{
    [Route("api/orderdetails")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderDetailController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var responeOrderDetails = _unitOfWork.OrderDetailRepository.Get();
            return Ok(responeOrderDetails);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var responeOrderDetails = _unitOfWork.OrderDetailRepository.GetByID(id);
            return Ok(responeOrderDetails);
        }
        [HttpPost]
        public IActionResult CreateOrderDetail(RequestOrderDetailModel requestOrderDetailModel)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = requestOrderDetailModel.OrderId,
                ProductItemId = requestOrderDetailModel.ProductItemId,
                Quantity = requestOrderDetailModel.Quantity,
                Price = requestOrderDetailModel.Price,
                OrderDetailStatus = requestOrderDetailModel.OrderDetailStatus,
            };
            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, RequestOrderDetailModel requestOrderDetailModel)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail != null)
            {
                existedOrderDetail.OrderId = requestOrderDetailModel.OrderId;
                existedOrderDetail.ProductItemId = requestOrderDetailModel.ProductItemId;
                existedOrderDetail.Quantity = requestOrderDetailModel.Quantity;
                existedOrderDetail.Price = requestOrderDetailModel.Price;
                existedOrderDetail.OrderDetailStatus = requestOrderDetailModel.OrderDetailStatus;
            }
            _unitOfWork.OrderDetailRepository.Update(existedOrderDetail);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            _unitOfWork.OrderDetailRepository.Delete(existedOrderDetail);
            _unitOfWork.Save();
            return Ok();
        }

    }
}
