using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.CountryModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;

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

        [HttpGet]
        public IActionResult GetAll()
        {
            var countries = _unitOfWork.CountryRepository.Get()
                                    .Where(country => country.Delete == 1)
                                    .Select(country => new ResponseCountryModel
                                    {
                                        CountryId = country.CountryId,
                                        CountryName = country.CountryName,
                                        Image = country.Image,
                                        Delete = country.Delete
                                    })
                                    .ToList();

            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountryById(int id)
        {
            var country = _unitOfWork.CountryRepository.GetByID(id);
            if (country == null || country.Delete != 1)
            {
                return NotFound();
            }

            var responseCountry = new ResponseCountryModel
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName,
                Image = country.Image,
                Delete = country.Delete
            };

            return Ok(responseCountry);
        }

        [HttpPost]
        public IActionResult CreateCountry(RequestCreateCountryModel requestCreateCountryModel)
        {
            var countryEntity = new Country
            {
                CountryId = requestCreateCountryModel.CountryId,
                CountryName = requestCreateCountryModel.CountryName,
                Image = requestCreateCountryModel.Image,
                Delete = 1
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
            existedCountryEntity.Image = requestUpdateCountryModel.Image;
            existedCountryEntity.Delete = requestUpdateCountryModel.Delete;

            _unitOfWork.CountryRepository.Update(existedCountryEntity);
            _unitOfWork.Save();
            return Ok(existedCountryEntity);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDeleteCountry(int id)
        {
            var existedCountryEntity = _unitOfWork.CountryRepository.GetByID(id);
            if (existedCountryEntity == null || existedCountryEntity.Delete != 1)
            {
                return NotFound();
            }

            _unitOfWork.CountryRepository.SoftDelete(existedCountryEntity); // Using SoftDelete method
            _unitOfWork.Save();
            return Ok(new { message = "Country deleted (soft) successfully." });
        }

        [HttpDelete("hard/{id}")]
        public IActionResult HardDeleteCountry(int id)
        {
            var existedCountryEntity = _unitOfWork.CountryRepository.GetByID(id);
            if (existedCountryEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.CountryRepository.Delete(existedCountryEntity);
            _unitOfWork.Save();
            return Ok(new { message = "Country hard deleted successfully." });
        }
    }
}
