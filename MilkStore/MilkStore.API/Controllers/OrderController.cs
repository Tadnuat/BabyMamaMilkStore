using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.DeliveryManModel;
using MilkStore.API.Models.OrderModel;
using MilkStore.API.Models.ProductItemModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Search orders based on filters including Month and Year.
        /// </summary>
        /// <param name="requestSearchOrderModel">Search parameters.</param>
        /// <returns>List of orders matching the search criteria.</returns>
        [HttpGet("SearchOrder")]
        public IActionResult SearchOrder([FromQuery] RequestSearchOrderModel requestSearchOrderModel)
        {
            // Extract filter parameters
            var month = requestSearchOrderModel.Month;
            var year = requestSearchOrderModel.Year;

            // Define filter expression
            Expression<Func<Order, bool>> filter = x =>
                (!month.HasValue || (x.OrderDate.HasValue && x.OrderDate.Value.Month == month.Value)) &&
                (!year.HasValue || (x.OrderDate.HasValue && x.OrderDate.Value.Year == year.Value));

            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null;

            if (requestSearchOrderModel.SortContent != null)
            {
                var sortType = requestSearchOrderModel.SortContent.sortOrderType;

                if (sortType == SortOrderTypeEnum.Ascending)
                {
                    orderBy = query => query.OrderBy(p => p.OrderDate.Value.Year).ThenBy(p => p.OrderDate.Value.Month);
                }
                else if (sortType == SortOrderTypeEnum.Descending)
                {
                    orderBy = query => query.OrderByDescending(p => p.OrderDate.Value.Year).ThenByDescending(p => p.OrderDate.Value.Month);
                }
            }

            // Get orders from repository based on filter and sorting
            var ordersQuery = _unitOfWork.OrderRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchOrderModel.pageIndex,
                pageSize: requestSearchOrderModel.pageSize
            );

            // Project the result to OrderDTO
            var responseOrder = ordersQuery.Select(order => new ResponseOrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                DeliveryManId = order.DeliveryManId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                StorageId = order.StorageId
            }).ToList();

            return Ok(responseOrder);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _unitOfWork.OrderRepository.Get()
                                    .Select(order => new ResponseOrderModel
                                    {
                                        OrderId = order.OrderId,
                                        CustomerId = order.CustomerId,
                                        DeliveryManId = order.DeliveryManId,
                                        OrderDate = order.OrderDate,
                                        ShippingAddress = order.ShippingAddress,
                                        TotalAmount= order.TotalAmount,
                                        StorageId= order.StorageId

                                    })
                                    .ToList();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _unitOfWork.OrderRepository.GetByID(id);
            if (order == null)
            {
                return NotFound();
            }
            var responseOrder = new ResponseOrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                DeliveryManId = order.DeliveryManId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                StorageId = order.StorageId
            };

            return Ok(responseOrder);
        }

        [HttpPost]
        public IActionResult CreateOrder(RequestCreateOrderModel requestCreateOrderModel)
        {
            var orderEntity = new Order
            {
                OrderId = requestCreateOrderModel.OrderId,
                CustomerId = requestCreateOrderModel.CustomerId,
                DeliveryManId = requestCreateOrderModel.DeliveryManId,
                OrderDate = requestCreateOrderModel.OrderDate,
                ShippingAddress = requestCreateOrderModel.ShippingAddress,
                TotalAmount = requestCreateOrderModel.TotalAmount,
                StorageId = requestCreateOrderModel.StorageId
            };
            _unitOfWork.OrderRepository.Insert(orderEntity);
            _unitOfWork.Save();
            return Ok(orderEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, RequestUpdateOrderModel requestUpdateOrderModel)
        {
            var existedOrderEntity = _unitOfWork.OrderRepository.GetByID(id);
            if (existedOrderEntity == null)
            {
                return NotFound();
            }
            existedOrderEntity.CustomerId = requestUpdateOrderModel.CustomerId;
            existedOrderEntity.DeliveryManId = requestUpdateOrderModel.DeliveryManId;
            existedOrderEntity.OrderDate = requestUpdateOrderModel.OrderDate;
            existedOrderEntity.ShippingAddress = requestUpdateOrderModel.ShippingAddress;
            existedOrderEntity.TotalAmount = requestUpdateOrderModel.TotalAmount;
            existedOrderEntity.StorageId = requestUpdateOrderModel.StorageId;

            _unitOfWork.OrderRepository.Update(existedOrderEntity);
            _unitOfWork.Save();
            return Ok(existedOrderEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var existedOrderEntity = _unitOfWork.OrderRepository.GetByID(id);
            if (existedOrderEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.OrderRepository.Delete(existedOrderEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
