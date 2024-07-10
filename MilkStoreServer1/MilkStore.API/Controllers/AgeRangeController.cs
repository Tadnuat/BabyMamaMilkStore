using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilkStore.API.Models.AgeRangeModel;
using MilkStore.Repo.Entities;
using MilkStore.Repo.UnitOfWork;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MilkStore.API.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/age-ranges")]
    [ApiController]
    public class AgeRangeController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public AgeRangeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ageRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (ageRange == null)
            {
                return NotFound();
            }

            var responseAgeRange = new ResponseAgeRangeModel
            {
                //AgeRangeID = ageRange.AgeRangeID,
                Baby = ageRange.Baby,
                Mama = ageRange.Mama,
                ProductItemID = ageRange.ProductItemID
            };

            return Ok(responseAgeRange);
        }

        [HttpPost]
        public IActionResult Create(RequestCreateAgeRangeModel requestCreateAgeRangeModel)
        {
            // Check if AgeRangeID already exists
            var ageRangeExists = _unitOfWork.AgeRangeRepository.Get(a => a.AgeRangeID == requestCreateAgeRangeModel.AgeRangeID).Any();
            if (ageRangeExists)
            {
                return Conflict(new { message = "The specified AgeRangeID already exists." });
            }

            // Check if the ProductItemID is provided and if it exists
            if (requestCreateAgeRangeModel.ProductItemID != null)
            {
                var productItemExists = _unitOfWork.ProductItemRepository.Get(p => p.ProductItemId == requestCreateAgeRangeModel.ProductItemID).Any();
                if (!productItemExists)
                {
                    return BadRequest(new { message = "The specified ProductItemID does not exist." });
                }
            }

            // Create new AgeRange entity
            var ageRangeEntity = new AgeRange
            {
                AgeRangeID = requestCreateAgeRangeModel.AgeRangeID,
                Baby = requestCreateAgeRangeModel.Baby,
                Mama = requestCreateAgeRangeModel.Mama,
                ProductItemID = requestCreateAgeRangeModel.ProductItemID // Accept null value if not provided
            };

            // Insert and save new AgeRange entity
            _unitOfWork.AgeRangeRepository.Insert(ageRangeEntity);
            _unitOfWork.Save();

            return Ok(ageRangeEntity);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ageRanges = _unitOfWork.AgeRangeRepository.Get();

            var responseAgeRanges = ageRanges.Select(ar => new ResponseAgeRangeModel
            {
                //AgeRangeID = ar.AgeRangeID,
                Baby = ar.Baby,
                Mama = ar.Mama,
                ProductItemID = ar.ProductItemID
            }).ToList();

            return Ok(responseAgeRanges);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, RequestUpdateAgeRangeModel requestCreateAgeRangeModel)
        {
            var existingAgeRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (existingAgeRange == null)
            {
                return NotFound();
            }
            // Check if the ProductItemID is provided and if it exists
            if (requestCreateAgeRangeModel.ProductItemID != null)
            {
                var productItemExists = _unitOfWork.ProductItemRepository.Get(p => p.ProductItemId == requestCreateAgeRangeModel.ProductItemID).Any();
                if (!productItemExists)
                {
                    return BadRequest(new { message = "The specified ProductItemID does not exist." });
                }
            }
            existingAgeRange.Baby = requestCreateAgeRangeModel.Baby;
            existingAgeRange.Mama = requestCreateAgeRangeModel.Mama;
            existingAgeRange.ProductItemID = requestCreateAgeRangeModel.ProductItemID;

            _unitOfWork.AgeRangeRepository.Update(existingAgeRange);
            _unitOfWork.Save();
            return Ok(existingAgeRange);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAgeRange = _unitOfWork.AgeRangeRepository.GetByID(id);
            if (existingAgeRange == null)
            {
                return NotFound();
            }

            _unitOfWork.AgeRangeRepository.Delete(existingAgeRange);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
