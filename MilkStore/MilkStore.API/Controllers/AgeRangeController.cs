using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.AgeRangeModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/age-ranges")]
    [ApiController]
    public class AgeRangeController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AgeRangeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (AgeRangeId = 1, Baby = 2, Mama = 3, ProductId = 4)
        /// 
        /// SortType (Ascending = 1,Descending = 2)        
        /// </summary>
        /// <param name="requestSearchAgeRangeModel"></param>
        /// <returns></returns>
        [HttpGet("Search")]
        public IActionResult Search([FromQuery] RequestSearchAgeRangeModel requestSearchAgeRangeModel)
        {
            var sortBy = requestSearchAgeRangeModel.SortContent?.sortAgeRangenBy;
            var sortType = requestSearchAgeRangeModel.SortContent?.sortAgeRangeType.ToString();

            Expression<Func<AgeRange, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchAgeRangeModel.Baby) || EF.Functions.Like(x.Baby, "%" + requestSearchAgeRangeModel.Baby + "%")) &&
                (string.IsNullOrEmpty(requestSearchAgeRangeModel.Mama) || EF.Functions.Like(x.Mama, "%" + requestSearchAgeRangeModel.Mama + "%")) &&
                (x.ProductItemID == requestSearchAgeRangeModel.ProductItemID || requestSearchAgeRangeModel.ProductItemID == null);

            Func<IQueryable<AgeRange>, IOrderedQueryable<AgeRange>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortAgeRangeTypeEnum.Ascending.ToString())
                {
                    if (sortBy.Equals("Baby", StringComparison.OrdinalIgnoreCase))
                    {
                        orderBy = query => query.OrderBy(p => p.Baby, StringComparer.OrdinalIgnoreCase);
                    }
                    else if (sortBy.Equals("ProductItemID", StringComparison.OrdinalIgnoreCase))
                    {
                        orderBy = query => query.OrderBy(p => p.ProductItemID);
                    }
                }
                else if (sortType == SortAgeRangeTypeEnum.Descending.ToString())
                {
                    if (sortBy.Equals("Baby", StringComparison.OrdinalIgnoreCase))
                    {
                        orderBy = query => query.OrderByDescending(p => p.Baby, StringComparer.OrdinalIgnoreCase);
                    }
                    else if (sortBy.Equals("ProductItemID", StringComparison.OrdinalIgnoreCase))
                    {
                        orderBy = query => query.OrderByDescending(p => p.ProductItemID);
                    }
                }
            }

            var responseAgeRanges = _unitOfWork.AgeRangeRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchAgeRangeModel.PageIndex,
                pageSize: requestSearchAgeRangeModel.PageSize
            );

            return Ok(responseAgeRanges);
        }




        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ageRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (ageRange == null)
            {
                return NotFound();
            }
            return Ok(ageRange);
        }

        [HttpPost]
        public IActionResult Create(RequestCreateAgeRangeModel requestCreateAgeRangeModel)
        {
            var ageRangeEntity = new AgeRange
            {
                Baby = requestCreateAgeRangeModel.Baby,
                Mama = requestCreateAgeRangeModel.Mama,
                ProductItemID = requestCreateAgeRangeModel.ProductItemID // Chấp nhận giá trị NULL nếu không được cung cấp
            };

            _unitOfWork.AgeRangeRepository.Insert(ageRangeEntity);
            _unitOfWork.Save();
            return Ok(ageRangeEntity);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var ageRanges = _unitOfWork.AgeRangeRepository.Get();
            return Ok(ageRanges);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, RequestCreateAgeRangeModel requestCreateAgeRangeModel)
        {
            var existingAgeRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (existingAgeRange == null)
            {
                return NotFound();
            }

            existingAgeRange.Baby = requestCreateAgeRangeModel.Baby;
            existingAgeRange.Mama = requestCreateAgeRangeModel.Mama;
            existingAgeRange.ProductItemID = requestCreateAgeRangeModel.ProductItemID;

            _unitOfWork.AgeRangeRepository.Update(existingAgeRange);
            _unitOfWork.Save();
            return Ok(existingAgeRange);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAgeRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (existingAgeRange == null)
            {
                return NotFound();
            }

            _unitOfWork.AgeRangeRepository.Delete(existingAgeRange);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
