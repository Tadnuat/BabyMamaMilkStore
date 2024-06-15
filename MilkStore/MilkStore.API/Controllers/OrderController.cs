using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;
using MilkStore.API.Models.DeliveryManModel;
using MilkStore.API.Models.OrderModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
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
        /// SortBy (AdminId = 1, Username = 2, ...)
        /// 
        /// SortType (Ascending = 1,Descending = 2)        
        /// </summary>
        /// <param name="requestSearchOrderModel"></param>
        /// <returns></returns>
        [HttpGet("SearchOrder")]
        public IActionResult SearchOrder([FromQuery] RequestSearchOrderModel requestSearchOrderModel)
        {
            var sortBy = requestSearchOrderModel.SortContent?.sortOrderBy;
            var sortType = requestSearchOrderModel.SortContent?.sortOrderType.ToString();

            Expression<Func<Order, bool>> filter = x =>
                (x.OrderId == requestSearchOrderModel.OrderId || requestSearchOrderModel.OrderId == null);

            Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortOrderTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortOrderTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }

            var responseOrder = _unitOfWork.OrderRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchOrderModel.pageIndex,
                pageSize: requestSearchOrderModel.pageSize
            );

            return Ok(responseOrder);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _unitOfWork.OrderRepository.GetByID(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
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
        public IActionResult UpdateOrder(int id, RequestCreateOrderModel requestCreateOrderModel)
        {
            var existedOrderEntity = _unitOfWork.OrderRepository.GetByID(id);
            if (existedOrderEntity == null)
            {
                return NotFound();
            }
            existedOrderEntity.CustomerId = requestCreateOrderModel.CustomerId;
            existedOrderEntity.DeliveryManId = requestCreateOrderModel.DeliveryManId;
            existedOrderEntity.OrderDate = requestCreateOrderModel.OrderDate;
            existedOrderEntity.ShippingAddress = requestCreateOrderModel.ShippingAddress;
            existedOrderEntity.TotalAmount = requestCreateOrderModel.TotalAmount;
            existedOrderEntity.StorageId = requestCreateOrderModel.StorageId;

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
