using PhotoStock.Repositories.Interfaces;

namespace PhotoStock.Repositories
{
    public interface IRepositoryWrapper
    {
        public IAuthorRepository AuthorRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public IPhotoRepository PhotoRepository { get; }
        public ITextRepository TextRepository { get; }
        public IRatingValueRepository RatingValueRepository { get; }
    }
}
