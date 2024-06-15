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
            var products = _unitOfWork.ProductRepository.Get()
                                    .Select(product => new ResponseProductModel
                                    {
                                        ProductId = product.ProductId,
                                        ProductName = product.ProductName,
                                        BrandMilkId = product.BrandMilkId,
                                        AdminId = product.AdminId
                                    })
                                    .ToList();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _unitOfWork.ProductRepository.GetByID(id);

            if (product == null)
            {
                return NotFound(); // Handle the not found case appropriately
            }

            var responseProduct = new ResponseProductModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                BrandMilkId = product.BrandMilkId,
                AdminId = product.AdminId
            };

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
