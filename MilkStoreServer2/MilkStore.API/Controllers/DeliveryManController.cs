using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.DeliveryManModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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
        /// SortType (Ascending = 1,Descending = 2)
        /// </summary>
        /// <param name="requestSearchDeliveryManModel"></param>
        /// <returns></returns>
        [HttpGet("searchdeliveryname")]
        public IActionResult SearchDeliveryMan([FromQuery] RequestSearchDeliveryManModel requestSearchDeliveryManModel)
        {
            // Giải mã DeliveryName từ requestSearchDeliveryManModel
            var decodedDeliveryName = HttpUtility.UrlDecode(requestSearchDeliveryManModel.DeliveryName);
            var decodedDeliveryStatus = HttpUtility.UrlDecode(requestSearchDeliveryManModel.DeliveryStatus);

            var sortType = requestSearchDeliveryManModel.SortContent?.sortDeliveryManType;

            Func<DeliveryMan, bool> filter = x =>
                (string.IsNullOrEmpty(decodedDeliveryName) ||
                 RemoveVietnameseAccents(x.DeliveryName).Contains(RemoveVietnameseAccents(decodedDeliveryName))) &&
                (string.IsNullOrEmpty(decodedDeliveryStatus) ||
                 RemoveVietnameseAccents(x.DeliveryStatus).Contains(RemoveVietnameseAccents(decodedDeliveryStatus)));

            Func<IQueryable<DeliveryMan>, IOrderedQueryable<DeliveryMan>> orderBy = query =>
            {
                if (sortType == SortDeliveryManTypeEnum.Ascending)
                {
                    return query.OrderBy(p => p.DeliveryName);
                }
                else
                {
                    return query.OrderByDescending(p => p.DeliveryName);
                }
            };

            var deliveryMans = _unitOfWork.DeliveryManRepository.Get(
                orderBy: orderBy,
                pageIndex: requestSearchDeliveryManModel.pageIndex,
                pageSize: requestSearchDeliveryManModel.pageSize
            ).AsEnumerable().Where(filter).ToList();

            var response = deliveryMans.Select(deliveryMan => new ResponseDeliveryManModel
            {
                DeliveryManId = deliveryMan.DeliveryManId,
                DeliveryName = deliveryMan.DeliveryName,
                DeliveryStatus = deliveryMan.DeliveryStatus,
                PhoneNumber = deliveryMan.PhoneNumber,
                StorageId = deliveryMan.StorageId
            }).ToList();

            return Ok(response);
        }

        public static string RemoveVietnameseAccents(string text)
        {
            string[] VietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    text = text.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return text;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var deliveryMans = _unitOfWork.DeliveryManRepository.Get()
                                    .Select(deliveryMan => new ResponseDeliveryManModel
                                    {
                                        DeliveryManId = deliveryMan.DeliveryManId,
                                        DeliveryName = deliveryMan.DeliveryName,
                                        DeliveryStatus = deliveryMan.DeliveryStatus,
                                        PhoneNumber = deliveryMan.PhoneNumber,
                                        StorageId = deliveryMan.StorageId
                                    })
                                    .ToList();

            return Ok(deliveryMans);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeliveryManById(int id)
        {
            var delivery = _unitOfWork.DeliveryManRepository.GetByID(id);
            if (delivery == null)
            {
                return NotFound();
            }
            var responseDeliveryMan = new ResponseDeliveryManModel
            {
                DeliveryManId = delivery.DeliveryManId,
                DeliveryName = delivery.DeliveryName,
                DeliveryStatus = delivery.DeliveryStatus,
                PhoneNumber = delivery.PhoneNumber,
                StorageId = delivery.StorageId
            };

            return Ok(responseDeliveryMan);
        }

        [HttpPost]
        public IActionResult CreateDeliveryMan(RequestCreateDeliveryManModel requestCreateDeliveryManModel)
        {
            var deliveryEntity = new DeliveryMan
            {
                DeliveryManId = requestCreateDeliveryManModel.DeliveryManId,
                DeliveryName = requestCreateDeliveryManModel.DeliveryName,
                DeliveryStatus = requestCreateDeliveryManModel.DeliveryStatus,
                PhoneNumber = requestCreateDeliveryManModel.PhoneNumber,
                StorageId = requestCreateDeliveryManModel.StorageId
            };
            _unitOfWork.DeliveryManRepository.Insert(deliveryEntity);
            _unitOfWork.Save();

            var responseDeliveryMan = new ResponseDeliveryManModel
            {
                DeliveryManId = deliveryEntity.DeliveryManId,
                DeliveryName = deliveryEntity.DeliveryName,
                DeliveryStatus = deliveryEntity.DeliveryStatus,
                PhoneNumber = deliveryEntity.PhoneNumber,
                StorageId = deliveryEntity.StorageId
            };

            return Ok(responseDeliveryMan);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDeliveryMan(int id, RequestUpdateDeliveryManModel requestUpdateDeliveryManModel)
        {
            var existedDeliveryManEntity = _unitOfWork.DeliveryManRepository.GetByID(id);
            if (existedDeliveryManEntity == null)
            {
                return NotFound();
            }

            existedDeliveryManEntity.DeliveryName = requestUpdateDeliveryManModel.DeliveryName;
            existedDeliveryManEntity.DeliveryStatus = requestUpdateDeliveryManModel.DeliveryStatus;
            existedDeliveryManEntity.PhoneNumber = requestUpdateDeliveryManModel.PhoneNumber;
            existedDeliveryManEntity.StorageId = requestUpdateDeliveryManModel.StorageId;

            _unitOfWork.DeliveryManRepository.Update(existedDeliveryManEntity);
            _unitOfWork.Save();

            var responseDeliveryMan = new ResponseDeliveryManModel
            {
                DeliveryManId = existedDeliveryManEntity.DeliveryManId,
                DeliveryName = existedDeliveryManEntity.DeliveryName,
                DeliveryStatus = existedDeliveryManEntity.DeliveryStatus,
                PhoneNumber = existedDeliveryManEntity.PhoneNumber,
                StorageId = existedDeliveryManEntity.StorageId
            };

            return Ok(responseDeliveryMan);
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
