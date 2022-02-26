using PhotoStock.Data;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories.Implimentations
{
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(PhotoStockContext context)
            :base(context)
        {

        }
    }
}
