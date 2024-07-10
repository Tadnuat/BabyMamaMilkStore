using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.CountryModel;
using MilkStore.API.Models.PaymentModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = _unitOfWork.CountryRepository.Get()
                                    .Select(country => new ResponseCountryModel
                                    {
                                        CountryId = country.CountryId,
                                        CountryName = country.CountryName,

                                    })
                                    .ToList();

            return Ok(countries);
        }
        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country == null)
            {
                return NotFound();
            }
            var responseCountry = new ResponseCountryModel
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,

            };

            return Ok(responseCountry);
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
        public IActionResult UpdateCountry(int id, RequestUpdateCountryModel requestUpdateCountryModel)
        {
            var existedCountryEntity = _unitOfWork.CountryRepository.GetByID(id);
            if (existedCountryEntity == null)
            {
                return NotFound();
            }

            existedCountryEntity.CountryName = requestUpdateCountryModel.CountryName;

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