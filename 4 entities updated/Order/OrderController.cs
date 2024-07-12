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
                x.Delete == 1 &&
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
                Status = order.Status,
                Delete = order.Delete
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


        [HttpGet("OrderDateRange")]
        public IActionResult GetOrdersByDateRange(DateTime? startDate, DateTime? endDate)
        {
            // Define filter expression based on date range
            Expression<Func<Order, bool>> filter = x =>
                x.Delete == 1 &&
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
                Status = order.Status,
                Delete = order.Delete
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
            var orders = _unitOfWork.OrderRepository.Get(x => x.Delete == 1)
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
                                        Status = order.Status,
                                        Delete = order.Delete
                                    })
                                    .ToList();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _unitOfWork.OrderRepository.Get(x => x.OrderId == id && x.Delete == 1).FirstOrDefault();
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
                Status = order.Status,
                Delete = order.Delete
            };

            return Ok(responseOrder);
        }
        [HttpGet("Waiting")]
        public IActionResult GetPendingOrders()
        {
            return GetOrdersByStatus("Chờ lấy hàng");
        }

        [HttpGet("Delivering")]
        public IActionResult GetDeliveringOrders()
        {
            return GetOrdersByStatus("Đang giao hàng");
        }

        [HttpGet("Delivered")]
        public IActionResult GetDeliveredOrders()
        {
            return GetOrdersByStatus("Đã giao hàng");
        }

        [HttpGet("Cancelled")]
        public IActionResult GetCancelledOrders()
        {
            return GetOrdersByStatus("Đã hủy");
        }

        private IActionResult GetOrdersByStatus(string status)
        {
            var orders = _unitOfWork.OrderRepository.Get(x => x.Delete == 1 && x.Status == status)
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
                                                        Status = order.Status,
                                                        Delete = order.Delete
                                                    })
                                                    .ToList();

            return Ok(orders);
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
                OrderDate = requestCreateOrderModel.OrderDate ?? DateTime.Now, // Sử dụng DateTime.Now nếu OrderDate không có giá trị
                ShippingAddress = requestCreateOrderModel.ShippingAddress,
                TotalAmount = requestCreateOrderModel.TotalAmount ?? 0, // Sử dụng 0 nếu TotalAmount không có giá trị
                StorageId = requestCreateOrderModel.StorageId,
                DeliveryName = requestCreateOrderModel.DeliveryName,
                DeliveryPhone = requestCreateOrderModel.DeliveryPhone,
                PaymentMethod = requestCreateOrderModel.PaymentMethod,
                Status = requestCreateOrderModel.Status,
                Delete = 1 // Đặt giá trị mặc định của Delete là 1
            };

            _unitOfWork.OrderRepository.Insert(orderEntity);
            _unitOfWork.Save();

            var responseOrderModel = new ResponseOrderModel
            {
                OrderId = orderEntity.OrderId,
                CustomerId = orderEntity.CustomerId,
                DeliveryManId = orderEntity.DeliveryManId,
                OrderDate = orderEntity.OrderDate,
                ShippingAddress = orderEntity.ShippingAddress,
                TotalAmount = orderEntity.TotalAmount,
                StorageId = orderEntity.StorageId,
                DeliveryName = orderEntity.DeliveryName,
                DeliveryPhone = orderEntity.DeliveryPhone,
                PaymentMethod = orderEntity.PaymentMethod,
                Status = orderEntity.Status,
                Delete = orderEntity.Delete
            };

            return Ok(responseOrderModel);
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
            existedOrderEntity.OrderDate = requestUpdateOrderModel.OrderDate ?? existedOrderEntity.OrderDate;
            existedOrderEntity.ShippingAddress = requestUpdateOrderModel.ShippingAddress;
            existedOrderEntity.TotalAmount = requestUpdateOrderModel.TotalAmount ?? existedOrderEntity.TotalAmount;
            existedOrderEntity.StorageId = requestUpdateOrderModel.StorageId;
            existedOrderEntity.DeliveryName = requestUpdateOrderModel.DeliveryName;
            existedOrderEntity.DeliveryPhone = requestUpdateOrderModel.DeliveryPhone;
            existedOrderEntity.PaymentMethod = requestUpdateOrderModel.PaymentMethod;
            existedOrderEntity.Status = requestUpdateOrderModel.Status;
            existedOrderEntity.Delete = requestUpdateOrderModel.Delete; // Không thay đổi trường Delete

            _unitOfWork.OrderRepository.Update(existedOrderEntity);
            _unitOfWork.Save();

            var responseOrderModel = new ResponseOrderModel
            {
                OrderId = existedOrderEntity.OrderId,
                CustomerId = existedOrderEntity.CustomerId,
                DeliveryManId = existedOrderEntity.DeliveryManId,
                OrderDate = existedOrderEntity.OrderDate,
                ShippingAddress = existedOrderEntity.ShippingAddress,
                TotalAmount = existedOrderEntity.TotalAmount,
                StorageId = existedOrderEntity.StorageId,
                DeliveryName = existedOrderEntity.DeliveryName,
                DeliveryPhone = existedOrderEntity.DeliveryPhone,
                PaymentMethod = existedOrderEntity.PaymentMethod,
                Status = existedOrderEntity.Status,
                Delete = existedOrderEntity.Delete
            };

            return Ok(responseOrderModel);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDeleteOrder(int id)
        {
            var existedOrderEntity = _unitOfWork.OrderRepository.GetByID(id);
            if (existedOrderEntity == null || existedOrderEntity.Delete != 1)
            {
                return NotFound();
            }

            _unitOfWork.OrderRepository.SoftDelete(existedOrderEntity); // Using SoftDelete method
            _unitOfWork.Save();
            return Ok(new { message = "Order deleted (soft) successfully." });
        }

        [HttpDelete("hard/{id}")]
        public IActionResult HardDeleteOrder(int id)
        {
            var existedOrderEntity = _unitOfWork.OrderRepository.GetByID(id);
            if (existedOrderEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.OrderRepository.Delete(existedOrderEntity);
            _unitOfWork.Save();

            return Ok(new { message = "Order hard deleted successfully." });
        }
    }
}
