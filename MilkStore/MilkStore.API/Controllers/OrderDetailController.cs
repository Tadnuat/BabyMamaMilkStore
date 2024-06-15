using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.OrderDetailModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;
using System.Linq;
using System.Collections.Generic;

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
                                        OrderDetailId = orderDetail.OrderDetailId,
                                        OrderId = orderDetail.OrderId,
                                        ProductItemId = orderDetail.ProductItemId,
                                        Quantity = orderDetail.Quantity,
                                        Price = orderDetail.Price,
                                        ItemName = orderDetail.ItemName,
                                        Image = orderDetail.Image
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
                return NotFound(); // Handle the not found case
            }

            var responseOrderDetail = new ResponseOrderDetailModel
            {
                OrderDetailId = orderDetail.OrderDetailId,
                OrderId = orderDetail.OrderId,
                ProductItemId = orderDetail.ProductItemId,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.Price,
                ItemName = orderDetail.ItemName,
                Image = orderDetail.Image
            };

            return Ok(responseOrderDetail);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(RequestCreateOrderDetailModel requestCreateOrderDetailModel)
        {
            var orderDetail = new OrderDetail
            {
                OrderDetailId = requestCreateOrderDetailModel.OrderDetailId,
                OrderId = requestCreateOrderDetailModel.OrderId,
                ProductItemId = requestCreateOrderDetailModel.ProductItemId,
                Quantity = requestCreateOrderDetailModel.Quantity,
                Price = requestCreateOrderDetailModel.Price,
                ItemName = requestCreateOrderDetailModel.ItemName,
                Image = requestCreateOrderDetailModel.Image
            };

            _unitOfWork.OrderDetailRepository.Insert(orderDetail);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderDetail(int id, RequestUpdateOrderDetailModel requestUpdateOrderDetailModel)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail == null)
            {
                return NotFound(); // Handle the not found case
            }

            existedOrderDetail.OrderId = requestUpdateOrderDetailModel.OrderId;
            existedOrderDetail.ProductItemId = requestUpdateOrderDetailModel.ProductItemId;
            existedOrderDetail.Quantity = requestUpdateOrderDetailModel.Quantity;
            existedOrderDetail.Price = requestUpdateOrderDetailModel.Price;
            existedOrderDetail.ItemName = requestUpdateOrderDetailModel.ItemName;
            existedOrderDetail.Image = requestUpdateOrderDetailModel.Image;

            _unitOfWork.OrderDetailRepository.Update(existedOrderDetail);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderDetail(int id)
        {
            var existedOrderDetail = _unitOfWork.OrderDetailRepository.GetByID(id);
            if (existedOrderDetail == null)
            {
                return NotFound(); // Handle the not found case
            }

            _unitOfWork.OrderDetailRepository.Delete(existedOrderDetail);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
