using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.OrderDetailModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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
                                        OrderDetailId = orderDetail.OrderDetailId,
                                        OrderId = orderDetail.OrderId,
                                        CustomerId = orderDetail.CustomerId,
                                        ProductItemId = orderDetail.ProductItemId,
                                        Quantity = orderDetail.Quantity,
                                        Price = orderDetail.Price,
                                        ItemName = orderDetail.ItemName,
                                        Image = orderDetail.Image,
                                        OrderStatus = orderDetail.OrderStatus,
                                        Discount = orderDetail.Discount,
                                        Total = CalculateTotal(orderDetail.Price, orderDetail.Quantity, orderDetail.Discount)
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
                return NotFound();
            }

            var responseOrderDetail = new ResponseOrderDetailModel
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderId = orderDetail.OrderId,
                CustomerId = orderDetail.CustomerId,
                ProductItemId = orderDetail.ProductItemId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                ItemName = orderDetail.ItemName,
                Image = orderDetail.Image,
                OrderStatus = orderDetail.OrderStatus,
                Discount = orderDetail.Discount,
                Total = CalculateTotal(orderDetail.Price, orderDetail.Quantity, orderDetail.Discount)
            };

            return Ok(responseOrderDetail);
        }

        [HttpGet("status/{orderStatus}")]
        public IActionResult GetOrderDetailsByStatus(int orderStatus, [FromQuery] int? customerId = null)
        {
            var orderDetailsQuery = _unitOfWork.OrderDetailRepository.Get(od => od.OrderStatus == orderStatus);

            if (customerId.HasValue)
            {
                orderDetailsQuery = orderDetailsQuery.Where(od => od.CustomerId == customerId.Value);
            }

            var orderDetails = orderDetailsQuery.Select(orderDetail => new ResponseOrderDetailModel
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderId = orderDetail.OrderId,
                CustomerId = orderDetail.CustomerId,
                ProductItemId = orderDetail.ProductItemId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                ItemName = orderDetail.ItemName,
                Image = orderDetail.Image,
                OrderStatus = orderDetail.OrderStatus,
                Discount = orderDetail.Discount,
                Total = CalculateTotal(orderDetail.Price, orderDetail.Quantity, orderDetail.Discount)
            })
            .ToList();

            return Ok(orderDetails);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(RequestCreateOrderDetailModel requestCreateOrderDetailModel)
        {
            var orderDetail = new OrderDetail
            {
                OrderDetailId = requestCreateOrderDetailModel.OrderDetailId,
                OrderId = requestCreateOrderDetailModel.OrderId,
                CustomerId = requestCreateOrderDetailModel.CustomerId,
                ProductItemId = requestCreateOrderDetailModel.ProductItemId,
                Quantity = requestCreateOrderDetailModel.Quantity,
                Price = requestCreateOrderDetailModel.Price,
                ItemName = requestCreateOrderDetailModel.ItemName,
                Image = requestCreateOrderDetailModel.Image,
                OrderStatus = requestCreateOrderDetailModel.OrderStatus,
                Discount = requestCreateOrderDetailModel.Discount
            };

            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();

            return Ok(new { message = "OrderDetail created successfully." });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, RequestUpdateOrderDetailModel requestUpdateOrderDetailModel)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail == null)
            {
                return NotFound();
            }

            existedOrderDetail.OrderId = requestUpdateOrderDetailModel.OrderId;
            existedOrderDetail.CustomerId = requestUpdateOrderDetailModel.CustomerId;
            existedOrderDetail.ProductItemId = requestUpdateOrderDetailModel.ProductItemId;
            existedOrderDetail.Quantity = requestUpdateOrderDetailModel.Quantity;
            existedOrderDetail.Price = requestUpdateOrderDetailModel.Price;
            existedOrderDetail.ItemName = requestUpdateOrderDetailModel.ItemName;
            existedOrderDetail.Image = requestUpdateOrderDetailModel.Image;
            existedOrderDetail.OrderStatus = requestUpdateOrderDetailModel.OrderStatus;
            existedOrderDetail.Discount = requestUpdateOrderDetailModel.Discount;

            _unitOfWork.OrderDetailRepository.Update(existedOrderDetail);
            _unitOfWork.Save();

            return Ok(new { message = "OrderDetail updated successfully." });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail == null)
            {
                return NotFound();
            }

            _unitOfWork.OrderDetailRepository.Delete(existedOrderDetail);
            _unitOfWork.Save();

            return Ok(new { message = "OrderDetail deleted successfully." });
        }

        private decimal CalculateTotal(decimal? price, int? quantity, decimal? discount)
        {
            if (price.HasValue && quantity.HasValue && discount.HasValue)
            {
                return price.Value * quantity.Value * (1 - discount.Value / 100);
            }
            return 0;
        }
    }
}
