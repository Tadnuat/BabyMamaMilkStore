using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MilkStore.API.Models.ProductItemModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/productitems")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductItemController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("topsold")]
        public IActionResult GetTopSoldProductItems()
        {
            // Order by SoldQuantity in descending order and take the top 5 items
            var productItems = _unitOfWork.ProductItemRepository
                .Get(orderBy: query => query.OrderByDescending(p => p.SoldQuantity))
                .Take(5)
                .Select(productItem => new ResponseProductItemModel
                {
                    ProductItemId = productItem.ProductItemId,
                    ItemName = productItem.ItemName,
                    Price = productItem.Price,
                    Benefit = productItem.Benefit,
                    Description = productItem.Description,
                    Image1 = productItem.Image1,
                    Image2 = productItem.Image2,
                    Image3 = productItem.Image3,
                    Weight = productItem.Weight,
                    BrandMilkId = productItem.BrandMilkId,
                    Baby = productItem.Baby,
                    Mama = productItem.Mama,
                    BrandName = productItem.BrandName,
                    CountryName = productItem.CountryName,
                    CompanyName = productItem.CompanyName,
                    Discount = productItem.Discount,
                    SoldQuantity = productItem.SoldQuantity,
                    StockQuantity = productItem.StockQuantity
                })
                .ToList();

            return Ok(productItems);
        }
        [HttpGet]
        public IActionResult GetAllProductItems()
        {
            var productItems = _unitOfWork.ProductItemRepository.Get().ToList();

            var responseProductItems = productItems.Select(productItem => new ResponseProductItemModel
            {
                ProductItemId = productItem.ProductItemId,
                ItemName = productItem.ItemName,
                Price = productItem.Price,
                Benefit = productItem.Benefit,
                Description = productItem.Description,
                Image1 = productItem.Image1,
                Image2 = productItem.Image2,
                Image3 = productItem.Image3,
                Weight = productItem.Weight,
                BrandMilkId = productItem.BrandMilkId,
                Baby = productItem.Baby,
                Mama = productItem.Mama,
                BrandName = productItem.BrandName,
                CountryName = productItem.CountryName,
                CompanyName = productItem.CompanyName,
                Discount = productItem.Discount,
                SoldQuantity = productItem.SoldQuantity,
                StockQuantity = productItem.StockQuantity
            }).ToList();

            return Ok(responseProductItems);
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
                Image1 = productItem.Image1,
                Image2 = productItem.Image2,
                Image3 = productItem.Image3,
                Weight = productItem.Weight,
                BrandMilkId = productItem.BrandMilkId,
                Baby = productItem.Baby,
                Mama = productItem.Mama,
                BrandName = productItem.BrandName,
                CountryName = productItem.CountryName,
                CompanyName = productItem.CompanyName,
                Discount = productItem.Discount, // Include Discount property
                SoldQuantity = productItem.SoldQuantity,
                StockQuantity = productItem.StockQuantity
            };

            return Ok(responseProductItem);
        }


        [HttpGet("search")]
        public IActionResult SearchProductItem([FromQuery] RequestSearchProductItemModel requestSearchProductItemModel)
        {
            Expression<Func<ProductItem, bool>> filter = x =>
                (string.IsNullOrEmpty(requestSearchProductItemModel.ItemName) || x.ItemName.Contains(requestSearchProductItemModel.ItemName)) &&
                x.Price >= requestSearchProductItemModel.FromPrice &&
                (x.Price <= requestSearchProductItemModel.ToPrice || requestSearchProductItemModel.ToPrice == null) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.Mama) || x.Mama.Contains(requestSearchProductItemModel.Mama)) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.Baby) || x.Baby.Contains(requestSearchProductItemModel.Baby)) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.Benefit) || x.Benefit.Contains(requestSearchProductItemModel.Benefit)) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.BrandName) || x.BrandName.Contains(requestSearchProductItemModel.BrandName)) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.CountryName) || x.CountryName.Contains(requestSearchProductItemModel.CountryName)) &&
                (string.IsNullOrEmpty(requestSearchProductItemModel.CompanyName) || x.CompanyName.Contains(requestSearchProductItemModel.CompanyName));

            Func<IQueryable<ProductItem>, IOrderedQueryable<ProductItem>> orderBy = query => query.OrderBy(p => p.Price);

            if (requestSearchProductItemModel.SortContent != null)
            {
                var sortType = requestSearchProductItemModel.SortContent.SortProductItemType;
                var sortByProperty = requestSearchProductItemModel.SortContent.SortByProperty;

                switch (sortByProperty)
                {
                    case SortByPropertyEnum.Price:
                        orderBy = sortType == SortProductItemTypeEnum.Ascending
                            ? query => query.OrderBy(p => p.Price)
                            : query => query.OrderByDescending(p => p.Price);
                        break;
                    case SortByPropertyEnum.Mama:
                        orderBy = sortType == SortProductItemTypeEnum.Ascending
                            ? query => query.OrderBy(p => p.Mama)
                            : query => query.OrderByDescending(p => p.Mama);
                        break;
                    case SortByPropertyEnum.Baby:
                        orderBy = sortType == SortProductItemTypeEnum.Ascending
                            ? query => query.OrderBy(p => p.Baby)
                            : query => query.OrderByDescending(p => p.Baby);
                        break;
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
                Image1 = productItem.Image1,
                Image2 = productItem.Image2,
                Image3 = productItem.Image3,
                Weight = productItem.Weight,
                BrandMilkId = productItem.BrandMilkId,
                Baby = productItem.Baby,
                Mama = productItem.Mama,
                BrandName = productItem.BrandName,
                CountryName = productItem.CountryName,
                CompanyName = productItem.CompanyName,
                Discount = productItem.Discount, // Include Discount property
                SoldQuantity = productItem.SoldQuantity,
                StockQuantity = productItem.StockQuantity
            }).ToList();

            return Ok(responseProductItems);
        }

        [HttpPost]
        public IActionResult CreateProductItem(RequestCreateProductItemModel requestCreateProductItemModel)
        {
            var productItem = new ProductItem
            {
                ItemName = requestCreateProductItemModel.ItemName,
                Price = requestCreateProductItemModel.Price,
                Benefit = requestCreateProductItemModel.Benefit,
                Description = requestCreateProductItemModel.Description,
                Image1 = requestCreateProductItemModel.Image1,
                Image2 = requestCreateProductItemModel.Image2,
                Image3 = requestCreateProductItemModel.Image3,
                Weight = requestCreateProductItemModel.Weight,
                BrandMilkId = requestCreateProductItemModel.BrandMilkId,
                Baby = requestCreateProductItemModel.Baby,
                Mama = requestCreateProductItemModel.Mama,
                BrandName = requestCreateProductItemModel.BrandName,
                CountryName = requestCreateProductItemModel.CountryName,
                CompanyName = requestCreateProductItemModel.CompanyName,
                Discount = requestCreateProductItemModel.Discount, // Include Discount property
                SoldQuantity = requestCreateProductItemModel.SoldQuantity,
                StockQuantity = requestCreateProductItemModel.StockQuantity
            };

            _unitOfWork.ProductItemRepository.Insert(productItem);
            _unitOfWork.Save();

            return Ok(new { message = "ProductItem created successfully." });
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
                existedProductItem.Image1 = requestUpdateProductItemModel.Image1;
                existedProductItem.Image2 = requestUpdateProductItemModel.Image2;
                existedProductItem.Image3 = requestUpdateProductItemModel.Image3;
                existedProductItem.Weight = requestUpdateProductItemModel.Weight;
                existedProductItem.BrandMilkId = requestUpdateProductItemModel.BrandMilkId;
                existedProductItem.Baby = requestUpdateProductItemModel.Baby;
                existedProductItem.Mama = requestUpdateProductItemModel.Mama;
                existedProductItem.BrandName = requestUpdateProductItemModel.BrandName;
                existedProductItem.CountryName = requestUpdateProductItemModel.CountryName;
                existedProductItem.CompanyName = requestUpdateProductItemModel.CompanyName;
                existedProductItem.Discount = requestUpdateProductItemModel.Discount; // Include Discount property
                existedProductItem.SoldQuantity = requestUpdateProductItemModel.SoldQuantity;
                existedProductItem.StockQuantity = requestUpdateProductItemModel.StockQuantity;

                _unitOfWork.ProductItemRepository.Update(existedProductItem);
                _unitOfWork.Save();

                return Ok(new { message = "ProductItem updated successfully." });
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

                return Ok(new { message = "ProductItem deleted successfully." });
            }

            return NotFound();
        }
    }
}
