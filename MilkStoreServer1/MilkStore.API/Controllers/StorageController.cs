using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.StorageModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public StorageController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var storageList = _unitOfWork.StorageRepository.Get();
            var responseList = storageList.Select(storage => new ResponseStorageModel
            {
                StorageId = storage.StorageId,
                StorageName = storage.StorageName,
            }).ToList();

            return Ok(responseList);
        }

        [HttpGet("{id}")]
        public IActionResult GetStorageById(int id)
        {
            var storage = _unitOfWork.StorageRepository.GetByID(id);

            if (storage == null)
            {
                return NotFound();
            }

            var responseStorage = new ResponseStorageModel
            {
                StorageId = storage.StorageId,
                StorageName = storage.StorageName,
            };

            return Ok(responseStorage);
        }

        [HttpPost]
        public IActionResult CreateOrderDetail(RequestCreateStorageModel requestCreateStorageModel)
        {
            var storage = new Storage
            {
                StorageId = requestCreateStorageModel.StorageId,
                StorageName = requestCreateStorageModel.StorageName,
            };
            _unitOfWork.StorageRepository.Insert(storage);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStorage(int id, RequestUpdateStorageModel requestUpdateStorageModel)
        {
            var existedStorage = _unitOfWork.StorageRepository.GetByID(id);
            if (existedStorage != null)
            {
                existedStorage.StorageName = requestUpdateStorageModel.StorageName;
            }
            _unitOfWork.StorageRepository.Update(existedStorage);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStorage(int id)
        {
            var existedStorage = _unitOfWork.StorageRepository.GetByID(id);
            _unitOfWork.StorageRepository.Delete(existedStorage);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("SearchStorage")]
        public IActionResult SearchStorage([FromQuery] RequestSearchStorageModel requestSearchStorageModel)
        {
            // Giải mã StorageName từ requestSearchStorageModel
            var decodedStorageName = HttpUtility.UrlDecode(requestSearchStorageModel.StorageName);

            var sortType = requestSearchStorageModel.SortContent?.SortStorageType;

            Func<Storage, bool> filter = x =>
                string.IsNullOrEmpty(decodedStorageName) || RemoveVietnameseAccents(x.StorageName).Contains(RemoveVietnameseAccents(decodedStorageName));

            Func<IQueryable<Storage>, IOrderedQueryable<Storage>> orderBy = query =>
            {
                if (sortType == SortStorageTypeEnum.Ascending)
                {
                    return query.OrderBy(p => p.StorageName);
                }
                else
                {
                    return query.OrderByDescending(p => p.StorageName);
                }
            };

            var storages = _unitOfWork.StorageRepository.Get(
                orderBy: orderBy,
                pageIndex: requestSearchStorageModel.PageIndex,
                pageSize: requestSearchStorageModel.PageSize
            ).AsEnumerable().Where(filter).ToList();

            var response = storages.Select(storage => new ResponseStorageModel
            {
                StorageId = storage.StorageId,
                StorageName = storage.StorageName,
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

    }
}
