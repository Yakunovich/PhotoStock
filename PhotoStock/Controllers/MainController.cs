using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoStock.Data.Models;
using PhotoStock.Repositories;
using PhotoStock.Repositories.Interfaces;
using System.Collections;

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repositoryWrapper;
        public MainController(IRepositoryWrapper repositoryWrapper, ILoggerManager logger)
        {
            _logger = logger;
            _repositoryWrapper = repositoryWrapper;
        }

        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            ArrayList entities = new ArrayList();

            entities.AddRange(_repositoryWrapper.AuthorRepository.GetAll());
            entities.AddRange(_repositoryWrapper.PhotoRepository.GetAll());
            entities.AddRange(_repositoryWrapper.TextRepository.GetAll());

            _logger.LogInfo("Fetching all entities from the storage");

            return entities;
        }
    }
}
