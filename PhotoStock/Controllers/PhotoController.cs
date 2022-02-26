using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoStock.Data.Contracts;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IBaseRepository<Photo> Photos { get; set; }
        private IBaseRepository<RatingValue> RatingValues { get; set; }

        public PhotoController(IBaseRepository<Photo> photos, IBaseRepository<RatingValue> ratingValues, ILoggerManager logger)
        {
            Photos = photos;
            RatingValues = ratingValues;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PhotoDto> Get()
        {
            var photos = from p in Photos.GetAll()
                         select PhotoToDto(p);

            _logger.LogInfo("Fetching all the Photos from the storage");

            return photos;
        }


        [HttpGet("{id}")]
        public ActionResult<PhotoDto> Get(Guid id)
        {
            var photo = Photos.Get(id);

            if(photo == null)
            {
                _logger.LogError($"Failed to fetch the Photo with id '{id}' from the storage");

                return NotFound();
            }

            _logger.LogInfo($"Fetching the Photo with id '{id}' from the storage");


            return PhotoToDto(photo);
        }

        [HttpPut]
        public ActionResult Put(Guid id, PhotoDto photoDto)
        {
            var photo = Photos.Get(id);
            if(photo == null)
            {
                _logger.LogInfo($"Failed to fetch the Photo with id '{id}' from the storage");

                return NotFound();
            }

            photo.Name = photoDto.Name;
            photo.ContentUri = photoDto.ContentUri;
            photo.Size = photoDto.Size;
            photo.ContentUri = photoDto.ContentUri;
            photo.Price = photoDto.Price;
            photo.CountOfPurchases = photoDto.CountOfPurchases;

            try
            {
                Photos.Update(photo);

                _logger.LogInfo($"The Photo with id '{id}' updated successfully");
            }
            catch (DbUpdateConcurrencyException) when (!PhotoExists(id))
            {
                _logger.LogError($"Failed to update the Photo with id '{id}' from the storage");

                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("Rate")]
        public ActionResult Rate(Guid id, int ratingValue)
        {
            var photo = Photos.Get(id);

            if(photo == null)
            {
                _logger.LogError($"Failed to fetch the Photo with id '{id}' from the storage");

                return NotFound();
            }

            RatingValues.Create(
                new RatingValue() 
                { 
                    Id = Guid.NewGuid(),
                    RatingId = photo.RatingId,
                    Value = ratingValue 
                });

            _logger.LogInfo($"The Photo with id '{id}' created successfully");

            return Ok();
           
        }
        private bool PhotoExists(Guid id) =>
                    Photos.Get(id) != null;
        private static PhotoDto PhotoToDto(Photo photo) =>
            new PhotoDto()
            {
                Name = photo.Name,
                ContentUri = photo.ContentUri,
                Size = photo.Size,
                CreationDate = photo.CreationDate,
                AuthorName = photo.Author.Name,
                AuthorNickname = photo.Author.Nickname,
                Price = photo.Price,
                CountOfPurchases = photo.CountOfPurchases,
                Rating = photo.Rating.AvarageRating()
            };
    }
}
