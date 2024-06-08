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
        private readonly IUnitOfWork _unitOfWork;

        public AgeRangeController(IUnitOfWork unitOfWork)
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
            var sortBy = requestSearchAgeRangeModel.SortContent?.SortBy;
            var sortType = requestSearchAgeRangeModel.SortContent?.SortType.ToString();

            Expression<Func<AgeRange, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchAgeRangeModel.Baby) || x.Baby.Contains(requestSearchAgeRangeModel.Baby)) &&
                (string.IsNullOrEmpty(requestSearchAgeRangeModel.Mama) || x.Mama.Contains(requestSearchAgeRangeModel.Mama)) &&
                (x.ProductId == requestSearchAgeRangeModel.ProductId || requestSearchAgeRangeModel.ProductId == null);

            Func<IQueryable<AgeRange>, IOrderedQueryable<AgeRange>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
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
                ProductId = requestCreateAgeRangeModel.ProductId
            };
            _unitOfWork.AgeRangeRepository.Insert(ageRangeEntity);
            _unitOfWork.Save();
            return Ok(ageRangeEntity);
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
            existingAgeRange.ProductId = requestCreateAgeRangeModel.ProductId;

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
