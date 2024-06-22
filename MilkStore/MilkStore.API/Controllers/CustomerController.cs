using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.CountryModel;
using MilkStore.API.Models.CustomerModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    // update 12/6
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
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.Get()
                                    .Select(customer => new ResponseCustomerModel
                                    {
                                        CustomerId = customer.CustomerId,
                                        CustomerName = customer.CustomerName,
                                        Email = customer.Email,
                                        Password = customer.Password,
                                        Phone = customer.Phone

                                    })
                                    .ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null)
            {
                return NotFound();
            }
            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone


            };

            return Ok(responseCustomer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(RequestCreateCustomerModel requestCreateCustomerModel)
        {
            var customerEntity = new Customer
            {
                CustomerId = requestCreateCustomerModel.CustomerId,
                CustomerName = requestCreateCustomerModel.CustomerName,
                Email = requestCreateCustomerModel.Email,
                Password = requestCreateCustomerModel.Password,
                Phone = requestCreateCustomerModel.Phone


            };
            _unitOfWork.CustomerRepository.Insert(customerEntity);
            _unitOfWork.Save();
            return Ok(customerEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, RequestUpdateCustomerModel requestUpdateCustomerModel)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null)
            {
                return NotFound();
            }

            existedCustomerEntity.CustomerName = requestUpdateCustomerModel.CustomerName;
            existedCustomerEntity.Email = requestUpdateCustomerModel.Email;
            existedCustomerEntity.Password = requestUpdateCustomerModel.Password;
            existedCustomerEntity.Phone = requestUpdateCustomerModel.Phone;

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
