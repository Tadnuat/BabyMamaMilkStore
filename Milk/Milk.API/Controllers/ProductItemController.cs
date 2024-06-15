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

            var responseProductItem = _unitOfWork.ProductItemRepository.Search(
                searchExpression: filter,
                includeProperties: "",
                orderBy: orderBy,
                pageIndex: requestSearchProductItemModel.PageIndex,
                pageSize: requestSearchProductItemModel.PageSize
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
            var productItem = new ProductItem
            {
                ProductItemId = requestCreateProductItemModel.ProductItemID,
                ProductId = requestCreateProductItemModel.ProductId,
                ItemName = requestCreateProductItemModel.ItemName,
                Price = requestCreateProductItemModel.Price,
                Benefit = requestCreateProductItemModel.Benefit,
                Description = requestCreateProductItemModel.Description,
                Image = requestCreateProductItemModel.Image,
                Weight = requestCreateProductItemModel.Weight
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
                existedProductItem.ProductId = requestUpdateProductItemModel.ProductId;
                existedProductItem.ItemName = requestUpdateProductItemModel.ItemName;
                existedProductItem.Price = requestUpdateProductItemModel.Price;
                existedProductItem.Benefit = requestUpdateProductItemModel.Benefit;
                existedProductItem.Description = requestUpdateProductItemModel.Description;
                existedProductItem.Image = requestUpdateProductItemModel.Image;
                existedProductItem.Weight = requestUpdateProductItemModel.Weight;
                _unitOfWork.ProductItemRepository.Update(existedProductItem);
                _unitOfWork.Save();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductItem(int id)
        {
            var existedProductItem = _unitOfWork.ProductItemRepository.GetByID(id);
            if (existedProductItem != null)
            {
                _unitOfWork.ProductItemRepository.Delete(existedProductItem);
                _unitOfWork.Save();
            }
            return Ok();
        }
    }
}
