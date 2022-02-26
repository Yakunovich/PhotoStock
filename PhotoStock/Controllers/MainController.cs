using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;
using System.Collections;

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IBaseRepository<Photo> Photos { get; set; }
        private IBaseRepository<Text> Texts { get; set; }
        private IBaseRepository<Author> Authors { get; set; }

        public MainController(IBaseRepository<Photo> photos, IBaseRepository<Text> texts, IBaseRepository<Author> authors, ILoggerManager logger)
        {
            Photos = photos;
            Authors = authors;
            Texts = texts;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            ArrayList entities = new ArrayList();
            entities.AddRange(Photos.GetAll());
            entities.AddRange(Texts.GetAll());
            entities.AddRange(Authors.GetAll());

            _logger.LogInfo("Fetching all entities from the storage");

            return entities;
        }
    }
}
