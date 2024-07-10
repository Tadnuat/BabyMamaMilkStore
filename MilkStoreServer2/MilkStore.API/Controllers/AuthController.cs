using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.LoginModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly TokenService _tokenService;

        public AuthController(UnitOfWork unitOfWork, TokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        [HttpPost("loginadmin")]
        public IActionResult LoginAdmin([FromBody] LoginModelAdmin loginModel)
        {
            // Kiểm tra trong bảng Admin
            var admin = _unitOfWork.AdminRepository.Get(x => x.Username == loginModel.Username && x.Password == loginModel.Password).FirstOrDefault();
            if (admin != null)
            {
                var token = _tokenService.GenerateToken(admin.Username, admin.Role);
                return Ok(new { token,id=admin.AdminID ,Username = admin.Username, Role = admin.Role});
            }

           

            return Unauthorized("Invalid username or password.");
        }


        [HttpPost("logincustomer")]
        public IActionResult LoginCustomer([FromBody] LoginModelCustomer loginModel)
        {
            

            // Kiểm tra trong bảng Customer
            var customer = _unitOfWork.CustomerRepository.Get(x => x.Email == loginModel.Username && x.Password == loginModel.Password).FirstOrDefault();
            if (customer != null)
            {
                var token = _tokenService.GenerateToken(customer.CustomerName, "Customer");
                return Ok(new { token,customerName = customer.CustomerName, customerId = customer.CustomerID});
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
