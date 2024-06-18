using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.LoginModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq;

namespace MilkStore.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AuthController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            // Kiểm tra trong bảng Admin
            var admin = _unitOfWork.AdminRepository.Get(x => x.Username == loginModel.Username && x.Password == loginModel.Password).FirstOrDefault();
            if (admin != null)
            {
                return Ok(new { Role = "Admin", RedirectUrl = "adminPage" });
            }

            // Kiểm tra trong bảng Customer
            var customer = _unitOfWork.CustomerRepository.Get(x => x.CustomerName == loginModel.Username && x.Password == loginModel.Password).FirstOrDefault();
            if (customer != null)
            {
                return Ok(new { Role = "Customer", RedirectUrl = "homePage" });
            }

            return Unauthorized("Invalid username or password.");
        }
    }
}
