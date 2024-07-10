using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.OrderModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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
            var customerId = requestSearchOrderModel.CustomerId;
            var status = requestSearchOrderModel.Status;
            var day = requestSearchOrderModel.Day;
            var month = requestSearchOrderModel.Month;
            var year = requestSearchOrderModel.Year;

            // Define filter expression
            Expression<Func<Order, bool>> filter = x =>
                (!customerId.HasValue || x.CustomerId == customerId.Value) &&
                (string.IsNullOrEmpty(status) || x.Status.ToLower() == status.ToLower()) &&
                (!day.HasValue || !month.HasValue || !year.HasValue ||
                 (x.OrderDate.HasValue && x.OrderDate.Value.Day == day && x.OrderDate.Value.Month == month && x.OrderDate.Value.Year == year));

            // Define sorting order
            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null;
            if (requestSearchOrderModel.sortContent.SortOrderType == SortOrderTypeEnum.Ascending)
            {
                orderBy = query => query.OrderBy(p => p.OrderDate);
            }
            else if (requestSearchOrderModel.sortContent.SortOrderType == SortOrderTypeEnum.Descending)
            {
                orderBy = query => query.OrderByDescending(p => p.OrderDate);
            }

            // Get orders from repository based on filter and sorting
            var ordersQuery = _unitOfWork.OrderRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchOrderModel.PageIndex,
                pageSize: requestSearchOrderModel.PageSize
            );

            // Project the result to ResponseOrderModel
            var responseOrders = ordersQuery.Select(order => new ResponseOrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                DeliveryManId = order.DeliveryManId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                StorageId = order.StorageId,
                DeliveryName = order.DeliveryName,
                DeliveryPhone = order.DeliveryPhone,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status
            }).ToList();

            // Calculate the total sum of TotalAmount
            var totalSum = responseOrders.Sum(order => order.TotalAmount);

            // Get the count of orders
            var orderCount = responseOrders.Count;

            // Create the response model
            var responseSearchOrderModel = new ResponseSearchOrderModel
            {
                Orders = responseOrders,
                TotalSum = totalSum,
                OrderCount = orderCount // Include order count in the response
            };

            return Ok(responseSearchOrderModel);
        }

        /// <summary>
        /// Get orders within a specific date range.
        /// </summary>
        /// <param name="requestDateRangeModel">Date range parameters.</param>
        /// <returns>List of orders within the specified date range.</returns>
        [HttpGet("OrderDateRange")]
        public IActionResult GetOrdersByDateRange(DateTime? startDate, DateTime? endDate)
        {
            // Define filter expression based on date range
            Expression<Func<Order, bool>> filter = x =>
                (!startDate.HasValue || x.OrderDate >= startDate) &&
                (!endDate.HasValue || x.OrderDate <= endDate);

            // Get orders from repository based on filter
            var ordersQuery = _unitOfWork.OrderRepository.Get(
                filter,
                orderBy: query => query.OrderBy(p => p.OrderDate), // Order by OrderDate ascending
                includeProperties: ""
            );

            // Project the result to ResponseOrderModel
            var responseOrders = ordersQuery.Select(order => new ResponseOrderModel
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                DeliveryManId = order.DeliveryManId,
                OrderDate = order.OrderDate,
                ShippingAddress = order.ShippingAddress,
                TotalAmount = order.TotalAmount,
                StorageId = order.StorageId,
                DeliveryName = order.DeliveryName,
                DeliveryPhone = order.DeliveryPhone,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status
            }).ToList();

            // Calculate the total sum of TotalAmount
            var totalSum = responseOrders.Sum(order => order.TotalAmount);

            // Get the count of orders
            var orderCount = responseOrders.Count;

            // Create the response model
            var responseSearchOrderModel = new ResponseSearchOrderModel
            {
                Orders = responseOrders,
                TotalSum = totalSum,
                OrderCount = orderCount // Include order count in the response
            };

            return Ok(responseSearchOrderModel);
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
                                        TotalAmount = order.TotalAmount,
                                        StorageId = order.StorageId,
                                        DeliveryName = order.DeliveryName,
                                        DeliveryPhone = order.DeliveryPhone,
                                        PaymentMethod = order.PaymentMethod,
                                        Status = order.Status
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
                StorageId = order.StorageId,
                DeliveryName = order.DeliveryName,
                DeliveryPhone = order.DeliveryPhone,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status
            };

            return Ok(responseOrder);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] RequestCreateOrderModel requestCreateOrderModel)
        {
            if (requestCreateOrderModel == null)
            {
                return BadRequest("The requestCreateOrderModel field is required.");
            }

            var orderEntity = new Order
            {
                OrderId = requestCreateOrderModel.OrderId, // Nhận OrderId từ request
                CustomerId = requestCreateOrderModel.CustomerId,
                DeliveryManId = requestCreateOrderModel.DeliveryManId,
                OrderDate = requestCreateOrderModel.OrderDate.HasValue ? requestCreateOrderModel.OrderDate.Value : DateTime.Now, // Sử dụng DateTime.Now nếu OrderDate không có giá trị
                ShippingAddress = requestCreateOrderModel.ShippingAddress,
                TotalAmount = requestCreateOrderModel.TotalAmount ?? 0, // Sử dụng 0 nếu TotalAmount không có giá trị
                StorageId = requestCreateOrderModel.StorageId,
                DeliveryName = requestCreateOrderModel.DeliveryName,
                DeliveryPhone = requestCreateOrderModel.DeliveryPhone,
                PaymentMethod = requestCreateOrderModel.PaymentMethod,
                Status = requestCreateOrderModel.Status
            };

            try
            {
                _unitOfWork.OrderRepository.Insert(orderEntity);
                _unitOfWork.Save();
                return Ok(orderEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the order. Please try again later.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] RequestUpdateOrderModel requestUpdateOrderModel)
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
            existedOrderEntity.DeliveryName = requestUpdateOrderModel.DeliveryName;
            existedOrderEntity.DeliveryPhone = requestUpdateOrderModel.DeliveryPhone;
            existedOrderEntity.PaymentMethod = requestUpdateOrderModel.PaymentMethod;
            existedOrderEntity.Status = requestUpdateOrderModel.Status;

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
