using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.CustomerModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
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
        /// Search and sort customers by CustomerName
        /// </summary>
        /// <param name="requestSearchCustomerModel"></param>
        /// <returns></returns>
        [HttpGet("searchcustomer")]
        public IActionResult SearchCustomer([FromQuery] RequestSearchCustomerModel requestSearchCustomerModel)
        {
            // Giải mã CustomerName từ requestSearchCustomerModel
            var decodedCustomerName = HttpUtility.UrlDecode(requestSearchCustomerModel.CustomerName);

            Func<Customer, bool> filter = x =>
                (string.IsNullOrEmpty(decodedCustomerName) || RemoveVietnameseAccents(x.CustomerName).Contains(RemoveVietnameseAccents(decodedCustomerName))) && x.Delete == 1;

            Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = query =>
            {
                if (requestSearchCustomerModel.SortType == SortType.Ascending)
                {
                    return query.OrderBy(p => p.CustomerName);
                }
                else
                {
                    return query.OrderByDescending(p => p.CustomerName);
                }
            };

            var customers = _unitOfWork.CustomerRepository.Get(
                orderBy: orderBy,
                pageIndex: requestSearchCustomerModel.pageIndex,
                pageSize: requestSearchCustomerModel.pageSize
            ).Where(filter).ToList();

            var responseCustomers = customers.Select(customer => new ResponseCustomerModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone,
                Delete = customer.Delete
            }).ToList();

            return Ok(responseCustomers);
        }

        public static string RemoveVietnameseAccents(string text)
        {
            string[] VietnameseSigns = new string[]
            {
                "aAeEoOuUiIdDyY",
                "áàạảãâấầậẩẫăắằặẳẵ",
                "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                "éèẹẻẽêếềệểễ",
                "ÉÈẸẺẼÊẾỀỆỂỄ",
                "óòọỏõôốồộổỗơớờợởỡ",
                "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                "úùụủũưứừựửữ",
                "ÚÙỤỦŨƯỨỪỰỬỮ",
                "íìịỉĩ",
                "ÍÌỊỈĨ",
                "đ",
                "Đ",
                "ýỳỵỷỹ",
                "ÝỲỴỶỸ"
            };

            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    text = text.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }

            return text;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.Get()
                                    .Where(customer => customer.Delete == 1)
                                    .Select(customer => new ResponseCustomerModel
                                    {
                                        CustomerId = customer.CustomerId,
                                        CustomerName = customer.CustomerName,
                                        Email = customer.Email,
                                        Password = customer.Password,
                                        Phone = customer.Phone,
                                        Delete = customer.Delete
                                    })
                                    .ToList();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _unitOfWork.CustomerRepository.GetByID(id);
            if (customer == null || customer.Delete != 1)
            {
                return NotFound();
            }

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone,
                Delete = customer.Delete
            };

            return Ok(responseCustomer);
        }

        [HttpGet("email")]
        public IActionResult GetCustomerByEmail([FromQuery] string email)
        {
            var customer = _unitOfWork.CustomerRepository.Get(c => c.Email == email && c.Delete == 1).FirstOrDefault();
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone,
                Delete = customer.Delete
            };

            return Ok(responseCustomer);
        }

        [HttpPost]
        public IActionResult CreateCustomer(RequestCreateCustomerModel requestCreateCustomerModel)
        {
            // Kiểm tra xem email đã tồn tại chưa
            var existingCustomer = _unitOfWork.CustomerRepository.Get(c => c.Email == requestCreateCustomerModel.Email).FirstOrDefault();
            if (existingCustomer != null)
            {
                return BadRequest(new { message = "Email đã được sử dụng để đăng ký tài khoản khác." });
            }

            var customerEntity = new Customer
            {
                CustomerId = requestCreateCustomerModel.CustomerId,
                CustomerName = requestCreateCustomerModel.CustomerName,
                Email = requestCreateCustomerModel.Email,
                Password = requestCreateCustomerModel.Password,
                Phone = requestCreateCustomerModel.Phone,
                Delete = 1 //mặc định delete là 1 khi create
            };

            _unitOfWork.CustomerRepository.Insert(customerEntity);
            _unitOfWork.Save();

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customerEntity.CustomerId,
                CustomerName = customerEntity.CustomerName,
                Email = customerEntity.Email,
                Password = customerEntity.Password,
                Phone = customerEntity.Phone,
                Delete = customerEntity.Delete
            };

            return Ok(responseCustomer);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, RequestUpdateCustomerModel requestUpdateCustomerModel)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null || existedCustomerEntity.Delete != 1)
            {
                return NotFound();
            }

            existedCustomerEntity.CustomerName = requestUpdateCustomerModel.CustomerName;
            existedCustomerEntity.Email = requestUpdateCustomerModel.Email;
            existedCustomerEntity.Password = requestUpdateCustomerModel.Password;
            existedCustomerEntity.Phone = requestUpdateCustomerModel.Phone;
            existedCustomerEntity.Delete = requestUpdateCustomerModel.Delete;

            _unitOfWork.CustomerRepository.Update(existedCustomerEntity);
            _unitOfWork.Save();

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = existedCustomerEntity.CustomerId,
                CustomerName = existedCustomerEntity.CustomerName,
                Email = existedCustomerEntity.Email,
                Password = existedCustomerEntity.Password,
                Phone = existedCustomerEntity.Phone,
                Delete = existedCustomerEntity.Delete
            };

            return Ok(responseCustomer);
        }

        [HttpDelete("soft/{id}")]
        public IActionResult SoftDeleteCustomer(int id)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null || existedCustomerEntity.Delete != 1)
            {
                return NotFound();
            }

            _unitOfWork.CustomerRepository.SoftDelete(existedCustomerEntity); // Using SoftDelete method
            _unitOfWork.Save();
            return Ok(new { message = "Customer deleted (soft) successfully." });
        }

        [HttpDelete("hard/{id}")]
        public IActionResult HardDeleteCustomer(int id)
        {
            var existedCustomerEntity = _unitOfWork.CustomerRepository.GetByID(id);
            if (existedCustomerEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.CustomerRepository.Delete(existedCustomerEntity);
            _unitOfWork.Save();

            return Ok(new { message = "Customer hard deleted successfully." });
        }
    }
}
