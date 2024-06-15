using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.CountryModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CountryController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (AdminId = 1, Username = 2, ...)
        /// 
        /// SortType (Ascending = 1,Descending = 2)        
        /// </summary>
        /// <param name="requestSearchCountryModel"></param>
        /// <returns></returns>
        [HttpGet("SearchCountry")]
        public IActionResult SearchCountry([FromQuery] RequestSearchCountryModel requestSearchCountryModel)
        {
            var sortBy = requestSearchCountryModel.SortContent?.sortCountryBy;
            var sortType = requestSearchCountryModel.SortContent?.sortCountryType.ToString();

            Expression<Func<Country, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchCountryModel.CountryName) || x.CountryName.Contains(requestSearchCountryModel.CountryName)) &&
                (x.CountryId == requestSearchCountryModel.CountryId || requestSearchCountryModel.CountryId == null);

            Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortCountryTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortCountryTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }

            var responseCountry = _unitOfWork.CountryRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchCountryModel.pageIndex,
                pageSize: requestSearchCountryModel.pageSize
            );

            return Ok(responseCountry);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public IActionResult CreateCountry(RequestCreateCountryModel requestCreateCountryModel)
        {
            var countryEntity = new Country
            {
                CountryId = requestCreateCountryModel.CountryId,
                CountryName = requestCreateCountryModel.CountryName


            };
            _unitOfWork.CountryRepository.Insert(countryEntity);
            _unitOfWork.Save();
            return Ok(countryEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCountry(int id, RequestCreateCountryModel requestCreateCountryModel)
        {
            var existedCountryEntity = _unitOfWork.CountryRepository.GetByID(id);
            if (existedCountryEntity == null)
            {
                return NotFound();
            }

            existedCountryEntity.CountryName = requestCreateCountryModel.CountryName;
         
            _unitOfWork.CountryRepository.Update(existedCountryEntity);
            _unitOfWork.Save();
            return Ok(existedCountryEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountry(int id)
        {
            var existedCountryEntity = _unitOfWork.CountryRepository.GetByID(id);
            if (existedCountryEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.CountryRepository.Delete(existedCountryEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
