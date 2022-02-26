using PhotoStock.Data;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories.Implimentations
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(PhotoStockContext context)
            : base(context)
        {

        }
    }
}
