using PhotoStock.Data;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories.Implimentations
{
    public class RatingValueRepository : BaseRepository<RatingValue>, IRatingValueRepository
    {
        public RatingValueRepository(PhotoStockContext context)
            : base(context)
        {

        }
    }
}
