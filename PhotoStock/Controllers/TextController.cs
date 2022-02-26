using Microsoft.AspNetCore.Mvc;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;
using System;
using PhotoStock.Services;
using System.Linq;
using PhotoStock.Data.Contracts;
using LoggerService;
using PhotoStock.Repositories;

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repositoryWrapper;
        public TextController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var texts = from t in _repositoryWrapper.TextRepository.GetAll()
                         select TextToDto(t);

            var csv = DataConverter.ConvertToCvs(texts);

            _logger.LogInfo($"Fetching all the Texts from storage");

            return csv;
        }

        [HttpPost]
        public ActionResult Post(Guid authorId, TextDto textDto)
        {
            if(_repositoryWrapper.AuthorRepository.Get(authorId) == null)
            {
                _logger.LogError($"Failed to fetch the Author with id '{authorId}'");

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

            _repositoryWrapper.TextRepository.Create(text);

            _logger.LogInfo($"The Text with id '{text.Id}' created successfully");

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
