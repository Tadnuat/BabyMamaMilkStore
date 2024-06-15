using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.StorageModel;
using MilkStore.Repo.UnitOfWork;
using MilkStore.Repo.Entities;
using System.Security.Cryptography.X509Certificates;


namespace MilkStore.API.Controllers
{
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
                return NotFound(); // Handle the not found case appropriately
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

    }
}
