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
            var orderDetails = _unitOfWork.OrderDetailRepository.Get()
                                    .Select(orderDetail => new ResponseOrderDetailModel
                                    {
                                        OrderDetailID = orderDetail.OrderDetailId,
                                        OrderId = orderDetail.OrderId,
                                        ProductItemId = orderDetail.ProductItemId,
                                        Quantity = orderDetail.Quantity,
                                        Price = orderDetail.Price,
                                        OrderDetailStatus = orderDetail.OrderDetailStatus
                                    })
                                    .ToList();

            return Ok(orderDetails);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetailById(int id)
        {
            var orderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);

            if (orderDetail == null)
            {
                return NotFound(); // Assuming you handle not found cases this way
            }

            var responseOrderDetail = new ResponseOrderDetailModel
            {
                OrderDetailID = orderDetail.OrderDetailId,
                OrderId = orderDetail.OrderId,
                ProductItemId = orderDetail.ProductItemId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                OrderDetailStatus = orderDetail.OrderDetailStatus
            };

            return Ok(responseOrderDetail);
        }
        [HttpPost]
        public IActionResult CreateOrderDetail(RequestCreateOrderDetailModel requestCreateOrderDetailModel)
        {
            var orderDetail = new OrderDetail
            {
                OrderDetailId = requestCreateOrderDetailModel.OrderDetailID,
                OrderId = requestCreateOrderDetailModel.OrderId,
                ProductItemId = requestCreateOrderDetailModel.ProductItemId,
                Quantity = requestCreateOrderDetailModel.Quantity,
                Price = requestCreateOrderDetailModel.Price,
                OrderDetailStatus = requestCreateOrderDetailModel.OrderDetailStatus,
            };
            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, RequestUpdateOrderDetailModel requestUpdateOrderDetailModel)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail != null)
            {
                existedOrderDetail.OrderId = requestUpdateOrderDetailModel.OrderId;
                existedOrderDetail.ProductItemId = requestUpdateOrderDetailModel.ProductItemId;
                existedOrderDetail.Quantity = requestUpdateOrderDetailModel.Quantity;
                existedOrderDetail.Price = requestUpdateOrderDetailModel.Price;
                existedOrderDetail.OrderDetailStatus = requestUpdateOrderDetailModel.OrderDetailStatus;
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
