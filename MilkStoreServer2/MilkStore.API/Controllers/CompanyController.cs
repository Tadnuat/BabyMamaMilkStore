using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.AgeRangeModel;
using MilkStore.API.Models.BrandMilkModel;
using MilkStore.API.Models.CompanyModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CompanyController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetCompanyById(int id)
        {
            var company = _unitOfWork.CompanyRepository.GetByID(id);
            if (company == null)
            {
                return NotFound();
            }

            var responseCompany = new ResponseCompanyModel
            {
                CompanyName = company.CompanyName,
                CountryID = company.CountryID
            };

            return Ok(responseCompany);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies = _unitOfWork.CompanyRepository.Get();

            var responseCompanies = companies.Select(c => new ResponseCompanyModel
            {
                CompanyName = c.CompanyName,
                CountryID = c.CountryID
            }).ToList();

            return Ok(responseCompanies);
        }

        [HttpPost]
        public IActionResult CreateCompany(RequestCreateCompanyModel requestCreateCompanyModel)
        {
            var companyEntity = new Company
            {
                CompanyName = requestCreateCompanyModel.CompanyName,
                CountryID = requestCreateCompanyModel.CountryID
            };
            _unitOfWork.CompanyRepository.Insert(companyEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompany(int id, RequestUpdateCompanyModel requestUpdateCompanyModel)
        {
            var existedCompanyEntity = _unitOfWork.CompanyRepository.GetByID(id);
            if (existedCompanyEntity == null)
            {
                return NotFound();
            }

            existedCompanyEntity.CompanyName = requestUpdateCompanyModel.CompanyName;
            existedCompanyEntity.CountryID = requestUpdateCompanyModel.CountryID;

            _unitOfWork.CompanyRepository.Update(existedCompanyEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompany(int id)
        {
            var existedCompanyEntity = _unitOfWork.CompanyRepository.GetByID(id);
            if (existedCompanyEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.CompanyRepository.Delete(existedCompanyEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
