using PhotoStock.Data.Models;
using PhotoStock.Models;
using System.Collections.Generic;

namespace PhotoStock.Repositories.Interfaces
{
    public interface IPhotoRepository : IBaseRepository<Photo>
    {
        public List<Photo> GetAll(ModelParameters modelParameters);
    }
}
