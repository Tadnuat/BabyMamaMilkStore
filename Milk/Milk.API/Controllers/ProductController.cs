using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.ProductModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

using static System.Net.Mime.MediaTypeNames;

namespace MilkStore.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// SortBy (ProductId = 1,ProductName = 2,CategoryId = 3,UnitsInStock = 4,UnitPrice = 5,)
        /// 
        /// SortType (Ascending = 1,Descending = 2,)        
        /// </summary>
        /// <param name="requestSearchProductModel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchProduct([FromQuery] RequestSearchProductModel requestSearchProductModel)
        {
            var sortBy = requestSearchProductModel.SortContent != null ? requestSearchProductModel.SortContent?.sortProductBy.ToString() : null;
            var sortType = requestSearchProductModel.SortContent != null ? requestSearchProductModel.SortContent?.sortProductType.ToString() : null;
            Expression<Func<Product, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchProductModel.ProductName) || x.ProductName.Contains(requestSearchProductModel.ProductName)) &&
                (x.BrandMilkId == requestSearchProductModel.BrandMilkId || requestSearchProductModel.BrandMilkId == null) &&
                (x.AdminId <= requestSearchProductModel.AdminId || requestSearchProductModel.AdminId == null);

            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortProductTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortProductTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }
            var responseProduct = _unitOfWork.ProductRepository.Get(
                null,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchProductModel.pageIndex,
                pageSize: requestSearchProductModel.pageSize
            );
            return Ok(responseProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var responseProduct = _unitOfWork.ProductRepository.GetByID(id);
            return Ok(responseProduct);
        }
        [HttpPost]
        public IActionResult CreateProduct(RequestCreateProductModel requestCreateProductModel)
        {
            var product = new Product
            {
                ProductName = requestCreateProductModel.ProductName,
                BrandMilkId = requestCreateProductModel.BrandMilkId,
                AdminId = requestCreateProductModel.AdminId
            };
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, RequestCreateProductModel RequestCreateProductModel)
        {
            var existedProduct = _unitOfWork.ProductRepository.GetByID(id);
            if (existedProduct != null)
            {
                existedProduct.ProductName = RequestCreateProductModel.ProductName;
                existedProduct.BrandMilkId = RequestCreateProductModel.BrandMilkId;
                existedProduct.AdminId = RequestCreateProductModel.AdminId;
            }
            _unitOfWork.ProductRepository.Update(existedProduct);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existedProduct = _unitOfWork.ProductRepository.GetByID(id);
            _unitOfWork.ProductRepository.Delete(existedProduct);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
