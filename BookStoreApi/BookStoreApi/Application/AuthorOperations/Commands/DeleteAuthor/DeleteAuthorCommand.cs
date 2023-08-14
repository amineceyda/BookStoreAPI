using BookStoreApi.DBOperations;

namespace BookStoreApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId { get; set; }

        private readonly BookStoreDbContext _dbContext;
        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Yazar Bulunamadı");
            
            _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
