using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.ProductItemModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System.Linq.Expressions;

using static System.Net.Mime.MediaTypeNames;

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

        /// <summary>
        /// SortBy (ProductId = 1,ProductName = 2,CategoryId = 3,UnitsInStock = 4,UnitPrice = 5,)
        /// 
        /// SortType (Ascending = 1,Descending = 2,)        
        /// </summary>
        /// <param name="requestSearchProductItemModel"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SearchProductItem([FromQuery] RequestSearchProductItemModel requestSearchProductItemModel)
        {
            var sortBy = requestSearchProductItemModel.SortContent != null ? requestSearchProductItemModel.SortContent?.sortProductItemBy.ToString() : null;
            var sortType = requestSearchProductItemModel.SortContent != null ? requestSearchProductItemModel.SortContent?.sortProductItemType.ToString() : null;
            Expression<Func<ProductItem, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchProductItemModel.ItemName) || x.ItemName.Contains(requestSearchProductItemModel.ItemName)) &&
                (x.Weight == requestSearchProductItemModel.Weight || requestSearchProductItemModel.Weight == null) &&
                x.Price >= requestSearchProductItemModel.FromPrice &&
                (x.Price <= requestSearchProductItemModel.ToPrice || requestSearchProductItemModel.ToPrice == null);

            Func<IQueryable<ProductItem>, IOrderedQueryable<ProductItem>> orderBy = null;

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (sortType == SortProductItemTypeEnum.Ascending.ToString())
                {
                    orderBy = query => query.OrderBy(p => EF.Property<object>(p, sortBy));
                }
                else if (sortType == SortProductItemTypeEnum.Descending.ToString())
                {
                    orderBy = query => query.OrderByDescending(p => EF.Property<object>(p, sortBy));
                }
            }
            var responseProductItem = _unitOfWork.ProductItemRepository.Get(
                null,
                orderBy,
                includeProperties: "",
                pageIndex: requestSearchProductItemModel.pageIndex,
                pageSize: requestSearchProductItemModel.pageSize
            );
            return Ok(responseProductItem);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductItemById(int id)
        {
            var responseProductItem = _unitOfWork.ProductItemRepository.GetByID(id);
            return Ok(responseProductItem);
        }
        [HttpPost]
        public IActionResult CreateProductItem(RequestCreateProductItemModel requestCreateProductItemModel)
        {
            var productEntity = new ProductItem
            {
                ProductId = requestCreateProductItemModel.ProductId,
                ItemName = requestCreateProductItemModel.ItemName,
                Price = requestCreateProductItemModel.Price,
                Benefit = requestCreateProductItemModel.Benefit,
                Description = requestCreateProductItemModel.Description,
                Image = requestCreateProductItemModel.Image,
                Weight = requestCreateProductItemModel.Weight
            };
            _unitOfWork.ProductItemRepository.Insert(productEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductItem(int id, RequestCreateProductItemModel RequestCreateProductItemModel)
        {
            var existedProductEntity = _unitOfWork.ProductItemRepository.GetByID(id);
            if (existedProductEntity != null)
            {
                existedProductEntity.ProductId = RequestCreateProductItemModel.ProductId;
                existedProductEntity.ItemName = RequestCreateProductItemModel.ItemName;
                existedProductEntity.Price = RequestCreateProductItemModel.Price;
                existedProductEntity.Benefit = RequestCreateProductItemModel.Benefit;
                existedProductEntity.Description = RequestCreateProductItemModel.Description;
                existedProductEntity.Image = RequestCreateProductItemModel.Image;
                existedProductEntity.Weight = RequestCreateProductItemModel.Weight;
            }
            _unitOfWork.ProductItemRepository.Update(existedProductEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductItem(int id)
        {
            var existedCategoryEntity = _unitOfWork.ProductItemRepository.GetByID(id);
            _unitOfWork.ProductItemRepository.Delete(existedCategoryEntity);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
