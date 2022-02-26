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
            var texts = from t in Texts.GetAll()
                         select TextToDto(t);
            var csv = DataConverter.ConvertToCvs(texts);

            return csv;
        }

        [HttpPost]
        public ActionResult Post(Guid authorId, TextDto textDto)
        {
            if(Authors.Get(authorId) == null)
            {
                return NotFound();
            }
            var text = new Text()
            {
                Id = Guid.NewGuid(),
                Name = textDto.Name,
                Content = textDto.Content,
                Size = textDto.Content.Length,
                CreationDate = DateTime.Now,
                AuthorId = authorId,
                Price = textDto.Price,
                CountOfPurchases = textDto.CountOfPurchases,
                Rating = new Rating()
            };

            Texts.Create(text);

            return CreatedAtAction(
                nameof(Get),
                new { id = text.Id },
                TextToDto(text));

        }
        private static TextDto TextToDto(Text text) =>
            new TextDto()
            {
                Name = text.Name,
                Content = text.Content,
                Size = text.Size,
                CreationDate = text.CreationDate,
                AuthorName = text.Author.Name,
                AuthorNickname = text.Author.Nickname,
                Price = text.Price,
                CountOfPurchases = text.CountOfPurchases,
                Rating = text.Rating.AvarageRating()
            };
    }
}
