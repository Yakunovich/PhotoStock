using PhotoStock.Data;
using PhotoStock.Data.Models;
using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories.Implimentations
{
    public class TextRepository : BaseRepository<Text>, ITextRepository
    {
        public TextRepository(PhotoStockContext context)
            : base(context)
        {

        }
    }
}
