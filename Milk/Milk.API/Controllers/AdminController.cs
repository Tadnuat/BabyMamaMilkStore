using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.AdminModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AdminController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (AdminId = 1, Username = 2, ...)
        /// 
        /// SortType (Ascending = 0,Descending = 1)        
        /// </summary>
        /// <param name="requestSearchAdminModel"></param>
        /// <returns></returns>
        /// 
        [HttpGet("SearchAdmin")]
        public IActionResult SearchAdmin([FromQuery] RequestSearchAdminModel requestSearchAdminModel)
        {
            var sortBy = requestSearchAdminModel.SortContent?.sortAdminBy;
            var sortType = requestSearchAdminModel.SortContent?.sortAdminType;

            Expression<Func<Admin, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchAdminModel.Username) || x.Username.Contains(requestSearchAdminModel.Username)) &&
                (x.AdminId == requestSearchAdminModel.AdminId || requestSearchAdminModel.AdminId == null);

            Func<IQueryable<Admin>, IOrderedQueryable<Admin>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortAdminTypeEnum.Ascending)
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortAdminTypeEnum.Descending)
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }

            var responseAdmin = _unitOfWork.AdminRepository.Get(
                filter,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchAdminModel.pageIndex,
                pageSize: requestSearchAdminModel.pageSize
            );

            return Ok(responseAdmin);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _unitOfWork.AdminRepository.GetByID(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult CreateAdmin(RequestCreateAdminModel requestCreateAdminModel)
        {
            var adminEntity = new Admin
            {
                AdminId = requestCreateAdminModel.AdminId,
                Username = requestCreateAdminModel.Username,
                Password = requestCreateAdminModel.Password
            };
            _unitOfWork.AdminRepository.Insert(adminEntity);
            _unitOfWork.Save();
            return Ok(adminEntity);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdmin(int id, RequestCreateAdminModel requestCreateAdminModel)
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
