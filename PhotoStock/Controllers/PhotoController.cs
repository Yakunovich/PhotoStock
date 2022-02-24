using Microsoft.AspNetCore.Mvc;
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
        private IBaseRepository<Photo> Photos { get; set; }

        public PhotoController(IBaseRepository<Photo> photos)
        {
            Photos = photos;
        }

        [HttpGet]
        public IEnumerable<PhotoDto> Get()
        {
            var photos = from p in Photos.GetAll()
                         select new PhotoDto()
                         {
                             Name = p.Name,
                             ContentUri = p.ContentUri,
                             Size = p.Size,
                             CreationDate = p.CreationDate,
                             AuthorName = p.Author.Name,
                             AuthorNickname = p.Author.Nickname,
                             Price = p.Price,
                             CountOfPurchases = p.CountOfPurchases,
                             Rating = p.Rating
                         };

            return photos;
        }

        [HttpGet("{id}")]
        public ActionResult<PhotoDto> Get(Guid id)
        {
            var p = Photos.Get(id);
            var photo =  new PhotoDto()
                         {
                             Name = p.Name,
                             ContentUri = p.ContentUri,
                             Size = p.Size,
                             CreationDate = p.CreationDate,
                             AuthorName = p.Author.Name,
                             AuthorNickname = p.Author.Nickname,
                             Price = p.Price,
                             CountOfPurchases = p.CountOfPurchases,
                             Rating = p.Rating
                         };

            return photo;
        }

        [HttpPut]
        public string Put(Photo photo)
        {
            bool success = true;
            try
            {
               if (photo != null)
                   Photos.Update(photo);
               else success = false;
            }
            catch (Exception e)
            {
                success = false;
                return e.Message;
            }
            return success.ToString() ;
        }


    }
}
