using PhotoStock.Data;
using PhotoStock.Data.Models;
using PhotoStock.Models;
using PhotoStock.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PhotoStock.Repositories.Implimentations
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoStockContext context)
            : base(context)
        {

        }
        public List<Photo> GetAll(ModelParameters modelParameters)
        {
            return Context.Set<Photo>()
                .Skip((modelParameters.PageNumber - 1) * modelParameters.PageSize)
                .Take(modelParameters.PageSize)
                .ToList();
        }
    }
}
