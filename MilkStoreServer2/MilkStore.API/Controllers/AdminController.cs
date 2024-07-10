using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.AdminModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/admins")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AdminController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = "AdminPolicy")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _unitOfWork.AdminRepository.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = "AdminPolicy")]
        public IActionResult GetAllAdmins()
        {
            var admins = _unitOfWork.AdminRepository.Get();
            return Ok(admins);
        }

        [HttpGet("username")]
        [AllowAnonymous]
        public IActionResult GetAdminByUsername([FromQuery] string username)
        {
            var admin = _unitOfWork.AdminRepository.Get(a => a.Username == username).FirstOrDefault();
            if (admin == null)
            {
                return NotFound(new { message = "Admin not found." });
            }

            return Ok(admin);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateAdmin(RequestCreateAdminModel requestCreateAdminModel)
        {
            // Check if the password has at least 8 characters
            if (string.IsNullOrWhiteSpace(requestCreateAdminModel.Password) || requestCreateAdminModel.Password.Length < 8)
            {
                return BadRequest(new { message = "Password must be at least 8 characters long." });
            }

            // Check if the role is either "Admin" or "Staff"
            if (requestCreateAdminModel.Role != "Admin" && requestCreateAdminModel.Role != "Staff")
            {
                return BadRequest(new { message = "Role must be either 'Admin' or 'Staff'." });
            }

            var existingAdmin = _unitOfWork.AdminRepository.Get(a => a.AdminID == requestCreateAdminModel.AdminID).FirstOrDefault();
            if (existingAdmin != null)
            {
                return Conflict(new { message = "AdminID already exists." });
            }

            var adminEntity = new Admin
            {
                AdminID = requestCreateAdminModel.AdminID,
                Username = requestCreateAdminModel.Username,
                Password = requestCreateAdminModel.Password,
                Role = requestCreateAdminModel.Role // Ensure the role is set properly
            };

            _unitOfWork.AdminRepository.Insert(adminEntity);
            _unitOfWork.Save();

            return Ok(adminEntity);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = "AdminPolicy")]
        public IActionResult UpdateAdmin(int id, RequestUpdateAdminModel requestCreateAdminModel)
        {
            var existedAdminEntity = _unitOfWork.AdminRepository.GetByID(id);
            if (existedAdminEntity == null)
            {
                return NotFound();
            }

            existedAdminEntity.Username = requestCreateAdminModel.Username;
            existedAdminEntity.Password = requestCreateAdminModel.Password;

            _unitOfWork.AdminRepository.Update(existedAdminEntity);
            _unitOfWork.Save();
            return Ok(existedAdminEntity);
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        //[Authorize(Policy = "AdminPolicy")]
        public IActionResult DeleteAdmin(int id)
        {
            var existedAdminEntity = _unitOfWork.AdminRepository.GetByID(id);
            if (existedAdminEntity == null)
            {
                return NotFound();
            }

            _unitOfWork.AdminRepository.Delete(existedAdminEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
