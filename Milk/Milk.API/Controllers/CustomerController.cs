using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.CustomerModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public CustomerController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (AdminId = 1, Username = 2, ...)
        /// 
        /// SortType (Ascending = 1,Descending = 2)        
        /// </summary>
        /// <param name="requestSearchCustomerModel"></param>
        /// <returns></returns>
        [HttpGet("SearchCustomer")]
        public IActionResult SearchCustomer([FromQuery] RequestSearchCustomerModel requestSearchCustomerModel)
        {
            var sortBy = requestSearchCustomerModel.SortContent?.sortCustomerBy;
            var sortType = requestSearchCustomerModel.SortContent?.sortCustomerType.ToString();

            Expression<Func<Customer, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchCustomerModel.CustomerName) || x.CustomerName.Contains(requestSearchCustomerModel.CustomerName)) &&
                (x.CustomerId == requestSearchCustomerModel.CustomerId || requestSearchCustomerModel.CustomerId == null);

            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortCustomerTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortCustomerTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }

            var responseCustomer = _unitOfWork.CustomerRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchCustomerModel.pageIndex,
                pageSize: requestSearchCustomerModel.pageSize
            );

            return Ok(requestSearchCustomerModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(RequestCreateCustomerModel requestCreateCustomerModel)
        {
            var customerEntity = new Customer
            {
               
                CustomerName = requestCreateCustomerModel.CustomerName,
                Email = requestCreateCustomerModel.Email,
                Password = requestCreateCustomerModel.Password


            };
            _unitOfWork.CustomerRepository.Insert(customerEntity);
            _unitOfWork.Save();
            return Ok(customerEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, RequestCreateCustomerModel requestCreateCustomerModel)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null)
            {
                return NotFound();
            }

            existedCustomerEntity.CustomerName = requestCreateCustomerModel.CustomerName;
            existedCustomerEntity.Email = requestCreateCustomerModel.Email;
            existedCustomerEntity.Password = requestCreateCustomerModel.Password;

            _unitOfWork.CustomerRepository.Update(existedCustomerEntity);
            _unitOfWork.Save();
            return Ok(existedCustomerEntity);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.CustomerRepository.Delete(existedCustomerEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
