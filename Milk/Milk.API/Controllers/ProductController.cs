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

        [HttpGet]
        public IActionResult GetAll()
        {
            var responseProduct = _unitOfWork.ProductRepository.Get();
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
                ProductId = requestCreateProductModel.ProductId,
                ProductName = requestCreateProductModel.ProductName,
                BrandMilkId = requestCreateProductModel.BrandMilkId,
                AdminId = requestCreateProductModel.AdminId
            };
            _unitOfWork.ProductRepository.Insert(product);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, RequestUpdateProductModel requestUpdateProductModel)
        {
            var existedProduct = _unitOfWork.ProductRepository.GetByID(id);
            if (existedProduct != null)
            {
                existedProduct.ProductName = requestUpdateProductModel.ProductName;
                existedProduct.BrandMilkId = requestUpdateProductModel.BrandMilkId;
                existedProduct.AdminId = requestUpdateProductModel.AdminId;
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
