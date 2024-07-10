using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.AgeRangeModel;
using MilkStore.API.Models.BrandMilkModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/brandmilks")]
    [ApiController]
    public class BrandMilkController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public BrandMilkController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandMilkById(int id)
        {
            var brandMilk = _unitOfWork.BrandMilkRepository.GetByID(id);
            if (brandMilk == null)
            {
                return NotFound();
            }

            var responseBrandMilk = new ResponseBrandMilkModel
            {
                //BrandMilkID = brandMilk.BrandMilkID,
                BrandName = brandMilk.BrandName,
                CompanyID = brandMilk.CompanyID
            };

            return Ok(responseBrandMilk);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var brandMilks = _unitOfWork.BrandMilkRepository.Get();

            var responseBrandMilks = brandMilks.Select(bm => new ResponseBrandMilkModel
            {
                //BrandMilkID = bm.BrandMilkID,
                BrandName = bm.BrandName,
                CompanyID = bm.CompanyID
            }).ToList();

            return Ok(responseBrandMilks);
        }

        [HttpPost]
        public IActionResult CreateBrandMilk(RequestCreateBrandMilkModel requestCreateBrandMilkModel)
        {
            var brandEntity = new BrandMilk
            {
                BrandMilkID = requestCreateBrandMilkModel.BrandMilkID,
                BrandName = requestCreateBrandMilkModel.BrandName,
                CompanyID = requestCreateBrandMilkModel.CompanyID
            };
            _unitOfWork.BrandMilkRepository.Insert(brandEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrandMilk(int id, RequestUpdateBrandMilkModel requestUpdateBrandMilkModel)
        {
            var existedBrandEntity = _unitOfWork.BrandMilkRepository.GetByID(id);
            if (existedBrandEntity != null)
            {
                existedBrandEntity.BrandName = requestUpdateBrandMilkModel.BrandName;
                existedBrandEntity.CompanyID = requestUpdateBrandMilkModel.CompanyID;
            }
            _unitOfWork.BrandMilkRepository.Update(existedBrandEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrandMilk(int id)
        {
            var existedBrandEntity = _unitOfWork.BrandMilkRepository.GetByID(id);
            _unitOfWork.BrandMilkRepository.Delete(existedBrandEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
