using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.ProductItemModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [Route("api/productitems")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductItemController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetProductItemById(int id)
        {
            var productItem = _unitOfWork.ProductItemRepository.GetByID(id);

            if (productItem == null)
            {
                return NotFound();
            }

            var responseProductItem = new ResponseProductItemModel
            {
                ProductItemId = productItem.ProductItemId,
                ItemName = productItem.ItemName,
                Price = productItem.Price,
                Benefit = productItem.Benefit,
                Description = productItem.Description,
                Image = productItem.Image,
                Weight = productItem.Weight,
                BrandMilkId = productItem.BrandMilkId,
                Baby = productItem.Baby,
                Mama = productItem.Mama,
                BrandName = productItem.BrandName,
                CountryName = productItem.CountryName,
                CompanyName = productItem.CompanyName
            };

            return Ok(responseProductItem);
        }

        [HttpGet]
        public IActionResult SearchProductItem([FromQuery] RequestSearchProductItemModel requestSearchProductItemModel)
        {
            Expression<Func<ProductItem, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchProductItemModel.ItemName) || x.ItemName.Contains(requestSearchProductItemModel.ItemName)) &&
                x.Price >= requestSearchProductItemModel.FromPrice &&
                (x.Price <= requestSearchProductItemModel.ToPrice || requestSearchProductItemModel.ToPrice == null);

            Func<IQueryable<ProductItem>, IOrderedQueryable<ProductItem>> orderBy = query => query.OrderBy(p => p.Price);

            if (requestSearchProductItemModel.SortContent != null)
            {
                var sortType = requestSearchProductItemModel.SortContent.SortProductItemType;

                if (sortType == SortProductItemTypeEnum.Descending)
                {
                    orderBy = query => query.OrderByDescending(p => p.Price);
                }
            }

            var productItems = _unitOfWork.ProductItemRepository.Search(
                searchExpression: filter,
                includeProperties: "",
                orderBy: orderBy,
                pageIndex: requestSearchProductItemModel.PageIndex,
                pageSize: requestSearchProductItemModel.PageSize
            );

            var responseProductItems = productItems.Select(productItem => new ResponseProductItemModel
            {
                ProductItemId = productItem.ProductItemId,
                ItemName = productItem.ItemName,
                Price = productItem.Price,
                Benefit = productItem.Benefit,
                Description = productItem.Description,
                Image = productItem.Image,
                Weight = productItem.Weight,
                BrandMilkId = productItem.BrandMilkId,
                Baby = productItem.Baby,
                Mama = productItem.Mama,
                BrandName = productItem.BrandName,
                CountryName = productItem.CountryName,
                CompanyName = productItem.CompanyName
            }).ToList();

            return Ok(responseProductItems);
        }

        [HttpPost]
        public IActionResult CreateProductItem(RequestCreateProductItemModel requestCreateProductItemModel)
        {
            var productItem = new ProductItem
            {
                ProductItemId = requestCreateProductItemModel.ProductItemId,
                ItemName = requestCreateProductItemModel.ItemName,
                Price = requestCreateProductItemModel.Price,
                Benefit = requestCreateProductItemModel.Benefit,
                Description = requestCreateProductItemModel.Description,
                Image = requestCreateProductItemModel.Image,
                Weight = requestCreateProductItemModel.Weight,
                BrandMilkId = requestCreateProductItemModel.BrandMilkId,
                Baby = requestCreateProductItemModel.Baby,
                Mama = requestCreateProductItemModel.Mama,
                BrandName = requestCreateProductItemModel.BrandName,
                CountryName = requestCreateProductItemModel.CountryName,
                CompanyName = requestCreateProductItemModel.CompanyName
            };

            _unitOfWork.ProductItemRepository.Insert(productItem);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductItem(int id, RequestUpdateProductItemModel requestUpdateProductItemModel)
        {
            var existedProductItem = _unitOfWork.ProductItemRepository.GetByID(id);
            if (existedProductItem != null)
            {
                existedProductItem.ItemName = requestUpdateProductItemModel.ItemName;
                existedProductItem.Price = requestUpdateProductItemModel.Price;
                existedProductItem.Benefit = requestUpdateProductItemModel.Benefit;
                existedProductItem.Description = requestUpdateProductItemModel.Description;
                existedProductItem.Image = requestUpdateProductItemModel.Image;
                existedProductItem.Weight = requestUpdateProductItemModel.Weight;
                existedProductItem.BrandMilkId = requestUpdateProductItemModel.BrandMilkId;
                existedProductItem.Baby = requestUpdateProductItemModel.Baby;
                existedProductItem.Mama = requestUpdateProductItemModel.Mama;
                existedProductItem.BrandName = requestUpdateProductItemModel.BrandName;
                existedProductItem.CountryName = requestUpdateProductItemModel.CountryName;
                existedProductItem.CompanyName = requestUpdateProductItemModel.CompanyName;

                _unitOfWork.ProductItemRepository.Update(existedProductItem);
                _unitOfWork.Save();

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductItem(int id)
        {
            var existedProductItem = _unitOfWork.ProductItemRepository.GetByID(id);
            if (existedProductItem != null)
            {
                _unitOfWork.ProductItemRepository.Delete(existedProductItem);
                _unitOfWork.Save();

                return Ok();
            }

            return NotFound();
        }
    }
}
