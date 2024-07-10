using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.CustomerModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
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
                string.IsNullOrEmpty(decodedCustomerName) || RemoveVietnameseAccents(x.CustomerName).Contains(RemoveVietnameseAccents(decodedCustomerName));

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
            ).ToList();

            var responseCustomers = customers.Select(customer => new ResponseCustomerModel
            {
                CustomerId = customer.CustomerID,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone
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
                                    .Select(customer => new ResponseCustomerModel
                                    {
                                        CustomerId = customer.CustomerID,
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
                CustomerId = customer.CustomerID,
                CustomerName = customer.CustomerName,
                Email = customer.Email,
                Password = customer.Password,
                Phone = customer.Phone
            };

            return Ok(responseCustomer);
        }

        [HttpGet("email")]
        public IActionResult GetCustomerByEmail([FromQuery] string email)
        {
            var customer = _unitOfWork.CustomerRepository.Get(c => c.Email == email).FirstOrDefault();
            if (customer == null)
            {
                return NotFound(new { message = "Customer not found." });
            }

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customer.CustomerID,
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
                CustomerName = requestCreateCustomerModel.CustomerName,
                Email = requestCreateCustomerModel.Email,
                Password = requestCreateCustomerModel.Password,
                Phone = requestCreateCustomerModel.Phone
            };

            _unitOfWork.CustomerRepository.Insert(customerEntity);
            _unitOfWork.Save();

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = customerEntity.CustomerID,
                CustomerName = customerEntity.CustomerName,
                Email = customerEntity.Email,
                Password = customerEntity.Password,
                Phone = customerEntity.Phone
            };

            return Ok(responseCustomer);
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

            var responseCustomer = new ResponseCustomerModel
            {
                CustomerId = existedCustomerEntity.CustomerID,
                CustomerName = existedCustomerEntity.CustomerName,
                Email = existedCustomerEntity.Email,
                Password = existedCustomerEntity.Password,
                Phone = existedCustomerEntity.Phone
            };

            return Ok(responseCustomer);
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
