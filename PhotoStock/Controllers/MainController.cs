using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;
using System.Collections;

namespace PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private IBaseRepository<Photo> Photos { get; set; }
        private IBaseRepository<Text> Texts { get; set; }
        private IBaseRepository<Author> Authors { get; set; }
        public MainController(IBaseRepository<Photo> photos, IBaseRepository<Text> texts, IBaseRepository<Author> authors)
        {
            Photos = photos;
            Authors = authors;
            Texts = texts;
        }

        [HttpGet]
        public ActionResult<ArrayList> Get()
        {
            ArrayList entities = new ArrayList();
            entities.AddRange(Photos.GetAll());
            entities.AddRange(Texts.GetAll());
            entities.AddRange(Authors.GetAll());
            
            return entities;
        }
    }
}
