using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.AgeRangeModel;
using MilkStore.API.Models.CompanyModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CompanyController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (CompanyName = 1, CountryId = 2)
        /// 
        /// SortType (Ascending = 1, Descending = 2)        
        /// </summary>
        /// <param name="requestSearchCompanyModel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchCompany([FromQuery] RequestSearchCompanyModel requestSearchCompanyModel)
        {
            var sortBy = requestSearchCompanyModel.SortContent != null ? requestSearchCompanyModel.SortContent?.SortBy.ToString() : null;
            var sortType = requestSearchCompanyModel.SortContent != null ? requestSearchCompanyModel.SortContent?.SortCompanyType.ToString() : null;
            Expression<Func<Company, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchCompanyModel.CompanyName) || x.CompanyName.Contains(requestSearchCompanyModel.CompanyName)) &&
                (x.CountryId == requestSearchCompanyModel.CountryId || requestSearchCompanyModel.CountryId == null);

            Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null;

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
            var responseCompany = _unitOfWork.CompanyRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchCompanyModel.PageIndex,
                pageSize: requestSearchCompanyModel.PageSize
            );
            return Ok(responseCompany);
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var responseCompany = _unitOfWork.CompanyRepository.GetByID(id);
            return Ok(responseCompany);
        }

        [HttpPost]
        public IActionResult CreateCompany(RequestCreateCompanyModel requestCreateCompanyModel)
        {
            var companyEntity = new Company
            {
                CompanyName = requestCreateCompanyModel.CompanyName,
                CountryId = requestCreateCompanyModel.CountryId
            };
            _unitOfWork.CompanyRepository.Insert(companyEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, RequestCreateCompanyModel requestCreateCompanyModel)
        {
            var existedCompanyEntity = _unitOfWork.CompanyRepository.GetByID(id);
            if (existedCompanyEntity != null)
            {
                existedCompanyEntity.CompanyName = requestCreateCompanyModel.CompanyName;
                existedCompanyEntity.CountryId = requestCreateCompanyModel.CountryId;
            }
            _unitOfWork.CompanyRepository.Update(existedCompanyEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var existedCompanyEntity = _unitOfWork.CompanyRepository.GetByID(id);
            _unitOfWork.CompanyRepository.Delete(existedCompanyEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
