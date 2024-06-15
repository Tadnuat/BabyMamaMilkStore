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

<<<<<<< Updated upstream
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

=======
>>>>>>> Stashed changes
        [HttpGet("{id}")]
        public IActionResult GetProductItemById(int id)
        {
            var productItem = _unitOfWork.ProductItemRepository.GetByID(id);

            if (productItem == null)
            {
                return NotFound(); // Handle the not found case appropriately
            }

            var responseProductItem = new ResponseProductItemModel
            {
                ProductItemID = productItem.ProductItemId,
                ItemName = productItem.ItemName,
                Price = productItem.Price,
                Benefit = productItem.Benefit,
                Description = productItem.Description,
                Image = productItem.Image,
                Weight = productItem.Weight,
                ProductId = productItem.ProductId
            };

            return Ok(responseProductItem);
        }

<<<<<<< Updated upstream
=======
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
                ProductItemID = productItem.ProductItemId,
                ItemName = productItem.ItemName,
                Price = productItem.Price,
                Benefit = productItem.Benefit,
                Description = productItem.Description,
                Image = productItem.Image,
                Weight = productItem.Weight,
                ProductId = productItem.ProductId
            }).ToList();

            return Ok(responseProductItems);
        }

>>>>>>> Stashed changes
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

            return Ok(); // Assuming OK status code to indicate successful operation
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
<<<<<<< Updated upstream
                _unitOfWork.ProductItemRepository.Update(existedProductItem);
                _unitOfWork.Save();
            }
            return Ok();
=======

                _unitOfWork.ProductItemRepository.Update(existedProductItem);
                _unitOfWork.Save();

                return Ok(); // Assuming OK status code to indicate successful operation
            }

            return NotFound(); // Handle the case when the item does not exist
>>>>>>> Stashed changes
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductItem(int id)
        {
            var existedProductItem = _unitOfWork.ProductItemRepository.GetByID(id);
            if (existedProductItem != null)
            {
                _unitOfWork.ProductItemRepository.Delete(existedProductItem);
                _unitOfWork.Save();
<<<<<<< Updated upstream
            }
            return Ok();
=======

                return Ok(); // Assuming OK status code to indicate successful operation
            }

            return NotFound(); // Handle the case when the item does not exist
>>>>>>> Stashed changes
        }
    }
}
