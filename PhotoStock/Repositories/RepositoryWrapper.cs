using PhotoStock.Data;
using PhotoStock.Repositories.Implimentations;
using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private PhotoStockContext context;
        private IAuthorRepository authorRepository;
        private ITextRepository textRepository;
        private IPhotoRepository photoRepository;
        private IRatingRepository ratingRepository;
        private IRatingValueRepository ratingValueRepository;

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if(authorRepository == null)
                {
                    authorRepository = new AuthorRepository(context);
                }
                return authorRepository;
            }
        }
        public IRatingValueRepository RatingValueRepository
        {
            get
            {
                if (ratingValueRepository == null)
                {
                    ratingValueRepository = new RatingValueRepository(context);
                }
                return ratingValueRepository;
            }
        }
        public IPhotoRepository PhotoRepository
        {
            get
            {
                if (photoRepository == null)
                {
                    photoRepository = new PhotoRepository(context);
                }
                return photoRepository;
            }
        }
        public ITextRepository TextRepository
        {
            get
            {
                if (textRepository == null)
                {
                    textRepository = new TextRepository(context);
                }
                return textRepository;
            }
        }
        public IRatingRepository RatingRepository
        {
            get
            {
                if (ratingRepository == null)
                {
                    ratingRepository = new RatingRepository(context);
                }
                return ratingRepository;
            }
        }
        public RepositoryWrapper(PhotoStockContext photoStockContext)
        {
            context = photoStockContext;
        }
    }
}
