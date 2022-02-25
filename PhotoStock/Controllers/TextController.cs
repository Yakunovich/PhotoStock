using Microsoft.AspNetCore.Mvc;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;
using System;
using PhotoStock.Services;
using System.Collections.Generic;
using System.Linq;
using PhotoStock.Data.Contracts;

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private IBaseRepository<Text> Texts { get; set; }
        private IBaseRepository<Author> Authors { get; set; }
        public TextController(IBaseRepository<Text> texts, IBaseRepository<Author> authors)
        {
            Texts = texts;
            Authors = authors;
        }

        [HttpGet]
        public string Get()
        {
            var AllTexts = Texts.GetAll();
            
            var photos = from t in Texts.GetAll()
                         select new TextDto()
                         {
                             Name = t.Name,
                             Content = t.Content,
                             Size = t.Size,
                             CreationDate = t.CreationDate,
                             AuthorName = t.Author.Name,
                             AuthorNickname = t.Author.Nickname,
                             Price = t.Price,
                             CountOfPurchases = t.CountOfPurchases,
                             Rating = t.Rating
                         };
            var csv = DataConverter.ConvertToCvs(photos);
            return csv;
        }

        [HttpPost]
        public ActionResult Post(TextDto textDto, Guid authorId)
        {
            if(textDto != null && Authors.Get(authorId)!=null)
            {
                var newText = new Text()
                {
                    Id = Guid.NewGuid(),
                    Name = textDto.Name,
                    Content = textDto.Content,
                    Size = textDto.Size,
                    CreationDate = DateTime.Now,
                    AuthorId = authorId,
                    Price = textDto.Price,
                    CountOfPurchases = textDto.CountOfPurchases,
                    Rating = textDto.Rating
                };
                Texts.Create(newText);
                return Ok(newText);
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
