using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.DeliveryManModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/deliverymans")]
    [ApiController]
    public class DeliveryManController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public DeliveryManController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (AdminId = 1, Username = 2, ...)
        /// 
        /// SortType (Ascending = 1,Descending = 2)        
        /// </summary>
        /// <param name="requestSearchDeliveryManModel"></param>
        /// <returns></returns>
        [HttpGet("SearchDeliveryMan")]
        public IActionResult SearchDeliveryMan([FromQuery] RequestSearchDeliveryManModel requestSearchDeliveryManModel)
        {
            var sortBy = requestSearchDeliveryManModel.SortContent?.sortDeliveryManBy;
            var sortType = requestSearchDeliveryManModel.SortContent?.sortDeliveryManType.ToString();

            Expression<Func<DeliveryMan, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchDeliveryManModel.DeliveryName) || x.DeliveryName.Contains(requestSearchDeliveryManModel.DeliveryName)) &&
                (x.DeliveryManId == requestSearchDeliveryManModel.DeliveryManId || requestSearchDeliveryManModel.DeliveryManId == null);

            Func<IQueryable<DeliveryMan>, IOrderedQueryable<DeliveryMan>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortDeliveryManTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortDeliveryManTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }

            var responseDeliveryMan = _unitOfWork.DeliveryManRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchDeliveryManModel.pageIndex,
                pageSize: requestSearchDeliveryManModel.pageSize
            );

            return Ok(requestSearchDeliveryManModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeliveryManById(int id)
        {
            var delivery = _unitOfWork.DeliveryManRepository.GetByID(id);
            if (delivery == null)
            {
                return NotFound();
            }
            return Ok(delivery);
        }

        [HttpPost]
        public IActionResult CreateDeliveryMan(RequestCreateDeliveryManModel requestCreateDeliveryManModel)
        {
            var deliveryEntity = new DeliveryMan
            {
                DeliveryManId = requestCreateDeliveryManModel.DeliveryManId,
                DeliveryName = requestCreateDeliveryManModel.DeliveryName,
                DeliveryStatus = requestCreateDeliveryManModel.DeliveryStatus,
                PhoneNumber = requestCreateDeliveryManModel.PhoneNumber


            };
            _unitOfWork.DeliveryManRepository.Insert(deliveryEntity);
            _unitOfWork.Save();
            return Ok(deliveryEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDeliveryMan(int id, RequestCreateDeliveryManModel requestCreateDeliveryManModel)
        {
            var existedDeliveryManEntity = _unitOfWork.DeliveryManRepository.GetByID(id);
            if (existedDeliveryManEntity == null)
            {
                return NotFound();
            }

            existedDeliveryManEntity.DeliveryName = requestCreateDeliveryManModel.DeliveryName;
            existedDeliveryManEntity.DeliveryStatus = requestCreateDeliveryManModel.DeliveryStatus;
            existedDeliveryManEntity.PhoneNumber = requestCreateDeliveryManModel.PhoneNumber;

            _unitOfWork.DeliveryManRepository.Update(existedDeliveryManEntity);
            _unitOfWork.Save();
            return Ok(existedDeliveryManEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeliveryMan(int id)
        {
            var existedDeliveryManEntity = _unitOfWork.DeliveryManRepository.GetByID(id);
            if (existedDeliveryManEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.DeliveryManRepository.Delete(existedDeliveryManEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
