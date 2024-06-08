using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.BrandMilkModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

using static System.Net.Mime.MediaTypeNames;

namespace MilkStore.API.Controllers
{
    [Route("api/brandmilks")]
    [ApiController]
    public class BrandMilkController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public BrandMilkController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (BrandMilkId = 1,BrandName = 2,CompanyId = 3,)
        /// 
        /// SortType (Ascending = 1,Descending = 2,)        
        /// </summary>
        /// <param name="requestSearchBrandMilkModel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchBrandMilk([FromQuery] RequestSearchBrandMilkModel requestSearchBrandMilkModel)
        {
            var sortBy = requestSearchBrandMilkModel.SortContent != null ? requestSearchBrandMilkModel.SortContent?.sortBrandMilkBy.ToString() : null;
            var sortType = requestSearchBrandMilkModel.SortContent != null ? requestSearchBrandMilkModel.SortContent?.sortBrandMilkBy.ToString() : null;
            Expression<Func<BrandMilk, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchBrandMilkModel.BrandName) || x.BrandName.Contains(requestSearchBrandMilkModel.BrandName)) &&
                (x.CompanyId == requestSearchBrandMilkModel.CompanyId || requestSearchBrandMilkModel.CompanyId == null);

            Func<IQueryable<BrandMilk>, IOrderedQueryable<BrandMilk>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortBrandMilkTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortBrandMilkTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }
            var responseBrandMilk = _unitOfWork.BrandMilkRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchBrandMilkModel.pageIndex,
                pageSize: requestSearchBrandMilkModel.pageSize
            );
            return Ok(responseBrandMilk);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandMilkById(int id)
        {
            var responseBrandMilk = _unitOfWork.BrandMilkRepository.GetByID(id);
            return Ok(responseBrandMilk);
        }

        [HttpPost]
        public IActionResult CreateBrandMilk(RequestCreateBrandMilkModel requestCreateBrandMilkModel)
        {
            var brandEntity = new BrandMilk
            {
                BrandName = requestCreateBrandMilkModel.BrandName,
                CompanyId = requestCreateBrandMilkModel.CompanyId
            };
            _unitOfWork.BrandMilkRepository.Insert(brandEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBrandMilk(int id, RequestCreateBrandMilkModel RequestCreateBrandMilkModel)
        {
            var existedBrandEntity = _unitOfWork.BrandMilkRepository.GetByID(id);
            if (existedBrandEntity != null)
            {
                existedBrandEntity.BrandName = RequestCreateBrandMilkModel.BrandName;
                existedBrandEntity.CompanyId = RequestCreateBrandMilkModel.CompanyId;
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
