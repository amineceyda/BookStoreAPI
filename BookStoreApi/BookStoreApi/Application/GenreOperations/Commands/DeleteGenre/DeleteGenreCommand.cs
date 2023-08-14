using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var genre = _dbContext.Genres.FirstOrDefault(x=> x.Id == GenreId);
            if (genre is not null)
                throw new InvalidOperationException("Kitap türü bulunamadı");

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
        
    }
}
